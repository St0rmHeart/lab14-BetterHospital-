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
            //Каждое мгновение есть вероятность заболеть 
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
            //Обрабатываем агентов, которые должны сейчас сработать
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

            ApplicationConfiguration.Initialize();
            Form1 form1 = new Form1();
            Application.Run(form1);
        }
    }
}