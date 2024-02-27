using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blogs.Classes
{
    internal class Loaders
    {
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
