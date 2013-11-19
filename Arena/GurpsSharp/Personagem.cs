using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    [Serializable]
    public class Personagem
    {
        /// <summary>
        /// nome do doido
        /// </summary>
        public string nome;

        /// <summary>
        /// Vetor com a quantidade de pontos gastos pelo personagem em cada atributo. Ex: Se o personagem gastar 10 pontos em ST, o vetor vai ficar como [10,0,0,0,...]
        /// </summary>
        public Atributo[] atributos;
        public int xp;
        public SerializableDictionary<int, int> habilidades;
        public SerializableDictionary<string,Equipamento> inventorio;

        public Personagem()
        {

        }

        public Personagem(string nome_)
        {
            nome = nome_;
            habilidades = new SerializableDictionary<int, int>();
            atributos = new Atributo[AtributoInfo.QT];            
                for (int i = 0; i < atributos.Length; i++)
                {
                    atributos[i] = new Atributo();
                }
                inventorio = new SerializableDictionary<string, Equipamento>();
        }
        
        public int pegarValorAtributo(int indice)
        {
            return Mestre.ValorAtributo(indice,this);
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

        public void Equipar(string onde, Equipamento equipamento)
        {
            equipamento.equipadoPor = this;
            if (inventorio.ContainsKey(onde))
            {
                inventorio[onde] = equipamento;
            }
            else
            {
                inventorio.Add(onde, equipamento);
            }
        }

        public void Usar(string ondeEsta)
        {
            if (inventorio.ContainsKey(ondeEsta))
            {
                inventorio[ondeEsta].Usar(this);
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
                var atributo = Mestre.Atributos[i];
                if (!atributo.exclusivoEquipamento)
                {
                    sb.AppendLine(atributo.nome + ": " + Mestre.ValorAtributo(i,this));
                }
            }

            foreach (var item in habilidades)
            {
                var habilidade = Mestre.Habilidades[item.Key];
                sb.AppendLine(habilidade.nome + ": " + Mestre.Habilidades[item.Key].numeroAlvoBase(this));
            }

            sb.AppendLine("-------------------------");
            return sb.ToString();
        }

    }
}
