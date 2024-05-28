namespace lab14__BetterHospital_
{
	public class Disease
	{
		public DiseaseName DiseaseName { get; set; }

		public int Severity { get; set; }

		public int UntilNextRequest { get; set; }

		public Disease()
        {
            DiseaseName = RandomDiseaseName();
            Severity = new Random().Next(1, 3);
        }

        public DiseaseName RandomDiseaseName()
        {
            Random rnd = new Random();
            return (DiseaseName)rnd.Next(3);
        }
    }
}
