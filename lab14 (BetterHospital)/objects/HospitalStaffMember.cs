namespace lab14__BetterHospital_
{
    public abstract class HospitalStaffMember : Agent
    {
        public HospitalStaffMember(Hospital hospital) : base()
        {
            Hospital = hospital;
            IsFree = true;
            SetID();
        }   
        public Hospital Hospital { get; set; }
        public int Productivity { get; } = Program.Random.Next(5);
        protected Villager Patient { get; set; }
        public bool IsFree { get; set; }

        public abstract void StartService();
        public abstract void EndService();
        public abstract int CalculateServiceLength();

    }
}
