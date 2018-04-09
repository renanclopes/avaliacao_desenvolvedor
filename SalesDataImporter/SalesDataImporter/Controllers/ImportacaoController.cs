using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesDataImporter.DAL;
using SalesDataImporter.Models;

namespace SalesDataImporter.Controllers
{
    public class ImportacaoController : Controller
    {
        private readonly SalesDataImporterContext _dbContext = new SalesDataImporterContext();

        private enum DadosLinhaArquivo
        {
            NomeCliente = 0,
            DescricaoProduto = 1,
            PrecoProduto = 2,
            Quantidade = 3,
            EnderecoCliente = 4,
            RazaoSocialFornecedor = 5
        }


        public ActionResult Importacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportarArquivo(HttpPostedFileBase arquivo)
        {
            if (arquivo == null)
                return RedirectToAction("Importacao");

            var path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = path + Path.GetFileName(arquivo.FileName);
            arquivo.SaveAs(filePath);

            var arquivoTxt = System.IO.File.ReadAllLines(filePath);

            const char splitChar = '\t';

            foreach (var linha in arquivoTxt)
            {
                if (linha == arquivoTxt[0]) continue;

                var vendaInfo = linha.Split(splitChar);

                var consultaCliente = GetClienteByNome(vendaInfo[(int)DadosLinhaArquivo.NomeCliente]);
                var cliente = consultaCliente ??
                              new Cliente
                              {
                                  Nome = vendaInfo[(int)DadosLinhaArquivo.NomeCliente],
                                  Endereco = vendaInfo[(int)DadosLinhaArquivo.EnderecoCliente]
                              };
                if (consultaCliente == null)
                    _dbContext.Clientes.Add(cliente);

                var consultaFornecedor = GetFornecedorByRazaoSocial(vendaInfo[(int)DadosLinhaArquivo.RazaoSocialFornecedor]);
                var fornecedor = consultaFornecedor ??
                                 new Fornecedor { RazaoSocial = vendaInfo[(int)DadosLinhaArquivo.RazaoSocialFornecedor] };
                if (consultaFornecedor == null)
                    _dbContext.Fornecedores.Add(fornecedor);

                var consultaProduto = GetProdutoByDescricao(vendaInfo[(int)DadosLinhaArquivo.DescricaoProduto]);
                var produto = consultaProduto ??
                              new Produto
                              {
                                  Descricao = vendaInfo[(int)DadosLinhaArquivo.DescricaoProduto],
                                  Preco = Convert.ToDouble(vendaInfo[(int)DadosLinhaArquivo.PrecoProduto].Replace(".",","))
                              };
                if (consultaProduto == null)
                    _dbContext.Produtos.Add(produto);

                if (ModelState.IsValid)
                    _dbContext.SaveChanges();

                cliente = GetClienteByNome(vendaInfo[(int)DadosLinhaArquivo.NomeCliente]);
                fornecedor = GetFornecedorByRazaoSocial(vendaInfo[(int)DadosLinhaArquivo.RazaoSocialFornecedor]);
                produto = GetProdutoByDescricao(vendaInfo[(int)DadosLinhaArquivo.DescricaoProduto]);

                var dadosVenda = new DadosVenda
                {
                    ClienteId = cliente.Id,
                    FornecedorId = fornecedor.Id,
                    ProdutoId = produto.Id,
                    ValorUnitario = produto.Preco,
                    Quantidade = Convert.ToDouble(vendaInfo[(int)DadosLinhaArquivo.Quantidade]),
                    Total = produto.Preco * Convert.ToDouble(vendaInfo[(int)DadosLinhaArquivo.Quantidade])
                };

                _dbContext.DadosVendas.Add(dadosVenda);

                if (ModelState.IsValid)
                    _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public Cliente GetClienteByNome(string nome)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.Nome == nome);
        }

        public Fornecedor GetFornecedorByRazaoSocial(string razao)
        {
            return _dbContext.Fornecedores.FirstOrDefault(f => f.RazaoSocial == razao);
        }

        public Produto GetProdutoByDescricao(string descricao)
        {
            return _dbContext.Produtos.FirstOrDefault(p => p.Descricao == descricao);
        }
    }
}