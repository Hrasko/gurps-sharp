using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arena;

namespace ArenaTest
{
    [TestClass]
    public class DanoTest
    {
        [TestMethod]
        public void GetSwing()
        {
            Mestre.Load(@"C:\Users\Hrasko\git\aulas\Arena\Arena\ArenaTest\mestre.xml");
            Personagem jogador;
            jogador = new Personagem("tester");
            jogador.xp = 100000;
            int[] resultado;

            // ST 2: 1d-5
            jogador.gastePontosAtributo(0, -80);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-5, resultado[1]);

            // ST 4: 1d-4
            jogador.gastePontosAtributo(0, 20);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-4, resultado[1]);

            // ST 6: 1d-3
            jogador.gastePontosAtributo(0, 20);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-3, resultado[1]);

            // ST 8: 1d-2
            jogador.gastePontosAtributo(0, 20);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-2, resultado[1]);

            // ST 9: 1d-1
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-1, resultado[1]);

            // ST 10: 1d+0
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(0, resultado[1]);

            // ST 11: 1d+1
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(1, resultado[1]);

            // ST 12: 1d+2
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(2, resultado[1]);

            // ST 13: 2d-1
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(2, resultado[0]);
            Assert.AreEqual(-1, resultado[1]);

            // ST 14: 2d+0
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseSwing(jogador);
            Assert.AreEqual(2, resultado[0]);
            Assert.AreEqual(0, resultado[1]);
        }


        [TestMethod]
        public void GetThrust()
        {
            Mestre.Load(@"C:\Users\Hrasko\git\aulas\Arena\Arena\ArenaTest\mestre.xml");
            Personagem jogador;
            jogador = new Personagem("tester");
            jogador.xp = 100000;
            int[] resultado;
            
            // ST 2: 1d-6
            jogador.gastePontosAtributo(0, -80);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-6, resultado[1]);

            // ST 4: 1d-5
            jogador.gastePontosAtributo(0, 20);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-5, resultado[1]);

            // ST 6: 1d-4
            jogador.gastePontosAtributo(0, 20);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-4, resultado[1]);

            // ST 8: 1d-3
            jogador.gastePontosAtributo(0, 20);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-3, resultado[1]);
            
            // ST 10: 1d-2
            jogador.gastePontosAtributo(0, 20);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-2, resultado[1]);
            
            // ST 11: 1d-1
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-1, resultado[1]);

            // ST 12: 1d-1
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(-1, resultado[1]);

            // ST 13: 1d+0
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(0, resultado[1]);

            // ST 14: 1d+0
            jogador.gastePontosAtributo(0, 10);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(0, resultado[1]);

            // ST 18: 1d+2
            jogador.gastePontosAtributo(0, 40);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(1, resultado[0]);
            Assert.AreEqual(2, resultado[1]);

            // ST 26: 2d+2
            jogador.gastePontosAtributo(0, 80);
            resultado = Mestre.getDanoBaseThrust(jogador);
            Assert.AreEqual(2, resultado[0]);
            Assert.AreEqual(2, resultado[1]);
        }
    }
}
