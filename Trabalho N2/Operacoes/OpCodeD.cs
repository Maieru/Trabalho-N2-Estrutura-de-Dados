using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeD
    {
        public static int QuantidadeVendasIndividuais { get; set; }

        public static string Executar() => "D - " + QuantidadeVendasIndividuais + Environment.NewLine;
    }
}
