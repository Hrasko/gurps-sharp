using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Dados
    {
        private static Random random = new Random();

        private static Logger gerente;

        public static int rolarXdYZ(int x, int y, int z)
        {
            int total  = 0;
            int parcial = 0;
            for (int i = 0; i < x; i++)
			{
			    parcial = random.Next(y) + 1;
                gerente.log(String.Format("1d{0}: {1}",y,parcial));
                total += parcial;
			}
            total += z;
            gerente.log(String.Format("{0}d{1}+{2}: {3}",x,y,z,total));
            return total;
        }

        public static string damageRangeXdYZ(int x, int y, int z)
        {
            return String.Format("{0} - {1}", x + z, x * y + z); ;
        }

        public static float probabilidade3d6Gurps(int valor)
        {

            switch (valor)
            {
                case 16: return 98.1f;
                case 15: return 95.4f;
                case 14: return 90.7f;
                case 13: return 83.8f;
                case 12: return 74.0f;
                case 11: return 62.5f;
                case 10: return 50.0f;
                case 9: return 25.9f;
                case 8: return 16.2f;
                case 7: return 9.3f;
                case 6: return 4.6f;
                case 5: return 1.9f;
                case 4: return 98.0f;
                default:
                    if (valor >= 17)
                    {
                        return 99.0f;
                    }
                    else
                    {
                        return 0.5f;
                    }
            }
            
        }
    }
}
