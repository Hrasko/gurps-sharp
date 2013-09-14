﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Atributo
    {
        public const int QT = 7;

        
        public const int ST = 0;
        public const int DX = 1;
        public const int IQ = 2;
        public const int HT = 3;
        public const int PV = 4;
        public const int Fadiga = 5;
        public const int Velocidade = 6;

        public string nome;
        public int xp;
        int id;
        float valor;

        protected Personagem meuPersonagem;

        public virtual float Valor
        {
            get
            {
                if (xp > 0)
                {
                    return xp / 10 + 10;
                }
                return valor;
            }
        }

        public virtual int ValorAtual
        {
            get
            {
                return (int)valor;
            }
        }


        public Atributo(int id_, Personagem meuPersonagem_)
        {
            meuPersonagem = meuPersonagem_;
            xp = 0;
            id = id_;
            switch (id)
            {
                case ST:            nome = "ST"; valor = 10; break;
                case DX:            nome = "DX"; valor = 10; break;
                case IQ:            nome = "IQ"; valor = 10; break;
                case HT:            nome = "HT"; valor = 10; break;
                case PV:            nome = "PV"; valor = 10; break;
                case Fadiga:        nome = "Fadiga"; valor = 10; break;
                case Velocidade:    nome = "Velocidade"; valor = 5; break;
                default:            nome = "invalido"; valor = 0; break;
            }
        }

        public void gastePontos(int pontos)
        {
            xp += pontos;
        }

    }
}
