using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeG
    {
        // Chave = CPF do Cliente
        // Valor = Qtd de Compras do Cliente
        public static Dictionary<string, int> ComprasPorCliente { get; set; } = new Dictionary<string, int>();

        private static string ConsegueNomeDosCliente()
        {
            HashSet<string> aux = ComprasPorCliente.Keys.OrderBy(x => x).ToHashSet<string>();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (string CPF in aux)
            {
                string nome = Dados.Clientes[CPF].Nome;
                int compras = ComprasPorCliente[CPF];
                stringBuilder.Append("G - " + CPF + "|" + nome + "|" + compras +
                                     Environment.NewLine);
            }

            ComprasPorCliente = null;

            GC.Collect();

            return stringBuilder.ToString();
        }
        public static string Executar() => ConsegueNomeDosCliente();
    }
}
