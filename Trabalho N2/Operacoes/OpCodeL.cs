using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    class OpCodeL
    {
        // Chave = Codigo do Produto
        // Valor = Numero de vezes vendido
        public static Dictionary<int, ushort> ProdutoEQuantidadeVendida { get; set; } = new Dictionary<int, ushort>();

        private static string Resultado()
        {
            StringBuilder stringBuilder = new StringBuilder();

            double maiorQuantidadeDeVendas = 0;
            List<int> produtosMaisVendidos = new List<int>();

            foreach (int codigo in ProdutoEQuantidadeVendida.Keys)
            {
                if (ProdutoEQuantidadeVendida[codigo] > maiorQuantidadeDeVendas)
                {
                    produtosMaisVendidos = new List<int>();
                    produtosMaisVendidos.Add(codigo);
                    maiorQuantidadeDeVendas = ProdutoEQuantidadeVendida[codigo];
                }
                else if (ProdutoEQuantidadeVendida[codigo] == maiorQuantidadeDeVendas)
                    produtosMaisVendidos.Add(codigo);
            }

            foreach (int codigo in produtosMaisVendidos)
            {
                string descricao = Dados.Produtos[codigo].Descricao;

                stringBuilder.Append("L - " + descricao + "|" + ProdutoEQuantidadeVendida[codigo] + Environment.NewLine);
            }

            ProdutoEQuantidadeVendida = null;

            GC.Collect();

            return stringBuilder.ToString();
        }
        public static string Executar() => Resultado();
    }
}
