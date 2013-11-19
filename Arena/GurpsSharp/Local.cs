using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    public class Local
    {
        public string nome;

        public string[] dependentes;

        public bool manipulador;
        public bool andador;
        public float fatalidade;

        public Local(string nome_)
        {
            nome = nome_;
            manipulador = false;
            andador = false;
            fatalidade = 0;
        }

        public Local(string nome_, bool manipulador_, bool andador_)
        {
            nome = nome_;
            manipulador = manipulador_;
            andador = andador_;
        }

    }
}
