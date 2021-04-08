using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Text;
using NLog;
using System.Data;
//using Microsoft.VisualBasic.FileIO;
//using PerformanceReportTask2.app;

namespace AutoSF.Helper {
    public static class CacheDb {
        //DB for Userspecific Data

        //private const string QUERY_AllSoldiers = "SELECT * FROM soldaten WHERE stufe = @stufe AND typ = @typ AND konter = @konter AND bonus = @bonus;";

        private static string QUERY_CreateMissionSoldiersTables = "";
        private static string QUERY_GetMissionSoldiers = "SELECT * FROM TempBusy5; ";
        private const string QUERY_BusySoldiers = "SELECT count(*) FROM unterwegs where unterwegs.id = @id;";
        private const string INSERT_BusySoldier = "INSERT INTO unterwegs (id,dauer) VALUES (@id, @dauer);";
        private const string INSERT_ScanSoldier = "INSERT INTO soldaten (stufe,typ,konter,bonus,anzahl) VALUES (@stufe,@typ,@konter,@bonus,@anzahl);";
        private const string DYNAMIC_DB_Path = "C:\\temp\\";
        private static  SQLiteConnection connection;
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public static DataTable DataTableFilteredSoldiers = new DataTable();  //Filtered Soldiers From CacheDB


        public static void InitializeCacheDb() {
            log.Debug("initializing dynamic cache db stored at C:\\temp ");
            //connection = new SQLiteConnection("Data Source=:memory:;Version=3");
            connection = new SQLiteConnection("Data Source=C:\\temp\\AutoSFDynamic.db;Version=3");
            connection.Open();
            InitializeTables();
        }

        private static void InitializeTables() {
            log.Debug("initializing tables in dynamic db");
            StringBuilder buf = new StringBuilder("CREATE TABLE IF NOT EXISTS soldaten (");
            buf.Append("'id' INTEGER NOT NULL UNIQUE, ");
            buf.Append("'stufe' TEXT NOT NULL, ");
            buf.Append("'typ' TEXT NOT NULL, ");
            buf.Append("'konter' TEXT NOT NULL, ");
            buf.Append("'bonus' TEXT NOT NULL, ");
            buf.Append("'anzahl' TEXT NOT NULL, ");
            buf.Append("PRIMARY KEY('id'));");

            buf.Append(" CREATE TABLE IF NOT EXISTS unterwegs (");
            buf.Append("'id' INTEGER NOT NULL, ");
            buf.Append("'dauer' TEXT NOT NULL);");
            Execute(buf.ToString());

            GetMissionSoldiers();
        }

        public static void GetMissionSoldiers() {
            log.Debug("initializing temptables in dynamic db");
            StringBuilder temptable = new StringBuilder("DROP TABLE IF EXISTS TempBusy; ");
            temptable.Append("CREATE TABLE TempBusy AS SELECT id,COUNT(*) as Allbusy ");
            temptable.Append("FROM unterwegs ");
            temptable.Append("GROUP BY id; ");

            temptable.Append("DROP TABLE IF EXISTS TempBusy2; ");
            temptable.Append("CREATE TABLE TempBusy2 AS select soldaten.id,CAST(substr(soldaten.stufe,-1,1)AS INT)AS stufe,soldaten.typ,soldaten.konter,soldaten.bonus,IIF(length(soldaten.anzahl) = 4 OR length(soldaten.anzahl) = 5,substr(soldaten.anzahl,-2,2),IIF(length(soldaten.anzahl) = 3, substr(soldaten.anzahl,-1,1),'ERROR')) as anzahl,Allbusy from soldaten ");
            temptable.Append("LEFT JOIN TempBusy ON soldaten.id = TempBusy.id; ");

            temptable.Append("DROP TABLE IF EXISTS TempBusy3; ");
            temptable.Append("CREATE TABLE TempBusy3 AS  ");
            temptable.Append("SELECT TempBusy2.id,TempBusy2.stufe,TempBusy2.typ,TempBusy2.konter,TempBusy2.bonus,(IIF(TempBusy2.Allbusy <> NULL,(CAST(TempBusy2.anzahl AS INT) - CAST(TempBusy2.Allbusy AS INT)),CAST(TempBusy2.anzahl AS INT))) AS availible ");
            temptable.Append("FROM TempBusy2 ");
            temptable.Append("WHERE (TempBusy2.stufe=@stufe1 OR TempBusy2.stufe=@stufe2) AND (TempBusy2.konter=@konter1 ");
            temptable.Append("OR TempBusy2.konter=@konter2 OR  TempBusy2.konter =@konter3 OR TempBusy2.konter=@konter4 OR TempBusy2.konter=@konter5) ");
            temptable.Append("ORDER BY availible DESC; ");

            temptable.Append("DROP TABLE IF EXISTS TempBusy4; ");
            temptable.Append("CREATE TABLE TempBusy4 AS SELECT *,count(TempBusy3.typ) AS TypeCount FROM TempBusy3 GROUP BY TempBusy3.typ; ");

            temptable.Append("DROP TABLE IF EXISTS TempBusy5; ");
            temptable.Append("CREATE TABLE TempBusy5 AS Select TempBusy3.id,TempBusy3.stufe,TempBusy3.typ,TempBusy3.konter,TempBusy3.bonus,TempBusy3.availible,TempBusy4.TypeCount, IIF((TempBusy3.bonus = 'bskoordination' OR TempBusy3.bonus = 'bsdrohne' ), TempBusy3.stufe * 5 + 10 , TempBusy3.stufe * 5) AS normalrate, IIF(TempBusy3.bonus = 'bsimprovisation', 5, 0) AS shortrate, IIF(TempBusy3.bonus = 'bsaufsteiger', 5, 0) AS longrate FROM TempBusy4 ");
            temptable.Append("LEFT JOIN TempBusy3 ON TempBusy3.typ = TempBusy4.typ ");
            temptable.Append("ORDER BY TypeCount, TempBusy3.typ, TempBusy3.availible  DESC; ");

            QUERY_CreateMissionSoldiersTables = temptable.ToString();
            //temptable.Append("SELECT * FROM TempBusy5; ");
        }


        private static void Execute(string sql) {
            using(SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }

        public static void Dispose() {
            connection.Close();
            connection.Dispose();
        }

        //ToDo change stufe1,stufe2 to difficulty in GetSoldiers Method, Query(stufe1 = difficulty +1, stufe2 = difficulty), variables,...
        public static (string, string) GetSoldiers(int stufe1, int stufe2 = 0, string konter1 = "", string konter2 = "", string konter3 = "", string konter4 = "", string konter5 = "") {
            using(SQLiteCommand command = new SQLiteCommand(QUERY_CreateMissionSoldiersTables, connection)) {

                command.Parameters.AddWithValue("@stufe1", stufe1);
                command.Parameters.AddWithValue("@stufe2", stufe2);
                command.Parameters.AddWithValue("@konter1", konter1.ToLower());
                command.Parameters.AddWithValue("@konter2", konter2.ToLower());
                command.Parameters.AddWithValue("@konter3", konter3.ToLower());
                command.Parameters.AddWithValue("@konter4", konter4.ToLower());
                command.Parameters.AddWithValue("@konter5", konter5.ToLower());
                command.ExecuteNonQuery();  //Writing action

                //using(reader = command.ExecuteReader()) {
                //    if(reader.Read()) {
                //        DtMissionSoldiers.Load(CacheDb.reader);
                //        //MainWindow.GridDataTableCacheDB = reader.Read();
                //        //return (GetEmptyStringOrValue(reader["id"]),GetEmptyStringOrValue(reader["amount"])); // TODO maybe throw error?
                //        return ("", "");
                //    }
                //}
                //return ("", "");
            }
            return ("",""); // TODO maybe throw error?
        }

        public static void GetSoldiersSelect() {
            using(SQLiteCommand command2 = new SQLiteCommand(QUERY_GetMissionSoldiers, connection)) {

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command2); //Adds command2 QueryResult into dataAdapter
                dataAdapter.Fill(DataTableFilteredSoldiers); //Writes dataAdapter into the DataTable
            }
        }
      

        //"SELECT count(*) FROM unterwegs where unterwegs.id = @id;"
        public static string GetBusySoldiers(int id) {
            using(SQLiteCommand command = new SQLiteCommand(QUERY_BusySoldiers, connection)) {
                command.Parameters.AddWithValue("@id", id);
                using(SQLiteDataReader reader = command.ExecuteReader()) {
                    if(reader.Read()) {
                        return GetEmptyStringOrValue(reader["count(*)"]); // TODO maybe throw error?
                    }
                }
            }
            return "";
        }

        public static bool InsertBusySoldier(int id, DateTime dauer) {
            //try {
            //    if(!Directory.Exists(DYNAMIC_DB_Path)) {
            //        log.Error("couldn't find dynamicDB´s path '" + DYNAMIC_DB_Path + "'");
            //        return false;
            //    }
            //}
            //catch(UnauthorizedAccessException) {
            //    log.Error("was denied access to dynamicDB´s path '" + DYNAMIC_DB_Path + "'");
            //    return false;
            //}

            //string filename = Path.Combine(DYNAMIC_DB_Path + "AutoSFDynamic.db");

            //if(!File.Exists(filename)) {
            //    log.Error("couldn't find dynamicDB");
            //    return false;
            //}
            

            using(SQLiteTransaction transaction = connection.BeginTransaction()) { //gathers many inserts together into a transaction - better performance if a lot of inserts are done at once
                using(SQLiteCommand command = connection.CreateCommand()) {
                    command.Transaction = transaction;
                   
                        command.CommandText = INSERT_BusySoldier;
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@dauer", dauer);
                        command.ExecuteNonQuery();
                    
                }

                transaction.Commit();
            }

            return true;
        }

        public static bool InsertScanSoldier(string stufe, string typ, string konter, string bonus, string anzahl) {
            using(SQLiteTransaction transaction = connection.BeginTransaction()) { //gathers many inserts together into a transaction - better performance if a lot of inserts are done at once
                using(SQLiteCommand command = connection.CreateCommand()) {
                    command.Transaction = transaction;

                    command.CommandText = INSERT_ScanSoldier;
                    command.Parameters.AddWithValue("@stufe", stufe.ToLower());
                    command.Parameters.AddWithValue("@typ", typ.ToLower());
                    command.Parameters.AddWithValue("@konter", konter.ToLower());
                    command.Parameters.AddWithValue("@bonus", bonus.ToLower());
                    command.Parameters.AddWithValue("@anzahl", anzahl);
                    command.ExecuteNonQuery();
                    log.Debug("Insert successfull - starting Commit");

                }
                transaction.Commit();
            }
            return true;
        }

        private static string GetEmptyStringOrValue(object resultValue) {
            if(resultValue == null || resultValue == DBNull.Value) {
                return "";
            }

            return (string)resultValue;
        }
    }
}