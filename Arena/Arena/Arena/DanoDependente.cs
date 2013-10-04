using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    abstract class DanoDependente : Dano
    {
        Personagem atacante;

        public DanoDependente(int modificador_, int tipo_, Personagem atacante_)
            :base(modificador_, tipo_)
        {
            atacante = atacante_;
        }

        public override int rolarDano()
        {
            return 0;
        }

        protected abstract int[] pegarValoresDano();
    }
}
