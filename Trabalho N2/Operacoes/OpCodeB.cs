using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeB
    {
        public static int NumeroDeProdutosTotal { get; set; }

        public static string Executar() => "B - " + NumeroDeProdutosTotal + Environment.NewLine;
    }
}
