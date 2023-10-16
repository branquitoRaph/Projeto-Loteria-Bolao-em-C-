using System;
using System.Runtime.CompilerServices;

class Pessoa {
    // Atributos da Classe
    protected string nome, cpf;

    // Construtor da Classe
    public Pessoa() {
        Console.WriteLine("Digite o nome da pessoa: ");
        this.nome = Console.ReadLine();
        bool verificado = false;
        while (!verificado) {
            Console.WriteLine("Digite o CPF da pessoa: ");
            string cpf = Console.ReadLine();
            if (VerificarCpf(cpf)) {
                this.cpf = cpf;
                verificado = true;
            } else {
                Console.WriteLine("CPF informado é inválido!");
            }
        }
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

    // Método para atualizar nome e CPF
    public void AtualizarDados(string novoNome, string novoCpf) {
        this.SetNome(novoNome);
        this.SetCpf(novoCpf);
    }

    // Método de Validação de CPF
    public bool VerificarCpf(string cpf) {
        // Verificando o tamanho do CPF (uma string de 14 caracteres)
        if (cpf.Length != 14) {
            Console.WriteLine("Você digitou um CPF fora do formato: '000.000.000-00'.");
            return false;
        }
        // Removendo os caracteres "." e "-"
        cpf = cpf.Replace(".", "").Replace("-", "");
        // Destrinchando o CPF para verificar os dois últimos digitos
        int[] digitos = new int[11];
        for (int i = 0; i < 11; i++) {
            digitos[i] = int.Parse(cpf[i].ToString());
        }
        // Verificando o primeiro digito
        int primeiroDigito = 0;
        for (int i = 0; i < 9; i++) {
            primeiroDigito += digitos[i] * (10 - i);
        }
        primeiroDigito = primeiroDigito % 11;
        if (primeiroDigito < 2) {
            primeiroDigito = 0;
        } else {
            primeiroDigito = 11 - primeiroDigito;
        }
        // Verificando o segundo digito
        int segundoDigito = 0;
        for (int i = 0; i < 9; i++) {
            segundoDigito += digitos[i] * (11 - i);
        }
        segundoDigito = segundoDigito + (primeiroDigito * 2);
        segundoDigito = segundoDigito % 11;

        if (segundoDigito < 2) {
            segundoDigito = 0;
        } else {
            segundoDigito = 11 - segundoDigito;
        }

        // Verificando com os digitos informados
        if (primeiroDigito == digitos[9] && segundoDigito == digitos[10]) {
            return true;
        } else {
            return false;
        }
    }
    
    // Método para exibir os dados da Pessoa
    public void listarDados() {
        Console.WriteLine("Dados do Jogador(a):");
        Console.WriteLine($"Nome: {this.GetNome()}");
        Console.WriteLine($"CPF: {this.GetCpf()}");
    }
}
