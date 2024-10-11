using back_Patient.Data;
using back_Patient.Model;
using back_Patient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_Patient.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("API/[Controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly PatientService _patientService;

        public PatientController(ILogger<PatientController> logger, ApplicationDbContext context, PatientService patientService)
        {
            _logger = logger;
            _context = context;
            _patientService = patientService;
        }

        /// Checks if a cookie / key exists in the current HttpContext.
        /// </summary>
      /*  public bool CookieExist(string cookieName, string keyName)
        {
            IRequestCookieCollection cookies = _httpContextAccessor.HttpContext.Request.Cookies;
            //  HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
            return (String.IsNullOrEmpty(keyName))
                ? cookies[cookieName] != null
                : cookies[cookieName] != null && cookies[cookieName][keyName] != null;
        }*/
      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //  CookieExist(".AspNetCore.Identity.Application");
          //  string cookie = Request.Cookies[".AspNetCore.Identity.Application"];



            var ListePatients = new List<Patient>();
            try
            {
                ListePatients = await _context.Patients.ToListAsync();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex); 
            }

            return Ok(ListePatients);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Patient= await _context.Patients.FindAsync(id);
            return Ok(Patient);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedPatient = await _patientService.AddPatient(patient);
            return Ok(addedPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] Patient patient)
        {  if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedPatient = await _patientService.UpdatePatient(id, patient);

            if (!updatedPatient)
                return NotFound();

            var patientList = _context.Patients.ToList();
            return Ok(patientList);
        }
    }
}
