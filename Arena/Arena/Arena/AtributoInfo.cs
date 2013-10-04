using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    [Serializable]
    public class AtributoInfo
    {
        public const int QT = 7;

        public string nome;
        public int id;
        public int valorInicial;

        public int custoNivel;

        public bool exclusivoPersonagem;
        public bool exclusivoEquipamento;

        public AtributoInfo()
        {

        }

        public AtributoInfo(int id_, string nome_, int custoNivel_, int valorInicial_, int tipoExclusividade)
        {
            id = id_;
            custoNivel = custoNivel_;
            valorInicial = valorInicial_;
            nome = nome_;
            switch (tipoExclusividade)
            {
                case 1:exclusivoPersonagem = true; exclusivoEquipamento = false; break;
                case 2: exclusivoPersonagem = false; exclusivoEquipamento = true; break;
                default: exclusivoPersonagem = false; exclusivoEquipamento = false; break;
            }
            
        }
        
        public virtual int ValorAtributo(int indice, Personagem p)
        {
            if (p.atributos[indice].xp > 0)
            {
                return p.atributos[indice].xp / custoNivel + valorInicial;
            }
            return valorInicial;
        }

    }
}
