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

        // Defaults
        public string Lang = "es";
        public string currentSet = "A";

        // Initialize
        public int currentBlog = 0;
        public int IDarticle = 0;
        public int AuxKey = 0;
        public int maintMode = Modes.Status.EMPTY;
        public bool testMode = false;
        
        // This is current database
        public DBConnection db = null;
        // This is fixed database, for common tables
        public DBConnection dbCommon = null;

        public string ErrorText = string.Empty;
        public string url = string.Empty;
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

