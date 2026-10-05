

namespace CalcularValorDosJuros.Models;

public class JurosSimples
{
    public decimal ValorInicial { get; set; }

    public decimal TaxaJuros { get; set; }

    public int Tempo { get; set; }

    public decimal CalcularJuros()
    {
        return ValorInicial * TaxaJuros * Tempo;
    }    
}
