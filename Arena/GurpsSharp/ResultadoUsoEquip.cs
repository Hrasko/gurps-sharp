using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    class ResultadoUsoEquip
    {
        public int rolagem = 0;
        public int numeroAlvo = 0;
        public int dano = 0;
        public Equipamento equipamento;

        public bool sucesso
        {
            get
            {
                return numeroAlvo >= rolagem;
            }
        }

        public ResultadoUsoEquip(Equipamento equipamento_)
        {
            equipamento = equipamento_;
        }
    }
}
