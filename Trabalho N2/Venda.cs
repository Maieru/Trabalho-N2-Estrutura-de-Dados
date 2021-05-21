using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2
{
    class Venda
    {
        private Cliente cliente;
        private List<Produto> produtos;

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
        public List<Produto> Produtos
        {
            get => produtos;
            set
            {
                if (value == null)
                    throw new Exception("Produto não preenchido");
                produtos = value;
            }
        }
        public DateTime DataDaVenda { get; set; }
    }
}
