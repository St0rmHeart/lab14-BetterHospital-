namespace lab14__BetterHospital_
{
	public class Therapist : HospitalStaffMember
    {
        public Therapist(Hospital hospital) : base(hospital) { }
        public override void StartService()
        {
            //1. подозвать персого из очереди пациента
            if (Hospital.TherapistQueue.Count != 0)
            {
                IsFree = false;
                Patient = Hospital.TherapistQueue[0];
                Hospital.TherapistQueue.RemoveAt(0);
                TimeOfNextEvent = Program.CurrentTime + CalculateServiceLength();
            }
        }
        public override void EndService()
        {
            Patient = null;
            IsFree = true;
            StartService();
        }

        public override int CalculateServiceLength()
        {
            return new Random().Next(5, 10) - Productivity;
        }

        public override void ExecuteAction()
        {
            switch (Patient.HealthStatus)
            {
                case EHealthStatus.UnknownDisease:
                    //20%, что это очевидная простуда
                    if (Program.Random.NextDouble() < 0.2)
                    {
                        Patient.HealthStatus = EHealthStatus.OnTreatment;
                        Patient.Disease = new Disease(EDiseaseName.Fever, Patient)
                        {
                            Severity = Program.Random.Next(1, 4)
                        };
                    }
                    //10%, что это перелом
                    if (Program.Random.NextDouble() < 0.1)
                    {
                        Patient.HealthStatus = EHealthStatus.OnTreatment;
                        Patient.Disease = new Disease(EDiseaseName.BoneFracture, Patient)
                        {
                            Severity = Program.Random.Next(1, 4)
                        };
                    }
                    else //нужны анализы
                    {
                        Hospital.Laboratory.AddPatientToLab(Patient);
                        EndService();
                        return;
                    }
                    break;

                case EHealthStatus.OnTreatment:
                    double severityDecrementChance;
                    switch (Patient.Disease.DiseaseName)
                    {
                        case EDiseaseName.Fever:
                            severityDecrementChance = 1.5 * Patient.Immunity + 35 * (4 - Patient.Disease.Severity);
                            CheckForSeverityDecrement(severityDecrementChance);
                            break;
                        case EDiseaseName.Covid:
                            severityDecrementChance = 1 * Patient.Immunity + 15 * (4 - Patient.Disease.Severity);
                            CheckForSeverityDecrement(severityDecrementChance);
                            break;
                        default:
                            throw new Exception("ПАЦИЕНТ С ПЕРЕЛОМОМ");
                    }
                    break;
                default:
                    throw new Exception("ЗДОРОВЫЙ ПАЦИЕНТ");
            }

            if (Patient.Disease.Severity == 0)
            {
                Patient.Recover();
            }


            EndService();
        }


        public void CheckForSeverityDecrement(double severityDecrementChance)
        {
            if (Program.Random.NextDouble() < severityDecrementChance)
            {
                Patient.Disease.Severity = Patient.Disease.Severity - 1;
            }
            else
            {
                Patient.Disease.Severity = Patient.Disease.Severity;
            }
        }

    }
}
