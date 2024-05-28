namespace lab14__BetterHospital_
{
	public class Disease
	{
        public Villager Owner { get; set; }
        public EDiseaseName DiseaseName { get; set; }

        private int _severity;
		public int Severity
        {
            get
            { 
                return _severity;
            }
            set
            {
                if (value > 0)
                {
                    DateOfNextRequest = Program.CurrentTime + Program.Random.Next(30, 61) / value;
                    Owner.TimeOfNextEvent = DateOfNextRequest;
                }
                _severity = value;
            } 
        }
		public int DateOfNextRequest { get; private set; }

		public Disease(EDiseaseName diseaseName, Villager owner)
        {
            Owner = owner;
            DiseaseName = diseaseName;
        }

        public EDiseaseName RandomDiseaseName()
        {
            Random rnd = new Random();
            return (EDiseaseName)rnd.Next(3);
        }
    }
}
