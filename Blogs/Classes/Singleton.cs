using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blogs.Classes
{
    /*
        Constructor privado
        Campo estático privado con inicialización directa (inline)
        Propiedad estática pública que devuelve el campo instanciado     
    */
    class Singleton
    {
        private static Singleton _instance;

        public string Lang = "es";
        public int currentBlog = 0;
        public DBConnection db;
        public string ErrorText = string.Empty;
        public int IDarticle = 0;

        // Constructor (protected)
        protected Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
            return _instance;
        }
    }
}

