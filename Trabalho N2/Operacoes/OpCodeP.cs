using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    class OpCodeP
    {
        // Chave = CPF do Cliente
        public static HashSet<string> ClienteQueJaCompraram { get; set; } = new HashSet<string>();
        static int QuantidadeDeClientesQueNaoFizeramCompras { get; set; } = 0;

        static private string ProcuraPorClientesQueNaoRealizaramCompras()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string CPF in Dados.Clientes.Keys)
            {
                if (!ClienteQueJaCompraram.Contains(CPF))
                    QuantidadeDeClientesQueNaoFizeramCompras++;
            }

            ClienteQueJaCompraram = null;
            GC.Collect();

            stringBuilder.Append("P - " + QuantidadeDeClientesQueNaoFizeramCompras + Environment.NewLine);

            return stringBuilder.ToString();
        }
        public static string Executar() => ProcuraPorClientesQueNaoRealizaramCompras();
    }
}
