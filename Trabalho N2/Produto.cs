using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2
{
    class Produto
    {
        private Categoria categoria;

        public int Codigo { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria
        {
            get => categoria;
            set
            {
                if (categoria == null)
                    throw new Exception("Categoria não foi preenchida.");
                categoria = value;
            }
        }
        public DateTime DataDaCompra { get; set; }
    }
}
