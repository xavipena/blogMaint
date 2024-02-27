using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Blogs.Classes
{
    internal class Writers
    {
        public static string WriteHeader(List<string> DataList)
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return "Cap article seleccionat";

            string response = string.Empty;
            string sql =    "update articles set " +
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

            Gdata.db.DBOpen();
            try 
            { 
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
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            finally
            {
                Gdata.db.DBClose();
            }
            return response;
        }
    }
}
