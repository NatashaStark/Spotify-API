using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAcidLabs.Models
{
    public class Artista
    {
        public int ID { get; set; }
        public string NombreArtista { get; set; }
        public decimal PopularidadArtista { get; set; }

        public virtual ICollection<Album> Albumes { get; set; }
    }
}