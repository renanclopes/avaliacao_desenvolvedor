using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesDataImporter.Models
{
    [Table("DadosVenda")]
    public class DadosVenda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public double ValorUnitario { get; set; }

        [Required]
        public double Total { get; set; }

    }
}