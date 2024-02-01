// BoletoDTO.cs
public class BoletoDTO
{
    public int Id { get; set; }
    public string NomePagador { get; set; }
    //public string CPFCNPJPagador { get; set; }
    public string NomeBeneficiario { get; set; }
    //public string CPFCNPJBeneficiario { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public string Observacao { get; set; }

    // Relacionamento com Banco (exemplo)
    public BancoDTO Banco { get; set; }


}
