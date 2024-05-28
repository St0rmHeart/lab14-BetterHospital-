using System.Diagnostics.Metrics;

namespace lab14__BetterHospital_
{
    public class Laboratory : Agent
    {
        public Laboratory(Hospital hospital)
        {
            Hospital = hospital;
        }
        public Hospital Hospital { get; set; }
        public int ServiceTime { get; } = 20;
        public List<(Villager Patient, int AnalysisResultsDate)> OnLabPatients { get; set; } = [];

        public void AddPatientToLab(Villager patient)
        {
            OnLabPatients.Add((patient, Program.CurrentTime + ServiceTime));
            TimeOfNextEvent = OnLabPatients.Min(patient => patient.AnalysisResultsDate);
        }

        public override void ExecuteAction()
        {
            foreach (var (patient, analysisResultsDate) in OnLabPatients)
            {
                if(analysisResultsDate == Program.CurrentTime)
                {
                    patient.HealthStatus = EHealthStatus.OnTreatment;
                    patient.Disease = new Disease((EDiseaseName)Program.Random.Next(3), patient)
                    {
                        Severity = Program.Random.Next(1, 4)
                    };
                }
            }
            OnLabPatients.RemoveAll(patient => patient.AnalysisResultsDate == Program.CurrentTime);
        }
    }
}
