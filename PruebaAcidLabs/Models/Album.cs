using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAcidLabs.Models
{
    public class Album
    {
        public string ID { get; set; }
        public string ArtistaID { get; set; }
        public string NombreAlbum { get; set; }
        public string PopularidadAlbum { get; set; }
        public string Disponibilidad { get; set; }

        public virtual Artista Artista { get; set; }
        public virtual ICollection<Pista> Pistas { get; set; }

    }
}