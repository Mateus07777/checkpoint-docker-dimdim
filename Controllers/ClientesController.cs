using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DimDimAPP.Data;
using DimDimAPP.Models;

namespace DimDimAPP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Post(Cliente cliente)
    {
        _context.Clientes.Add(cliente);

        await _context.SaveChangesAsync();

        return Ok(cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cliente cliente)
    {
        var clienteBanco = await _context.Clientes.FindAsync(id);

        if (clienteBanco == null)
            return NotFound();

        clienteBanco.Nome = cliente.Nome;
        clienteBanco.Email = cliente.Email;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        _context.Clientes.Remove(cliente);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}