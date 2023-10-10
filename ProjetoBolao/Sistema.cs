using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
class Sistema {
    private List<Aposta> apostas;
    private List<Jogador> jogadores;

    public Sistema() {
        this.apostas = new List<Aposta>();
        this.jogadores = new List<Jogador>();
    }

    public static int MenuInicial() {
        Console.WriteLine("------Bem vindo a Lotérica do Tico e Teco------ ");
        Console.WriteLine("Digite uma das opções abaixo: ");
        Console.WriteLine("01) Cadastrar Jogador");
        Console.WriteLine("02) Cadastrar Aposta");
        Console.WriteLine("03) Inserir Sorteio e Listar Vencedores");
        Console.WriteLine("04) Sair");

        int opcao;
        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4) {
            Console.WriteLine("Por favor, digite uma operação válida dentre essas acima!");
        }

        return opcao;
    }

    public void CadastrarJogador() {
        Jogador jog = new Jogador();
        this.jogadores.Add(jog);
    }

    public void CadastrarAposta() {
        Aposta apt = new Aposta();
        apt.InserirNumeros();
        apt.InserirOrganizador(jogadores);
        apt.InserirJogadores(jogadores);
        this.apostas.Add(apt);
    }

    private List<Aposta> Vencedoras(List<int> numerosSorteados) {
        List<Aposta> aptsAux = new List<Aposta>();
        foreach (Aposta apt in this.apostas) {
            if (apt.Vencedora(numerosSorteados)) {
                Console.WriteLine("Aposta Vencedora!");
                aptsAux.Add(apt);
            }
            else {
                Console.WriteLine("Aposta Perdedora!");
            }
        }
        return aptsAux;
    }

    public void InserirSorteio() {
        List<int> numerosSorteados = new List<int>();
        Console.WriteLine("Começa agora, o cadastro dos números que foram sorteados!");
        for (int i = 0; i < 6; i++) {
            Console.WriteLine("Digite um número sorteado: ");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 60 || numerosSorteados.Contains(num)) {
                if (num < 1) {
                    Console.WriteLine("Número informado é menor que 1, por favor digite um número maior que 1!");
                }
                else if (num > 60) {
                    Console.WriteLine("Número informado é maior que 60, por favor digite um número menor que 60!");
                }
                else if (numerosSorteados.Contains(num)) {
                    Console.WriteLine("Número Informado já foi sorteado, digite um número válido!");
                }

                Console.WriteLine("Digite um número sorteado: ");
            }

            numerosSorteados.Add(num);
        }

        Console.WriteLine("Digite o valor total do Prêmio: ");
        double premio;
        while (!double.TryParse(Console.ReadLine(), out premio)) {
            Console.WriteLine("Por favor, digite um valor válido para o prêmio!");
        }
        List<Aposta> auxiliar = this.Vencedoras(numerosSorteados);
        double premioAposta = premio / auxiliar.Count;
        foreach (Aposta aptPremiadas in auxiliar) {
            aptPremiadas.ListarVencedores(premioAposta);
        }
    }
}

