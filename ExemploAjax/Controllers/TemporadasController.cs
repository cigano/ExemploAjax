using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExemploAjax.Models;

namespace ExemploAjax.Controllers
{
    public class TemporadasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Temporadas
        public async Task<ActionResult> Index()
        {
            var temporadas = db.Temporadas.Include(t => t.Hotel).Include(t => t.Quarto);
            return View(await temporadas.ToListAsync());
        }

        // GET: Temporadas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = await db.Temporadas.FindAsync(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // GET: Temporadas/Create
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome");
            ViewBag.QuartoId = new SelectList(db.Quartos, "QuartoId", "Nome");
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TemporadaId,NomeTemporada,Chegada,Saida,DiariaForaTemporada,DiariaTemporada,DiariaSabado,DiariaSemana,DiariaMes,QuartoId,HotelId")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Temporadas.Add(temporada);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome", temporada.HotelId);
            ViewBag.QuartoId = new SelectList(db.Quartos, "QuartoId", "Nome", temporada.QuartoId);
            return View(temporada);
        }

        // GET: Temporadas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = await db.Temporadas.FindAsync(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome", temporada.HotelId);
            ViewBag.QuartoId = new SelectList(db.Quartos, "QuartoId", "Nome", temporada.QuartoId);
            return View(temporada);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TemporadaId,NomeTemporada,Chegada,Saida,DiariaForaTemporada,DiariaTemporada,DiariaSabado,DiariaSemana,DiariaMes,QuartoId,HotelId")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporada).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome", temporada.HotelId);
            ViewBag.QuartoId = new SelectList(db.Quartos, "QuartoId", "Nome", temporada.QuartoId);
            return View(temporada);
        }

        // GET: Temporadas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = await db.Temporadas.FindAsync(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // POST: Temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Temporada temporada = await db.Temporadas.FindAsync(id);
            db.Temporadas.Remove(temporada);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
