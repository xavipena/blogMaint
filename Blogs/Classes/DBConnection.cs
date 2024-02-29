using MySql.Data.MySqlClient;
using System;
using Blogs.Classes;

namespace Blogs
{
    public class DBConnection
    {
        public DBConnection()
        {
            // Default
            SetDatabase(BlogSet.TECHNICAL);
            this.IsConnected = false;
            this.IsOpen = false;
        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsConnected { get; set; }
        public bool IsOpen { get; set; }

        public MySqlConnection Connection { get; set; }

        /*
        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }
        */

        public void SetDatabase(string set)
        {
            switch (set)
            {
                case BlogSet.TECHNICAL:
                    this.Server = dBServers.TECHNICAL;
                    this.DatabaseName = "qahz995";
                    this.UserName = "qahz995";
                    this.Password = "CrisRami2023";
                    break;

                case BlogSet.PERSONAL:
                    this.Server = dBServers.PERSONAL;
                    this.DatabaseName = "qahz997";
                    this.UserName = "qahz997";
                    this.Password = "CrisRami2023";
                    break;
            }
        }

        public bool DBConnect()
        {
            IsConnected = false;
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;

                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                IsConnected = true;
            }
            return IsConnected;
        }
        public void DBOpen()
        {
            Connection.Open();
            IsOpen = true;
        }

        public void DBClose()
        {
            Connection.Close();
            IsOpen = false;
        }
    }
}
