// DTOs/BancoDTO.cs

using System.ComponentModel.DataAnnotations;

public class BancoDTO
{
    [Required]
    public string NomeBanco { get; set; }
    
    [Required]
    public string CodigoBanco { get; set; }
    
    [Required]
    public decimal PercentualJuros { get; set; }
}
