namespace lab14__BetterHospital_
{
    public static class Program
    {
        public static int CurrentTime { get; set; } = 0;
        private static int _agentID = 0;
        public static int AgentID { get { _agentID++; return _agentID; } }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}