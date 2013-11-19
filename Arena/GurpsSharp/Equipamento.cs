using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    public class Equipamento : Personagem
    {
        public float peso;
        public int tamanho;
        public HabilidadeInfo habilidadeUsar;
        protected ResultadoUsoEquip resultadoUso;
        public bool preparado;
        public Personagem equipadoPor;

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
            resultadoUso = new ResultadoUsoEquip(this);
            preparado = false;
        }

        public float Eficiencia
        {
            get
            {
                return (float)atributos[Atributo.PV].valorAtual / Mestre.Atributos[Atributo.PV].ValorAtributo(Atributo.PV,this);
            }
        }

        public virtual ResultadoUsoEquip Usar(Personagem usuario)
        {
            resultadoUso.rolagem = Dados.rolarXdYZ(3, 6, 0);
            resultadoUso.numeroAlvo = habilidadeUsar.numeroAlvoBase(usuario);
            return resultadoUso;
        }

    }
}
