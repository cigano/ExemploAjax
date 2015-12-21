using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploAjax.Models
{
    [Table("Quartos")]
    public class Quarto
    {
        [Key]
        public int QuartoId { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Currency)]
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Temporada> Temporadas { get; set; }
    }
}