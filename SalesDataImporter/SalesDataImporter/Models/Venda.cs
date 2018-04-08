using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesDataImporter.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FornecedorId { get; set; }
        public int ProdutoId { get; set; }
        public double ValorUnitario { get; set; }
        public double Total { get; set; }

    }
}