using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Data;
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
        // ---------------------------------------------------------------------------
        // Updates/inserts to database
        // ---------------------------------------------------------------------------

        public static bool UpdateHeader(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            string table = "articles";
            if (RowExistsIn(table))
            {
                sql = "update " + table + " set " +
                      " type       = @val01 " +
                      ",date       = @val02 " +
                      ",published  = @val03 " +
                      ",updated    = @val04 " +
                      ",title      = @val05 " +
                      ",excerpt    = @val06 " +
                      ",status     = @val07 " +
                      ",IDauthor   = @val08 " +
                      ",lang       = @val09 " +
                      ",next       = @val10 " +
                      ",prev       = @val11 " +
                      ",readTime   = @val12 " +
                      ",wordCount  = @val13 " +
                      "where IDblog = @par1 and IDarticle = @par2"; 
            }
            else
            {
                sql = "insert into " + table + " set " +
                      " IDblog      = @par1 " +
                      ",IDarticle   = @par2 " +
                      ",type        = @val01 " +
                      ",date        = @val02 " +
                      ",published   = @val03 " +
                      ",updated     = @val04 " +
                      ",title       = @val05 " +
                      ",excerpt     = @val06 " +
                      ",status      = @val07 " +
                      ",IDauthor    = @val08 " +
                      ",lang        = @val09 " +
                      ",next        = @val10 " +
                      ",prev        = @val11 " +
                      ",readTime    = @val12 " +
                      ",wordCount   = @val13 ";
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

        public static bool UpdateText(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            string table = "article_details";
            Gdata.AuxKey = Int32.Parse(DataList[0]);
            if (RowExistsIn(table))
            {
                sql = "update " + table + " set " +
                      " section = @val01" +
                      ",type    = @val02" +
                      ",text    = @val03" +
                      ",status  = @val04" +
                      "where IDarticle = @par1 and position = @par2 and lang = @par3";
            }
            else
            {
                sql = "insert into " + table + " set " +
                      " IDarticle   = @par1" +
                      ",position    = @par2" +
                      ",section     = @val01" +
                      ",type        = @val02" +
                      ",text        = @val03" +
                      ",status      = @val04" +
                      ",lang        = @par3";
            }
            Gdata.db.DBOpen();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            // Key
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            cmd.Parameters.AddWithValue("@par2", DataList[0]);
            cmd.Parameters.AddWithValue("@par3", DataList[5]);
            // Values
            cmd.Parameters.AddWithValue("@val01", DataList[1]);
            cmd.Parameters.AddWithValue("@val02", DataList[2]);
            cmd.Parameters.AddWithValue("@val03", DataList[3]);
            cmd.Parameters.AddWithValue("@val04", DataList[4]);
            // Run
            response = RunUpdate(cmd);
            Gdata.db.DBClose();
            return response;
        }

        public static bool UpdateImage(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            string table = "article_images";
            Gdata.AuxKey = Int32.Parse(DataList[0]);
            if (RowExistsIn(table))
            {
                sql = "update " + table + " set " +
                      " section = @val01" +
                      ",type    = @val02" +
                      ",text    = @val03" +
                      ",status  = @val04" +
                      "where IDarticle = @par1 and position = @par2 and lang = @par3";
            }
            else
            {
                sql = "insert into " + table + " set " +
                      " IDarticle   = @par1" +
                      ",position    = @par2" +
                      ",section     = @val01" +
                      ",type        = @val02" +
                      ",text        = @val03" +
                      ",status      = @val04" +
                      ",lang        = @par3";
            }
            Gdata.db.DBOpen();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            // Key
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            cmd.Parameters.AddWithValue("@par2", DataList[0]);
            cmd.Parameters.AddWithValue("@par3", DataList[5]);
            // Values
            cmd.Parameters.AddWithValue("@val01", DataList[1]);
            cmd.Parameters.AddWithValue("@val02", DataList[2]);
            cmd.Parameters.AddWithValue("@val03", DataList[3]);
            cmd.Parameters.AddWithValue("@val04", DataList[4]);
            // Run
            response = RunUpdate(cmd);
            Gdata.db.DBClose();
            return response;
        }

        public static bool UpdateLinks(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            string table = "article_links";
            Gdata.AuxKey = Int32.Parse(DataList[0]);
            if (RowExistsIn(table))
            {
                sql = "update " + table + " set " +
                      " section = @val01" +
                      ",type    = @val02" +
                      ",text    = @val03" +
                      ",status  = @val04" +
                      "where IDarticle = @par1 and position = @par2 and lang = @par3";
            }
            else
            {
                sql = "insert into " + table + " set " +
                      " IDarticle   = @par1" +
                      ",position    = @par2" +
                      ",section     = @val01" +
                      ",type        = @val02" +
                      ",text        = @val03" +
                      ",status      = @val04" +
                      ",lang        = @par3";
            }
            Gdata.db.DBOpen();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            // Key
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            cmd.Parameters.AddWithValue("@par2", DataList[0]);
            cmd.Parameters.AddWithValue("@par3", DataList[5]);
            // Values
            cmd.Parameters.AddWithValue("@val01", DataList[1]);
            cmd.Parameters.AddWithValue("@val02", DataList[2]);
            cmd.Parameters.AddWithValue("@val03", DataList[3]);
            cmd.Parameters.AddWithValue("@val04", DataList[4]);
            // Run
            response = RunUpdate(cmd);
            Gdata.db.DBClose();
            return response;
        }

        public static bool UpdateRefs(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            string table = "article_related";
            Gdata.AuxKey = Int32.Parse(DataList[0]);
            if (RowExistsIn(table))
            {
                sql = "update " + table + " set " +
                      " section = @val01" +
                      ",type    = @val02" +
                      ",text    = @val03" +
                      ",status  = @val04" +
                      "where IDarticle = @par1 and position = @par2 and lang = @par3";
            }
            else
            {
                sql = "insert into " + table + " set " +
                      " IDarticle   = @par1" +
                      ",position    = @par2" +
                      ",section     = @val01" +
                      ",type        = @val02" +
                      ",text        = @val03" +
                      ",status      = @val04" +
                      ",lang        = @par3";
            }
            Gdata.db.DBOpen();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            // Key
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            cmd.Parameters.AddWithValue("@par2", DataList[0]);
            cmd.Parameters.AddWithValue("@par3", DataList[5]);
            // Values
            cmd.Parameters.AddWithValue("@val01", DataList[1]);
            cmd.Parameters.AddWithValue("@val02", DataList[2]);
            cmd.Parameters.AddWithValue("@val03", DataList[3]);
            cmd.Parameters.AddWithValue("@val04", DataList[4]);
            // Run
            response = RunUpdate(cmd);
            Gdata.db.DBClose();
            return response;
        }

        public static bool UpdateQuote(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            string table = "article_quotes";
            Gdata.AuxKey = Int32.Parse(DataList[0]);
            if (RowExistsIn(table))
            {
                sql = "update " + table + " set " +
                      " section = @val01" +
                      ",type    = @val02" +
                      ",text    = @val03" +
                      ",status  = @val04" +
                      "where IDarticle = @par1 and position = @par2 and lang = @par3";
            }
            else
            {
                sql = "insert into " + table + " set " +
                      " IDarticle   = @par1" +
                      ",position    = @par2" +
                      ",section     = @val01" +
                      ",type        = @val02" +
                      ",text        = @val03" +
                      ",status      = @val04" +
                      ",lang        = @par3";
            }
            Gdata.db.DBOpen();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            // Key
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            cmd.Parameters.AddWithValue("@par2", DataList[0]);
            cmd.Parameters.AddWithValue("@par3", DataList[5]);
            // Values
            cmd.Parameters.AddWithValue("@val01", DataList[1]);
            cmd.Parameters.AddWithValue("@val02", DataList[2]);
            cmd.Parameters.AddWithValue("@val03", DataList[3]);
            cmd.Parameters.AddWithValue("@val04", DataList[4]);
            // Run
            response = RunUpdate(cmd);
            Gdata.db.DBClose();
            return response;
        }

        public static bool UpdateCode(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;

            bool response = true;
            string sql = string.Empty;
            string table = "article_code";
            Gdata.AuxKey = Int32.Parse(DataList[0]);
            if (RowExistsIn(table))
            {
                sql = "update " + table + " set " +
                      " section = @val01" +
                      ",type    = @val02" +
                      ",text    = @val03" +
                      ",status  = @val04" +
                      "where IDarticle = @par1 and position = @par2 and lang = @par3";
            }
            else
            {
                sql = "insert into " + table + " set " +
                      " IDarticle   = @par1" +
                      ",position    = @par2" +
                      ",section     = @val01" +
                      ",type        = @val02" +
                      ",text        = @val03" +
                      ",status      = @val04" +
                      ",lang        = @par3";
            }
            Gdata.db.DBOpen();

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            // Key
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            cmd.Parameters.AddWithValue("@par2", DataList[0]);
            cmd.Parameters.AddWithValue("@par3", DataList[5]);
            // Values
            cmd.Parameters.AddWithValue("@val01", DataList[1]);
            cmd.Parameters.AddWithValue("@val02", DataList[2]);
            cmd.Parameters.AddWithValue("@val03", DataList[3]);
            cmd.Parameters.AddWithValue("@val04", DataList[4]);
            // Run
            response = RunUpdate(cmd);
            Gdata.db.DBClose();
            return response;
        }

        public static bool UpdateMetadata(DataGridView dgv)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return false;
            bool ok = false;

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (dgvr.Cells[2].Value != null)
                {
                    string sql = string.Empty;
                    string table = "article_metadata";
                    Gdata.AuxKey = Int32.Parse(dgvr.Cells[0].Value.ToString());
                    if (RowExistsIn(table))
                    {
                        sql = "update " + table + " set " +
                              " value   = @val01 " +
                              "where IDarticle = @par1 and IDmeta = @par2 and lang = @par3";
                    }
                    else
                    {
                        sql = "insert into " + table + " set " +
                              " IDarticle   = @par1" +
                              ",IDmeta      = @par2" +
                              ",value       = @val01" +
                              ",lang        = @par3";
                    }
                    Gdata.db.DBOpen();
                    using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
                    {
                        // Key
                        cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
                        cmd.Parameters.AddWithValue("@par2", dgvr.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@par3", Gdata.Lang);
                        // Values
                        string cellValue = dgvr.Cells[3].Value == null ? " " : dgvr.Cells[3].Value.ToString();
                        cmd.Parameters.AddWithValue("@val01", cellValue);
                        // Run
                        ok = RunUpdate(cmd);
                        if (!ok)
                        {
                            break;
                        }
                    }
                }
            }
            return ok;
        }

        // ---------------------------------------------------------------------------
        // Common methods
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Check if current row exists
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static bool RowExistsIn(string table)
        {
            bool exists = false;
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            string sql = "select * from " + table + " where ";
            switch(table)
            {
                case "articles":
                    sql += "IDarticle = " + Gdata.IDarticle + " and lang = '" + Gdata.Lang + "'";
                    break;
                case "article_details":
                    sql += "IDarticle = " + Gdata.IDarticle + " and position = " + Gdata.AuxKey + " and lang = '" + Gdata.Lang + "'";
                    break;
                case "article_metadata":
                    sql += "IDarticle = " + Gdata.IDarticle + " and IDmeta = " + Gdata.AuxKey + " and lang = '" + Gdata.Lang + "'";
                    break;
            }
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            exists = reader.HasRows;
            Gdata.db.DBClose();
            return exists;
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
            string sql = string.Empty;
            try
            {
                sql = cmd.CommandText;
                if (Gdata.testMode)
                {
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
                foreach (MySqlParameter p in cmd.Parameters)
                {
                    sql = sql.Replace(p.ParameterName.ToString(), p.Value.ToString());
                }
                MessageBox.Show(ex.Message + Environment.NewLine + sql);
            }
            return result;
        }

    }
}
