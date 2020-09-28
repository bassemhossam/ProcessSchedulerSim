namespace OS_Assignment_try_1
{
    partial class Schedulers
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
            this.proTxtbox = new System.Windows.Forms.TextBox();
            this.proLbl = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.GroupBox();
            this.qntTxtbox = new System.Windows.Forms.TextBox();
            this.PriorityCombo = new System.Windows.Forms.ComboBox();
            this.SJFCombo = new System.Windows.Forms.ComboBox();
            this.RRChk = new System.Windows.Forms.CheckBox();
            this.PriorityChk = new System.Windows.Forms.CheckBox();
            this.SJFChk = new System.Windows.Forms.CheckBox();
            this.FCFSChk = new System.Windows.Forms.CheckBox();
            this.nxtBtn = new System.Windows.Forms.Button();
            this.typeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // proTxtbox
            // 
            this.proTxtbox.Location = new System.Drawing.Point(130, 30);
            this.proTxtbox.Name = "proTxtbox";
            this.proTxtbox.Size = new System.Drawing.Size(142, 20);
            this.proTxtbox.TabIndex = 4;
            this.proTxtbox.Text = "Enter Number of processes";
            this.proTxtbox.TextChanged += new System.EventHandler(this.proTxtbox_TextChanged_1);
            // 
            // proLbl
            // 
            this.proLbl.AutoSize = true;
            this.proLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proLbl.ForeColor = System.Drawing.Color.Black;
            this.proLbl.Location = new System.Drawing.Point(12, 33);
            this.proLbl.Name = "proLbl";
            this.proLbl.Size = new System.Drawing.Size(107, 13);
            this.proLbl.TabIndex = 5;
            this.proLbl.Text = "Number of processes";
            this.proLbl.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // typeBox
            // 
            this.typeBox.BackColor = System.Drawing.Color.Transparent;
            this.typeBox.Controls.Add(this.qntTxtbox);
            this.typeBox.Controls.Add(this.PriorityCombo);
            this.typeBox.Controls.Add(this.SJFCombo);
            this.typeBox.Controls.Add(this.RRChk);
            this.typeBox.Controls.Add(this.PriorityChk);
            this.typeBox.Controls.Add(this.SJFChk);
            this.typeBox.Controls.Add(this.FCFSChk);
            this.typeBox.Location = new System.Drawing.Point(35, 69);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(178, 221);
            this.typeBox.TabIndex = 6;
            this.typeBox.TabStop = false;
            this.typeBox.Text = "Scheduler Type";
            this.typeBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // qntTxtbox
            // 
            this.qntTxtbox.Location = new System.Drawing.Point(84, 171);
            this.qntTxtbox.Name = "qntTxtbox";
            this.qntTxtbox.Size = new System.Drawing.Size(88, 20);
            this.qntTxtbox.TabIndex = 11;
            this.qntTxtbox.Text = "Quantum Time";
            this.qntTxtbox.Visible = false;
            this.qntTxtbox.TextChanged += new System.EventHandler(this.qntTxtbox_TextChanged_1);
            // 
            // PriorityCombo
            // 
            this.PriorityCombo.FormattingEnabled = true;
            this.PriorityCombo.Items.AddRange(new object[] {
            "Preemtive",
            "Non-Preemtive"});
            this.PriorityCombo.Location = new System.Drawing.Point(84, 127);
            this.PriorityCombo.Name = "PriorityCombo";
            this.PriorityCombo.Size = new System.Drawing.Size(88, 21);
            this.PriorityCombo.TabIndex = 10;
            this.PriorityCombo.Visible = false;
            this.PriorityCombo.SelectedIndexChanged += new System.EventHandler(this.PriorityCombo_SelectedIndexChanged);
            // 
            // SJFCombo
            // 
            this.SJFCombo.FormattingEnabled = true;
            this.SJFCombo.Items.AddRange(new object[] {
            "Preemtive",
            "Non-Preemtive"});
            this.SJFCombo.Location = new System.Drawing.Point(84, 82);
            this.SJFCombo.Name = "SJFCombo";
            this.SJFCombo.Size = new System.Drawing.Size(88, 21);
            this.SJFCombo.TabIndex = 9;
            this.SJFCombo.Visible = false;
            this.SJFCombo.SelectedIndexChanged += new System.EventHandler(this.SJFCombo_SelectedIndexChanged);
            // 
            // RRChk
            // 
            this.RRChk.AutoSize = true;
            this.RRChk.BackColor = System.Drawing.Color.White;
            this.RRChk.ForeColor = System.Drawing.Color.Black;
            this.RRChk.Location = new System.Drawing.Point(13, 171);
            this.RRChk.Name = "RRChk";
            this.RRChk.Size = new System.Drawing.Size(42, 17);
            this.RRChk.TabIndex = 3;
            this.RRChk.Text = "RR";
            this.RRChk.UseVisualStyleBackColor = false;
            this.RRChk.CheckedChanged += new System.EventHandler(this.RRChk_CheckedChanged);
            // 
            // PriorityChk
            // 
            this.PriorityChk.AutoSize = true;
            this.PriorityChk.BackColor = System.Drawing.Color.White;
            this.PriorityChk.ForeColor = System.Drawing.Color.Black;
            this.PriorityChk.Location = new System.Drawing.Point(13, 131);
            this.PriorityChk.Name = "PriorityChk";
            this.PriorityChk.Size = new System.Drawing.Size(57, 17);
            this.PriorityChk.TabIndex = 2;
            this.PriorityChk.Text = "Priority";
            this.PriorityChk.UseVisualStyleBackColor = false;
            this.PriorityChk.CheckedChanged += new System.EventHandler(this.PriorityChk_CheckedChanged);
            // 
            // SJFChk
            // 
            this.SJFChk.AutoSize = true;
            this.SJFChk.BackColor = System.Drawing.Color.White;
            this.SJFChk.ForeColor = System.Drawing.Color.Black;
            this.SJFChk.Location = new System.Drawing.Point(13, 86);
            this.SJFChk.Name = "SJFChk";
            this.SJFChk.Size = new System.Drawing.Size(44, 17);
            this.SJFChk.TabIndex = 1;
            this.SJFChk.Text = "SJF";
            this.SJFChk.UseVisualStyleBackColor = false;
            this.SJFChk.CheckedChanged += new System.EventHandler(this.SJFChk_CheckedChanged);
            // 
            // FCFSChk
            // 
            this.FCFSChk.AutoSize = true;
            this.FCFSChk.BackColor = System.Drawing.Color.White;
            this.FCFSChk.ForeColor = System.Drawing.Color.Black;
            this.FCFSChk.Location = new System.Drawing.Point(13, 42);
            this.FCFSChk.Name = "FCFSChk";
            this.FCFSChk.Size = new System.Drawing.Size(52, 17);
            this.FCFSChk.TabIndex = 0;
            this.FCFSChk.Text = "FCFS";
            this.FCFSChk.UseVisualStyleBackColor = false;
            this.FCFSChk.CheckedChanged += new System.EventHandler(this.FCFSChk_CheckedChanged);
            // 
            // nxtBtn
            // 
            this.nxtBtn.BackColor = System.Drawing.Color.AliceBlue;
            this.nxtBtn.ForeColor = System.Drawing.Color.Black;
            this.nxtBtn.Location = new System.Drawing.Point(271, 267);
            this.nxtBtn.Name = "nxtBtn";
            this.nxtBtn.Size = new System.Drawing.Size(75, 23);
            this.nxtBtn.TabIndex = 7;
            this.nxtBtn.Text = "Next>";
            this.nxtBtn.UseVisualStyleBackColor = false;
            this.nxtBtn.Click += new System.EventHandler(this.nxtBtn_Click);
            // 
            // Schedulers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(395, 312);
            this.Controls.Add(this.nxtBtn);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.proLbl);
            this.Controls.Add(this.proTxtbox);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "Schedulers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedulers";
            this.Load += new System.EventHandler(this.Schedulers_Load);
            this.typeBox.ResumeLayout(false);
            this.typeBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox proTxtbox;
        private System.Windows.Forms.Label proLbl;
        private System.Windows.Forms.GroupBox typeBox;
        private System.Windows.Forms.CheckBox RRChk;
        private System.Windows.Forms.CheckBox PriorityChk;
        private System.Windows.Forms.CheckBox SJFChk;
        private System.Windows.Forms.CheckBox FCFSChk;
        private System.Windows.Forms.Button nxtBtn;
        private System.Windows.Forms.ComboBox PriorityCombo;
        private System.Windows.Forms.ComboBox SJFCombo;
        private System.Windows.Forms.TextBox qntTxtbox;
    }
}

