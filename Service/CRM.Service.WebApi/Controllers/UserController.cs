using CRM.Application.DTO;
using CRM.Application.Interface;
using CRM.Service.WebApi.Helpers;
using CRM.Transversal.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CRM.Service.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserApplication _userApplication;
    private readonly AppSettings _appSettings;
    public UserController(IUserApplication userApplication, IOptions<AppSettings> appSettings)
    {
        _userApplication = userApplication;
        _appSettings = appSettings.Value;
    }
    [HttpPost]
    public IActionResult Authenticate([FromBody] UserDTO userDTO)
    {
        try
        {
            if (userDTO.UserName == null)
            {
                return BadRequest("User Empty.");
            }
            if (userDTO.Password == null)
            {
                return BadRequest("Password Empty.");
            }
            var response = _userApplication.Authenticate(userDTO.UserName, userDTO.Password);
            if (response.IsSuccess)
            {
                if (response.Data == null)
                {
                    return NotFound(response.Message);
                }
                else
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    private string BuildToken(Response<UserDTO> userDTO)
    {
        if (_appSettings.Secret == null)
        {
            throw new Exception();
        }
        if (userDTO.Data == null)
        {
            throw new Exception();
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, userDTO.Data.UserID.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.Audience
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}