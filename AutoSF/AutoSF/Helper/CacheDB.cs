using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Text;
using NLog;
//using Microsoft.VisualBasic.FileIO;
//using PerformanceReportTask2.app;

namespace AutoSF.Helper {
    public static class CacheDb {
        //DB for Userspecific Data

        private const string QUERY_AllSoldiers = "SELECT * FROM soldaten WHERE stufe = @stufe AND typ = @typ AND konter = @konter AND bonus = @bonus;";
        private const string QUERY_BusySoldiers = "SELECT count(*) FROM unterwegs where unterwegs.id = @id;";
        private const string INSERT_BusySoldier = "INSERT INTO unterwegs (id,dauer) VALUES (@id, @dauer);";
        private const string INSERT_ScanSoldier = "INSERT INTO soldaten (stufe,typ,konter,bonus,anzahl) VALUES (@stufe,@typ,@konter,@bonus,@anzahl);";
        private const string DYNAMIC_DB_Path = "C:\\temp\\";
        private static  SQLiteConnection connection;
        private static readonly Logger log = LogManager.GetCurrentClassLogger();


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

        public static (string, string) GetSoldiers(int stufe, string typ, string konter, string bonus) {
            using(SQLiteCommand command = new SQLiteCommand(QUERY_AllSoldiers, connection)) {
                command.Parameters.AddWithValue("@stufe", stufe);
                command.Parameters.AddWithValue("@typ", typ.ToLower());
                command.Parameters.AddWithValue("@konter", konter.ToLower());
                command.Parameters.AddWithValue("@bonus", bonus.ToLower());
                using(SQLiteDataReader reader = command.ExecuteReader()) {
                    if(reader.Read()) {
                        return (GetEmptyStringOrValue(reader["id"]),GetEmptyStringOrValue(reader["amount"])); // TODO maybe throw error?
                    }
                }
            }

            return ("",""); // TODO maybe throw error?
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