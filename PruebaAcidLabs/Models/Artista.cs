using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAcidLabs.Models
{
    public class Artista
    {
        public string ID { get; set; }
        public string NombreArtista { get; set; }
        public string PopularidadArtista { get; set; }

        public virtual ICollection<Album> Albumes { get; set; }
    }
}