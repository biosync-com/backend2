using BioSync.Application.DTOs; // Crie um LoginDTO aqui
using BioSync.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthenticate _authenticationService;

    public AccountController(IAuthenticate authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var result = await _authenticationService.Authenticate(loginDto.Email, loginDto.Password);

        if (!string.IsNullOrEmpty(result))
        {
            
            return Ok(new { message = "Login bem-sucedido" });
        }

        return Unauthorized("Email ou senha inválidos.");
    }
}
