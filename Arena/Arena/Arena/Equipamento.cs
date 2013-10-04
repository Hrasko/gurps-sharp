using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    public class Equipamento : Personagem
    {
        public float peso;
        public int tamanho;
        public HabilidadeInfo habilidadeUsar;

        public Equipamento(string nome_,float peso_, int tamanho_, HabilidadeInfo habilidade)
            :base(nome_)
        {
            for (int i = 0; i < Mestre.Atributos.Length; i++)
            {
                if (Mestre.Atributos[i].exclusivoPersonagem)
                {
                    atributos[i].gasteXP(Mestre.Atributos[i].valorInicial * Mestre.Atributos[i].custoNivel * -1);
                }
            }
            peso = peso_;
            tamanho = tamanho_;
            habilidadeUsar = habilidade;
        }

        public float Eficiencia
        {
            get
            {
                return (float)atributos[Atributo.PV].valorAtual / Mestre.Atributos[Atributo.PV].ValorAtributo(Atributo.PV,this);
            }
        }



    }
}
