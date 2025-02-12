using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
namespace Server.Controllers

{ 
[Route("api/usercomics")]
[ApiController]
public class UserComicsController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserComicsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<UserComic>>> GetUserComics(int userId)
    {
        var userComics = await _context.UserComics
            .Where(uc => uc.UserId == userId)
            .Include(uc => uc.Comic) // Include related comic details
            .ToListAsync();

        if (!userComics.Any())
        {
            return NotFound("No comics found for this user.");
        }

        return Ok(userComics);
    }
}
}