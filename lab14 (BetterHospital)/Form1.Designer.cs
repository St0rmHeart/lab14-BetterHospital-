namespace lab14__BetterHospital_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label13 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(531, 59);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 0;
            label1.Text = "Очередь регистрации";
            // 
            // button1
            // 
            button1.Location = new Point(575, 855);
            button1.Name = "button1";
            button1.Size = new Size(298, 76);
            button1.TabIndex = 1;
            button1.Text = "Старт/Стоп";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(667, 59);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 2;
            label2.Text = "Очередь к терапевту";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(825, 59);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 3;
            label3.Text = "Очередь к хирургу";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 59);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 4;
            label4.Text = "Регистраторы";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(202, 59);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 5;
            label5.Text = "Терапевты";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(373, 59);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 6;
            label6.Text = "Хирурги";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(987, 67);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 7;
            label7.Text = "Пациенты";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1195, 67);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 8;
            label8.Text = "label8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1387, 67);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 9;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1605, 67);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 10;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1835, 67);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 11;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1066, 855);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 12;
            label12.Text = "label12";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1524, 855);
            label13.Name = "label13";
            label13.Size = new Size(44, 15);
            label13.TabIndex = 13;
            label13.Text = "label13";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1943, 1006);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private System.Windows.Forms.Timer timer1;
        private Label label13;
    }
}
