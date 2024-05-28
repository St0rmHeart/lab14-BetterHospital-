namespace lab14__BetterHospital_
{
    public class Surgeon : HospitalStaffMember
    {
        public override void StartService()
        {
            //1. подозвать персого из очереди пациента
            if (Hospital.RegistryQueue.Count != 0)
            {
                IsFree = false;
                Patient = Hospital.SurgeonQueue[0];
                Hospital.SurgeonQueue.RemoveAt(0);
                TimeOfNextEvent = Program.CurrentTime + CalculateServiceLength();
            }
            else
            {
                IsFree = true;
            }
        }
        public override void EndService()
        {
            //1.Направить пациента в нужную очередь
            if (Patient.Disease?.DiseaseName == DiseaseName.Tumor) //вырезали опухоль и катись отсюда
            {
                Patient.HealthStatus = HealthStatus.Healthy;
                Patient.Disease = null;
                Patient = null;
            }
            else //если ковид или лихорадка - его надо пролечить и выпнуть из больницы на N тиков
            {
                Patient.Disease.Severity--;
                Hospital.TherapistQueue.Add(Patient);
            }
            StartService();
        }

        public override int CalculateServiceLength()
        {
            return new Random().Next(10);
        }

        public override void ExecuteAction()
        {
            EndService();
        }
    }
}
