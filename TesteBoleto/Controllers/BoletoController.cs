// Controllers/BoletoController.cs
using AutoMapper;
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
    private readonly IMapper _mapper;

    public BoletoController(ApplicationContext context, IMapper mapper)
    {
         _mapper = mapper; 
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

       var boletoDTO = _mapper.Map<BoletoDTO>(boleto);

        return Ok(boletoDTO);
    }
}

