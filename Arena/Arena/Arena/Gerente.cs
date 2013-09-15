using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        public void listarTodosPersonagens()
        {
            String[] lista = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.personagem");
            foreach (var item in lista)
            {
                this.escrever(item);
            }
        }

        public Personagem carregar(string nome)
        {
            Stream TestFileStream = File.OpenRead(nome + ".personagem");
            BinaryFormatter deserializer = new BinaryFormatter();
            return deserializer.Deserialize(TestFileStream) as Personagem;
        }

        public void salvar(Personagem p)
        {
            Stream sw = File.Create(p.nome + ".personagem");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(sw, p);
            sw.Close();
            this.escrever("salvo!");
            System.Threading.Thread.Sleep(1000);
        }

    }
}
