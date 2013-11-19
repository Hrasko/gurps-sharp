using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GurpsSharp
{
    [Serializable]
    public class Mestre
    {
        public LocalSet[] tiposLocalizacao;
        public HabilidadeInfo[] habilidades;
        public AtributoInfo[] atributos;
        public List<Equipamento> equipamentos;

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

        /// <summary>
        /// Carrega as regras do jogo. eventualmente puxar de um banco de dados :p
        /// </summary>
        /// <param name="fileLocation"></param>
        public static void Load(string fileLocation)
        {
            
            System.IO.Stream sw = System.IO.File.OpenRead(fileLocation);
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Mestre));
            //BinaryFormatter deserializer = new BinaryFormatter();
            instancia =  deserializer.Deserialize(sw) as Mestre;
            sw.Close();
            Atributo.PV = 4;
        }

        /// <summary>
        /// Metodo que vai sumir na versao final. Serve para simular o banco de dados
        /// </summary>
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

            tiposLocalizacao = new LocalSet[1];
            tiposLocalizacao[0] = new LocalSet("humanoide");
            tiposLocalizacao[0].adicionaLocal("olhos");
            tiposLocalizacao[0].adicionaLocal("cabeca","olhos","face");
            tiposLocalizacao[0].adicionaLocal("face", "olhos");

            instancia.locais[i] = new Local(i, "Olhos"); i++;
            instancia.locais[i] = new Local(i, "Cabeca"); i++;
            instancia.locais[i] = new Local(i, "Face"); i++;
            instancia.locais[i] = new Local(i, "Pescoco"); i++;
            instancia.locais[i] = new Local(i, "Perna Direita"); i++;
            instancia.locais[i] = new Local(i, "Braco Direito"); i++;
            instancia.locais[i] = new Local(i, "Mao Direita"); i++;
            instancia.locais[i] = new Local(i, "Pe Direito"); i++;
            instancia.locais[i] = new Local(i, "Peito"); i++;
            instancia.locais[i] = new Local(i, "Cintura"); i++;
            instancia.locais[i] = new Local(i, "Virilha"); i++;
            instancia.locais[i] = new Local(i, "Perna Esquerda"); i++;
            instancia.locais[i] = new Local(i, "Braco Esquerdo"); i++;
            instancia.locais[i] = new Local(i, "Mao Esquerda"); i++;
            instancia.locais[i] = new Local(i, "Pe Esquerdo"); i++;
            instancia.locais[i] = new Local(i, "Costas"); i++;

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

        /// <summary>
        /// Dano basico swing
        /// </summary>
        /// <param name="p">personagem</param>
        /// <returns>qt danos, modicador</returns>
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

        /// <summary>
        /// Dano basico thurst
        /// </summary>
        /// <param name="p">personagem</param>
        /// <returns>qt danos, modicador</returns>
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