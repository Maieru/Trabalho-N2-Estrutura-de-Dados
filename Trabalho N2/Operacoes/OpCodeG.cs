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
        public static Dictionary<string, int> DicionarioDeCompraEVendas = new Dictionary<string, int>();

        private static string ConsegueNomeDosCliente()
        {
            HashSet<string> aux = DicionarioDeCompraEVendas.Keys.OrderBy(x => x).ToHashSet<string>();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (string CPF in aux)
            {
                string nome = Dados.Clientes[CPF].Nome;
                int compras = DicionarioDeCompraEVendas[CPF];
                stringBuilder.Append(CPF + "|" + nome + "|" + compras +
                                     Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public static string Executar() => "G - " + ConsegueNomeDosCliente();
    }
}
