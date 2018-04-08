using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesDataImporter.Models;

namespace SalesDataImporter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public Cliente GetClienteByName(string name)
        {
            return new Cliente {Id = 1, Nome = "Renan"};
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