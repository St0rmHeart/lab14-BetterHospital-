using System.Diagnostics.PerformanceData;

namespace lab14__BetterHospital_
{
    public abstract class Agent
    {
        public int AgentID { get; set; }
        private static int _idCounter = 0;
        public int TimeOfNextEvent { get; set; } = -1;
        public abstract void ExecuteAction();
        public void SetID()
        {
            AgentID = _idCounter;
            _idCounter++;
        }
    }
}
