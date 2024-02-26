using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Blogs.Classes
{
    /// <summary>
    /// Class for key values stores in configuration file
    /// </summary>
    public class cbOption
    {
        /// <summary>
        /// Name of key
        /// </summary>
        [XmlAttribute("Name")]
        public string entityName { get; set; }
        /// <summary>
        /// Key value
        /// </summary>
        [XmlAttribute("Value")]
        public string entityValue { get; set; }
    }
}
