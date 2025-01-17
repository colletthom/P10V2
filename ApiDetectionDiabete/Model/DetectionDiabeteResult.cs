﻿using ApiDetectionDiabete.VModel;

namespace ApiDetectionDiabete.Model
{
    public class DetectionDiabeteResult
    {
        public string Statut { get; set; }
        public PatientVM Patient { get; set; }
        public List<NoteVM> Notes { get; set; }
    }
}