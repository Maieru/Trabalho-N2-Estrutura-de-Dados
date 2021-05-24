using System.Collections.Generic;
using System.Linq;

namespace Trabalho_N2.Operacoes
{
    static class OpCodeF
    {
        private static int CalculaONumeroDeNomesDeClientesRepetidos()
        {
            HashSet<string> NomesJaInseridos = new HashSet<string>();
            int aux = 0;

            foreach(Cliente cliente in Dados.Clientes.Values)
            {
                if (!NomesJaInseridos.Contains(cliente.Nome))
                {
                    aux++;
                    NomesJaInseridos.Add(cliente.Nome);
                }
            }

            return aux;
        }
        public static string Executar() => "F - " + CalculaONumeroDeNomesDeClientesRepetidos();
    }
}
