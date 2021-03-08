using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace AutoSF.Helper {
    public static class DB {

        private static SQLiteConnection DBConnection;
        readonly static SQLiteCommand cmd = new SQLiteCommand();
        public static DataTable dt = new DataTable();

        public static void InitializeDB() {

            
            if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                DBConnection = new SQLiteConnection("Data Source=C:\\Spiele\\AutoSFDebug\\AutoSF.db; Mode=ReadOnly;FailIfMissing=True;Version=3;");  //Version = Sqliteverion 
            }
            else {
                DBConnection = new SQLiteConnection("Data Source=C:\\Users\\gr4nd\\Documents\\GitHub\\FirstSteps\\AutoSF\\AutoSF\\AutoSF.db; Mode=ReadOnly;FailIfMissing=True;Version=3;");  //Version = Sqliteverion
            }
            DBConnection.Open();

            cmd.Connection = DBConnection;
            InitializeDBcmd(); //Fills DataTable dt with all data from Table Missions
        }

        public static SQLiteDataReader InitializeDBcmd(string query = "") {
            cmd.CommandText = "Select * From Missions" + query;
            SQLiteDataReader queryResult = cmd.ExecuteReader();
            dt.Load(queryResult);
            return queryResult;
        }
    }
}
