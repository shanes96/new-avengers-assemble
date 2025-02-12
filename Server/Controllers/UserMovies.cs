using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
namespace Server.Controllers

{ 

[Route("api/usermovies")]
[ApiController]
public class UserMoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserMoviesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<UserMovie>>> GetUserMovies(int userId)
    {
        var userMovies = await _context.UserMovies
            .Where(um => um.UserId == userId)
            .Include(um => um.Movie)
            .ToListAsync();

        if (!userMovies.Any())
        {
            return NotFound("No movies found for this user.");
        }
        return Ok(userMovies);
    }
}
}
