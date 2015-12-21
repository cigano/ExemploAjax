using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploAjax.Models
{
    [Table("Temporadas")]
    public class Temporada
    {
        [Key]
        public int TemporadaId { get; set; }
        public string NomeTemporada { get; set; }

        public DateTime Chegada { get; set; }

        public DateTime Saida { get; set; }

        [Display(Name = " Diaria Fora de Temporada")]
        public decimal DiariaForaTemporada { get; set; }

        [Display(Name = "$ Diaria Temporada ")]
        public decimal DiariaTemporada { get; set; }

        [Display(Name = "$ Diaria Sexta/Sabado")]
        public decimal DiariaSabado { get; set; }

        [Display(Name = "$ Diaria Semana")]
        public decimal DiariaSemana { get; set; }

        [Display(Name = "$ Diaria Mes")]
        public decimal DiariaMes { get; set; }

        public int QuartoId { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Quarto Quarto { get; set; }
    }
}