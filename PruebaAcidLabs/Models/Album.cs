using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAcidLabs.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public int ArtistaID { get; set; }
        public string Nombre { get; set; }
        public Double Popularidad { get; set; }
        public string Disponibilidad { get; set; }

        public virtual Artista Artista { get; set; }
    }
}