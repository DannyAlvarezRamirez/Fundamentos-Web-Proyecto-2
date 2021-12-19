using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_2.Data;
using Proyecto_2.Models;

namespace Proyecto_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosClientesController : ControllerBase
    {
        private readonly Proyecto_2Context _context;

        public ProyectosClientesController(Proyecto_2Context context)
        {
            _context = context;
        }

        // GET: api/ProyectosClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProyectoCliente>>> GetProyectoCliente()
        {
            return await _context.ProyectoCliente.ToListAsync();
        }

        // GET: api/ProyectosClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProyectoCliente>> GetProyectoCliente(int id)
        {
            var proyectoCliente = await _context.ProyectoCliente.FindAsync(id);

            if (proyectoCliente == null)
            {
                return NotFound();
            }

            return proyectoCliente;
        }

        // PUT: api/ProyectosClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]//("{id}")]
        public async Task<IActionResult> PutProyectoCliente(ProyectoCliente proyectoCliente)
        {
            //if (id != proyectoCliente.id_proyecto)
            //{
            //    return BadRequest();
            //}

            _context.Entry(proyectoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProyectoClienteExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                return NotFound();//borrar si quito comentarios arriba
            }

            return NoContent();
        }

        // POST: api/ProyectosClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProyectoCliente>> PostProyectoCliente(ProyectoCliente proyectoCliente)
        {
            _context.ProyectoCliente.Add(proyectoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectoCliente", new { id = proyectoCliente.id_proyecto }, proyectoCliente);
        }

        // DELETE: api/ProyectosClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectoCliente(int id)
        {
            var proyectoCliente = await _context.ProyectoCliente.FindAsync(id);
            if (proyectoCliente == null)
            {
                return NotFound();
            }

            _context.ProyectoCliente.Remove(proyectoCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoClienteExists(int id)
        {
            return _context.ProyectoCliente.Any(e => e.id_proyecto == id);
        }
    }
}
