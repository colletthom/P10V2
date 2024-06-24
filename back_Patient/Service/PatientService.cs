using back_Patient.Data;
using back_Patient.Model;

namespace back_Patient.Service
{
    public class PatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            var _patient = new Patient
            {
                Prenom = patient.Prenom,
                Nom = patient.Nom,
                DateNaissance = patient.DateNaissance,
                Genre = patient.Genre,
                AdressePostale = patient.AdressePostale,
                Telephone = patient.Telephone
            };
            _context.Patients.Add(_patient);
            await _context.SaveChangesAsync();
            return _patient;
        }

        public async Task<bool> UpdatePatient(int id, Patient patient)
        {
            var _patient = _context.Patients.Find(id);
            if (_patient == null)
            {
                return false;
            }

            _patient.Prenom = patient.Prenom;
            _patient.Nom = patient.Nom;
            _patient.DateNaissance = patient.DateNaissance;
            _patient.Genre = patient.Genre;
            _patient.AdressePostale = patient.AdressePostale;
            _patient.Telephone = patient.Telephone;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
