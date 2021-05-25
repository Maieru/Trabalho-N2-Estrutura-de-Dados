using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeJ
    {
        // Chave = Mes/Ano ( formato yyyyMM )
        // Valor = Valor Total de Vendas
        public static Dictionary<string, double> VendasPorMesEAno { get; set; } = new Dictionary<string, double>();

        private static string Resultado()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string mesEAno in VendasPorMesEAno.Keys)
            {
                stringBuilder.Append("J - " + mesEAno.Substring(4,2) + "/" +
                                     mesEAno.Substring(0,4) + "| R$ " + VendasPorMesEAno[mesEAno] + Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
        public static string Executar() => Resultado();
    }
}
