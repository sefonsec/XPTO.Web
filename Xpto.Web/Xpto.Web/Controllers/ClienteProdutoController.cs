using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xpto.Modelo;
using Xpto.Persistencia.Context;

namespace Xpto.Web.Controllers
{
    public class ClienteProdutoController : Controller
    {
        private EFContext db = new EFContext();

        // GET: ClienteProduto
        public ActionResult Index()
        {
            var clientesProdutos = db.ClientesProdutos.Include(c => c.Cliente).Include(c => c.Produto);
            return View(clientesProdutos.ToList());
        }

        // GET: ClienteProduto/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteProduto clienteProduto = db.ClientesProdutos.Find(id);
            if (clienteProduto == null)
            {
                return HttpNotFound();
            }
            return View(clienteProduto);
        }

        // GET: ClienteProduto/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao");
            return View();
        }

        // POST: ClienteProduto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,ProdutoId")] ClienteProduto clienteProduto)
        {
            if (ModelState.IsValid)
            {
                db.ClientesProdutos.Add(clienteProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", clienteProduto.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao", clienteProduto.ProdutoId);
            return View(clienteProduto);
        }

        // GET: ClienteProduto/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteProduto clienteProduto = db.ClientesProdutos.Find(id);
            if (clienteProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", clienteProduto.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao", clienteProduto.ProdutoId);
            return View(clienteProduto);
        }

        // POST: ClienteProduto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,ProdutoId")] ClienteProduto clienteProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", clienteProduto.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao", clienteProduto.ProdutoId);
            return View(clienteProduto);
        }

        // GET: ClienteProduto/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteProduto clienteProduto = db.ClientesProdutos.Find(id);
            if (clienteProduto == null)
            {
                return HttpNotFound();
            }
            return View(clienteProduto);
        }

        // POST: ClienteProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClienteProduto clienteProduto = db.ClientesProdutos.Find(id);
            db.ClientesProdutos.Remove(clienteProduto);
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
