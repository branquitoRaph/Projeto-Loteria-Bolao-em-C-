using System;
using System.Runtime.CompilerServices;

class Jogador : Pessoa {
    // Atributos da classe

    private string chavePix;
    protected int anoNascimento;
    protected int idade;

    // Construtor da Classe (Utiliza o construtor da classe Pessoa)
    public Jogador() {
        Console.WriteLine("Digite a chave pix a ser cadastrada: ");
        this.chavePix = Console.ReadLine();
        bool verificando = false;
        while (!verificando) {
            Console.WriteLine("Digite o ano de nascimento: ");
            this.anoNascimento = int.Parse(Console.ReadLine());
            if (VerificarIdade(anoNascimento)) {
                Console.WriteLine("Jogador maior de idade!");
                verificando = true;
            } else {
                Console.WriteLine("Jogador menor de idade, não pode ser cadastrado!");
                Console.WriteLine("Tente novamente!");
            }
        }
    }

    // Métodos Gets e Sets
    public string GetPix() {
        return this.chavePix;
    }

    public void setChavePix(string novaChave) {
        this.chavePix = novaChave;
    }

    public int GetAnoNascimento() {
        return this.anoNascimento;
    }

    public void SetAnoNascimento(int novoAnoNascimento) {
        this.anoNascimento = novoAnoNascimento;
    }

    public int GetIdade() {
        return this.idade;
    }

    public void SetIdade(int novaIdade) {
        this.idade = novaIdade;
    }

    // Método para Verificar se Jogador já foi cadastrado
    public bool Igualdade(List<Jogador> jogadoresCadastrados, Jogador novoJogador) {
        foreach (Jogador j in jogadoresCadastrados) {
            if (j.GetCpf() == novoJogador.GetCpf()) {
                return true;
            }
        }
        return false;
    }

    // Método para verificar a idade (se a idade é maior que 18 anos)
    public bool VerificarIdade(int anoNascimento) {
        int anoAtual = DateTime.Now.Year;
        SetIdade(anoAtual - anoNascimento);
        if (GetIdade() >= 18) {
            return true;
        } else {
            return false;
        }
        
    }

    public void listarDados() {
        base.listarDados();
        Console.WriteLine($"Chave Pix: {this.GetPix()}");
    } 

}
