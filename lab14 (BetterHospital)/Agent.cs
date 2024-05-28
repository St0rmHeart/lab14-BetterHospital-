namespace lab14__BetterHospital_
{
    public abstract class Agent
    {
        public int AgentID { get; set; }
        public int TimeOfNextEvent { get; set; } = -1;
        public abstract void ExecuteAction();
    }
}
