using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    class DanoSwing : DanoDependente
    {
        public DanoSwing(int modificador_, Personagem atacante_)
            : base(modificador_, Dano.SWING, atacante_)
        {

        }

        public override int rolarDano()
        {
            int[] dano = Mestre.getDanoBaseSwing(this.atacante);
            return Dados.rolarXdYZ(dano[0],6,dano[1] + modificador);
        }

    }
}
