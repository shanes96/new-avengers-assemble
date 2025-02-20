using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Data;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _context.UserProfiles.FirstOrDefault(u => u.Email == request.Email);

        if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }


        var token = GenerateToken();
        var authToken = new AuthToken
        {
            Token = token,
            UserId = user.Id,
            Created = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddHours(24)
        };

        _context.AuthTokens.Add(authToken);
        _context.SaveChanges();

        return Ok(new { Token = token, UserId = user.Id });
    }

    private static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }


    [HttpPost("logout")]
    public IActionResult Logout()
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var authToken = _context.AuthTokens.FirstOrDefault(t => t.Token == token);

        if (authToken != null)
        {
            _context.AuthTokens.Remove(authToken);
            _context.SaveChanges();
        }

        return Ok("Logged out successfully");
    }

    private string GenerateToken()
    {
        byte[] tokenBytes = new byte[32];
        RandomNumberGenerator.Fill(tokenBytes);
        return Convert.ToBase64String(tokenBytes);
    }

}
