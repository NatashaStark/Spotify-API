using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaAcidLabs.Models
{
    public class Pista
    {
        public string ID { get; set; }
        public string AlbumID { get; set; }
        public string NombrePista { get; set; }
        public int NumeroPista { get; set; }
        public decimal Duracion { get; set; }
        public decimal Popularidad { get; set; }

        public virtual Album Album { get; set; }
    }
}