using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
