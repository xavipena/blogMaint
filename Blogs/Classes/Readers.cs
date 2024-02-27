using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blogs.Classes
{
    internal class Readers
    {
        public static List<cbOption> GetBlogs()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            var list = new List<cbOption>();

            string sql = "select blog, name " +
                         "from project_blogs where status = 'A' and lang = '" + Gdata.Lang + "' and ga4 = 'A'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbOption op = new cbOption()
                {
                    entityValue = reader.GetInt32(0).ToString(),
                    entityName = reader.GetString(1)
                };
                list.Add(op);
            }

            Gdata.db.DBClose();
            return list;
        }

        public static string GetBlogDescription()
        {
            string desc = string.Empty;
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            string sql = "select description " +
                         "from project_blogs where IDblog = " + Gdata.currentBlog + " and status = 'A' and lang = '" + Gdata.Lang + "' and ga4 = 'A'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                desc = reader.GetString(0);
            }

            Gdata.db.DBClose();
            return desc;
        }

        public static List<string> GetTabHeader()
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();
            Gdata.db.DBOpen();

            string sql = "select * from articles where IDblog = " + Gdata.currentBlog + " and IDarticle = " + IDarticle + " and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetString(2));
                list.Add(reader.GetDateTime(3).ToString());
                list.Add(reader.GetDateTime(4).ToString());
                list.Add(reader.GetDateTime(5).ToString());
                list.Add(reader.GetString(6));
                list.Add(reader.GetString(7));
                list.Add(reader.GetString(8));
                list.Add(reader.GetInt32(9).ToString());
                list.Add(reader.GetString(10));
                list.Add(reader.GetInt32(11).ToString());
                list.Add(reader.GetInt32(12).ToString());
                list.Add(reader.GetDecimal(13).ToString());
                list.Add(reader.GetInt32(12).ToString());
            }

            Gdata.db.DBClose();
            return list;
        }

        public static string GetTitle()
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return null;
            string title = string.Empty;
            Gdata.db.DBOpen();

            string sql = "select title from articles where IDblog = " + Gdata.currentBlog + " and IDarticle = " + Gdata.IDarticle + " and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                title = reader.GetString(0);
            }

            Gdata.db.DBClose();
            return title;
        }

        // ---------------------------------------------------------------------------
        // Combos
        // ---------------------------------------------------------------------------

        private void LoadBlogs()
        {
            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            dataSource = Readers.GetBlogs();

            //Setup data binding
            cbBlogs.DataSource = dataSource;
            cbBlogs.DisplayMember = "entityName";
            cbBlogs.ValueMember = "entityValue";

            // readonly
            cbBlogs.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
