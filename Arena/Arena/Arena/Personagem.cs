using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Personagem
    {
        Mestre mestre;

        string nome;
        Atributo[] atributos;
        public int xp;
        Dictionary<int, int> habilidades;

        public Personagem(string nome_,Mestre mestre_)
        {
            nome = nome_;
            mestre = mestre_;
            atributos = new Atributo[4];
            atributos[Atributo.ST] = new Atributo(Atributo.ST);
            atributos[Atributo.DX] = new AtributoHabilidade(Atributo.DX);
            atributos[Atributo.IQ] = new AtributoHabilidade(Atributo.IQ);
            atributos[Atributo.HT] = new Atributo(Atributo.HT);
            habilidades = new Dictionary<int, int>();
        }

        public float pegarValorAtributo(int indice)
        {
            return atributos[indice].Valor;
        }


        public int pontosNaHabilidade(int indice)
        {
            return habilidades[indice];
        }

        public void gastePontosAtributo(int indice, int pontos)
        {
            if (pontos <= xp)
            {
                xp -= pontos;
                atributos[indice].gastePontos(pontos);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("-------------------------");
            sb.AppendLine();
            sb.AppendLine("Nome: " + nome);
            sb.AppendLine("XP: " + xp);
            for (int i = 0; i < atributos.Length; i++)
            {
                sb.AppendLine(atributos[i].nome + ": " + atributos[i].Valor);
            }

            foreach (var item in habilidades)
            {
                sb.AppendLine(mestre.habilidades[item.Key].nome + ": " + item.Value);
            }

            sb.AppendLine("-------------------------");
            return sb.ToString();
        }

    }
}
