using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    public class ArmaMelee : Arma
    {
        public ArmaMelee(string nome_, float peso_, int tamanho_, HabilidadeInfo habilidade_, int alcance_)
            :base(nome_,peso_, tamanho_, habilidade_, alcance_)
        {

        }

        public override ResultadoUsoEquip Usar(Personagem usuario)
        {
            base.Usar(usuario);
            if (resultadoUso.sucesso)
            {
                resultadoUso.dano = dano.rolarDano();
            }
            else
            {
                resultadoUso.dano = 0;
            }
            return resultadoUso;
        }
    }
}
