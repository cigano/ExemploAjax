﻿using System;
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
    public class QuartosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quartos
        public async Task<ActionResult> Index()
        {
            var quartos = db.Quartos.Include(q => q.Hotel);
            return View(await quartos.ToListAsync());
        }

        // GET: Quartos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = await db.Quartos.FindAsync(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // GET: Quartos/Create
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome");
            return View();
        }

        // POST: Quartos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QuartoId,Nome,HotelId")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Quartos.Add(quarto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome", quarto.HotelId);
            return View(quarto);
        }

        // GET: Quartos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = await db.Quartos.FindAsync(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome", quarto.HotelId);
            return View(quarto);
        }

        // POST: Quartos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QuartoId,Nome,HotelId")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HotelId = new SelectList(db.Hoteis, "HotelId", "Nome", quarto.HotelId);
            return View(quarto);
        }

        // GET: Quartos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = await db.Quartos.FindAsync(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // POST: Quartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Quarto quarto = await db.Quartos.FindAsync(id);
            db.Quartos.Remove(quarto);
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
