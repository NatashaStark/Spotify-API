using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using Demo.Helper.External.Models;

namespace Demo.Helper
{
    public class XMLReader
    {
        /// <summary>  
        /// Return list of products from XML.  
        /// </summary>  
        /// <returns>List of products</returns>  
        public List<Artist> RetrunListaArtistas(string Path)
        {
            string xmlData = Path; 
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var artistas = new List<Artist>();
            artistas = (from rows in ds.Tables[2].AsEnumerable()
                        select new Artist
                        {
                            name = rows[0].ToString(),
                            popularity = rows[1].ToString(),
                        }).ToList();
            return artistas;
        }
    }
}
