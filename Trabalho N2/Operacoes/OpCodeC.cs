using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    class OpCodeC
    {
        public static int QuantidadeTotalDeClientes { get; set; }

        public static string Executar() => "C - " + QuantidadeTotalDeClientes;
    }
}
