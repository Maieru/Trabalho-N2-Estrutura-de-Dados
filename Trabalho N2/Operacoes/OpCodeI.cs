using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeI
    {
        // Chave = Categoria
        // Valor = Valor Total de Vendas
        public static Dictionary<Categoria, double> VendasPorCategoria { get; set; } = new Dictionary<Categoria, double>();

        private static string ConsegueNomeDosCliente()
        {
            HashSet<Categoria> aux = VendasPorCategoria.Keys.OrderBy(x => x.Descricao).ToHashSet<Categoria>();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Categoria categoria in aux)
            {
                double totalEmVendas = VendasPorCategoria[categoria];

                stringBuilder.Append("I - " + categoria.Descricao + "|" + categoria.Codigo +
                                     "|R$" + totalEmVendas + Environment.NewLine);
            }

            VendasPorCategoria = null;

            GC.Collect();

            return stringBuilder.ToString();
        }
        public static string Executar() => ConsegueNomeDosCliente();
    }
}
