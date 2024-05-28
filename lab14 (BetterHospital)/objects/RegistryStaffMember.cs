namespace lab14__BetterHospital_
{
    public class RegistryStaffMember : HospitalStaffMember
    {
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
            else
            { 
                IsFree = true;
            }
        }
        public override void EndService()
        {
            //1.Направить пациента в нужную очередь
            if(Patient.Disease?.DiseaseName == DiseaseName.BoneFracture)
            {
                Hospital.SurgeonQueue.Add(Patient);
            }
            else
            {
                Hospital.TherapistQueue.Add(Patient);
            }
            StartService();
        }

        public override int CalculateServiceLength()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteAction()
        {
            EndService();
        }
    }
}
