using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blogs.Classes
{
    internal class Loaders
    {

        // ---------------------------------------------------------------------------
        // Generic ComboBox loader
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Generic combo loader
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="sql"></param>
        public static bool LoadComboBox(ComboBox combobox, string sql)
        {
            if (combobox == null) return true; 
            if (sql == string.Empty) return true;

            bool result = true;
            List<cbOption> list = new List<cbOption>();
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            try
            {
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
            }
            catch (Exception ex)
            {
                Gdata.ErrorText = ex.Message;
                result = false;
            }
            finally
            {
                Gdata.db.DBClose();
            }
            combobox.DataSource = null;
            combobox.DataSource = list;
            combobox.ValueMember = "entityValue";
            combobox.DisplayMember = "entityName";
            // Readonly, not editable
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            return result;
        }

        public static void LoadCombo(System.Windows.Forms.ComboBox combobox, int ComboType)
        {
            cbOption op;
            List<cbOption> list = new List<cbOption>();

            switch (ComboType)
            {
                case Combos.STATUS:

                    op = new cbOption() { entityValue = "A", entityName = "Actiu" };
                    list.Add(op);
                    op = new cbOption() { entityValue = "I", entityName = "Inactiu" };
                    list.Add(op);
                    break;

                case Combos.LANGUAGE:

                    op = new cbOption() { entityValue = "es", entityName = "Castellà" };
                    list.Add(op);
                    op = new cbOption() { entityValue = "ca", entityName = "Català" };
                    list.Add(op);
                    break;

                case Combos.AUTHOR:

                    op = new cbOption() { entityValue = "1", entityName = "Xavi P." };
                    list.Add(op);
                    op = new cbOption() { entityValue = "2", entityName = "Cris R." };
                    list.Add(op);
                    break;

                case Combos.SECTION_TYPE:

                    op = new cbOption() { entityValue = "T", entityName = "Text" };
                    list.Add(op);
                    break;

                case Combos.BLOG_SET:

                    op = new cbOption() { entityValue = "A", entityName = "Blocs técnics" };
                    list.Add(op);
                    op = new cbOption() { entityValue = "B", entityName = "Blocs personals" };
                    list.Add(op);
                    break;
            }

            SetCombo(list, combobox);
        }

        private static void SetCombo(List<cbOption> list, System.Windows.Forms.ComboBox combobox)
        {
            combobox.DataSource = list;
            combobox.ValueMember = "entityValue";
            combobox.DisplayMember = "entityName";
            // Readonly, not editable
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;

        }
    }
}
