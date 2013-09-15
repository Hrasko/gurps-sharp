using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    [Serializable]
    class Personagem
    {
        Mestre mestre;

        public string nome;
        public Atributo[] atributos;
        public int xp;
        Dictionary<int, int> habilidades;

        public Personagem(string nome_,Mestre mestre_)
        {
            nome = nome_;
            mestre = mestre_;
            atributos = new Atributo[Atributo.QT];
            atributos[Atributo.ST] = new Atributo(Atributo.ST,this,10);
            atributos[Atributo.DX] = new Atributo(Atributo.DX, this, 20);
            atributos[Atributo.IQ] = new Atributo(Atributo.IQ, this, 20);
            atributos[Atributo.HT] = new Atributo(Atributo.HT, this, 10);
            atributos[Atributo.PV] = new Atributo(Atributo.PV, this, 2);
            atributos[Atributo.Fadiga] = new Atributo(Atributo.Fadiga, this, 3);
            atributos[Atributo.Velocidade] = new Atributo(Atributo.Velocidade, this, 5);
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
                atributos[indice].gasteXP(pontos);
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
                sb.AppendLine(atributos[i].nome + ": " + atributos[i].Valor);
            }

            foreach (var item in habilidades)
            {
                sb.AppendLine(mestre.habilidades[item.Key].nome + ": NH " + mestre.habilidades[item.Key].numeroAlvoBase(this));
            }

            sb.AppendLine("-------------------------");
            return sb.ToString();
        }

    }
}
