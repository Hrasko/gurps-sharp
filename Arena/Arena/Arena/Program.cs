using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena
{
    class Program
    {
        static Personagem jogador;
        static Gerente gerente = new Gerente();
        static Mestre mestre = new Mestre();

        static void Main(string[] args)
        {
            gerente.escrever("1 - Crie Personagem");
            gerente.escrever("2 - Sair");

            int op = gerente.requererInt("Opção: ");
            switch (op)
            {
                case 1: criarPersonagem(); break;
            }
        }

        static void criarPersonagem()
        {
            gerente.limpar();
            string nome = gerente.requerer("Escreva um nome: ");
            jogador = new Personagem(nome,mestre);
            jogador.xp = 100;
            levelup();
        }

        static void levelup()
        {
            int op = -1;
            while (jogador.xp > 0 && op != 0)
            {
                gerente.limpar();
                gerente.escrever(jogador.ToString());
                gerente.escrever("1 - Compre Atributos");
                gerente.escrever("2 - Compre Habilidade");
                gerente.escrever("0 - Sair");

                op = gerente.requererInt("Opção: ");
                int op2 = 0;
                switch (op)
                {
                    case 1:
                        gerente.escrever("Qual atributo?");
                        
                        gerente.escrever("1 - ST");
                        gerente.escrever("2 - DX");
                        gerente.escrever("3 - IQ");
                        gerente.escrever("4 - HT");
                        gerente.escrever("5 - Fadiga");
                        gerente.escrever("6 - Velocidade");
                        gerente.escrever("0 - Voltar");
                        op2 = gerente.requererInt("Opção: ");
                        int qtPontos = gerente.requererInt("Quantos pontos?");
                        jogador.gastePontosAtributo(op2 - 1, qtPontos);
                        break;
                }
            }
        }

    }
}
