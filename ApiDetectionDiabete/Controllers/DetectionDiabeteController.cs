using ApiDetectionDiabete.Model;
using ApiDetectionDiabete.Service;
using ApiDetectionDiabete.VModel;
using Microsoft.AspNetCore.Mvc;


namespace ApiDetectionDiabete.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    public class DetectionDiabeteController : ControllerBase
    {
        private readonly DetectionDiabeteService _detectionDiabeteService;
        public DetectionDiabeteController(DetectionDiabeteService detectionDiabeteService)
        {
            _detectionDiabeteService = detectionDiabeteService;
        }

        [HttpGet("{idPatient}")]
        public async Task<IActionResult> GetStatutDiabete(int idPatient)
        {
            try
            {
                using var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
                using var client = new HttpClient(handler);

                var patient = await client.GetFromJsonAsync<PatientVM>($"https://ApiGateway:5011/API/patient-back/{idPatient}");
                var notesDuPatient = await client.GetFromJsonAsync<List<NoteVM>>($"https://ApiGateway:5011/API/gestiondesnotes-back/{idPatient}");
                string StatutDetectionDiabete = _detectionDiabeteService.calculRisqueDiabete(patient, notesDuPatient);
                var result = new DetectionDiabeteResult
                {
                    Statut = StatutDetectionDiabete,
                    Patient = patient,
                    Notes = notesDuPatient
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
