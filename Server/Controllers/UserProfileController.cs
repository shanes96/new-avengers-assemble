using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserProfileController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/UserProfile
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var profiles = await _context.UserProfiles.ToListAsync();
        return Ok(profiles);
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserProfile>> GetUserProfile(int userId)
    {
        var userProfile = await _context.UserProfiles
            .Include(up => up.FavoriteComics)
                .ThenInclude(uc => uc.Comic) // Include Comics
            .Include(up => up.FavoriteMovies)
                .ThenInclude(um => um.Movie) // Include Movies
            .FirstOrDefaultAsync(up => up.Id == userId);

        if (userProfile == null)
        {
            return NotFound("User profile not found.");
        }

        return Ok(userProfile);
    }


    // POST: api/UserProfile
    [HttpPost]
    public async Task<IActionResult> AddProfile([FromBody] UserProfile profile)
    {
        if (profile == null)
        {
            return BadRequest("Invalid profile data.");
        }

        _context.UserProfiles.Add(profile);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserProfile), new { userId = profile.Id }, profile);
    }
}

