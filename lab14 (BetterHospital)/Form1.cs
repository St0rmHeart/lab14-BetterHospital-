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
                button1.Text = "�����";
            }
            else
            {
                timer1.Start();
                _isRunning = true;
                button1.Text = "����";
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
            
            label13.Text = $"���������� �����, ������ ������ �� �����������: {Program.Hospital.Laboratory.OnLabPatients.Count}";

        }

        private void UpdateRegistryQueue()
        {
            string registryQueue = "";

            for (int i = 0; i < Program.Hospital.RegistryQueue.Count; i++)
            {
                registryQueue += " id:" + Program.Hospital.RegistryQueue[i].AgentID + "\n";
            }
            label1.Text = "������� �����������:\n" + registryQueue;
        }

        private void UpdateTherapistQueue()
        {
            string therapistQueue = "";

            for (int i = 0; i < Program.Hospital.TherapistQueue.Count; i++)
            {
                therapistQueue += " id:" + Program.Hospital.TherapistQueue[i].AgentID + "\n";
            }
            label2.Text = "������� � ���������:\n" + therapistQueue;
        }

        private void UpdateSurgeonQueue()
        {
            string surgeonQueue = "";

            for (int i = 0; i < Program.Hospital.SurgeonQueue.Count; i++)
            {
                surgeonQueue += " id:" + Program.Hospital.SurgeonQueue[i].AgentID + "\n";
            }

            label3.Text = "������� � �������:\n" + surgeonQueue;
        }

        private void UpdateRegisters()
        {
            string registers = "";

            for (int i = 0; i < Program.Hospital.RegistryDepartment.Count; i++)
            {
                registers += " id:" + Program.Hospital.RegistryDepartment[i].AgentID + " ";
                if (!Program.Hospital.RegistryDepartment[i].IsFree)
                {
                    registers += $" ����� id:{Program.Hospital.RegistryDepartment[i].GetPatientID()}\n";
                }
                else
                {
                    registers += " ��������\n";
                }
            }

            label4.Text = "������������:\n" + registers;
        }

        private void UpdateTherapists()
        {
            string therapists = "";

            for (int i = 0; i < Program.Hospital.TherapeuticDepartment.Count; i++)
            {
                therapists += " id:" + Program.Hospital.TherapeuticDepartment[i].AgentID + " ";
                if (!Program.Hospital.TherapeuticDepartment[i].IsFree)
                {
                    therapists += $" ����� id:{Program.Hospital.TherapeuticDepartment[i].GetPatientID()}\n";
                }
                else
                {
                    therapists += " ��������\n";
                }
            }

            label5.Text = "���������:\n" + therapists;
        }

        private void UpdateSurgeons()
        {
            string surgeons = "";

            for (int i = 0; i < Program.Hospital.SurgicalDepartment.Count; i++)
            {
                surgeons += " id:" + Program.Hospital.SurgicalDepartment[i].AgentID + " ";
                if (!Program.Hospital.SurgicalDepartment[i].IsFree)
                {
                    surgeons += $" ����� id:{Program.Hospital.SurgicalDepartment[i].GetPatientID()}\n";
                }
                else
                {
                    surgeons += " ��������\n";
                }
            }

            label6.Text = "�������:\n" + surgeons;
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
                    populationlist[j] += $" ������� �� {Program.Hospital.Population[i].Disease.DiseaseName}\n";
                    counters[0]++;
                }
                else if (Program.Hospital.Population[i].HealthStatus == EHealthStatus.UnknownDisease)
                {
                    populationlist[j] += $"����������� �������\n";
                    counters[1]++;
                }
                else
                {
                    populationlist[j] += $" ������ \n";
                    counters[2]++;
                }


            }


            label7.Text = "��������:\n" + populationlist[0];
            label8.Text = populationlist[1];
            label9.Text = populationlist[2];
            label10.Text = populationlist[3];
            label11.Text = populationlist[4];

            string tabulation = "    ";

            label12.Text = $"�������: {counters[0]} {tabulation}{tabulation} ����������� �������: {counters[1]} {tabulation}{tabulation} �������: {counters[2]}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Program.Tick();
            UpdateVisuals();
        }
    }
}
