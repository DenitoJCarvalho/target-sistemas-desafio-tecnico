

namespace RegistroDeVendasTimeComercial.Models;

public record Vendas(
    string Vendedor,
    decimal Valor
);

public record DadosVendas(List<Vendas> Vendas);

