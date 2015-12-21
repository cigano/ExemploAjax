using ExemploAjax.Models;
using ExemploAjax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploAjax.Controllers
{
    public class ReservasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservas
        public ActionResult Index()
        {
            ViewBag.Quartos = db.Quartos.ToList();
            return View();
        }

        public JsonResult CalcularReserva(ReservasViewModel viewModel)
        {
            var dChegada = viewModel.DataChegada;
            var dSaida = viewModel.DataSaida;
            var vlrdiaria = 0;

            for (var curDate = dChegada; curDate < dSaida; curDate = curDate.AddDays(1))
            {
                vlrdiaria += Convert.ToInt32(ValorDiaria(curDate));
            }

            return Json(new { ValorReserva = vlrdiaria }, JsonRequestBehavior.AllowGet);
        }

        private static int ValorDiaria(DateTime Date)
        {
            if ((Date.DayOfWeek == DayOfWeek.Friday) || (Date.DayOfWeek == DayOfWeek.Saturday))
            {
                return 100;
            }

            return 80;
        }
    }
}