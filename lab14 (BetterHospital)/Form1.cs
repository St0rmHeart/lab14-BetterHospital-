namespace lab14__BetterHospital_
{
    public partial class Form1 : Form
    {
        private bool _isRunning = false;
        public static int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                timer1.Stop();
                _isRunning = false;
                button1.Text = "Старт";
            }
            else
            {
                timer1.Start();
                _isRunning = true;
                button1.Text = "Стоп";
            }
        }

        private void UpdateVisuals()
        {
            UpdateRegistryQueue();

            UpdateTherapistQueue();

            UpdateSurgeonQueue();

            UpdateRegisters();

            UpdateTherapists();

            UpdateSurgeons();

            UpdatePatients();
            
            label13.Text = $"Количество людей, ждущих анализ из лаборатории: {Program.Hospital.Laboratory.OnLabPatients.Count}";

        }

        private void UpdateRegistryQueue()
        {
            string registryQueue = "";

            for (int i = 0; i < Program.Hospital.RegistryQueue.Count; i++)
            {
                registryQueue += " id:" + Program.Hospital.RegistryQueue[i].AgentID + "\n";
            }
            label1.Text = "Очередь регистрации:\n" + registryQueue;
        }

        private void UpdateTherapistQueue()
        {
            string therapistQueue = "";

            for (int i = 0; i < Program.Hospital.TherapistQueue.Count; i++)
            {
                therapistQueue += " id:" + Program.Hospital.TherapistQueue[i].AgentID + "\n";
            }
            label2.Text = "Очередь к терапевту:\n" + therapistQueue;
        }

        private void UpdateSurgeonQueue()
        {
            string surgeonQueue = "";

            for (int i = 0; i < Program.Hospital.SurgeonQueue.Count; i++)
            {
                surgeonQueue += " id:" + Program.Hospital.SurgeonQueue[i].AgentID + "\n";
            }

            label3.Text = "Очередь к хирургу:\n" + surgeonQueue;
        }

        private void UpdateRegisters()
        {
            string registers = "";

            for (int i = 0; i < Program.Hospital.RegistryDepartment.Count; i++)
            {
                registers += " id:" + Program.Hospital.RegistryDepartment[i].AgentID + " ";
                if (!Program.Hospital.RegistryDepartment[i].IsFree)
                {
                    registers += $" лечит id:{Program.Hospital.RegistryDepartment[i].GetPatientID()}\n";
                }
                else
                {
                    registers += " свободен\n";
                }
            }

            label4.Text = "Регистраторы:\n" + registers;
        }

        private void UpdateTherapists()
        {
            string therapists = "";

            for (int i = 0; i < Program.Hospital.TherapeuticDepartment.Count; i++)
            {
                therapists += " id:" + Program.Hospital.TherapeuticDepartment[i].AgentID + " ";
                if (!Program.Hospital.TherapeuticDepartment[i].IsFree)
                {
                    therapists += $" лечит id:{Program.Hospital.TherapeuticDepartment[i].GetPatientID()}\n";
                }
                else
                {
                    therapists += " свободен\n";
                }
            }

            label5.Text = "Терапевты:\n" + therapists;
        }

        private void UpdateSurgeons()
        {
            string surgeons = "";

            for (int i = 0; i < Program.Hospital.SurgicalDepartment.Count; i++)
            {
                surgeons += " id:" + Program.Hospital.SurgicalDepartment[i].AgentID + " ";
                if (!Program.Hospital.SurgicalDepartment[i].IsFree)
                {
                    surgeons += $" лечит id:{Program.Hospital.SurgicalDepartment[i].GetPatientID()}\n";
                }
                else
                {
                    surgeons += " свободен\n";
                }
            }

            label6.Text = "Хирурги:\n" + surgeons;
        }

        private void UpdatePatients()
        {
            int[] counters = new int[3];

            List<string> populationlist = [];
            string population1 = "";
            string population2 = "";
            string population3 = "";
            string population4 = "";
            string population5 = "";
            populationlist.Add(population1);
            populationlist.Add(population2);
            populationlist.Add(population3);
            populationlist.Add(population4);
            populationlist.Add(population5);

            int j = 0;
            for (int i = 0; i < Program.Hospital.Population.Count; i++)
            {

                if (i % 50 == 0 && i != 0)
                {
                    j++;
                }


                populationlist[j] += " id:" + Program.Hospital.Population[i].AgentID + " ";
                if (Program.Hospital.Population[i].HealthStatus == EHealthStatus.OnTreatment)
                {
                    populationlist[j] += $" лечится от {Program.Hospital.Population[i].Disease.DiseaseName}\n";
                    counters[0]++;
                }
                else if (Program.Hospital.Population[i].HealthStatus == EHealthStatus.UnknownDisease)
                {
                    populationlist[j] += $"неизвестная болезнь\n";
                    counters[1]++;
                }
                else
                {
                    populationlist[j] += $" здоров \n";
                    counters[2]++;
                }


            }


            label7.Text = "Пациенты:\n" + populationlist[0];
            label8.Text = populationlist[1];
            label9.Text = populationlist[2];
            label10.Text = populationlist[3];
            label11.Text = populationlist[4];

            string tabulation = "    ";

            label12.Text = $"Лечатся: {counters[0]} {tabulation}{tabulation} Неизвестная болезнь: {counters[1]} {tabulation}{tabulation} Здоровы: {counters[2]}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Program.Tick();
            UpdateVisuals();
        }
    }
}
