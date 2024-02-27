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
        public static string WriteHeader() 
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return "Cap article seleccionat";

            string response = string.Empty;
            string sql = "update articles set " +
                            "type =" +
                            "date =" +
                            "published =" +
                            "updated =" +
                            "title =" +
                            "excerpt =" +
                            "status =" +
                            "IDauthor =" +
                            "lang =" +
                            "next =" +
                            "prev =" +
                            "readTime = @val1, " +
                            "wordCount = @val2 " +
                         "where IDblog = @par1 and IDarticle = @par2";

            Gdata.db.DBOpen();
            try 
            { 
                var cmd = new MySqlCommand(sql, Gdata.db.Connection);
                cmd.Parameters.AddWithValue("@par1", Gdata.currentBlog);
                cmd.Parameters.AddWithValue("@par2", Gdata.IDarticle);
                cmd.Parameters.AddWithValue("@val1", );
                cmd.Parameters.AddWithValue("@val2", );
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
