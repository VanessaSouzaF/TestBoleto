// Controllers/BancoController.cs
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BancoController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;


    public BancoController(ApplicationContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    // GET: api/Banco
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Banco>>> GetBancos()
    {
        return await _context.Bancos.ToListAsync();
    }

    // GET: api/Banco/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Banco>> GetBanco(int id)
    {
        var banco = await _context.Bancos.FindAsync(id);

        if (banco == null)
        {
            return NotFound();
        }

        var bancoDTO = _mapper.Map<BancoDTO>(banco);

        return Ok(bancoDTO);
    }
    
    // POST: api/Banco
    [HttpPost]
    public async Task<ActionResult<Banco>> AdicionarBanco([FromBody] Banco banco)
    {
        // Verifica se o modelo é válido
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Adiciona o banco ao contexto e salva as alterações
        _context.Bancos.Add(banco);
        await _context.SaveChangesAsync();

        // Retorna a resposta com o objeto criado
        return CreatedAtAction(nameof(AdicionarBanco), new { id = banco.Id }, banco);

    }
}
