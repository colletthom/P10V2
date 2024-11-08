using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Front.Data;
using Front.VModel;

namespace Front.Pages.Note
{
    public class EditModel : PageModel
    {
        private readonly Front.Data.ApplicationDbContext _context;

        public EditModel(Front.Data.ApplicationDbContext context)
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

            var notevm =  await _context.NoteVM.FirstOrDefaultAsync(m => m.id == id);
            if (notevm == null)
            {
                return NotFound();
            }
            NoteVM = notevm;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NoteVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteVMExists(NoteVM.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NoteVMExists(int id)
        {
          return (_context.NoteVM?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
