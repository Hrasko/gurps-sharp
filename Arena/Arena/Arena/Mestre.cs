using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Mestre
    {
        public Dictionary<int, Habilidade> habilidades;

        public const string ESPADA = "Espada";
        public const string ESPADA2MAOS = "Espada de duas Mãos";
        public const string MACHADOS = "Machados";
        public const string LANCAS = "Lanças";


        public Mestre()
        {
            habilidades = new Dictionary<int, Habilidade>();
            habilidades.Add(0,new Habilidade(0,Habilidade.Dificuldade.Medio,Atributo.DX,ESPADA));
            habilidades.Add(1, new Habilidade(1, Habilidade.Dificuldade.Medio, Atributo.DX, ESPADA2MAOS));
            habilidades.Add(2, new Habilidade(2, Habilidade.Dificuldade.Medio, Atributo.DX, MACHADOS));
            habilidades.Add(3, new Habilidade(3, Habilidade.Dificuldade.Medio, Atributo.DX, LANCAS));
        }



    }
}
