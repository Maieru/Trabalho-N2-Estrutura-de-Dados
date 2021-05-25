using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    class OpCodeQ
    {
        // Chave = Codigo da categoria
        public static HashSet<UInt16> CategoriasQueJaForamVendidas { get; set; } = new HashSet<UInt16>();
        static ushort QuantidadeDeCategoriasNuncaVendidas { get; set; } = 0;

        static private string ProcuraPorCategoriasQueNaoForamVendidas()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (UInt16 codigo in Dados.Categorias.Keys)
            {
                if (!CategoriasQueJaForamVendidas.Contains(codigo))
                    QuantidadeDeCategoriasNuncaVendidas++;
            }

            CategoriasQueJaForamVendidas = null;
            GC.Collect();

            stringBuilder.Append("Q - " + QuantidadeDeCategoriasNuncaVendidas);

            return stringBuilder.ToString();
        }
        public static string Executar() => ProcuraPorCategoriasQueNaoForamVendidas();
    }
}
