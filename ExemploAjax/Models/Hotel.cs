using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExemploAjax.Models
{
    [Table("Hoteis")]
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        public string Nome { get; set; }
        public virtual ICollection<Quarto> Quartos { get; set; }
    }
}