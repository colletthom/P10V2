using back_gestionDesNotes.Model;
using back_gestionDesNotes.Data;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace back_gestionDesNotes.Controllers
{
    [Route("API/[Controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationMongoDbContext _context;

        public NoteController(ApplicationMongoDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filter = Builders<Note>.Filter.Eq(x => x.Id, id);
            var Notes = await _context.Notes.Find(filter).ToListAsync();
            return Ok(Notes);
        }
    }
}
