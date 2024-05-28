namespace lab14__BetterHospital_
{
	public class Therapist : HospitalStaffMember
    {
        public override void StartService()
        {
            //1. ��������� ������� �� ������� ��������
            if (Hospital.RegistryQueue.Count != 0)
            {
                IsFree = false;
                Patient = Hospital.TherapistQueue[0];
                Hospital.TherapistQueue.RemoveAt(0);
                TimeOfNextEvent = Program.CurrentTime + CalculateServiceLength();
            }
            else
            {
                IsFree = true;
            }
        }
        public override void EndService()
        {
            //1.��������� �������� � ������ �������
            if (Patient.Disease?.DiseaseName == DiseaseName.Tumor)
            {
                Hospital.SurgeonQueue.Add(Patient);
            }
            else //���� ����� ��� ��������� - ��� ���� ��������� � ������� �� �������� �� N �����
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
            if (Patient.HealthStatus == HealthStatus.UnknownDisease)
            {
                Patient.HealthStatus = HealthStatus.OnTreatment;
            }
            EndService();
        }
    }
}
