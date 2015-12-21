using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploAjax.ViewModels
{
    public class ReservasViewModel
    {
        public int QuartoId { get; set; }
        public DateTime DataChegada { get; set; }
        public DateTime DataSaida { get; set; }
        public Decimal ValorReserva { get; set; }
    }
}