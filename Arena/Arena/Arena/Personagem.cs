using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Personagem
    {
        string nome;
        Atributo[] atributos;

        public Personagem()
        {
            atributos = new Atributo[Atributo.QT];
            for (int i = 0; i < Atributo.QT; i++)
            {
                atributos[i] = new Atributo(i);
            }
        }

        public float pegarValorAtributo(int indice)
        {
            return atributos[indice].Valor;
        }


        public int pontosNaHabilidade(int indice)
        {
            // TODO: criar estrutura de dados para guardas pontos
            return 0;
        }
    }
}
