using EFCoreRelationships.DataContext;
using EFCoreRelationships.DTOs;
using EFCoreRelationships.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        public readonly ApplicationContext _context;
        public CharacterController(ApplicationContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacterDTO>>> GetCharById(int userId)
        {
            var User = _context.Users.Find(userId);
            if(User == null)
            {
                return NotFound(new {error = "Not A Valid User"});
            }
            var result = await _context.Characters.Where(c => c.User.Id == userId).Include(c => c.Weapon).ToListAsync();
            return Ok(result.Select(r => CharacterDTO.ToCharacterDTO(r)).ToList());

        }

        [HttpPost]
        public async Task<ActionResult<Character>> Create(string Name, string RGPClass, int UserId)
        {
            var user = await _context.Users.Where(u => u.Id == UserId).SingleOrDefaultAsync();
            if(user == null)
            {
                return BadRequest(new {Error = "Reason: Not A Valid User" });
            } else
            {
                var result = _context.Characters.Add(new()
                {
                    Name = Name,
                    RPGClass = RGPClass,
                    User = user!
                });
                _context.SaveChanges();
                return Ok(result.Entity.Id);
            }

            


        }
    }
}
