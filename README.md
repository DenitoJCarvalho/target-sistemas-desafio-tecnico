# Desafio Técnico - Target Sistemas

Este repositório tem a resolução das 3 tarefas enviadas pela **Target Sistemas**.

Todos os projetos são feitos em **C#**, como **aplicação console**, e ficam juntos na solução `DesafioTecnicoTargetSistemas.sln`.

## Índice

- [Desafio Técnico - Target Sistemas](#desafio-técnico---target-sistemas)
  - [Índice](#índice)
  - [Estrutura do repositório](#estrutura-do-repositório)
  - [Requisitos](#requisitos)
  - [Como executar](#como-executar)
  - [Tarefa 1 - Comissão de vendas](#tarefa-1---comissão-de-vendas)
    - [Enunciado](#enunciado)
    - [Como funciona](#como-funciona)
    - [Premissas](#premissas)
  - [Tarefa 2 - Movimentação de estoque](#tarefa-2---movimentação-de-estoque)
    - [Enunciado](#enunciado-1)
    - [Como funciona](#como-funciona-1)
    - [Validações](#validações)
    - [Exemplo](#exemplo)
    - [Premissas](#premissas-1)
  - [Tarefa 3 - Cálculo de juros](#tarefa-3---cálculo-de-juros)
    - [Enunciado](#enunciado-2)
    - [Como funciona](#como-funciona-2)
    - [Exemplo](#exemplo-1)
    - [Premissas](#premissas-2)

## Estrutura do repositório

| Tarefa | Projeto                         |
| ------ | ------------------------------- |
| 1      | `RegistroDeVendasTimeComercial` |
| 2      | `LancarMovimentacoesDeEstoque`  |
| 3      | `CalcularValorDosJuros`         |

```text
Target Sistemas/
├── DesafioTecnicoTargetSistemas.sln
├── RegistroDeVendasTimeComercial/
├── LancarMovimentacoesDeEstoque/
└── CalcularValorDosJuros/
```

## Requisitos

- [.NET SDK 9.0](https://dotnet.microsoft.com/download) ou superior

Para conferir se está instalado:

```bash
dotnet --version
```

## Como executar

Cada tarefa é um projeto separado. O passo a passo é o mesmo para os 3.

**Opção 1: pela raiz do repositório**

```bash
dotnet run --project RegistroDeVendasTimeComercial
dotnet run --project LancarMovimentacoesDeEstoque
dotnet run --project CalcularValorDosJuros
```

**Opção 2: entrando na pasta do projeto**

```bash
cd LancarMovimentacoesDeEstoque
dotnet run
```

> O `dotnet run` já baixa as dependências e compila o projeto sozinho. Não precisa rodar `dotnet restore` antes.

Os arquivos `.json` ficam dentro de cada projeto e são copiados automaticamente para a pasta de saída (`bin`) na hora de compilar.

---

## Tarefa 1 - Comissão de vendas

**Projeto:** `RegistroDeVendasTimeComercial`

### Enunciado

Considerando que o JSON abaixo tem registros de vendas de um time comercial, faça um programa que leia os dados e calcule a comissão de cada vendedor, seguindo a seguinte regra para cada venda:

- Vendas abaixo de R$ 100,00 não geram comissão.
- Vendas abaixo de R$ 500,00 geram 1% de comissão.
- A partir de R$ 500,00 geram 5% de comissão.

```json
{
  "vendas": [
    { "vendedor": "João Silva", "valor": 1200.50 },
    { "vendedor": "João Silva", "valor": 950.75 },
    { "vendedor": "João Silva", "valor": 1800.00 },
    { "vendedor": "João Silva", "valor": 1400.30 },
    { "vendedor": "João Silva", "valor": 1100.90 },
    { "vendedor": "João Silva", "valor": 1550.00 },
    { "vendedor": "João Silva", "valor": 1700.80 },
    { "vendedor": "João Silva", "valor": 250.30 },
    { "vendedor": "João Silva", "valor": 480.75 },
    { "vendedor": "João Silva", "valor": 320.40 },

    { "vendedor": "Maria Souza", "valor": 2100.40 },
    { "vendedor": "Maria Souza", "valor": 1350.60 },
    { "vendedor": "Maria Souza", "valor": 950.20 },
    { "vendedor": "Maria Souza", "valor": 1600.75 },
    { "vendedor": "Maria Souza", "valor": 1750.00 },
    { "vendedor": "Maria Souza", "valor": 1450.90 },
    { "vendedor": "Maria Souza", "valor": 400.50 },
    { "vendedor": "Maria Souza", "valor": 180.20 },
    { "vendedor": "Maria Souza", "valor": 90.75 },

    { "vendedor": "Carlos Oliveira", "valor": 800.50 },
    { "vendedor": "Carlos Oliveira", "valor": 1200.00 },
    { "vendedor": "Carlos Oliveira", "valor": 1950.30 },
    { "vendedor": "Carlos Oliveira", "valor": 1750.80 },
    { "vendedor": "Carlos Oliveira", "valor": 1300.60 },
    { "vendedor": "Carlos Oliveira", "valor": 300.40 },
    { "vendedor": "Carlos Oliveira", "valor": 500.00 },
    { "vendedor": "Carlos Oliveira", "valor": 125.75 },

    { "vendedor": "Ana Lima", "valor": 1000.00 },
    { "vendedor": "Ana Lima", "valor": 1100.50 },
    { "vendedor": "Ana Lima", "valor": 1250.75 },
    { "vendedor": "Ana Lima", "valor": 1400.20 },
    { "vendedor": "Ana Lima", "valor": 1550.90 },
    { "vendedor": "Ana Lima", "valor": 1650.00 },
    { "vendedor": "Ana Lima", "valor": 75.30 },
    { "vendedor": "Ana Lima", "valor": 420.90 },
    { "vendedor": "Ana Lima", "valor": 315.40 }
  ]
}
```

### Como funciona

1. Lê o arquivo `vendas.json`.
2. Calcula a comissão de cada venda pela faixa de valor.
3. Soma as comissões de cada vendedor.
4. Mostra o resultado na tela.

### Premissas

- Venda de exatamente R$ 100,00 gera **1%**, porque a regra só exclui valores *abaixo* de R$ 100,00.
- Venda de exatamente R$ 500,00 gera **5%**, porque a regra de 5% começa *a partir* de R$ 500,00.
- Os valores usam o tipo `decimal`, que evita erros de arredondamento em dinheiro.

---

## Tarefa 2 - Movimentação de estoque

**Projeto:** `LancarMovimentacoesDeEstoque`

### Enunciado

Faça um programa onde eu possa lançar movimentações de estoque dos produtos que estão no JSON abaixo, dando entrada ou saída da mercadoria no meu depósito, onde cada movimentação deve ter:

- Um número identificador único.
- Uma descrição para identificar o tipo da movimentação realizada.

E que, ao final da movimentação, me retorne a quantidade final do estoque do produto movimentado.

```json
{
  "estoque": [
    {
      "codigoProduto": 101,
      "descricaoProduto": "Caneta Azul",
      "estoque": 150
    },
    {
      "codigoProduto": 102,
      "descricaoProduto": "Caderno Universitário",
      "estoque": 75
    },
    {
      "codigoProduto": 103,
      "descricaoProduto": "Borracha Branca",
      "estoque": 200
    },
    {
      "codigoProduto": 104,
      "descricaoProduto": "Lápis Preto HB",
      "estoque": 320
    },
    {
      "codigoProduto": 105,
      "descricaoProduto": "Marcador de Texto Amarelo",
      "estoque": 90
    }
  ]
}
```

### Como funciona

1. Lê o arquivo `estoque.json`.
2. Pede o **código do produto** e mostra os dados dele.
3. Pede o **tipo da movimentação**: `1` para entrada ou `2` para saída.
4. Pede a **quantidade** e a **descrição** da movimentação.
5. Gera um **identificador único** (`Guid`) para a movimentação.
6. Atualiza o estoque e mostra a **quantidade final**.

### Validações

- Código de produto que não existe é recusado.
- Quantidade precisa ser um número maior que zero.
- Saída maior que o estoque disponível é recusada (o estoque não fica negativo).
- A descrição é obrigatória.

### Exemplo

```text
Informe o código do produto: 101

  Código do Produto: 101
  Descrição do Produto: Caneta Azul
  Estoque Atual: 150

Informe o tipo de movimentação: (1) Entrada | (2) Saída: 2
Informe a quantidade: 50
Informe a descrição da movimentação: Venda para cliente

  Descrição: Venda para cliente
  Código do Produto: 101
  Descrição do Produto: Caneta Azul
  Tipo de Movimentação: Saida
  Quantidade: 50
  Estoque Final: 100
```

### Premissas

- As movimentações ficam **na memória** durante a execução.
- O arquivo `estoque.json` original **não é alterado**.

---

## Tarefa 3 - Cálculo de juros

**Projeto:** `CalcularValorDosJuros`

### Enunciado

Faça um programa que, a partir de um valor e de uma data de vencimento, calcule o valor dos juros na data de hoje, considerando que a multa seja de 2,5% ao dia.

### Como funciona

1. Pede o **valor** e a **data de vencimento** (formato `dd/MM/yyyy`).
2. Calcula quantos **dias de atraso** existem entre o vencimento e hoje.
3. Aplica a fórmula e mostra os juros e o total a pagar.

```text
juros = valor × 2,5% × dias em atraso
```

### Exemplo

Valor de `1000,00` vencido há 10 dias:

```text
Valor original: R$ 1.000,00
Dias em atraso: 10
Taxa: 2,5% ao dia
Juros: R$ 250,00
Total a pagar: R$ 1.250,00
```

### Premissas

- O cálculo usa **juros simples**: a taxa sempre incide sobre o valor original.
- Se a conta ainda não venceu (ou vence hoje), **não há juros**.
- O enunciado fala em "multa", mas a conta de valor por dia de atraso foi tratada como juros.