using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeM
    {
        private static string ProcuraMesComMaiorVenda()
        {
            StringBuilder stringBuilder = new StringBuilder();

            double maiorValorDeVendas = 0;
            List<string> mesesComMaiorVenda = new List<string>();

            foreach (string mesAno in OpCodeJ.VendasPorMesEAno.Keys)
            {
                double aux = Convert.ToDouble(OpCodeJ.VendasPorMesEAno[mesAno]);
                if (aux > maiorValorDeVendas)
                {
                    mesesComMaiorVenda = new List<string>();
                    mesesComMaiorVenda.Add(mesAno);
                    maiorValorDeVendas = OpCodeJ.VendasPorMesEAno[mesAno];
                }
                else if (aux == maiorValorDeVendas)
                    mesesComMaiorVenda.Add(mesAno);
            }

            foreach (string mesAno in mesesComMaiorVenda)
            {
                string data = mesAno.Substring(4,2) + "/" + mesAno.Substring(0,4);

                stringBuilder.Append("M - " + data + "|" + maiorValorDeVendas + Environment.NewLine);
            }

            OpCodeJ.VendasPorMesEAno = null;

            GC.Collect();

            return stringBuilder.ToString();
        }
        public static string Executar() => ProcuraMesComMaiorVenda();
    }
}
