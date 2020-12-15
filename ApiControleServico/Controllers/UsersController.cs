using ApiControleServico.Data;
using ApiControleServico.Services;
using DomainLib.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleServico.Controllers
{
    [Route("/usuario")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiControleServicoContext _context;
        private readonly IUserService userService;

        public UsersController(ApiControleServicoContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        // GET: api/Users

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await userService.GetAll();
            //return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("getbyid:{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update:{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await userService.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("remove:{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet("searchstring:{string}")]
        public async Task<ActionResult<List<User>>> GetWtihString(string texto)
        {
            var result = await userService.GetWithName(texto);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        private bool TableEmpty()
        {
            return _context.User.Any();
        }
    }
}