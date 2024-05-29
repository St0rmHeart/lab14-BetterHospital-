namespace lab14__BetterHospital_
{
    public class Surgeon : HospitalStaffMember
    {
        //событие передаёт True если начат приём, False если окончен приём
        delegate void InSurgeonHandler(bool startOrEnd);
        event InSurgeonHandler? Notify;
        public Surgeon(Hospital hospital) : base(hospital) { } 
        public override void StartService()
        {
            // ПОДОЗВАТЬ ПЕРСОВ
            if (Hospital.SurgeonQueue.Count != 0)
            {
                IsFree = false;
                Patient = Hospital.SurgeonQueue[0];
                Hospital.SurgeonQueue.RemoveAt(0);
                TimeOfNextEvent = Program.CurrentTime + CalculateServiceLength();
                Notify?.Invoke(true);
            }
        }
        public override void EndService()
        {
            Patient = null;
            IsFree = true;
            Notify?.Invoke(false);
            StartService();
        }

        public override int CalculateServiceLength()
        {
            var lenth = Program.Random.Next(1, 15) - Productivity * 2;
            if (Patient.Disease.DiseaseName == EDiseaseName.Tumor)
            {
                //проводим операцию
                lenth += 7 * Patient.Disease.Severity;
            }
            return lenth;
        }

        public override void ExecuteAction()
        {
            //Направить пациента в нужную очередь
            switch (Patient.Disease.DiseaseName)
            {
                case EDiseaseName.Tumor:
                    Patient.Recover();
                    break;
                case EDiseaseName.BoneFracture:
                    if (Patient.Disease.Severity > 0)
                    {
                        Patient.Disease.Severity = Patient.Disease.Severity - 1;
                    }
                    if (Patient.Disease.Severity == 0)
                    {
                        Patient.Recover();
                    }
                    break;
                default:
                    throw new Exception();
            }
            EndService();
        }
    }
}
