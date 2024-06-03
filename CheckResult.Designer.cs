namespace Diplom
{
    partial class CheckResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            getResButtonCent = new Button();
            getResButtonSwarm = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(getResButtonCent);
            panel1.Controls.Add(getResButtonSwarm);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 80);
            panel1.TabIndex = 0;
            // 
            // getResButtonCent
            // 
            getResButtonCent.BackColor = SystemColors.ControlDarkDark;
            getResButtonCent.FlatStyle = FlatStyle.Flat;
            getResButtonCent.Font = new Font("Alef", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            getResButtonCent.ForeColor = SystemColors.ControlLightLight;
            getResButtonCent.Location = new Point(551, 12);
            getResButtonCent.Name = "getResButtonCent";
            getResButtonCent.Size = new Size(237, 47);
            getResButtonCent.TabIndex = 2;
            getResButtonCent.Text = "Get centralized result";
            getResButtonCent.UseVisualStyleBackColor = false;
            getResButtonCent.Click += buttonCentralized_Click;
            // 
            // getResButtonSwarm
            // 
            getResButtonSwarm.BackColor = SystemColors.ScrollBar;
            getResButtonSwarm.FlatStyle = FlatStyle.Flat;
            getResButtonSwarm.Font = new Font("Alef", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            getResButtonSwarm.ForeColor = SystemColors.ControlLightLight;
            getResButtonSwarm.Location = new Point(12, 12);
            getResButtonSwarm.Name = "getResButtonSwarm";
            getResButtonSwarm.Size = new Size(237, 47);
            getResButtonSwarm.TabIndex = 1;
            getResButtonSwarm.Text = "Get swarm result";
            getResButtonSwarm.UseVisualStyleBackColor = false;
            getResButtonSwarm.Click += buttonSwarm_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 370);
            panel2.TabIndex = 1;
            // 
            // CheckResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CheckResult";
            Text = "CheckResult";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button getResButtonSwarm;
        private Button getResButtonCent;
        private Panel panel2;
    }
}