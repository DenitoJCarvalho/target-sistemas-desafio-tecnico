using LancarMovimentacoesDeEstoque.Enums;

namespace LancarMovimentacoesDeEstoque.Models;

public record Movimentacao(
Guid Id,
int CodigoProduto,
TipoMovimentacao Tipo,
int Quantidade,
string Descricao
);