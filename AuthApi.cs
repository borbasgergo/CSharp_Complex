using AuthAPI.Domains.Inputs;
using AuthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI;

[ApiController]
[Route("api/auth/v1/")]
public class AuthApi
{
    private readonly IJwtService _jwtService;
    public AuthApi(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Check([FromHeader] JwtHeaderInput jwtHeaderInput)
    {
        var isValid = await _jwtService.IsValidJwt(jwtHeaderInput);

        return new OkObjectResult(new
        {
            isValid
        });
    }
    
    
    [HttpGet("token")]
    public async Task<IActionResult> Create()
    {
        var token = await _jwtService.CreateToken();

        return new OkObjectResult(new
        {
            token
        });
    }

}