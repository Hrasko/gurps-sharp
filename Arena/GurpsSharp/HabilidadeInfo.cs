using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    [Serializable]
    public class HabilidadeInfo
    {
        public enum Dificuldade
        {
            Facil,
            Medio,
            Dificil,
            MuitoDificil
        }

        public int id;
        public Dificuldade dificuldade;
        public int atributoBase;
        public string nome;

        public HabilidadeInfo()
        {

        }

        public HabilidadeInfo(int id_,Dificuldade dificuldade_,int atributo_,string nome_)
        {
            id = id_;
            dificuldade = dificuldade_;
            atributoBase = atributo_;
            nome = nome_;
        }
        
        public int numeroAlvoBase(Personagem personagem)
        {
            int numeroAlvo = personagem.pegarValorAtributo(atributoBase);
            int pontosNaHabilidade = personagem.pontosNaHabilidade(id);
            int bonusPontos = 0;
            if (pontosNaHabilidade == 0)
            {
                bonusPontos = bonusDefault(personagem);
            }
            else
            {
                if (pontosNaHabilidade < 2)
                {
                    bonusPontos = 0;
                }
                else if (pontosNaHabilidade < 4)
                {
                    bonusPontos = 1;
                }
                else
                {
                    bonusPontos = 1 + pontosNaHabilidade /4;
                }
                
                switch (dificuldade)
                {
                    case Dificuldade.Medio: numeroAlvo -= 1; break;
                    case Dificuldade.Dificil: numeroAlvo -= 2; break;
                    case Dificuldade.MuitoDificil: numeroAlvo -= 3; break;
                }
            }
            return numeroAlvo + bonusPontos;
        }

        protected int bonusDefault(Personagem personagem)
        {
            switch (dificuldade)
            {
                case Dificuldade.Facil: return -4;
                case Dificuldade.Medio: return -5;
                case Dificuldade.Dificil: return -6;
                default: return int.MinValue;
            }
        }
    }
}
