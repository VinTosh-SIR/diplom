namespace Diplom
{
    partial class StinkBugs
    {

        private System.ComponentModel.IContainer components = null;
        private Panel panel1;
        private Panel panel2;

        /// <summary>
        /// Clean up any resources being used.
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

        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            completionLabel = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(completionLabel);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1085, 94);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumSeaGreen;
            button2.Font = new Font("SuperFrench", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 2);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(892, 29);
            button2.Name = "button2";
            button2.Padding = new Padding(2);
            button2.Size = new Size(181, 54);
            button2.TabIndex = 3;
            button2.Text = "Start centralized algorithm";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumAquamarine;
            button1.Font = new Font("SuperFrench", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 2);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(706, 29);
            button1.Name = "button1";
            button1.Padding = new Padding(2);
            button1.Size = new Size(180, 54);
            button1.TabIndex = 2;
            button1.Text = "Start swarm algorithm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // completionLabel
            // 
            completionLabel.AutoSize = true;
            completionLabel.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            completionLabel.ForeColor = SystemColors.ControlLightLight;
            completionLabel.Location = new Point(0, 53);
            completionLabel.Name = "completionLabel";
            completionLabel.Size = new Size(145, 21);
            completionLabel.TabIndex = 2;
            completionLabel.Text = "time for complete:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Simplex_IV25", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(795, 0);
            label1.Name = "label1";
            label1.Size = new Size(290, 26);
            label1.TabIndex = 2;
            label1.Text = "Return back press ESC";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(26, 114, 119);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 94);
            panel2.Name = "panel2";
            panel2.Size = new Size(1085, 439);
            panel2.TabIndex = 1;
            // 
            // StinkBugs
            // 
            ClientSize = new Size(1085, 533);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StinkBugs";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Label label1;
        private Label completionLabel;
        private Button button2;
        private Button button1;
    }
}
