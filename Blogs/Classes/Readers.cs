using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipelines;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blogs.Classes
{
    internal class Readers
    {
        /// <summary>
        /// Retrieve blog description
        /// </summary>
        /// <returns></returns>
        public static string GetBlogDescription()
        {
            string desc = string.Empty;
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            string sql = "select description, url " +
                         "from project_blogs " +
                         "where IDblog = " + Gdata.currentBlog + " and status = 'A' " +
                         "  and lang = '" + Gdata.Lang + "' and ga4 = '" + Gdata.currentSet + "'";
            
            using (var cmd = new MySqlCommand(sql, Gdata.dbCommon.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    desc = reader.GetString(0);
                    Gdata.url = reader.GetString(1);
                }
            }
            return desc;
        }

        /// <summary>
        /// Retrieve header tab for current blog/article
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTabHeader()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();

            string sql = "select * from articles where IDblog = " + Gdata.currentBlog + " and IDarticle = " + IDarticle + " and lang = '" + Gdata.Lang + "'";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
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
            }
            return list;
        }

        /// <summary>
        /// Retrieve texts tab for given section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static List<string> GetTabTexts(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();

            string sql = "select section, position, type, text, status, lang " +
                         "from article_details " +
                         "where IDarticle = " + IDarticle + " and position = " + section + " and lang = '" + Gdata.Lang + "'";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    list.Add(reader.GetString(0));
                    list.Add(reader.GetInt32(1).ToString());
                    list.Add(reader.GetString(2));
                    list.Add(reader.GetString(3));
                    list.Add(reader.GetString(4));
                    list.Add(reader.GetString(5));
                }
            }
            return list;
        }

        /// <summary>
        /// Retrieve image detail for given section/sequence
        /// </summary>
        /// <param name="section"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static List<string> GetTabImages(int section, int sequence)
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();

            string sql = "select sequence, image, caption, captionLong, alternate, credit, status, lang from article_images " +
                         "where IDarticle = " + IDarticle +
                         "  and section = " + section;
            if (sequence > 0)
            {
                // If not sequence given, then select first. This is for first time filling the tab
                // with no specific sequence selected
                sql += "  and sequence = '" + sequence + "' ";
            }            
            sql += "  and lang = '" + Gdata.Lang + "'";

            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    list.Add(reader.GetInt32(0).ToString());
                    list.Add(reader.GetString(1));
                    list.Add(reader.GetString(2));
                    list.Add(reader.GetString(3));
                    list.Add(reader.GetString(4));
                    list.Add(reader.GetString(5));
                    list.Add(reader.GetString(6));
                    list.Add(reader.GetString(7));
                }
            }
            return list;
        }

        /// <summary>
        /// Retrieve links tab for given section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static List<string> GetTabLinks(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();

            string sql = "select name, url, status, lang from article_links " +
                         "where IDarticle = " + IDarticle + " and section = " + section + " and lang = '" + Gdata.Lang + "'";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    list.Add(reader.GetString(0));
                    list.Add(reader.GetString(1));
                    list.Add(reader.GetString(2));
                    list.Add(reader.GetString(3));
                }
            }
            return list;
        }

        /// <summary>
        /// Retrieve references list tab
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<string> GetTabReferences(string key)
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();

            string sql = "select sequence, name, url, status from article_related " +
                         "where IDarticle = " + IDarticle + " and concat(section, '-', sequence) = '" + key +"'";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    list.Add(reader.GetInt32(0).ToString());
                    list.Add(reader.GetString(1));
                    list.Add(reader.GetString(2));
                    list.Add(reader.GetString(3));
                }
            }
            return list;
        }

        /// <summary>
        /// Retrieve quotes tab for given section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static List<string> GetTabQuotes(int section)
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();

            string sql = "select embed, status, lang, author from article_quotes " +
                         "where IDarticle = " + IDarticle + " and section = " + section + " and lang = '" + Gdata.Lang + "' ";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    list.Add(reader.GetString(1));
                    list.Add(reader.GetString(2));
                    list.Add(reader.GetString(3));
                    list.Add(reader.GetString(4));
                }
            }
            return list;
        }

        /// <summary>
        /// Retrieve coding tab for given section/sequence
        /// </summary>
        /// <param name="section"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static List<string> GetTabCode(int section, int sequence)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.currentSet == BlogSet.PERSONAL) return null;
            Gdata.db.DBOpen();

            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            List<string> list = new List<string>();

            string sql = "select sequence, os, code, status from article_code " +
                         "where IDarticle = " + IDarticle + " and section = " + section;
            if (sequence > 0)
            {
                // If not sequence given, then select first. This is for first time filling the tab
                // with no specific sequence selected
                sql += "  and sequence = '" + sequence + "' ";
            }

            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    list.Add(reader.GetInt32(0).ToString());
                    list.Add(reader.GetString(1));
                    list.Add(reader.GetString(2));
                    list.Add(reader.GetString(3));
                }
            }
            return list;
        }

        /// <summary>
        /// Get metadata for current article in selected blog
        /// </summary>
        /// <returns></returns>
        public static List<string[]> GetTabMetadata()
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;
            Gdata.db.DBOpen();
            List<string[]> list = new List<string[]>();

            string sql = "select article_metadata.IDmeta, metadata.protocol, article_metadata.value, metadata.property, metadata.description " +
                         "from article_metadata " +
                         "join metadata " +
                         "   on metadata.IDmeta = article_metadata.IDmeta " +
                         "where IDarticle = " + IDarticle + " and lang = '" + Gdata.Lang + "' " +
                         "order by article_metadata.IDmeta";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string[] aRow = new string[]
                    {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(1),
                    reader.GetString(3),
                    reader.GetString(2),
                    reader.GetString(4)
                    };
                    list.Add(aRow);
                }
            }
            return list;
        }

        public static List<string[]> GetCleanMetadata()
        {
            Singleton Gdata = Singleton.GetInstance();
            int IDarticle = Gdata.IDarticle;
            if (IDarticle == 0) return null;

            // Read metadata in a dictionary
            Dictionary<int, string> mlist = new Dictionary<int, string>();
            Gdata.db.DBOpen();
            string sql = string.Empty;

            // First, if ca then get es version
            if (Gdata.Lang == Language.CATALA)
            {
                sql = "select IDmeta, value from article_metadata " +
                             "where IDarticle = " + IDarticle + " and lang = '" + Language.CASTELLA + "' " +
                             "order by IDmeta";
                using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mlist.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }
            else
            {
                int PrevArticle = 0;
                // Search article to copy from
                sql = "select IDarticle from articles " +
                             "where IDblog = " + Gdata.currentBlog + " and lang = '" + Gdata.Lang + "' order by IDarticle desc limit 1,1";
                using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PrevArticle = reader.GetInt32(0);
                    }
                }
                if (PrevArticle == 0) return null;

                Gdata.db.DBOpen();
                sql = "select IDmeta, value from article_metadata " +
                             "where IDarticle = " + PrevArticle + " and lang = '" + Gdata.Lang + "' " +
                             "order by IDmeta";
                using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mlist.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }

            Gdata.db.DBOpen();
            List<string[]> list = new List<string[]>();

            sql = "select IDmeta, DefaultValue, property, protocol, description " +
                         "from metadata " +
                         "order by protocol, section";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string mValue = string.Empty;
                    mlist.TryGetValue(reader.GetInt32(0), out mValue);
                    string[] aRow = new string[]
                    {
                        reader.GetInt32(0).ToString(),
                        reader.GetString(3),
                        reader.GetString(2),
                        mValue,
                        reader.GetString(4)
                    };
                    list.Add(aRow);
                }
            }
            return list;
        }

        public static List<string[]> GetChained()
        {
            List<string[]> mList = new List<string[]>();
            Singleton Gdata = Singleton.GetInstance();

            Gdata.db.DBOpen();
            string sql = "select IDarticle, date, prev, title, next, type from articles " +
                         "where IDblog = " + Gdata.currentBlog + " and lang = '" + Gdata.Lang + "' order by type, date desc";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string[] row = new string[]
                    {
                        reader.GetInt32(0).ToString(),
                        reader.GetDateTime(1).ToString().Substring(1,10),
                        reader.GetInt32(2).ToString(),
                        reader.GetString(3),
                        reader.GetInt32(4).ToString(),
                        Marks.UNMARKED,
                        reader.GetString(5)
                    };
                    mList.Add(row);
                }
            }
            return mList;
        }

        /// <summary>
        /// Get article title
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static string GetTitle(string lang)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return null;
            Gdata.db.DBOpen();
            if (lang == string.Empty) lang = Gdata.Lang;
            string title = string.Empty;

            string sql = "select title from articles where IDblog = " + Gdata.currentBlog + " and IDarticle = " + Gdata.IDarticle + " and lang = '" + lang + "'";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    title = reader.GetString(0);
                }
            }
            return title;
        }

        /// <summary>
        /// Load cbOption list based on given query
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<cbOption> LoadList(string sql, DBConnection db)
        {
            if (db == null) return null;
            if (!db.IsConnected) return null;
            db.DBOpen();

            var list = new List<cbOption>();
            using (var cmd = new MySqlCommand(sql, db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cbOption op = new cbOption()
                    {
                        entityValue = reader.GetInt32(0).ToString(),
                        entityName = "> " + reader.GetString(1)
                    };
                    list.Add(op);
                }
            }
            return list;
        }

        /// <summary>
        /// Load programming languages list
        /// </summary>
        /// <returns></returns>
        public static List<cbOption> LoadLangTypes()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            var list = new List<cbOption>();
            string sql = "select * from article_code_types order by name";

            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cbOption op = new cbOption()
                    {
                        entityValue = reader.GetString(0),
                        entityName = reader.GetString(1)
                    };
                    list.Add(op);
                }
            }
            return list;
        }

        /// <summary>
        /// Load references list
        /// </summary>
        /// <returns></returns>
        public static List<cbOption> LoadRefList()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            string sql = "select section, sequence, name from article_related " +
                         "where IDarticle = " + Gdata.IDarticle + " order by section, sequence";
            var list = new List<cbOption>();
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cbOption op = new cbOption()
                    {
                        entityValue = reader.GetInt32(0).ToString() + "-" + reader.GetInt32(1).ToString(),
                        entityName = reader.GetString(2)
                    };
                    list.Add(op);
                }
            }
            return list;
        }

        /// <summary>
        /// Gte next article number in current blog
        /// </summary>
        /// <returns></returns>
        public static int GetNextArticle()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            int num = 0;
            string sql = "select IDarticle from articles " +
                         "where IDblog = " + Gdata.currentBlog + " order by IDarticle desc limit 1";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    num = reader.GetInt32(0) + 1;
                }
            }
            return num;
        }

        public static int GetNextTextSection()
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            int num = 10;
            string sql = "select position from article_details " +
                         "where IDarticle = " + Gdata.IDarticle + " order by position desc limit 1";
            using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    num = reader.GetInt32(0) + 10;
                }
            }
            return num;
        }
    }
}
