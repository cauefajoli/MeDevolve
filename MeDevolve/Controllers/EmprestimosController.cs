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
    public class EmprestimosController : Controller
    {
        private MeDevolveContext db = new MeDevolveContext();

        // GET: Emprestimos
        public ActionResult Index()
        {
            var emprestimoes = db.Emprestimoes.Include(e => e.OBJETO).Include(e => e.USUARIO);
            return View(emprestimoes.ToList());
        }

        // GET: Emprestimos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimoes.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public ActionResult Create()
        {
            ViewBag.IDOBJETO = new SelectList(db.Objetoes, "IDOBJETO", "NOME");
            ViewBag.IDUSUARIO = new SelectList(db.Usuarios, "IDUSUARIO", "NOME");
            return View();
        }

        // POST: Emprestimos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEMPRESTIMO,IDOBJETO,IDUSUARIO,DATAEMP,DATAPREVDEV,DATADEV")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimoes.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOBJETO = new SelectList(db.Objetoes, "IDOBJETO", "NOME", emprestimo.IDOBJETO);
            ViewBag.IDUSUARIO = new SelectList(db.Usuarios, "IDUSUARIO", "NOME", emprestimo.IDUSUARIO);
            return View(emprestimo);
        }

        // GET: Emprestimos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimoes.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOBJETO = new SelectList(db.Objetoes, "IDOBJETO", "NOME", emprestimo.IDOBJETO);
            ViewBag.IDUSUARIO = new SelectList(db.Usuarios, "IDUSUARIO", "NOME", emprestimo.IDUSUARIO);
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEMPRESTIMO,IDOBJETO,IDUSUARIO,DATAEMP,DATAPREVDEV,DATADEV")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOBJETO = new SelectList(db.Objetoes, "IDOBJETO", "NOME", emprestimo.IDOBJETO);
            ViewBag.IDUSUARIO = new SelectList(db.Usuarios, "IDUSUARIO", "NOME", emprestimo.IDUSUARIO);
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimoes.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimoes.Find(id);
            db.Emprestimoes.Remove(emprestimo);
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
