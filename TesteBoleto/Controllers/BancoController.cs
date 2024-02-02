// Controllers/BancoController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BancoController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public BancoController(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

        return banco;
    }
    
    // POST: api/Banco
    [HttpPost]
    public async Task<ActionResult<Banco>> AdicionarBanco([FromBody] BancoDTO bancoDTO)
    {
        // Verifica se o modelo é válido
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Mapeia o DTO para a entidade Banco
        var banco = _mapper.Map<Banco>(bancoDTO);

        // Adiciona o banco ao contexto e salva as alterações
        _context.Bancos.Add(banco);
        await _context.SaveChangesAsync();
        
        // Mapeia a entidade Banco de volta para DTO
        var bancoCriadoDTO = _mapper.Map<BancoDTO>(banco);

        // Retorna a resposta com o objeto criado
        return CreatedAtAction(nameof(AdicionarBanco), new { id = banco.Id }, bancoCriadoDTO);
    }
}
