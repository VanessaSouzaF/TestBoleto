// AuthController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly ApplicationContext _context;

    public AuthController(ITokenService tokenService, ApplicationContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        // Verifique se o usuário existe no banco de dados
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);

        if (user == null)
        {
            return Unauthorized("Usuário ou senha inválidos.");
        }

        // Verifique a senha
        if (user.Password != model.Password)
        {
            return Unauthorized("Usuário ou senha inválidos.");
        }

        // Autenticação bem-sucedida, gere um token
        var userId = user.UserId.ToString();
        var token = _tokenService.GenerateToken(userId);

        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        // Verifique se o usuário já existe
        if (await _context.Users.AnyAsync(u => u.UserName == model.UserName))
        {
            return BadRequest("Nome de usuário já em uso.");
        }

        // Crie um novo usuário
        var newUser = new UserModel
        {
            UserName = model.UserName,
            Password = model.Password
        };

        // Adicione o usuário ao banco de dados
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        // Autenticação bem-sucedida, gere um token para o novo usuário
        var userId = newUser.UserId.ToString();
        var token = _tokenService.GenerateToken(userId);

        return Ok(new { Token = token });
    }

    // ... outras ações do controlador ...
}
