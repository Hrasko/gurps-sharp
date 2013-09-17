using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    [Serializable]
    public class Personagem
    {
        Mestre mestre;

        public string nome;
        public Atributo[] atributos;
        public int xp;
        public SerializableDictionary<int, int> habilidades;

        public Personagem()
        {

        }

        public Personagem(string nome_)
        {
            nome = nome_;

            atributos = new Atributo[Mestre.Atributos.Length];
            for (int i = 0; i < atributos.Length; i++)
            {
                atributos[i] = new Atributo();

            }
        }

        
        public float pegarValorAtributo(int indice)
        {
            return atributos[indice];
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
                //atributos[indice].gasteXP(pontos);
            }
        }

        public void gastePontosHabilidade(int indice, int pontos)
        {
            if (pontos <= xp)
            {
                xp -= pontos;
                int pontosHabilidade;
                if (habilidades.TryGetValue(indice, out pontosHabilidade))
                {
                    habilidades[indice] = pontos + pontosHabilidade;
                }
                else
                {
                    habilidades.Add(indice, pontos);
                }
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
                // sb.AppendLine(atributos[i].nome + ": " + atributos[i].Valor);
            }

            foreach (var item in habilidades)
            {
                //sb.AppendLine(mestre.habilidades[item.Key].nome + ": NH " + mestre.habilidades[item.Key].numeroAlvoBase(this));
            }

            sb.AppendLine("-------------------------");
            return sb.ToString();
        }

    }
}
