// Controllers/BoletoController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BoletoController : ControllerBase
{
    private readonly ApplicationContext _context;

    public BoletoController(ApplicationContext context)
    {
        _context = context;
    }

    // POST: api/Boleto
    [HttpPost]
    public async Task<IActionResult> PostBoleto(Boleto boleto)
    {
        try
        {
            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoleto", new { id = boleto.Id }, boleto);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Boleto>> GetBoleto(int id)
    {
        var boleto = await _context.Boletos.FindAsync(id);

        if (boleto == null)
        {
            return NotFound();
        }

        if (DateTime.Now > boleto.DataVencimento)
        {
            // Lógica para calcular juros
            var banco = await _context.Bancos.FindAsync(boleto.BancoId);
            boleto.Valor += boleto.Valor * banco.PercentualJuros;
        }

        return boleto;
    }
}
