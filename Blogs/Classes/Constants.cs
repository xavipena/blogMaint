using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.Classes
{
    public class Constants
    {
        public const string YES = "Y";
        public const string NO = "N";
        public const string SAY_YES = "Sí";
        public const string SAY_NO = "No";
        public const int NUM_TABS = 11;
    }
    public class Paths
    {
        public const string DOWNLOAD = @"c:\temp\";
        public const string IMAGES_URI = @"https://diaridigital.net/#blog#/images/";
    }
    public class Delimiter
    {
        public const char SEMICOLON = ';';
    }
    public class TextMessage
    {
        public const string READY = "Listo";
    }
    public class Marks
    {
        public const string MODIFIED = "x";
        public const string UNMARKED = "";
    }
    public class Articles
    {
        public const int WORDS_PER_MIN = 235;
    }
    public class Tabs
    {
        // Should be the ordered list of tabs
        public const int SELECTOR = 0;
        public const int HEADER = 1;
        public const int SECTIONS = 2;
        public const int IMAGES = 3;
        public const int LINKS = 4;
        public const int REFERENCE = 5;
        public const int QUOTES = 6;
        public const int CODE = 7;
        public const int READ_TIME = 8;
        public const int METADATA = 9;
        public const int CREDITS = 10;
    }
    public class Combos
    {
        public const int STATUS = 0;
        public const int LANGUAGE = 1;
        public const int AUTHOR = 2;
        public const int SECTION_TYPE = 3;
        public const int BLOG_SET = 4;
    }
    public class Language
    {
        public const string CASTELLA = "es";
        public const string CATALA = "ca";
    }
    public class BlogSet
    {
        public const string TECHNICAL = "A";
        public const string PERSONAL = "B";
    }
    public class dBServers
    {
        public const string TECHNICAL = "qahz995.diaridigital.net";
        public const string PERSONAL = "qahz997.diaridigital.net";
    }

    public class Messages
    {
        public const string CONNECTED = "Connectat";
        public const string READY = "Preparat";
    }
    public class Actions
    {
        public const int LIST = 0;
        public const int CLEAR = 1;
    }
}
