using System.Text.Json;

using LancarMovimentacoesDeEstoque.Models;
using LancarMovimentacoesDeEstoque.Enums;

var caminho = Path.Combine(AppContext.BaseDirectory, "estoque.json");

if (!File.Exists(caminho))
{
    Console.WriteLine("Arquivo de dados não encontrado.");
    return;
}

var json = File.ReadAllText(caminho);

var opcoes = new JsonSerializerOptions
{
  PropertyNameCaseInsensitive = true
};

var estoque = JsonSerializer.Deserialize<DadosEstoque>(json, opcoes);

if (estoque?.Estoques is null || estoque.Estoques.Count == 0)
{
  Console.WriteLine("Nenhum produto encontrado no arquivo de dados.");
  return;
}

Console.Write("Informe o código do produto: " );

if (!int.TryParse(Console.ReadLine(), out var codigoProduto))
{
  Console.WriteLine("Código inválido. Digite apenas números.");
  return;
}

var produto = estoque.Estoques.FirstOrDefault(p => p.CodigoProduto == codigoProduto);

if (produto is null)
{
  Console.WriteLine("Produto não encontrado.");
  return;
}

Console.WriteLine(@$"
  Código do Produto: {produto.CodigoProduto}
  Descrição do Produto: {produto.DescricaoProduto}
  Estoque Atual: {produto.Estoque}
");

Console.Write("Informe o tipo de movimentação: (1) Entrada | (2) Saída: ");

if (!int.TryParse(Console.ReadLine(), out var tipoMovimentacao))
{
  Console.WriteLine("Tipo de movimentação inválido. Digite apenas números.");
  return;
}

var tipoMovimentacaoEnum = (TipoMovimentacao)tipoMovimentacao;

if (!Enum.IsDefined(typeof(TipoMovimentacao), tipoMovimentacao))
{
  Console.WriteLine("Tipo de movimentação inválido. Use 1 para Entrada ou 2 para Saída.");
  return;
}

Console.Write("Informe a quantidade:  ");

if (!int.TryParse(Console.ReadLine(), out var quantidade) || quantidade <= 0)
{
  Console.WriteLine("Quantidade inválida. Informe um número maior que zero.");
  return;
}

Console.Write("Informe a descrição da movimentação: ");
var descricao = Console.ReadLine();

if (string.IsNullOrWhiteSpace(descricao))
{
  Console.WriteLine("A descrição é obrigatória.");
  return;
}

switch (tipoMovimentacaoEnum)
{
  case TipoMovimentacao.Entrada:
    produto.Estoque += quantidade;
    break;
  case TipoMovimentacao.Saida:
    if (quantidade > produto.Estoque)
    {
      Console.WriteLine("Quantidade de saída maior que o estoque atual.");
      return;
    }
    produto.Estoque -= quantidade;
    break;
  default:
    Console.WriteLine("Tipo de movimentação inválido.");
    return;
}

var movimentacao = new Movimentacao(
  Id: Guid.NewGuid(),
  CodigoProduto: produto.CodigoProduto,
  Tipo: tipoMovimentacaoEnum,
  Quantidade: quantidade,
  Descricao: descricao
);

Console.WriteLine(@$"
  Movimentação registrada com sucesso!
  ID: {movimentacao.Id}
  Código do Produto: {movimentacao.CodigoProduto}
  Tipo de Movimentação: {movimentacao.Tipo}
  Quantidade: {movimentacao.Quantidade}
  Descrição: {movimentacao.Descricao}
  Estoque Final: {produto.Estoque}
");


