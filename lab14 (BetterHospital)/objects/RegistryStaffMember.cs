namespace lab14__BetterHospital_
{
    public class RegistryStaffMember : HospitalStaffMember
    {
        public RegistryStaffMember(Hospital hospital) : base(hospital)
        {
        }
        public override void StartService()
        {
            //1. подозвать персого из очереди пациента
            if (Hospital.RegistryQueue.Count != 0)
            {
                IsFree = false;
                Patient = Hospital.RegistryQueue[0];
                Hospital.RegistryQueue.RemoveAt(0);
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
            return new Random().Next(5, 8) - Productivity;
        }

        public override void ExecuteAction()
        {
            switch (Patient.HealthStatus)
            {
                case EHealthStatus.UnknownDisease:
                    Hospital.AddToTherapistQueue(Patient);
                    break;
                case EHealthStatus.OnTreatment:
                    switch (Patient.Disease.DiseaseName)
                    {
                        case EDiseaseName.Fever:
                        case EDiseaseName.Covid:
                            Hospital.AddToTherapistQueue(Patient);
                            break;
                        case EDiseaseName.BoneFracture:
                        case EDiseaseName.Tumor:
                            Hospital.AddToSurgeonQueue(Patient);
                            break;
                        default:
                            throw new Exception();
                    }
                    break;
                default:
                    throw new Exception();
            }
            EndService();
        }
    }
}
