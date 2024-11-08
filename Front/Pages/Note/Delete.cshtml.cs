using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Front.Data;
using Front.VModel;

namespace Front.Pages.Note
{
    public class DeleteModel : PageModel
    {
        private readonly Front.Data.ApplicationDbContext _context;

        public DeleteModel(Front.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public NoteVM NoteVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NoteVM == null)
            {
                return NotFound();
            }

            var notevm = await _context.NoteVM.FirstOrDefaultAsync(m => m.id == id);

            if (notevm == null)
            {
                return NotFound();
            }
            else 
            {
                NoteVM = notevm;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.NoteVM == null)
            {
                return NotFound();
            }
            var notevm = await _context.NoteVM.FindAsync(id);

            if (notevm != null)
            {
                NoteVM = notevm;
                _context.NoteVM.Remove(NoteVM);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
