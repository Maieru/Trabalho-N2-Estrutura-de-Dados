using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeK
    {
        // Chave = CPF
        // Valor = Valor Total de Vendas
        public static Dictionary<string, double> ClientesEVendas { get; set; } = new Dictionary<string, double>();

        private static string Resultado()
        {
            StringBuilder stringBuilder = new StringBuilder();
            double maiorVenda = 0;
            List<string> clientesComMaioresVendas = new List<string>();

            foreach (string CPF in ClientesEVendas.Keys)
            {
                if(ClientesEVendas[CPF] > maiorVenda)
                {
                    clientesComMaioresVendas = new List<string>();
                    clientesComMaioresVendas.Add(CPF);
                    maiorVenda = ClientesEVendas[CPF];
                }
                else if (ClientesEVendas[CPF] == maiorVenda)
                    clientesComMaioresVendas.Add(CPF);
            }

            foreach (string CPF in clientesComMaioresVendas)
            {
                string nome = Dados.Clientes[CPF].Nome;

                stringBuilder.Append("K - " + nome + "|" + CPF + "|R$ " + ClientesEVendas[CPF] + Environment.NewLine);
            }

            ClientesEVendas = null;

            GC.Collect();

            return stringBuilder.ToString();
        }
        public static string Executar() => Resultado();
    }
}
