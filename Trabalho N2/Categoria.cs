using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2
{
    class Categoria
    {
        private UInt16 codigo;
        private string descricao;

        public UInt16 Codigo
        {
            get => codigo;
            set
            {
                if (value < 0)
                    throw new Exception("Codigo de categoria inválido.");
                codigo = value;
            }
        }
        public string Descricao
        {
            get => descricao;
            set
            {
                if (value.Trim().Length <= 0)
                    throw new Exception("Descricao da categoria não preenchida.");
                descricao = value;
            }
        }
    }
}
