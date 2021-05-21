using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_N2
{
    class Cliente
    {
        private string cpf;
        private string nome;

        public string CPF
        {
            get => cpf;
            set
            {
                if (value.Trim().Length <= 0)
                    throw new Exception("CPF de cliente não preenchido.");
                cpf = value;
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                if (value.Trim().Length <= 0)
                    throw new Exception("Nome de cliente não preenchido.");
                nome = value;
            }
        }
    }
}
