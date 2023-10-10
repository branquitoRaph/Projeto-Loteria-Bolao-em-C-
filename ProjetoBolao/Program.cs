using System;

class Program {
    public static void Main(string[] args) {
        Sistema func = new Sistema();
        int op = Sistema.MenuInicial();
        while (op != 4) {
            if (op == 1) {
                func.CadastrarJogador();
                op = Sistema.MenuInicial();
            }
            if (op == 2) {
                func.CadastrarAposta();
                op = Sistema.MenuInicial();
            }
            if (op == 3) {
                func.InserirSorteio();
                op = Sistema.MenuInicial();
            }
        }
    }
}