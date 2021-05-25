using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeE
    {
        // Poderia usar um HashSet. Entretanto, o mesmo possui O(1) em pesquisa
        // e O(n) em adição de valores. Foi optado pelo uso de uma array já
        // que tanto alteração tanto consulta são O(1) e, além disso, utiliza
        // muito menos memória que um hashset ( mesmo tendo um tamanho pré-definido
        // maior que o número de produtos possiveis )

        private static bool[] ProdutosJaVendidos { get; set; } = new bool[100000];
        public static int QuantidadeDeProdutosDistintosVendidos { get; set; }

        public static void VerificaSeProdutoJaFoiVendido(ushort chave)
        {
            if (!ProdutosJaVendidos[chave])
            {
                QuantidadeDeProdutosDistintosVendidos++;
                ProdutosJaVendidos[chave] = true;
            }
        }

        public static string Executar()
        {
            ProdutosJaVendidos = null;
            return "E - " + QuantidadeDeProdutosDistintosVendidos + Environment.NewLine;
        }

    }
}
