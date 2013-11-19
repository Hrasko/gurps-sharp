using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    abstract class DanoDependente : Dano
    {
        protected Personagem atacante;

        public DanoDependente(int modificador_, int tipo_, Personagem atacante_)
            :base(modificador_, tipo_)
        {
            atacante = atacante_;
        }
    }
}
