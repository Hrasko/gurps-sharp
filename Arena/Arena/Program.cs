using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GurpsSharp;

namespace Arena
{
    class Program
    {
        static Personagem jogador;
        static Logger gerente = new Logger();
        static Mestre mestre;

        static void Main(string[] args)
        {
            Mestre.Load("mestre.xml");
            
            gerente.escrever("1 - Crie Personagem");
            gerente.escrever("2 - Carregar Personagem");
            gerente.escrever("3 - Combate");
            gerente.escrever("4 - Sair");

            int op = gerente.requererInt("Opção: ");
            switch (op)
            {
                case 1: criarPersonagem(); break;
                case 2: carregarPersonagem(); break;
                case 3: combate(); break;
            }
        }

        static void combate()
        {
            gerente.limpar();
            gerente.listarTodosPersonagens();
            string nome = gerente.requerer("Escreva nome do seu personagem: ");
            jogador = gerente.carregar(nome);

            Personagem adversario;

            nome = gerente.requerer("Escreva nome do seu adversario: ");
            adversario = gerente.carregar(nome);


            ArmaMelee espada = new ArmaMelee("Katana", 5, 1, Mestre.Habilidades[0], 2);
            
            jogador.Equipar("maodireita", espada);

        }

        static void criarPersonagem()
        {
            gerente.limpar();
            string nome = gerente.requerer("Escreva um nome: ");
            jogador = new Personagem(nome);
            jogador.xp = 100;
            levelup();
        }

        static void carregarPersonagem()
        {
            gerente.limpar();
            gerente.listarTodosPersonagens();
            string nome = gerente.requerer("Escreva um nome: ");
            jogador = gerente.carregar(nome);
            levelup();
        }

        static void levelup()
        {
            int op = -1;
            while (jogador.xp > 0 && op != 0)
            {
                gerente.limpar();
                gerente.escrever(jogador.ToString());
                gerente.escrever("1 - Melhore Atributos");
                gerente.escrever("2 - Melhore Habilidade");
                gerente.escrever("3 - Salvar");
                gerente.escrever("0 - Sair");

                op = gerente.requererInt("Opção: ");
                int op2 = 0;
                int qtPontos;
                switch (op)
                {
                    case 1:
                        gerente.escrever("Qual atributo?");

                        foreach (var item in Mestre.Atributos)
                        {
                            gerente.escrever(item.id + " - " + item.nome);
                        }

                        gerente.escrever(Mestre.Atributos.Length + " - Voltar");
                        op2 = gerente.requererInt("Opção: ");
                        qtPontos = gerente.requererInt("Quantos pontos?");
                        jogador.gastePontosAtributo(op2, qtPontos);
                        break;
                    case 2:
                        gerente.escrever("Qual Habilidade?");

                        foreach (var item in Mestre.Habilidades)
                        {
                            gerente.escrever(item.id + " - " + item.nome);
                        }

                        gerente.escrever( Mestre.Habilidades.Length + " - Voltar");
                        op2 = gerente.requererInt("Opção: ");
                        qtPontos = gerente.requererInt("Quantos pontos?");
                        jogador.gastePontosHabilidade(op2, qtPontos);
                        break;
                    case 3:
                        gerente.salvar(jogador);
                        break;
                }
            }
        }

    }
}
