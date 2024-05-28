using System;
using System.Collections.Generic;
using System.Text;

namespace lab14__BetterHospital_
{
	public class HospitalVisit
	{
		public int RegistryQueue { get; set; }

		public int RegirstryAppointment { get; set; }

		public int TherapistQueue { get; set; }

		public int TherapistAppointment { get; set; }

		public int SurgeonQueue { get; set; }

		public int SurgeonAppointment { get; set; }

		public bool IsTested { get; set; }
	}
}
