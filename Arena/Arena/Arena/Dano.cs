using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    abstract class Dano
    {
        public const int SWING = 0;
        public const int THURT = 1;

        public int modificador;
        public int tipo;

        public Dano(int modificador_, int tipo_)
        {
            modificador = modificador_;
            tipo = tipo_;
        }

        public abstract int rolarDano();

    }
}
