
namespace Diplom
{
    partial class Start
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
            panel1 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            button2 = new Button();
            panel3 = new Panel();
            button1 = new Button();
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1019, 568);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.MenuHighlight;
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(312, 127);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(30);
            panel5.Size = new Size(395, 441);
            panel5.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(button2);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(707, 127);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(30);
            panel4.Size = new Size(312, 441);
            panel4.TabIndex = 3;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Dock = DockStyle.Top;
            button2.Font = new Font("TechnicBold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 2);
            button2.ForeColor = SystemColors.MenuHighlight;
            button2.Location = new Point(30, 30);
            button2.Name = "button2";
            button2.Size = new Size(252, 74);
            button2.TabIndex = 2;
            button2.Text = "Check result";
            button2.UseVisualStyleBackColor = true;
            button2.Click += changeFormToCheckResult;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 127);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(30);
            panel3.Size = new Size(312, 441);
            panel3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Top;
            button1.Font = new Font("TechnicBold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 2);
            button1.ForeColor = SystemColors.MenuHighlight;
            button1.Location = new Point(30, 30);
            button1.Name = "button1";
            button1.Size = new Size(252, 74);
            button1.TabIndex = 1;
            button1.Text = "Swarm algorithm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += changeFormToStinkBugs;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1019, 127);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Swis721 BlkEx BT", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(961, 9);
            label1.Name = "label1";
            label1.Size = new Size(46, 39);
            label1.TabIndex = 3;
            label1.Text = "X";
            label1.Click += closeFormBtn;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Vineta BT", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1019, 127);
            label2.TabIndex = 2;
            label2.Text = "TEST ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Start
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1019, 568);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlLightLight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Start";
            Text = "Algorythm test";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Button button1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
        private Label label1;

        private void changeFormToStinkBugs(object sender, EventArgs e)
        {
            var frm = new StinkBugs();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void changeFormToCheckResult(object sender, EventArgs e)
        {
            var frm = new CheckResult();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private Button button2;
    }
}
