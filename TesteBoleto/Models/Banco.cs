// Models/Banco.cs
using System.ComponentModel.DataAnnotations;

public class Banco
{
    public int Id { get; set; }
    [Required]
    public string NomeBanco { get; set; }
    [Required]
    public string CodigoBanco { get; set; }
    [Required]
    public decimal PercentualJuros { get; set; }
    [Required]

    // Relacionamento com os Boletos
    public List<Boleto> Boletos { get; set; }
}