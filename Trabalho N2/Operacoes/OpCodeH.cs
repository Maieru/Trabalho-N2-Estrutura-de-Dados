using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    class OpCodeH
    {
        // Chave = Nome do Produto
        // Valor = Qtd de Produto Vendidos
        public static Dictionary<Produto, int> DicionarioDeVendasDeProduto = new Dictionary<Produto, int>();

        private static string ArmazenaValoresEmString()
        {
            HashSet<Produto> aux = DicionarioDeVendasDeProduto.Keys.OrderBy(x => x.Descricao).ToHashSet<Produto>();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Produto produto in aux)
            {
                int numeroVendido = DicionarioDeVendasDeProduto[produto];

                stringBuilder.Append("H - " + produto.Descricao + "|" + produto.Codigo + "|" + numeroVendido +
                                     "|" + (numeroVendido * produto.Preco) + Environment.NewLine);
            }

            DicionarioDeVendasDeProduto = null;

            return stringBuilder.ToString();
        }

        public static string Executar() => ArmazenaValoresEmString();
    }
}
