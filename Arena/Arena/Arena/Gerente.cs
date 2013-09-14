using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Gerente
    {
        public void limpar()
        {
            Console.Clear();
        }

        public void escrever(string frase)
        {
            Console.WriteLine(frase);
        }

        public string requerer(string frase)
        {
            Console.WriteLine(frase);
            return Console.ReadLine();
        }

        public int requererInt(string frase)
        {
            return int.Parse(requerer(frase));
        }

        

    }
}
