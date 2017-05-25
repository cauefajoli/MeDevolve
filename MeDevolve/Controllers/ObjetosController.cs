using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeDevolve.Models;

namespace MeDevolve.Controllers
{
    public class ObjetosController : Controller
    {
        private MeDevolveContext db = new MeDevolveContext();

        // GET: Objetos
        public ActionResult Index()
        {
            return View(db.Objetoes.ToList());
        }

        // GET: Objetos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objeto objeto = db.Objetoes.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return View(objeto);
        }

        // GET: Objetos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objetos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOBJETO,NOME")] Objeto objeto)
        {
            if (ModelState.IsValid)
            {
                db.Objetoes.Add(objeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objeto);
        }

        // GET: Objetos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objeto objeto = db.Objetoes.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return View(objeto);
        }

        // POST: Objetos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOBJETO,NOME")] Objeto objeto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objeto);
        }

        // GET: Objetos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objeto objeto = db.Objetoes.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return View(objeto);
        }

        // POST: Objetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objeto objeto = db.Objetoes.Find(id);
            db.Objetoes.Remove(objeto);
            db.SaveChanges();
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
