using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesDataImporter.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RazaoSocial { get; set; }
    }
}