using System;
using System.Runtime.CompilerServices;

class Jogador : Pessoa {
    // Atributos da classe

    private string chavePix;

    // Construtor da Classe (Utiliza o construtor da classe Pessoa)
    public Jogador() {
        Console.WriteLine("Digite a chave pix a ser cadastrada: ");
        this.chavePix = Console.ReadLine();
    }

    // Métodos Gets e Sets
    public string GetPix() {
        return this.chavePix;
    }

    public void setChavePix(string novaChave) {
        this.chavePix = novaChave;
    }

    public void listarDados() {
        base.listarDados();
        Console.WriteLine($"Chave Pix: {this.GetPix()}");
    } 
}