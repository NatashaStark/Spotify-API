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
        public string NombreAlbum { get; set; }
        public decimal PopularidadAlbum { get; set; }
        public string Disponibilidad { get; set; }

        public virtual Artista Artista { get; set; }
        public virtual ICollection<Pista> Pistas { get; set; }

    }
}