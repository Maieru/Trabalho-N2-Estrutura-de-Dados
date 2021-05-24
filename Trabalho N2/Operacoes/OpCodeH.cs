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
        public static Dictionary<Produto, int> VendasDeCadaProduto { get; set; } = new Dictionary<Produto, int>();

        private static string ArmazenaValoresEmString()
        {
            HashSet<Produto> aux = VendasDeCadaProduto.Keys.OrderBy(x => x.Descricao).ToHashSet<Produto>();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Produto produto in aux)
            {
                int numeroVendido = VendasDeCadaProduto[produto];

                stringBuilder.Append("H - " + produto.Descricao + "|" + produto.Codigo + "|" + numeroVendido +
                                     "| R$" + (numeroVendido * produto.Preco) + Environment.NewLine);
            }

            VendasDeCadaProduto = null;

            GC.Collect();

            return stringBuilder.ToString();
        }
        public static string Executar() => ArmazenaValoresEmString();
    }
}
