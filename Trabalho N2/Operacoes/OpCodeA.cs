using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeA
    {
        // Considera-se apenas categorias válidas ou seja, aquelas cujo código
        // não está repetido
        public static int NumeroDeCategoriasTotal { get; set; }

        public static string Executar() => "A - " + NumeroDeCategoriasTotal + Environment.NewLine;
    }
}
