using System;
using System.Collections.Generic;
using System.Text;

namespace lab14__BetterHospital_
{
	public class Villager : Agent
	{
		public Hospital Hospital { get; set; }
		public int Immunity { get; }

		public EHealthStatus HealthStatus { get; set; }

		public Disease Disease { get; set; }

		public List<HospitalVisit> Visits { get; set; }
		public Villager(Hospital hospital)
		{
			Hospital = hospital;
			Immunity = new Random().Next(10);
			Disease = null;
			HealthStatus = EHealthStatus.Healthy;
			SetID();
		}
		public void Recover()
		{
			Disease = null;
			HealthStatus = EHealthStatus.Healthy;
			TimeOfNextEvent = -1;
        }
        public override void ExecuteAction()
        {
            Hospital.AddToRegistryQueue(this);
        }
    }
}
