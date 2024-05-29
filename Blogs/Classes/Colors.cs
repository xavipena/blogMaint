using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blogs.Classes
{
    public class Colors
    {
        static Color MenuOption = Color.FromArgb(72, 31, 170);
        static Color MenuOptionSelected = Color.FromArgb(46, 51, 73);
        static Color SelectedLanguage = Color.LightGreen;

        public static Color MenuOptionColor { get { return MenuOption; } }
        public static Color MenuOptionColorSelected { get { return MenuOptionSelected; } }
        public static Color ColorSelectedLanguage { get { return SelectedLanguage; } }
    }
}
