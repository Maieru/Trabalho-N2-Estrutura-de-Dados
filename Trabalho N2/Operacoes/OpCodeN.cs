using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeN
    {
        // Chave = Codigo da Venda
        static HashSet<int> MaioresVendas { get; set; } = new HashSet<int>();
        static double ValorDaMaiorVenda { get; set; } = 0;

        static public void VerificaSeVendaEMaior(Venda venda)
        {
            double valorDaVendaAtual = 0;

            foreach (Produto produto in venda.Produtos)
                valorDaVendaAtual += produto.Preco;

            if (valorDaVendaAtual > ValorDaMaiorVenda)
            {
                // Se a venda estava empatada em valor, apos ela adicionar
                // um produto, com certeza será maior que as outras vendas
                MaioresVendas.Clear();
                MaioresVendas.Add(venda.Codigo);

                ValorDaMaiorVenda = valorDaVendaAtual;

                return;
            }

            if (valorDaVendaAtual == ValorDaMaiorVenda)
            {
                MaioresVendas.Add(venda.Codigo);
                return;
            }
        }
        static private string EscreveMaioresVendas()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (int venda in MaioresVendas)
            {
                string cpfCliente = Dados.Vendas[venda].Cliente.CPF;
                stringBuilder.Append("N - " + venda + "|" + cpfCliente + "|R$" + ValorDaMaiorVenda + Environment.NewLine);
            }

            MaioresVendas = null;
            GC.Collect();

            return stringBuilder.ToString();
        }
        public static string Executar() => EscreveMaioresVendas();
    }
}
