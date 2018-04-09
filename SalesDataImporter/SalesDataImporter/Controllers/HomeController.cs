using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesDataImporter.DAL;
using SalesDataImporter.Models;
using SalesDataImporter.ViewModels;

namespace SalesDataImporter.Controllers
{
    public class HomeController : Controller
    {
        private readonly SalesDataImporterContext _context = new SalesDataImporterContext();

        public ActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            var fornecedores = _context.Fornecedores.ToList();
            var produtos = _context.Produtos.ToList();
            var dadosVenda = _context.DadosVendas.ToList();

            var vendaViewModel = new VendaViewModel
            {
                Clientes = new List<Cliente>(),
                Fornecedores = new List<Fornecedor>(),
                Produtos = new List<Produto>(),
                DadosVenda = new List<DadosVenda>()
            };

            vendaViewModel.Clientes.AddRange(clientes);
            vendaViewModel.Fornecedores.AddRange(fornecedores);
            vendaViewModel.Produtos.AddRange(produtos);
            vendaViewModel.DadosVenda.AddRange(dadosVenda);

            return View(vendaViewModel);
        }

    }
}