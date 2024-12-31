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
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Front.Pages.Note
{
    public class CreateModel : PageModel
    {
        private readonly Front.Data.ApplicationDbContext _context;
        private string? errorMessage;
        public CreateModel(Front.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreationNoteVM creationNoteVM { get; set; } = new CreationNoteVM();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            using var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            };
            using var client = new HttpClient(handler);

            var patient = await client.GetFromJsonAsync<PatientVM>($"https://ApiGateway:5011/API/patient-back/{id}");

            if (patient == null )
            {
                return NotFound();
            }

            creationNoteVM.patId = id;
            creationNoteVM.patient = patient.Nom;
            creationNoteVM.note = "test";
            Console.WriteLine($"{creationNoteVM.patId}  {creationNoteVM.patient}");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("2");
            try
            {
              /*  Console.WriteLine($"ModelState.IsValid:{ModelState.IsValid} _context.NoteVM:{_context.NoteVM} creationNoteVM:{creationNoteVM} ");
                if (!ModelState.IsValid || _context.NoteVM == null || creationNoteVM == null)
                {
                    return Page();
                }*/

                using var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
                using var client = new HttpClient(handler);
                var response = await client.PostAsJsonAsync<CreationNoteVM>($"https://ApiGateway:5011/API/gestiondesnotes-back/", creationNoteVM);

                // _context.NoteVM.Add(creationNoteVM);
                // await _context.SaveChangesAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                  //  NavigationManager.NavigateTo("/ListePatients");
                    return RedirectToPage("./ListePatients");
                }
                else
                {
                    // Gérer l'erreur de création du patient
                    errorMessage = "Une erreur s'est produite lors de la création du patient : " + response.ReasonPhrase;
                    return RedirectToPage("./Index");
                }
            }
            catch (HttpRequestException ex)
            {
                errorMessage = "Une erreur s'est produite lors de la mise à jour du patient : " + ex.Message + "\n" + ex.StackTrace;
                return Page();
            }
        }
    }
}
