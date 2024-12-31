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
        private readonly HttpClient _client;
        private int pathId;

        public CreateModel(Front.Data.ApplicationDbContext context, HttpClient client)
        {
            _context = context;
            _client = client;
        }

        [BindProperty]
        public NoteVM NoteVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var patient = await _client.GetFromJsonAsync<PatientVM>($"http://ApiGateway:5010/API/patient-back/{id}");

            if (patient == null )
            {
                return NotFound();
            }

            NoteVM.patId = id.ToString();
            NoteVM.patient = patient.Nom;

            return Page();
        }

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
