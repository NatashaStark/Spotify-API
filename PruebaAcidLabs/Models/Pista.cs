using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAcidLabs.Models
{
    public class Pista
    {
        public string ID { get; set; }
        public string AlbumID { get; set; }
        public string NombrePista { get; set; }
        public string NumeroPista { get; set; }
        public string Duracion { get; set; }
        public string Popularidad { get; set; }

        public virtual Album Album { get; set; }
    }
}