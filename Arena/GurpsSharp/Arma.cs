using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    public abstract class Arma : Equipamento
    {
        public int alcance;
        public Dano dano;

        public Arma(string nome_,float peso_, int tamanho_, HabilidadeInfo habilidade_, int alcance_)
            : base(nome_, peso_, tamanho_, habilidade_)
        {
            alcance = alcance_;
        }
    }
}
