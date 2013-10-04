using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    [Serializable]
    public class Mestre
    {
        public HabilidadeInfo[] habilidades;
        public AtributoInfo[] atributos;

        private static Mestre instancia;

        public static HabilidadeInfo[] Habilidades
        {
            get
            {
                return instancia.habilidades;
            }
        }

        public static AtributoInfo[] Atributos
        {
            get
            {
                return instancia.atributos;
            }
        }

        public int indiceAtributo(string nome)
        {
            for (int i = 0; i < Atributos.Length; i++)
            {
                if (Atributos[i].nome == nome)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void Load(string fileLocation)
        {
            
            System.IO.Stream sw = System.IO.File.OpenRead(fileLocation);
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Mestre));
            //BinaryFormatter deserializer = new BinaryFormatter();
            instancia =  deserializer.Deserialize(sw) as Mestre;
            sw.Close();
            Atributo.PV = instancia.indiceAtributo("PV");
        }

        public void Save()
        {
            instancia.atributos = new AtributoInfo[AtributoInfo.QT];
            int i = 0;
            instancia.atributos[i] = new AtributoInfo(i, "ST", 10, 10, 1); i++;
            instancia.atributos[i] = new AtributoInfo(i, "DX", 20, 10, 1); i++;
            instancia.atributos[i] = new AtributoInfo(i, "IQ", 20, 10, 1); i++;
            instancia.atributos[i] = new AtributoInfo(i, "HT", 10, 10, 0); i++;
            instancia.atributos[i] = new AtributoInfo(i, "PV", 2, 10, 0); i++;
            instancia.atributos[i] = new AtributoInfo(i, "Fadiga", 10, 10, 1); i++;
            instancia.atributos[i] = new AtributoInfo(i, "Velocidade", 10, 5, 1); i++;

            instancia.atributos[i] = new AtributoInfo(i, "RD", 0, 1, 2); i++;

            i = 0;
            instancia.habilidades = new HabilidadeInfo[4];
            instancia.habilidades[i] = new HabilidadeInfo(i, HabilidadeInfo.Dificuldade.Medio, 1, "Espada"); i++;
            instancia.habilidades[i] = new HabilidadeInfo(i, HabilidadeInfo.Dificuldade.Medio, 1, "Espada de duas maos"); i++;
            instancia.habilidades[i] = new HabilidadeInfo(i, HabilidadeInfo.Dificuldade.Medio, 1, "Machados"); i++;
            instancia.habilidades[i] = new HabilidadeInfo(i, HabilidadeInfo.Dificuldade.Medio, 1, "Lancas"); i++;

            System.IO.Stream sw = System.IO.File.Create("mestre.xml");
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Mestre));
            //BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(sw, this);
        }

        public static int ValorAtributo(int indice,Personagem p)
        {
            if (p.atributos[indice].xp != 0)
            {
                return p.atributos[indice].xp / instancia.atributos[indice].custoNivel + instancia.atributos[indice].valorInicial;
            }
            return instancia.atributos[indice].valorInicial;
        }

        public static int[] getDanoBaseSwing(Personagem p)
        {
            int forca = ValorAtributo(0, p);
            if (forca > 8)
            {
                int[] x = { ((forca - 1) / 4) - 1, ((forca + 3) % 4) - 1 };
                return x;
            }
            else
            {
                int[] y = {1, forca/2 - 6};
                return y;
            }            
        }

        public static int[] getDanoBaseThrust(Personagem p)
        {
            int forca = ValorAtributo(0, p);
            if (forca > 10)
            {
                int[] x = { (forca - 3) / 8, (((forca + 5) / 2) % 4) - 1 };
                return x;
            }
            else
            {
                int[] y = { 1, (forca / 2) - 7 };
                return y;
            }
        }

    }
}
