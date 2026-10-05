

using CalcularValorDosJuros.Models;

const decimal TAXA_JUROS = 0.025m;

Console.Write("Informe o valor Inicial: ");

if (!decimal.TryParse(Console.ReadLine(), out var valorInicial))
{
  Console.WriteLine("Valor inválido. Informe um número maior que zero.");
  return;
}

Console.Write("Informe a data de vencimento (dd/MM/yyyy): ");
if (!DateTime.TryParse(Console.ReadLine(), out var vencimento))
{
  Console.WriteLine("Data inválida. Informe uma data no formato dd/MM/yyyy.");
  return;
}

var diasEmAtraso = (DateTime.Today - vencimento.Date).Days;

if (diasEmAtraso <= 0)
{
  Console.WriteLine("Não há juros a serem calculados, pois a data de vencimento está dentro do prazo.");
  return;
}

var jurosSimples = new JurosSimples
{
  TaxaJuros = TAXA_JUROS,
  ValorInicial = valorInicial,
  Tempo = diasEmAtraso
};

var valorJuros = jurosSimples.CalcularJuros();

Console.WriteLine(@$"
  Valor Inicial: {valorInicial.ToString("C2")}
  Vencimento: {vencimento.ToString("dd/MM/yyyy")}
  Dias em atraso: {diasEmAtraso}
  Taxa de juros: {TAXA_JUROS:P1} ao dia
  Juros: {valorJuros.ToString("C2")}
  Total a pagar: {(valorInicial + valorJuros).ToString("C2")}
");
