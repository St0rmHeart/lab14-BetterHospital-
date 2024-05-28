namespace lab14__BetterHospital_
{
    public abstract class HospitalStuffMember : Agent
    {
        public Hospital Hospital { get; set; }
        public int Productivity { get; set; }
        protected Villager Patient { get; set; }
        public bool IsFree { get; set; }

        public abstract void StartService();
        public abstract void EndService();
        public abstract int CalculateServiceLenth();

    }
}
