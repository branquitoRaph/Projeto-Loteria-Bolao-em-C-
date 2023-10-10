using System;
using System.Runtime.CompilerServices;

class Pessoa {
    // Atributos da Classe
    protected string nome, cpf;

    // Construtor da Classe
    public Pessoa() {
        Console.WriteLine("Digite o nome da pessoa: ");
        this.nome = Console.ReadLine();
        Console.WriteLine("Digite o CPF da pessoa: ");
        this.cpf = Console.ReadLine();
    }

    // Métodos Gets e Sets dos atributos da Classe
    public string GetNome() {
        return this.nome;
    }

    public void SetNome(string novoNome) {
        this.nome = novoNome;
    }

    public string GetCpf() {
        return this.cpf;
    }

    public void SetCpf(string novoCpf) {
        this.cpf = novoCpf;
    }

    // Método para exibir os dados da Pessoa
    public void listarDados() {
        Console.WriteLine($"Nome: {this.GetNome()}");
        Console.WriteLine($"CPF: {this.GetCpf()}");
    }

    // Implementar Método de Validação de CPF

}