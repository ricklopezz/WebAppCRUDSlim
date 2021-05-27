using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppCRUDSlim.Models;

namespace WebAppCRUDSlim.Controllers
{
    public class Usuarios2Controller : Controller
    {
        private FundacionSlimEntities db = new FundacionSlimEntities();

        // GET: Usuarios2
        public ActionResult Index()
        {
            return View(db.TabUsuarios.ToList());
        }

        // GET: Usuarios2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabUsuarios tabUsuarios = db.TabUsuarios.Find(id);
            if (tabUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tabUsuarios);
        }

        // GET: Usuarios2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUsuario,NombreUsuario,APaternoUsuario,AMaternoUsuario,CorreoElectronico")] TabUsuarios tabUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.TabUsuarios.Add(tabUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabUsuarios);
        }

        // GET: Usuarios2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabUsuarios tabUsuarios = db.TabUsuarios.Find(id);
            if (tabUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tabUsuarios);
        }

        // POST: Usuarios2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUsuario,NombreUsuario,APaternoUsuario,AMaternoUsuario,CorreoElectronico")] TabUsuarios tabUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabUsuarios);
        }

        // GET: Usuarios2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabUsuarios tabUsuarios = db.TabUsuarios.Find(id);
            if (tabUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tabUsuarios);
        }

        // POST: Usuarios2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabUsuarios tabUsuarios = db.TabUsuarios.Find(id);
            db.TabUsuarios.Remove(tabUsuarios);
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
