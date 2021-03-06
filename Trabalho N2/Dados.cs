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

                #region OpCodeC
                OpCodeC.QuantidadeTotalDeClientes++;
                #endregion

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

                Produto produtoAtual = Produtos[Convert.ToInt32(conteudo[2])];
                string CPF = conteudo[1];
                Categoria categoria = produtoAtual.Categoria;

                #region OpCodeE

                OpCodeE.VerificaSeProdutoJaFoiVendido(Convert.ToUInt16(conteudo[2]));

                #endregion

                #region OpCodeH

                if (OpCodeH.VendasDeCadaProduto.ContainsKey(produtoAtual))
                    OpCodeH.VendasDeCadaProduto[produtoAtual]++;
                else
                    OpCodeH.VendasDeCadaProduto.Add(produtoAtual, 1);

                #endregion

                #region OpCodeI

                if (OpCodeI.VendasPorCategoria.ContainsKey(categoria))
                    OpCodeI.VendasPorCategoria[categoria] += produtoAtual.Preco;
                else
                    OpCodeI.VendasPorCategoria.Add(categoria, produtoAtual.Preco);

                #endregion

                #region OpCodeJ

                string mesEAno = conteudo[3].Substring(0, 6);

                if (OpCodeJ.VendasPorMesEAno.ContainsKey(mesEAno))
                    OpCodeJ.VendasPorMesEAno[mesEAno] += produtoAtual.Preco;
                else
                    OpCodeJ.VendasPorMesEAno.Add(mesEAno, produtoAtual.Preco);

                #endregion

                #region OpCodeL

                if (OpCodeK.ClientesEVendas.ContainsKey(CPF))
                    OpCodeK.ClientesEVendas[CPF] += produtoAtual.Preco;
                else
                    OpCodeK.ClientesEVendas.Add(CPF, produtoAtual.Preco);

                #endregion

                #region OpCodeK

                if (OpCodeL.ProdutoEQuantidadeVendida.ContainsKey(produtoAtual.Codigo))
                    OpCodeL.ProdutoEQuantidadeVendida[produtoAtual.Codigo]++;
                else
                    OpCodeL.ProdutoEQuantidadeVendida.Add(produtoAtual.Codigo, 1);

                #endregion

                #region OpCodeO

                if (!OpCodeO.ProdutosJaVendidos.Contains(produtoAtual.Codigo))
                    OpCodeO.ProdutosJaVendidos.Add(produtoAtual.Codigo);

                #endregion

                #region OpCodeP

                if (!OpCodeP.ClienteQueJaCompraram.Contains(CPF))
                    OpCodeP.ClienteQueJaCompraram.Add(CPF);

                #endregion

                #region OpCodeQ

                if (!OpCodeQ.CategoriasQueJaForamVendidas.Contains(categoria.Codigo))
                    OpCodeQ.CategoriasQueJaForamVendidas.Add(categoria.Codigo);

                #endregion

                // Caso a venda já tiver sido realizada, adiciona produto na lista da venda
                if (Vendas.ContainsKey(Convert.ToInt32(conteudo[0])))
                {
                    int numeroDaVenda = Convert.ToInt32(conteudo[0]);

                    Vendas[numeroDaVenda].Produtos.Add(produtoAtual);

                    OpCodeN.VerificaSeVendaEMaior(Vendas[numeroDaVenda]);

                    continue;
                }

                Venda venda = new Venda();

                venda.Codigo = Convert.ToInt32(conteudo[0]);
                venda.Cliente = Clientes[CPF];

                venda.Produtos = new List<Produto>();
                venda.Produtos.Add(produtoAtual);
                venda.DataDaVenda = DateTime.ParseExact(conteudo[3], "yyyyMMddHHmmss",
                                                           CultureInfo.InvariantCulture);

                #region OpCodeD

                OpCodeD.QuantidadeVendasIndividuais++;

                #endregion

                #region OpCodeG

                string nomeDoCliente = Clientes[conteudo[1]].CPF;

                if (OpCodeG.ComprasPorCliente.ContainsKey(nomeDoCliente))
                    OpCodeG.ComprasPorCliente[nomeDoCliente]++;
                else
                    OpCodeG.ComprasPorCliente.Add(nomeDoCliente, 1);

                #endregion

                Vendas.Add(venda.Codigo, venda);

                OpCodeN.VerificaSeVendaEMaior(Vendas[venda.Codigo]);
            }
        }
    }
}
