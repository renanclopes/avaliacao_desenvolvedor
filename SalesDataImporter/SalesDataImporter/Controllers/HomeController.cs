using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesDataImporter.DAL;
using SalesDataImporter.Models;

namespace SalesDataImporter.Controllers
{
    public class HomeController : Controller
    {
        private readonly SalesDataImporterContext _dbContext = new SalesDataImporterContext();

        public ActionResult Index()
        {
            return View();
        }

        public Cliente GetClienteByNome(string nome)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.Nome == nome);
        }

        public Fornecedor GetFornecedorByRazaoSocial(string razao)
        {
            return new Fornecedor {Id = 1, RazaoSocial = "Fornecedor 1"};
        }

        public Produto GetProdutoByDescricao(string descricao)
        {
            return new Produto {Id = 1, Descricao = "Produto 1", Preco = 10};
        }

    }
}