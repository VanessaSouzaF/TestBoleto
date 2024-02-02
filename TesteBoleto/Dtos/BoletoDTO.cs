// DTOs/BoletoDTO.cs

using System;
using System.ComponentModel.DataAnnotations;

public class BoletoDTO
{
    [Required]
    public string NomePagador { get; set; }

    [Required]
    public string CPFCNPJPagador { get; set; }

    [Required]
    public string NomeBeneficiario { get; set; }

    [Required]
    public string CPFCNPJBeneficiario { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    public DateTime DataVencimento { get; set; }

    public string Observacao { get; set; }

    [Required]
    public int BancoId { get; set; }
}
