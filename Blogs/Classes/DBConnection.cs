using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Bzip2;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Blogs
{
    public class DBConnection
    {
        private DBConnection()
        { }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsConnected = false;
        public bool IsOpen = false;

        public MySqlConnection Connection { get; set; }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
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
