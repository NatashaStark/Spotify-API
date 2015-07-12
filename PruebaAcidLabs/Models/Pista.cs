using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAcidLabs.Models
{
    public class Pista
    {
        public int PistaID { get; set; }
        public int AlbumID { get; set; }
        public string NombrePista { get; set; }
        public int NumeroPista { get; set; }
        public int Duracion { get; set; }
        public decimal Popularidad { get; set; }

        public virtual Album Album { get; set; }
    }
}