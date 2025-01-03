using ApiDetectionDiabete.VModel;
using System.Text.RegularExpressions;

namespace ApiDetectionDiabete.Service;

public class DetectionDiabeteService
{
    public string calculRisqueDiabete(PatientVM patientVM, IList<NoteVM> notesDuPatient)
    {
        string risqueDiabete = "none";

        bool isMoins30Ans = patientVM.DateNaissance.AddYears(30) > DateTime.Now;
        Char sexePatient = char.ToLower(patientVM.Genre);


        int nombreDeclencheurs = CalculNombreDeclencheurs(notesDuPatient);
        risqueDiabete = CalculRisqueDiabete(isMoins30Ans, sexePatient, nombreDeclencheurs);
        return risqueDiabete;
    }

    private string CalculRisqueDiabete(bool isMoins30Ans, Char sexePatient, int nombreDeclencheurs)
    {
        if (isMoins30Ans && sexePatient == 'm')
        {
            if (nombreDeclencheurs > 4)
            {
                return ("Early onset");
            }
            else if (nombreDeclencheurs > 2)
            {
                return ("In Danger");
            }
            else
            {
                return ("None");
            }
        }
        else if (isMoins30Ans && sexePatient == 'f')
        {
            if (nombreDeclencheurs > 6)
            {
                return ("Early onset");
            }
            else if (nombreDeclencheurs > 3)
            {
                return ("In Danger");
            }
            else
            {
                return ("None");
            }
        }
        else
        {
            if (nombreDeclencheurs > 7)
            {
                return ("Early onset");
            }
            else if (nombreDeclencheurs > 5)
            {
                return ("In Danger");
            }
            else if (nombreDeclencheurs > 1)
            {
                return ("Borderline");
            }
            else
            {
                return ("None");
            }
        }
    }

    private int CalculNombreDeclencheurs(IList<NoteVM> notesDuPatient)
    {
        int nombreDeclencheurs = 0;
        IList<Regex> facteursDeclencheur = new List<Regex>()
        {
            new Regex(@"H[éèe]moglobine A1C", RegexOptions.IgnoreCase),
            new Regex(@"Microalbumine", RegexOptions.IgnoreCase),
            new Regex(@"Taille", RegexOptions.IgnoreCase),
            new Regex(@"Poids", RegexOptions.IgnoreCase),
            new Regex(@"Fumeur", RegexOptions.IgnoreCase),
            new Regex(@"Fumeuse", RegexOptions.IgnoreCase),
            new Regex(@"Fumer", RegexOptions.IgnoreCase),
            new Regex(@"Anormal", RegexOptions.IgnoreCase),
            new Regex(@"cholest[eéè]rol", RegexOptions.IgnoreCase),
            new Regex(@"Vertiges?", RegexOptions.IgnoreCase),
            new Regex(@"Rechute", RegexOptions.IgnoreCase),
            new Regex(@"R[éeè]action", RegexOptions.IgnoreCase),
            new Regex(@"Anticorps", RegexOptions.IgnoreCase),
        };

        foreach (var regex in facteursDeclencheur)
        {
            bool isFacteurPresent = notesDuPatient.Any(note => regex.IsMatch(note.note));
            if (isFacteurPresent)
            {
                nombreDeclencheurs++;
            }
        }
        return nombreDeclencheurs;
    }
}
