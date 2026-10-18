using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISolution.Model;
using WebAPISolution.Context;

[Route("api/[controller]")]
//      api/curso
[ApiController]

public class CursoController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CursoController(ApplicationDbContext context)
    {
        _context = context;
    }

    //GET: api/Curso
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
    {
        return await _context.Cursos.ToListAsync();
    }

    //GET: api/Curso/5
    [HttpGet("{cursoid}")]
    public async Task<ActionResult<Curso>> GetCurso(int cursoid)
    {
        var curso = await _context.Cursos.FindAsync(cursoid);
        if (curso == null)
        {
            return NotFound();
        }
        return (curso);
    }

    //PUT: api/Curso/5
    //To protect from overposting attacks, see https://go.mocrosoft.com/fwlink/?linkid=2123754
    [HttpPut("{cursoid}")]
    public async Task<IActionResult> PutCurso(int? cursoid, Curso curso)
    {
        if (cursoid != curso.CursoId)

        {
            return BadRequest();
        }

        _context.Entry(curso).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CursoExists(cursoid))
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
    //POST: api/Curso
    //To protect from overposting attacks, see https://go.mocrosoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Curso>> PostCurso(Curso curso)
    {
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCurso", new { cursoid = curso.CursoId }, curso);
    }
    //DELETE: api/Curso/5
    [HttpDelete("{cursoid}")]

    public async Task<IActionResult> DeleteCurso(int? cursoid)
    {
        var curso = await _context.Cursos.FindAsync(cursoid);
        if (curso == null)
        {
            return NotFound();
        }
        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CursoExists(int? cursoid)
    {
        return _context.Cursos.Any(e => e.CursoId == cursoid);
    }
}
