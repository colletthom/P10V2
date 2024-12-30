using back_gestionDesNotes.Models;
using Microsoft.AspNetCore.Mvc;
using back_gestionDesNotes.Service;
using Microsoft.AspNetCore.Authorization;

namespace back_gestionDesNotes.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    public class NoteController : ControllerBase
    {
        private readonly NotesService _notesService;

        public NoteController(NotesService notesService)
        {
            _notesService = notesService;
        }
        
        [HttpGet]
        public async Task<List<Note>> Get() =>
            await _notesService.GetAsync();

        [HttpGet("{patId}")]
        public async Task<ActionResult<List<Note>>> GetPatient(int patId)
        {
            var note = await _notesService.GetPatientAsync(patId);

            if (note is null)
            {
                return NotFound();
            }

            return note ;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Note newNote)
        {
            //dans le swagger retirer "Id": "string",
            await _notesService.CreateAsync(newNote);

            return CreatedAtAction(nameof(Get), new { id = newNote.Id }, newNote);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Note updatedNote)
        {
            var note = await _notesService.GetAsync(id);

            if (note is null)
            {
                return NotFound();
            }

            updatedNote.patId = note.patId;

            await _notesService.UpdateAsync(id, updatedNote);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var note = await _notesService.GetAsync(id);

            if (note is null)
            {
                return NotFound();
            }

            await _notesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
