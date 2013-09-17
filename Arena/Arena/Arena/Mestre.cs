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

        public static void Load()
        {
            
            System.IO.Stream sw = System.IO.File.OpenRead("mestre.xml");
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Mestre));
            //BinaryFormatter deserializer = new BinaryFormatter();
            instancia =  deserializer.Deserialize(sw) as Mestre;
            sw.Close();
        }

        public void Save()
        {
            instancia.atributos = new AtributoInfo[AtributoInfo.QT];
            instancia.atributos[0] = new AtributoInfo(0, "ST", 10,10);
            instancia.atributos[1] = new AtributoInfo(1, "DX", 20, 10);
            instancia.atributos[2] = new AtributoInfo(2, "IQ", 20, 10);
            instancia.atributos[3] = new AtributoInfo(3, "HT", 10, 10);
            instancia.atributos[4] = new AtributoInfo(4, "PV", 2, 10);
            instancia.atributos[5] = new AtributoInfo(5, "Fadiga", 10, 10);
            instancia.atributos[6] = new AtributoInfo(6, "Velocidade", 10, 5);
            
            instancia.habilidades = new HabilidadeInfo[4];
            instancia.habilidades[0] = new HabilidadeInfo(0, HabilidadeInfo.Dificuldade.Medio, 1, "Espada");
            instancia.habilidades[1] = new HabilidadeInfo(1, HabilidadeInfo.Dificuldade.Medio, 1, "Espada de duas maos");
            instancia.habilidades[2] = new HabilidadeInfo(2, HabilidadeInfo.Dificuldade.Medio, 1, "Machados");
            instancia.habilidades[3] = new HabilidadeInfo(3, HabilidadeInfo.Dificuldade.Medio, 1, "Lancas");

            System.IO.Stream sw = System.IO.File.Create("mestre.xml");
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Mestre));
            //BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(sw, this);
        }

        public static int ValorAtributo(int indice,Personagem p)
        {
            if (p.atributos[indice].xp > 0)
            {
                return p.atributos[indice].xp / instancia.atributos[indice].custoNivel + instancia.atributos[indice].valorInicial;
            }
            return instancia.atributos[indice].valorInicial;
        }

    }
}
