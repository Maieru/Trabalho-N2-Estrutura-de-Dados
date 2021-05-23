using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    class OpCodeI
    {
        // Chave = Categoria
        // Valor = Valor Total de Vendas
        public static Dictionary<Categoria, int> DicionarioDeVendasDeCategoria = new Dictionary<Categoria, int>();

        private static string ConsegueNomeDosCliente()
        {
            HashSet<Categoria> aux = DicionarioDeVendasDeCategoria.Keys.OrderBy(x => x.Descricao).ToHashSet<Categoria>();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Categoria categoria in aux)
            {
                int totalEmVendas = DicionarioDeVendasDeCategoria[categoria];

                stringBuilder.Append("I - " + categoria.Descricao + "|" + categoria.Codigo +
                                     "|" + totalEmVendas + Environment.NewLine);
            }

            DicionarioDeVendasDeCategoria = null;

            return stringBuilder.ToString();
        }

        public static string Executar() => ConsegueNomeDosCliente();
    }
}
