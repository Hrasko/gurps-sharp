using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class DanoSwing : DanoDependente
    {
        public DanoSwing(int modificador_, int tipo_, Personagem atacante_)
            : base(modificador_, tipo_, atacante_)
        {

        }

        protected override int[] pegarValoresDano()
        {
            throw new NotImplementedException();
        }
    }
}
