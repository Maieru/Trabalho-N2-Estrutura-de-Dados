using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2
{
    class Vendas
    {
        private Cliente cliente;
        private Produto produto;

        public int Codigo { get; set; }
        public Cliente Cliente
        {
            get => cliente;
            set
            {
                if (value == null)
                    throw new Exception("Cliente não preenchido");
                cliente = value;
            }
        }
        public Produto Produto
        {
            get => produto;
            set
            {
                if (value == null)
                    throw new Exception("Produto não preenchido");
                produto = value;
            }
        }
        public DateTime DataDaVenda { get; set; }
    }
}
