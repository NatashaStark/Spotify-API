using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo.Helper.External.Models
{
    [Serializable]
    [XmlRoot("Albums"), XmlType("Albums")]
    public class Album
    {
        public string ID { get; set; }
        public string ArtistaID { get; set; }
        public string name { get; set; }
        public string popularity { get; set; }
        public string availability { get; set; }
    }
}
