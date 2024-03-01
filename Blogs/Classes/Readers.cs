using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Blogs.Classes
{
    internal class Readers
    {
        public static string GetBlogDescription()
        {
            string desc = string.Empty;
            Singleton Gdata = Singleton.GetInstance();
            Gdata.dbCommon.DBOpen();

            string sql = "select description, url " +
                         "from project_blogs " +
                         "where IDblog = " + Gdata.currentBlog + " and status = 'A' " +
                         "  and lang = '" + Gdata.Lang + "' and ga4 = '" + Gdata.currentSet + "'";
            var cmd = new MySqlCommand(sql, Gdata.dbCommon.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                desc = reader.GetString(0);
                Gdata.url = reader.GetString(1);
            }

            Gdata.dbCommon.DBClose();
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
                list.Add(reader.GetInt32(14).ToString());
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<string> GetTabTexts(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();
            Gdata.db.DBOpen();

            string sql = "select * from article_details " +
                         "where IDarticle = " + IDarticle + " and position = " + section + " and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetInt32(2).ToString());
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
                list.Add(reader.GetString(6));
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<string> GetTabImages(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();
            Gdata.db.DBOpen();

            string sql = "select * from article_images " +
                         "where IDarticle = " + IDarticle + " and section = " + section + " and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetInt32(2).ToString());
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
                list.Add(reader.GetString(6));
                list.Add(reader.GetString(7));
                list.Add(reader.GetString(8));
                list.Add(reader.GetString(9));
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<string> GetTabLinks(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();
            Gdata.db.DBOpen();

            string sql = "select * from article_links " +
                         "where IDarticle = " + IDarticle + " and section = " + section + " and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetString(2));
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<string> GetTabReferences(string key)
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();
            Gdata.db.DBOpen();

            string sql = "select * from article_related " +
                         "where IDarticle = " + IDarticle + " and concat(section, '-', sequence) = '" + key +"'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetInt32(2).ToString());
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<string> GetTabQuotes(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();
            Gdata.db.DBOpen();

            string sql = "select * from article_quotes " +
                         "where IDarticle = " + IDarticle + " and section = " + section + " and lang = '" + Gdata.Lang + "' ";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetInt32(1).ToString());
                list.Add(reader.GetString(2));
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<string> GetTabCode(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.currentSet == BlogSet.PERSONAL) return null;

            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();
            Gdata.db.DBOpen();

            string sql = "select * from article_code " +
                         "where IDarticle = " + IDarticle + " and section = " + section;
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetInt32(1).ToString());
                list.Add(reader.GetString(2));
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<string[]> GetTabMetadata()
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string[]> list = new List<string[]>();
            Gdata.db.DBOpen();

            string sql = "select article_metadata.IDmeta, article_metadata.value, metadata.property, metadata.description " +
                         "from article_metadata " +
                         "join metadata " +
                         "   on metadata.IDmeta = article_metadata.IDmeta " +
                         "where IDarticle = " + IDarticle + " and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] aRow = new string[]
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(2),
                    reader.GetString(1),
                    reader.GetString(3)
                };
                list.Add(aRow);
            }

            Gdata.db.DBClose();
            return list;
        }

        public static string GetTitle(string lang)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return null;
            if (lang == string.Empty) lang = Gdata.Lang;
            string title = string.Empty;
            Gdata.db.DBOpen();

            string sql = "select title from articles where IDblog = " + Gdata.currentBlog + " and IDarticle = " + Gdata.IDarticle + " and lang = '" + lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                title = reader.GetString(0);
            }

            Gdata.db.DBClose();
            return title;
        }

        public static List<cbOption> LoadList(string sql, DBConnection db)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (db == null) return null;
            if (!db.IsConnected) return null;
            db.DBOpen();

            var list = new List<cbOption>();
            var cmd = new MySqlCommand(sql, db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbOption op = new cbOption()
                {
                    entityValue = reader.GetInt32(0).ToString(),
                    entityName = "> " + reader.GetString(1)
                };
                list.Add(op);
            }

            db.DBClose();
            return list;
        }

        public static List<cbOption> LoadLangTypes()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            var list = new List<cbOption>();
            string sql = "select * from article_code_types order by name";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbOption op = new cbOption()
                {
                    entityValue = reader.GetString(0),
                    entityName = reader.GetString(1)
                };
                list.Add(op);
            }

            Gdata.db.DBClose();
            return list;
        }

        public static List<cbOption> LoadRefList()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            string sql = "select section, sequence, name from article_related " +
                         "where IDarticle = " + Gdata.IDarticle + " order by section, sequence";
            var list = new List<cbOption>();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbOption op = new cbOption()
                {
                    entityValue = reader.GetInt32(0).ToString() + "-" + reader.GetInt32(1).ToString(),
                    entityName = reader.GetString(2)
                };
                list.Add(op);
            }

            Gdata.db.DBClose();
            return list;
        }

    }
}
