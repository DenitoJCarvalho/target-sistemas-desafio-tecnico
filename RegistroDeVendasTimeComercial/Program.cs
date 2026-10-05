using System.Text.Json;

using RegistroDeVendasTimeComercial.Models;

var caminho = Path.Combine(AppContext.BaseDirectory, "vendas.json");

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

var vendas = JsonSerializer.Deserialize<DadosVendas>(json, opcoes);

if (vendas is null || vendas.Vendas.Count.Equals(0))
{
  Console.WriteLine("Nenhuma venda encontrada no arquivo de dados.");
  return;
}


Console.WriteLine($"Vendas Registras: {vendas.Vendas.Count}");

Console.WriteLine(new string('-', 50));

foreach (var venda in vendas.Vendas)
{
  Console.WriteLine($"Vendedor: {venda.Vendedor} - Valor: {venda.Valor} - comissão: {Comissao(venda.Valor).ToString("C")}");
}

static decimal Comissao(decimal valor)
{
  var comissao = 0m;
  
  if (valor >= 500m)
  {
    comissao = valor * 0.05m;
  }

  if (valor > 100m && valor <= 499.99m)
  {
    comissao = valor * 0.01m;
  }

  return comissao;
}