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
    [Route("/cliente")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApiControleServicoContext _context;
        private readonly IClienteService clienteService;

        public ClientesController(ApiControleServicoContext context, IClienteService clienteService)
        {
            _context = context;
            this.clienteService = clienteService;
        }

        // GET: api/Clientes
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            var resultList = await clienteService.GetAll();
            var result = resultList.OrderBy(o => o.Nome).ToList();
            return result;
            // return await _context.Cliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("getbyid:{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await clienteService.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5 To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update:{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            await clienteService.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("remove:{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await clienteService.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        [HttpGet("searchstring:{string}")]
        public async Task<ActionResult<List<Cliente>>> GetWtihString(string texto)
        {
            var result = await clienteService.GetWithName(texto);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}