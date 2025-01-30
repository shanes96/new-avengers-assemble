using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    // In-memory list to simulate database storage
    private static List<UserProfile> profiles = new List<UserProfile>
    {
        new UserProfile { Id = 1, Name = "Tony Stark", Email = "tony@stark.com", Bio = "Genius billionaire", ProfileImage = "https://media1.popsugar-assets.com/files/thumbor/ZCWD9YXxqYzk9riO2WR2OrxzWUw/721x0:1801x1080/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2019/07/01/098/n/46207611/5d2cc4f65d1ab1d1992803.52716266_/i/Why-Tony-Stark-Best-Marvel-Character.jpg", UserWins = 10, UserLosses = 5 }
    };

    // GET: api/UserProfile
    [HttpGet]
    public IActionResult GetAllProfiles()
    {
        return Ok(profiles);  // Return the list of profiles
    }

    // POST: api/UserProfile
    [HttpPost]
    public IActionResult AddProfile([FromBody] UserProfile profile)
    {
        // Automatically set the new profile's Id (incrementing)
        profile.Id = profiles.Count + 1;
        profiles.Add(profile);  // Add the new profile to the in-memory list
        return CreatedAtAction(nameof(GetAllProfiles), new { id = profile.Id }, profile);
    }
}
