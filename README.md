# Tetris em C#

Um Tetris simples feito em C# rodando no console.  
A ideia foi praticar lógica, matrizes bidimensionais, rotação de arrays e controle de colisão sem usar engine gráfica.

Tudo funciona direto no terminal.

---

## Como funciona

O jogo:

- Gera peças aleatórias  
- Permite movimentação lateral  
- Permite rotação (horária e anti-horária)  
- Detecta colisão com bordas e outras peças  
- Remove linhas completas  
- Soma pontos  
- Salva a pontuação em um arquivo `scores.txt`  

---

## Controles

A → mover para esquerda
D → mover para direita
S → descer
R → girar horário
E → girar anti-horário
---
## Conceitos praticados

Esse projeto foi feito principalmente por diversão e para treinar:

- Matrizes bidimensionais (`int[,]`)
- Rotação de matriz (algoritmo manual)
- Controle de colisão
- Manipulação de arquivos com `StreamWriter`
- Estruturação de loops de jogo
- Organização básica com orientação a objetos

---

## Sistema de pontuação

Cada linha completa removida soma **100 pontos**.  
Ao finalizar o jogo, o score é salvo em:

scores.txt 

No formato:

NomeJogador;Pontuação

---

## Tecnologias

- C#
- .NET (Console Application)
- Execução via terminal

---

## Observações

Esse projeto não utiliza bibliotecas externas nem interface gráfica.  
A proposta foi manter tudo na lógica pura para treinar fundamentos.

---
## Preview
<p align="center" >
<img width="320" height="378" alt="image" src="https://github.com/user-attachments/assets/c2aac890-e61e-4e46-960e-d378c84f3ada" />  
    &nbsp;&nbsp;
<img width="320" height="377" alt="image" src="https://github.com/user-attachments/assets/b03c9f69-c874-4565-a47b-63ffe8cfce36" />
  &nbsp;&nbsp;
<img width="321" height="378" alt="image" src="https://github.com/user-attachments/assets/fa9f3923-f5a8-491f-9615-ca8d6785ed2c" />
</p>




