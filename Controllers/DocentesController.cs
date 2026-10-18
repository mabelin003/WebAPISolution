using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISolution.Model;
using WebAPISolution.Context;

[Route("api/[controller]")]
//      api/docente
[ApiController]

public class DocenteController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public DocenteController(ApplicationDbContext context)
    {
        _context = context;
    }

    //GET: api/docente
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Docente>>> GetDocente()
    {
        return await _context.Docentes.ToListAsync();
    }

    //GET: api/Docente/5
    [HttpGet("{docenteid}")]
    public async Task<ActionResult<Docente>> GetDocente(int docenteid)
    {
        var docente = await _context.Docentes.FindAsync(docenteid);
        if (docente == null)
        {
            return NotFound();
        }
        return (docente);
    }

    //PUT: api/Docente/5
    //To protect from overposting attacks, see https://go.mocrosoft.com/fwlink/?linkid=2123754
    [HttpPut("{docenteid}")]
    public async Task<IActionResult> PutDocente(int? docenteid, Docente docente)
    {
        if (docenteid != docente.DocenteId)

        {
            return BadRequest();
        }

        _context.Entry(docente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DocenteExists(docenteid))
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
    //POST: api/Docente
    //To protect from overposting attacks, see https://go.mocrosoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Docente>> PostDocente(Docente docente)
    {
        _context.Docentes.Add(docente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDocente", new { docenteid = docente.DocenteId }, docente);
    }
    //DELETE: api/Docente/5
    [HttpDelete("{docenteid}")]

    public async Task<IActionResult> DeleteDocente(int? docenteid)
    {
        var docente = await _context.Docentes.FindAsync(docenteid);
        if (docente == null)
        {
            return NotFound();
        }
        _context.Docentes.Remove(docente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DocenteExists(int? docenteid)
    {
        return _context.Docentes.Any(e => e.DocenteId == docenteid);
    }
}
