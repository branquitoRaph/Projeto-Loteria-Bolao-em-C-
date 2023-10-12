# Descrição do Sistema

O projeto Loteria do Tico e Teco, tem como principal objetivo fazer um sistema para uma loteria, onde temos o cadastro de pessoas, logo em seguida de jogadores, fazer uma aposta e apresentar os se a aposta foi vencedora e se for, mostrar o prêmio para cada jogador.

## Classes

Atualmente, possuímos quatro classes + a classe principal, onde elas são:

* Pessoa: classe responsável por identificar, cadastrar, validar  e listar os dados de uma pessoa. (Obs: nem toda pessoa é um jogador, e todo jogador é uma pessoa);
* Jogador: classe responsável por mostrar os atributos de um jogador e listar os dados do jogador;
* Aposta: classe responsável por construir uma aposta, receber os números da aposta, cadastrar os jogadores (sendo um organizador por aposta e os demais jogadores) na aposta, confere se as apostas foram vencedoras e lista as vencedoras dividindo automaticamente o prêmio;
* Sistema: classe responsável por montar a interface (menu) e também temos alguns métodos, de cadastrar um jogador (não é criar), cadastrar aposta, ver apostas vencedoras, e inserir os números sorteados.

  A classe principal ficou responsável por criar um objeto da classe Sistema e então faz o tratamento do menu, rodando entre as opções que o usuário escolher.
