using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class AtributoHabilidade : Atributo
    {
        public AtributoHabilidade(int id_, Personagem p)
            :base(id_,p)
        {

        }

        public override float Valor
        {
            get
            {
                if (xp > 10)
                {
                    return xp / 20 + 10;
                }
                return base.Valor;
            }
        }
    }
}
