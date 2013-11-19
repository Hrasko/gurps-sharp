using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    class DanoThurst : DanoDependente
    {
        public DanoThurst(int modificador_, Personagem atacante_)
            : base(modificador_, Dano.THURST, atacante_)
        {

        }

        public override int rolarDano()
        {
            int[] dano = Mestre.getDanoBaseThrust(this.atacante);
            return Dados.rolarXdYZ(dano[0],6,dano[1] + modificador);
        }
    }
}
