using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo.Helper.External.Models
{
    [Serializable]
    [XmlRoot("Artists"), XmlType("Artists")]
    public class Artist
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string popularity { get; set; }
    }   
}
