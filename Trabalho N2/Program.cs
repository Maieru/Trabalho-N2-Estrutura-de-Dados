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
            StringBuilder resultado = new StringBuilder();

            DateTime horarioInicio = DateTime.Now;

            resultado.Append(horarioInicio.ToString("hh:mm:ss") + Environment.NewLine);

            Dados.LerCategorias();
            Dados.LerProdutos();
            Dados.LerClientes();
            Dados.LerVendas();

            resultado.Append(OpCodeA.Executar());
            resultado.Append(OpCodeB.Executar());
            resultado.Append(OpCodeC.Executar());
            resultado.Append(OpCodeD.Executar());
            resultado.Append(OpCodeE.Executar());
            resultado.Append(OpCodeF.Executar());
            resultado.Append(OpCodeG.Executar());
            resultado.Append(OpCodeH.Executar());
            resultado.Append(OpCodeI.Executar());
            resultado.Append(OpCodeJ.Executar());
            resultado.Append(OpCodeK.Executar());
            resultado.Append(OpCodeL.Executar());
            resultado.Append(OpCodeM.Executar());
            resultado.Append(OpCodeN.Executar());
            resultado.Append(OpCodeO.Executar());
            resultado.Append(OpCodeP.Executar());
            resultado.Append(OpCodeQ.Executar());

            if (File.Exists("resultado.txt"))
                File.Delete("resultado.txt");

            using (StreamWriter sw = new StreamWriter("resultado.txt", true, Encoding.UTF8, 65536))
            {
                sw.WriteLine(resultado.ToString());
            }

            DateTime horarioTermino = DateTime.Now;
            File.AppendAllText("resultado.txt",
                               horarioTermino.ToString("hh:mm:ss"));

            TimeSpan tempoDeProcessamento = horarioTermino.Subtract(horarioInicio);


            File.AppendAllText("resultado.txt",
                               Environment.NewLine + 
                               tempoDeProcessamento);

            Console.WriteLine("Concluido");

            Console.ReadKey();
        }
    }
}
