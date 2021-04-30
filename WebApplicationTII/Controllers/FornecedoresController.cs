using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.Tabelas;
using Servico.Tabelas;

namespace WebApplicationTII.Controllers
{
    public class FornecedoresController : Controller
    {

        private FornecedorServico fornecedorServico = new FornecedorServico();

        private ActionResult ObterVisaoFornecedorPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = fornecedorServico.ObterFornecedoresPorId((long)id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        private ActionResult GravarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fornecedorServico.GravarFornecedor(fornecedor);
                    return RedirectToAction("Index");
                }
                return View(fornecedor);
            }
            catch
            {
                return View(fornecedor);
            }
        }

        // GET: Fornecedores
        public ActionResult Index()
        {
            return View(fornecedorServico.ObterFornecedoresClassificadasPorNome());
        }

        // GET: Fornecedores
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fornecedor fornecedor)
        {
            return GravarFornecedor(fornecedor);
        }

        public ActionResult Edit(long id)
        {
            return ObterVisaoFornecedorPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            return GravarFornecedor(fornecedor);
        }

        public ActionResult Details(long id)
        {
            return ObterVisaoFornecedorPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoFornecedorPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fornecedor fornecedor = fornecedorServico.EliminarFornecedorPorId(id);
                TempData["Message"] = "Fornecedor " + fornecedor.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}