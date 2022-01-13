using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Domains.Inputs;

public record JwtHeaderInput([FromHeader] string Jwt);