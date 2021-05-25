using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeO
    {
        // Chave = Codigo do Produto
        public static HashSet<ushort> ProdutosJaVendidos { get; set; } = new HashSet<ushort>();
        static ushort QuantidadeDeProdutosNaoVendidos { get; set; } = 0;

        static private string ProcuraProdutosNaoVendidos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (ushort codigo in Dados.Produtos.Keys)
            {
                if (!ProdutosJaVendidos.Contains(codigo))
                    QuantidadeDeProdutosNaoVendidos++;
            }

            ProdutosJaVendidos = null;
            GC.Collect();

            stringBuilder.Append("O - " + QuantidadeDeProdutosNaoVendidos + Environment.NewLine);

            return stringBuilder.ToString();
        }
        public static string Executar() => ProcuraProdutosNaoVendidos();
    }
}
