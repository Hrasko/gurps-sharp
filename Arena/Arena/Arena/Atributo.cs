﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    public class Atributo
    {
        public int xp;
        public int valorAtual;

        public Atributo()
        {
            xp = 0;
            valorAtual = 0;
        }

        public void gasteXP(int pontos)
        {
            xp += pontos;
        }

        public void gaste(int pontos)
        {
            valorAtual -= pontos;
        }
    }
}
