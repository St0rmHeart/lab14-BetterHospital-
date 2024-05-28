using System;
using System.Collections.Generic;
using System.Text;

namespace lab14__BetterHospital_
{
	public class Villager
	{
		public int Immunity { get; set; }

		public HealthStatus HealthStatus { get; set; }

		public Disease Disease { get; set; }

		public List<HospitalVisit> Visits { get; set; }
		public Villager()
		{
			Immunity = new Random().Next(10);
			Disease = null;
			HealthStatus = HealthStatus.Healthy;
		}
	}
}
