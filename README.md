```markdown
# Jogo de Corrida dos Dados

Este repositório contém um jogo de console em **C#** onde o jogador compete contra o computador em uma corrida até a linha de chegada, utilizando lançamentos de dados para avançar.  
Nesta versão, o código foi refatorado em métodos separados para melhorar a organização e a legibilidade.

---

## Funcionalidades

- Exibe uma mensagem de boas-vindas antes de iniciar o jogo.
- O jogador e o computador começam na posição inicial (0).
- Cada turno consiste em rolar um dado (valores de 1 a 6).
- Regras especiais:
  - **Bonus**: ao cair em posições específicas (5, 10, 15, 20), o jogador ou computador avança +3 casas.
  - **Penalidade**: ao cair em posições específicas (7, 13, 20), o jogador ou computador volta -2 casas.
  - **Jogada extra**: se o dado cair em **6**, o jogador ou computador ganha uma jogada adicional.
- O jogo continua até que um dos participantes alcance ou ultrapasse a linha de chegada (posição 30).
- Ao final da partida, o jogador pode escolher se deseja jogar novamente.

---

## Estrutura do Projeto

  - `Program.cs`: contém toda a lógica do jogo, organizada em métodos:
  - `WelcomeMessage()`: exibe a mensagem inicial.
  - `PlayRound()`: controla uma rodada completa entre jogador e computador.
  - `Header()`: exibe o cabeçalho com a posição atual dos jogadores.
  - `RollDice()`: simula o lançamento do dado, aplicando bônus, penalidades e jogadas extras.
  - `Retry()`: pergunta ao jogador se deseja continuar jogando.
  - Uso de `RandomNumberGenerator.GetInt32(1, 7)` para gerar valores aleatórios entre 1 e 6.

---

## Como Executar

1. Abra o terminal na pasta do projeto.
2. Compile o projeto com o comando:
   ```bash
   dotnet build
   ```
3. Execute o jogo:
   ```bash
   dotnet run
   ```

---

## Requisitos

- [.NET SDK 6.0 ou superior](https://dotnet.microsoft.com/download).

---

## Objetivos de Aprendizado

- Praticar entrada e saída de dados em console.
- Utilizar geração de números aleatórios com `RandomNumberGenerator`.
- Implementar lógica de jogo com regras de bônus, penalidade e jogada extra.
- Trabalhar com estruturas de repetição e condicionais.
- Refatorar código em métodos para maior clareza e reutilização.
- Estruturar um jogo simples em C#.