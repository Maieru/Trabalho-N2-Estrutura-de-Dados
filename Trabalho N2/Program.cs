using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_N2.Operacoes;

namespace Trabalho_N2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dados.LerCategorias();
            Dados.LerProdutos();
            Dados.LerClientes();
            Dados.LerVendas();

            Console.WriteLine(OpCodeA.Executar());
            Console.WriteLine(OpCodeB.Executar());
            Console.WriteLine(OpCodeC.Executar());
            Console.WriteLine(OpCodeD.Executar());
            Console.WriteLine(OpCodeE.Executar());
            Console.WriteLine(OpCodeF.Executar());
            OpCodeG.Executar();
            Console.WriteLine(OpCodeH.Executar());
            Console.WriteLine(OpCodeI.Executar());

            Console.ReadKey();
        }
    }
}
