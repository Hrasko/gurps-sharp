using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class ArmaMelee : Arma
    {
        public ArmaMelee(string nome_, float peso_, int tamanho_, HabilidadeInfo habilidade_, int alcance_, Personagem dono)
            :base(nome_,peso_, tamanho_, habilidade_, alcance_, dono)
        {

        }
    }
}
