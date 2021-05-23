using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_N2.Operacoes;

namespace Trabalho_N2
{
    static class Dados
    {
        // Chave = Codigo
        // Valor = Categoria
        public static Dictionary<UInt16, Categoria> Categorias { get; private set; }
        // Chave = Codigo
        // Valor = Produto
        public static Dictionary<int, Produto> Produtos { get; private set; }
        // Chave = CPF
        // Valor = Cliente
        public static Dictionary<string, Cliente> Clientes { get; private set; }
        // Chave = Codigo Venda
        // Valor = Venda.
        public static Dictionary<int, Venda> Vendas { get; private set; }

        public static void LerCategorias()
        {
            if (!File.Exists("categorias.txt"))
                throw new Exception("Arquivos de categorias não está presente.");

            Categorias = new Dictionary<ushort, Categoria>();

            foreach(string linha in File.ReadAllLines("categorias.txt"))
            {
                string[] conteudo = linha.Split('|');

                if (Categorias.ContainsKey(Convert.ToUInt16(conteudo[0])))
                    continue;

                Categoria categoria = new Categoria();
                categoria.Codigo = Convert.ToUInt16(conteudo[0]);
                categoria.Descricao = conteudo[1];
                
                Categorias.Add(categoria.Codigo, categoria);

                OpCodeA.NumeroDeCategoriasTotal++;
            }
        }
        public static void LerProdutos()
        {
            if (!File.Exists("produtos.txt"))
                throw new Exception("Arquivos de produtos não está presente.");

            Produtos = new Dictionary<int, Produto>();

            foreach (string linha in File.ReadAllLines("produtos.txt"))
            {
                string[] conteudo = linha.Split('|');

                if (Produtos.ContainsKey(Convert.ToUInt16(conteudo[0])))
                    continue;

                Categoria categoriaDoProduto;

                if (!Categorias.TryGetValue(Convert.ToUInt16(conteudo[3]), out categoriaDoProduto))
                    continue;

                Produto produto = new Produto();

                produto.Codigo = Convert.ToUInt16(conteudo[0]);
                produto.Preco = float.Parse(conteudo[1]);
                produto.Descricao = conteudo[2];
                produto.Categoria = categoriaDoProduto;
                produto.DataDoCadastro = DateTime.ParseExact(conteudo[4], "yyyyMMddHHmmss",
                                                           CultureInfo.InvariantCulture);

                OpCodeB.NumeroDeProdutosTotal++;

                Produtos.Add(produto.Codigo, produto);
            }
        }
        public static void LerClientes()
        {
            if (!File.Exists("clientes.txt"))
                throw new Exception("Arquivos de cliente não está presente.");

            Clientes = new Dictionary<string, Cliente>();

            foreach (string linha in File.ReadAllLines("clientes.txt"))
            {
                string[] conteudo = linha.Split('|');

                if (Clientes.ContainsKey(conteudo[0]))
                    continue;

                Cliente cliente = new Cliente();

                cliente.CPF = conteudo[0];
                cliente.Nome = conteudo[1];

                OpCodeC.QuantidadeTotalDeClientes++;

                Clientes.Add(cliente.CPF, cliente);
            }
        }
        public static void LerVendas()
        {
            if (!File.Exists("vendas.txt"))
                throw new Exception("Arquivos de cliente não está presente.");

            Vendas = new Dictionary<int, Venda>();

            foreach (string linha in File.ReadAllLines("vendas.txt"))
            {
                string[] conteudo = linha.Split('|');

                // Verifica se produto é válido
                if (!Produtos.ContainsKey(Convert.ToInt32(conteudo[2])))
                    continue;

                // Verifica se cliente é valido
                if (!Clientes.ContainsKey(conteudo[1]))
                    continue;

                #region OpCodeE

                OpCodeE.VerificaSeProdutoJaFoiVendido(Convert.ToUInt16(conteudo[2]));

                #endregion

                // Caso a venda já tiver sido realizada, adiciona produto na lista da venda
                if (Vendas.ContainsKey(Convert.ToInt32(conteudo[0])))
                {
                    int numeroDaVenda = Convert.ToInt32(conteudo[0]);
                    int numeroDoProduto = Convert.ToInt32(conteudo[2]);

                    Vendas[numeroDaVenda].Produtos.Add(Produtos[numeroDoProduto]);
                    continue;
                }

                Venda venda = new Venda();

                venda.Codigo = Convert.ToInt32(conteudo[0]);
                venda.Cliente = Clientes[conteudo[1]];

                venda.Produtos = new List<Produto>();
                venda.Produtos.Add(Produtos[Convert.ToInt32(conteudo[2])]);
                venda.DataDaVenda = DateTime.ParseExact(conteudo[3], "yyyyMMddHHmmss",
                                                           CultureInfo.InvariantCulture);

                #region OpCodeD

                OpCodeD.QuantidadeVendasIndividuais++;

                #endregion

                #region OpCodeG

                string nomeDoCliente = Clientes[conteudo[1]].CPF;

                if (OpCodeG.DicionarioDeCompraEVendas.ContainsKey(nomeDoCliente))
                    OpCodeG.DicionarioDeCompraEVendas[nomeDoCliente]++;
                else
                    OpCodeG.DicionarioDeCompraEVendas.Add(nomeDoCliente, 1);

                #endregion

                Vendas.Add(venda.Codigo, venda);
            }
        }
    }
}
