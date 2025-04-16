﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;

namespace Clinic_Management_System.Services
{
    public class PatientService
    {
        private static List<Patient> _patients= new List<Patient>();

        public static void LoadPatients(List<Patient> patientsFromFile)
        {
            _patients = patientsFromFile;
        }

        public static List<Patient> GetAllForSaving()
        {
            return _patients;
        }

        public static void AddPatient(Patient patient)
        {
            _patients.Add(patient);
        }

        public static List<Patient> GetAllPatients ()
        {
            return _patients;
        }

        public static bool DeleteByMRN(int MRN)
        {
            var existingData = _patients.Find(p=>p.MedicalRecordNumber==MRN);
            if (existingData != null)
            {
                _patients.Remove(existingData);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPatientId(int id)
        {
            var exist = _patients.Find(p => p.Id == id);
            if (exist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
