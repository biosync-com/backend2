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
        var result = await _authenticationService.AuthenticateAsync(loginDto.Email, loginDto.Password);

        if (result)
        {
            // Aqui você geraria e retornaria um token JWT
            // Por enquanto, vamos retornar um Ok simples
            return Ok(new { message = "Login bem-sucedido" });
        }

        return Unauthorized("Email ou senha inválidos.");
    }
}
