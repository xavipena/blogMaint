using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Blogs.Classes
{
    internal class Writers
    {
        public static bool UpdateHeader(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            if (RowExistsIn("articles"))
            {
                sql = "update articles set " +
                      "type       = @val01," +
                      "date       = @val02," +
                      "published  = @val03," +
                      "updated    = @val04," +
                      "title      = @val05," +
                      "excerpt    = @val06," +
                      "status     = @val07," +
                      "IDauthor   = @val08," +
                      "lang       = @val09," +
                      "next       = @val10," +
                      "prev       = @val11," +
                      "readTime   = @val12," +
                      "wordCount  = @val13 " +
                      "where IDblog = @par1 and IDarticle = @par2";
            }
            else
            {
                sql = "insert into articles set " +
                      ", IDblog      =@val " +
                      ", IDarticle   =@val " +
                      ", type        =@val " +
                      ", date        =@val " +
                      ", publish     =@val " +
                      ", updated     =@val " +
                      ", excerpt     =@val " +
                      ", status      =@val " +
                      ", IDauthor    =@val " +
                      ", lang        =@val " +
                      ", next        =@val " +
                      ", prev        =@val " +
                      ", readTime    =@val " +
                      ", wordCount   =@val ";
            }
            Gdata.db.DBOpen();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            // Key
            cmd.Parameters.AddWithValue("@par1", Gdata.currentBlog);
            cmd.Parameters.AddWithValue("@par2", Gdata.IDarticle);
            // Values
            cmd.Parameters.AddWithValue("@val01", DataList[0]);
            cmd.Parameters.AddWithValue("@val02", DataList[1]);
            cmd.Parameters.AddWithValue("@val03", DataList[2]);
            cmd.Parameters.AddWithValue("@val04", DataList[3]);
            cmd.Parameters.AddWithValue("@val05", DataList[4]);
            cmd.Parameters.AddWithValue("@val06", DataList[5]);
            cmd.Parameters.AddWithValue("@val07", DataList[6]);
            cmd.Parameters.AddWithValue("@val08", DataList[7]);
            cmd.Parameters.AddWithValue("@val09", DataList[8]);
            cmd.Parameters.AddWithValue("@val10", DataList[9]);
            cmd.Parameters.AddWithValue("@val11", DataList[10]);
            cmd.Parameters.AddWithValue("@val12", DataList[11]);
            cmd.Parameters.AddWithValue("@val13", DataList[12]);
            // Run
            response = RunUpdate(cmd);
            Gdata.db.DBClose();
            return response;
        }

        private static bool RowExistsIn(string table)
        {
            bool exists = false;
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            string sql = "select * from " + table + " where IDarticle = " + Gdata.IDarticle + " and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            exists = reader.HasRows;
            Gdata.db.DBClose();
            return exists;
        }

        private static void AddHeader()
        {
            Singleton Gdata = Singleton.GetInstance();

            string[] val = { "", "", "", "" };
            cbOption op = cbHeadType.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbHeadStatus.SelectedItem as cbOption;
            val[1] = op.entityValue;
            op = cbHeadAuthor.SelectedItem as cbOption;
            val[2] = op.entityValue;
            op = cbHeadLang.SelectedItem as cbOption;
            val[3] = op.entityValue;

            string sql = "insert into articles set " +
                         ", IDblog      = " + Gdata.currentBlog +
                         ", IDarticle   = " + Gdata.IDarticle +
                         ", type        = '" + val[0] + "'" +
                         ", date        = '" + dtpHeadDate.Value.ToString("yyyy/MM/dd") + "'" +
                         ", publish     = '" + dtpHeadPub.Value.ToString("yyyy/MM/dd") + "'" +
                         ", updated     = '" + dtpHeadUpdate.Value.ToString("yyyy/MM/dd") + "'" +
                         ", excerpt     = '" + tbHeadExcerpt.Text + "'" +
                         ", status      = 'I'" +
                         ", IDauthor    =  " + val[2] +
                         ", lang        = '" + val[3] + "'" +
                         ", next        =  " + tbHeadNext.Text +
                         ", prev        =  " + tbHeadPrev.Text +
                         ", readTime    =  " + tbHeadTime.Text.Replace(',', '.') +
                         ", wordCount   =  " + tbHeadWords.Text;

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);

        }

        /// <summary>
        /// Executes
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool RunUpdate(MySqlCommand cmd)
        {
            Singleton Gdata = Singleton.GetInstance();
            bool result = false;
            try
            {
                if (Gdata.testMode)
                {
                    string sql = cmd.CommandText;
                    foreach (MySqlParameter p in cmd.Parameters)
                    {
                        sql = sql.Replace(p.ParameterName.ToString(), p.Value.ToString());
                    }
                    MessageBox.Show(sql);
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

    }
}
