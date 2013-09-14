using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Fadiga : Atributo
    {
        int valorAtual;

        public Fadiga(int id_, Personagem p)
            :base(id_, p)
        {
            valorAtual = (int)Valor;
        }

        public override float Valor
        {
            get
            {
                if (xp > 0)
                {
                    return this.meuPersonagem.pegarValorAtributo(Atributo.HT) + xp/3;
                }
                return this.meuPersonagem.pegarValorAtributo(Atributo.HT);
            }
        }

        public override int ValorAtual
        {
            get
            {
                return valorAtual;
            }
        }
    }
}
