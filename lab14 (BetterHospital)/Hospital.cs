namespace lab14__BetterHospital_
{
    public class Hospital 
    {
        public int AmoutOfRegisters { get; } = 5;
        public int AmoutOfTherapists { get; } = 8;
        public int AmoutOfSurgeons { get; } = 4;

        public List<Villager> RegistryQueue { get; } = [];
        public List<Villager> TherapistQueue { get; } = [];
        public List<Villager> SurgeonQueue { get; } = [];

        public List<RegistryStaffMember> RegistryDepartment { get; } = [];
        public List<Therapist> TherapeuticDepartment { get; } = [];
        public List<Therapist> SurgicalDepartment { get; } = [];
        public Hospital()
        {

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
    }
}
