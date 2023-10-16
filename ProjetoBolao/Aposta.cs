using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class Aposta {
    // Atributos da Classe
    private List<int> numeros;
    private Jogador organizador;
    private List<Jogador> jogadores;

    // Construtor da Classe
    public Aposta() {
        this.numeros = new List<int>();
        this.jogadores = new List<Jogador>();
    }

    // Método Gets e Sets
    public Jogador GetOrganizador() {
        return this.organizador;
    }

    public void SetOrganizador(Jogador novoJogador) {
        this.organizador = novoJogador;
    }

    public List<int> GetNumeros() {
        return this.numeros;
    }

    public void SetNumeros(List<int> novosNumeros) {
        this.numeros = novosNumeros;
    }

    public List<Jogador> GetJogadores() {
        return this.jogadores;
    }

    public void SetJogadores(List<Jogador> novosJogadores) {
        this.jogadores = novosJogadores;
    }

    public void InserirNumeros() {
        Console.WriteLine("Digite a quantidade de números apostados (entre 6 e 15): ");
        int cont = int.Parse(Console.ReadLine());
        while (cont < 6 || cont > 15) {
            Console.WriteLine("Número de quantidade inválido, por favor insira um número de 6 a 15: ");
            cont = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < cont; i++) {
            Console.WriteLine("Digite um dos número apostado: ");
            int num = int.Parse(Console.ReadLine());
            if (num >= 1 && num <= 60 && !numeros.Contains(num)) {
                numeros.Add(num);
            }
            else {
                if (num < 1) {
                    Console.WriteLine("Número informado é menor que 1, não pode ser cadastrado. Digite outro número: ");
                    i -= 1;
                }
                if (num > 60) {
                    Console.WriteLine("Número informado é maior que 60, não pode ser cadastrado. Digite outro número: ");
                    i -= 1;
                }
                if (numeros.Contains(num)) {
                    Console.WriteLine("Número informado já está cadastrado. Por favor, digite outro número: ");
                    i -= 1;
                }
            }
        }
    }

    public void InserirOrganizador(List<Jogador> jogadores) {
        foreach (Jogador jogador in jogadores) {
            jogador.listarDados();
        }
        Console.WriteLine("Digite o CPF do organizador a ser cadastrado: ");
        string cpfOrganizador = Console.ReadLine();
        Jogador organizador = jogadores.Find(j => j.GetCpf() == cpfOrganizador);
        if (organizador != null) {
            SetOrganizador(organizador);
            GetJogadores().Add(GetOrganizador());
        }
    }

    public void InserirJogadores(List<Jogador> jogadores) {
        Console.WriteLine("Digite a quantidade de jogadores a serem cadastrados na aposta: (Sem contar o organizador) ");
        int qtdJogadores = int.Parse(Console.ReadLine());
        for (int i = 0; i < qtdJogadores; i++) {
            foreach (Jogador jogadorJ in jogadores) {
                jogadorJ.listarDados();
            }
            Console.WriteLine("Digite o CPF do jogador que deseja cadastrar: ");
            string cpfJogadores = Console.ReadLine();
            Jogador jogador = jogadores.Find(j => j.GetCpf() == cpfJogadores);
            if (jogador != null) {
                GetJogadores().Add(jogador);
            }
        }
    }

    public bool Vencedora(List<int> numerosSorteados) {
        int cont = 0;
        foreach (int numero in numeros) {
            if (numerosSorteados.Contains(numero)) {
                cont += 1;
            }
        }
        return cont == 6;
    }

    public void ListarVencedores(double premio) {
        double transform = premio * 0.1;
        double transformParcial = (premio - transform) / this.jogadores.Count;
        double premioOrganizador = transform + transformParcial;
        GetOrganizador().listarDados();
        Console.WriteLine($"Prêmio {premioOrganizador.ToString("0.00")}");
        Console.WriteLine("");
        double novoValor = premio - transform;
        double premioJogadores = novoValor / this.jogadores.Count;
        for (int i = 1; i < GetJogadores().Count; i++) {
            GetJogadores()[i].listarDados();
            Console.Write($"Prêmio {premioJogadores.ToString("0.00")}");
            Console.WriteLine("");
        }
    }
}
