# Sales Data Importer #
---

## Tecnologias utilizadas

* ASP.NET MVC
* Entity Framework 6
* SQL SERVER


## Aplicação

Sua utilização tem como objetivo a importação de arquivos de vendas no formato .txt com layout pré-denifido. Os dados importados são gravados no banco e exibidos na página inicial.

## Configurações para execução da aplicação

* Faça o clone ou baixe o projeto em um diretório de sua preferência;
* Altere o arquivo web.config, indicando o nome da instância, usuário e senha do seu banco de dados SQL SERVER;
* Faça o build do projeto;
* Execute-o

## Manual de funcionamento

* Na primeira execução da aplicação, o banco de dados "SalesDataImporter" será criado com as seguintes tabelas:

** Cliente
- Fornecedor
- Produto
- DadosVenda

* A página incial irá exibir os dados das vendas importadas ou pedirá para que sejam importados arquivos caso não existam dados importados.

* A página de importação poderá ser acessada pelo menu "Importação" ou pela própria página inicial enquanto não houver registros de vendas.


