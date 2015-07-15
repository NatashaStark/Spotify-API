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
            DataSet ds = new DataSet(); //Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var artistas = new List<Artist>();
            artistas = (from rows in ds.Tables[2].AsEnumerable()
                        select new Artist
                        {
                            ID = rows[2].ToString().Split(':')[2].ToString(),
                            name = rows[0].ToString(),
                            popularity = rows[1].ToString(),
                        }).ToList();
            return artistas;
        }

        public List<Album> RetrunListaAlbumes(string Path)
        {
            string xmlData = Path;
            DataSet ds = new DataSet(); //Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var albumes = new List<Album>();
            albumes = (from rows in ds.Tables[2].AsEnumerable()
                        select new Album
                        {
                            ArtistaID = ds.Tables[0].Rows[1][2].ToString().Split(':')[2].ToString(),
                            name = rows[0].ToString(),
                            ID = rows[3].ToString().Split(':')[2].ToString(),
                            availability = ds.Tables[3].Rows[Convert.ToInt32(rows[1].ToString())][0].ToString(),
                            released = Convert.ToInt32(rows[2].ToString())
                        }).ToList();
            return albumes;
        }

        public List<Track> RetrunListaPistas(string Path)
        {
            string xmlData = Path;
            DataSet ds = new DataSet(); //Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var pistas = new List<Track>();
            pistas = (from rows in ds.Tables[4].AsEnumerable()
                      select new Track
                      {
                          ID = rows[1].ToString(),
                          name = rows[0].ToString(),
                          tracknumber = rows[4].ToString(),
                          length = rows[5].ToString(),
                          popularity = rows[6].ToString()
                      }).ToList();
            return pistas;
        }
    }
}
