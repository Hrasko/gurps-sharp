using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    public class Arma : Equipamento
    {
        public int alcance;
        public Personagem atacante;
        public bool preparada;        

        public Arma(string nome_,float peso_, int tamanho_, HabilidadeInfo habilidade_, int alcance_, Personagem dono)
            : base(nome_, peso_, tamanho_, habilidade_)
        {
            alcance = alcance_;
            atacante = dono;
            preparada = false;
        }
    }
}
