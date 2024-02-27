using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blogs.Classes
{
    internal class Workers
    {
        public static int GetWordCount(int IDarticle)
        {
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();

            string artText = string.Empty;
            int wordCount = 0;
            string sql = "select text " +
                         "from article_details where IDarticle = " + IDarticle + " and lang = '" + Gdata.Lang + "' and status = 'A'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                artText = reader.GetString(0);
                string[] words = artText.Split(' ');
                wordCount += words.Length;
            }

            Gdata.db.DBClose();
            return wordCount;
        }
    }
}
