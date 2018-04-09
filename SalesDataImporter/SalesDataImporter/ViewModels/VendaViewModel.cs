using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesDataImporter.Models;

namespace SalesDataImporter.ViewModels
{
    public class VendaViewModel
    {
        public List<Cliente> Clientes { get; set; }
        public List<Fornecedor> Fornecedores { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<DadosVenda> DadosVenda { get; set; }
    }
}