using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    class LocalSet
    {
        public string tipo;
        public Dictionary<string,Local> locais;

        public LocalSet(string tipo_)
        {
            tipo = tipo_;
            locais = new Dictionary<string, Local>();
        }

        public void adicionaLocal(string nome_, params string[] dependencias)
        {
            Local local = new Local(nome_);
            local.dependentes = dependencias;
            locais.Add(nome_, local);
        }

        public void adicionaLocal(string nome_, bool manipulador_, bool andador_, params string[] dependencias)
        {
            Local local = new Local(nome_,manipulador_,andador_);
            local.dependentes = dependencias;
            locais.Add(nome_, local);
        }

    }
}
