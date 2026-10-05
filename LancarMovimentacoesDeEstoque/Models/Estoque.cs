using System.Text.Json.Serialization;

namespace LancarMovimentacoesDeEstoque.Models;

public record DadosEstoque(
   [property: JsonPropertyName("estoque")] List<Produto> Estoques
);