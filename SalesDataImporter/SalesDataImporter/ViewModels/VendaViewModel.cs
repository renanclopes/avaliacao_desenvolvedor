using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesDataImporter.Models;

namespace SalesDataImporter.ViewModels
{
    public class VendaViewModel
    {
        private Cliente Cliente { get; set; }
        private Fornecedor Fornecedor { get; set; }
        private Produto Produto { get; set; }
    }
}