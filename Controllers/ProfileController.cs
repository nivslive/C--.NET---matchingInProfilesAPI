using Microsoft.AspNetCore.Mvc;
using MagicVilla.Models;

namespace MagicVilla.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController : ControllerBase
    {
        private static List<Profile> profiles = new List<Profile>
        {
            new Profile { Id = 1, Name = "Alice", Age = 25, Bio = "Looking for new connections.", Sex = "Female" },
            new Profile { Id = 2, Name = "Bob", Age = 28, Bio = "Enjoys long walks on the beach.", Sex = "Male" },
        };

        private static List<Match> matches = new List<Match>();

        [HttpGet]
        public IActionResult GetProfiles()
        {
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfileById(int id)
        {
            var profile = profiles.Find(p => p.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public IActionResult CreateProfile([FromBody] Profile profile)
        {
            profile.Id = profiles.Count + 1;
            profiles.Add(profile);
            return CreatedAtAction(nameof(GetProfileById), new { id = profile.Id }, profile);
        }

        [HttpPost("match")]
        public IActionResult CreateMatch([FromBody] MatchRequest matchRequest)
        {
            var profile1 = profiles.Find(p => p.Id == matchRequest.ProfileId1);
            var profile2 = profiles.Find(p => p.Id == matchRequest.ProfileId2);

            if (profile1 == null || profile2 == null)
            {
                return NotFound("One or more profiles not found.");
            }

            var match = new Match
            {
                Id = matches.Count + 1,
                Profile1 = profile1,
                Profile2 = profile2,
                MatchDate = DateTime.Now
            };

            matches.Add(match);

            return Ok(match);
        }
    }

}
