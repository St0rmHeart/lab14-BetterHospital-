namespace lab14__BetterHospital_
{
    public static class Program
    {
        public static Random Random { get; set; } = new();
        public static int CurrentTime { get; set; } = 0;
        public static List<Agent> Agents { get; set; } = [];
        public static Hospital Hospital { get; set; } = new();

        public static void Tick()
        {
            //������ ��������� ���� ����������� �������� 
            foreach (var member in Hospital.Population)
            {
                if(member.HealthStatus == EHealthStatus.Healthy)
                {
                    if (Random.NextDouble() < 0.01)
                    {
                        member.HealthStatus = EHealthStatus.UnknownDisease;
                        Hospital.AddToRegistryQueue(member);
                    }
                }
            }
            //������������ �������, ������� ������ ������ ���������
            foreach (var agent in Agents)
            {
                if(agent.TimeOfNextEvent == CurrentTime)
                {
                    agent.ExecuteAction();
                }
            }
            CurrentTime++;
        }



        static void Main()
        {
            

            for (int i = 0; i < 100; i++)
            {
                Tick();
            }


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}