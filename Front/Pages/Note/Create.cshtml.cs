using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Front.Data;
using Front.VModel;
using System.Security.Cryptography;

namespace Front.Pages.Note
{
    public class CreateModel : PageModel
    {
        private readonly Front.Data.ApplicationDbContext _context;
        private int pathId;

        public CreateModel(Front.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            pathId = id;                
            return Page();
        }

        [BindProperty]
        public NoteVM NoteVM { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.NoteVM == null || NoteVM == null)
            {
                return Page();
            }

            _context.NoteVM.Add(NoteVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
