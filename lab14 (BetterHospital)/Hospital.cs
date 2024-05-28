namespace lab14__BetterHospital_
{
    public class Hospital 
    {
        public int AmoutOfRegisters { get; } = 5;
        public int AmoutOfTherapists { get; } = 8;
        public int AmoutOfSurgeons { get; } = 4;
        public int AmoutOfPopulation { get; } = 200;


        public List<Villager> Population { get; } = [];
        public List<Villager> RegistryQueue { get; } = [];
        public List<Villager> TherapistQueue { get; } = [];
        public List<Villager> SurgeonQueue { get; } = [];

        public List<RegistryStaffMember> RegistryDepartment { get; } = [];
        public List<Therapist> TherapeuticDepartment { get; } = [];
        public List<Surgeon> SurgicalDepartment { get; } = [];

        public Laboratory Laboratory { get; }

        public Hospital()
        {
            for (int i = 0; i < AmoutOfRegisters; i++)
            {
                var registrator = new RegistryStaffMember(this);
                RegistryDepartment.Add(registrator);
                Program.Agents.Add(registrator);
            }
            for (int i = 0; i < AmoutOfTherapists; i++)
            {
                var therapist = new Therapist(this);
                TherapeuticDepartment.Add(therapist);
                Program.Agents.Add(therapist);
            }
            for (int i = 0; i < AmoutOfSurgeons; i++)
            {
                var surgeon = new Surgeon(this);
                SurgicalDepartment.Add(surgeon);
                Program.Agents.Add(surgeon);
            }
            for(int i = 0; i < AmoutOfPopulation; i++)
            {
                var villager = new Villager(this);
                Population.Add(villager);
                Program.Agents.Add(villager);
            }
            Laboratory = new Laboratory(this);
            Program.Agents.Add(Laboratory);
        }
        public void AddToRegistryQueue(Villager villager)
        {
            RegistryQueue.Add(villager);
            foreach (var registrator in RegistryDepartment)
            {
                if (registrator.IsFree)
                {
                    registrator.StartService();
                    return;
                }
            }
        }
        public void AddToTherapistQueue(Villager villager)
        {
            TherapistQueue.Add(villager);
            foreach (var therapis in TherapeuticDepartment)
            {
                if (therapis.IsFree)
                {
                    therapis.StartService();
                    return;
                }
            }
        }
        public void AddToSurgeonQueue(Villager villager)
        {
            SurgeonQueue.Add(villager);
            foreach (var surgeon in SurgicalDepartment)
            {
                if (surgeon.IsFree)
                {
                    surgeon.StartService();
                    return;
                }
            }
        }

    }
}
