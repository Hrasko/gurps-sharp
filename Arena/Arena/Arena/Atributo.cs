using System;
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
        public const int Carga = 7;
        
        

        int id;
        float valor;

        public float Valor
        {
            get
            {
                return valor;
            }
        }

        public Atributo(int id_)
        {
            id = id_;
            switch (id)
            {
                case ST:
                case DX:
                case IQ:
                case HT:
                case Fadiga:
                case Velocidade:
                    valor = 10; break;

                default: valor = 0; break;
            }
        }

        

    }
}
