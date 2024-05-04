namespace ReportingSystem
{
    partial class EditCoy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCoy));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Brigade = new System.Windows.Forms.GroupBox();
            this.CmbCoy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCoy = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBrigade = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Brigade.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(568, 201);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // Brigade
            // 
            this.Brigade.Controls.Add(this.CmbCoy);
            this.Brigade.Controls.Add(this.label1);
            this.Brigade.Controls.Add(this.button2);
            this.Brigade.Controls.Add(this.txtCoy);
            this.Brigade.Controls.Add(this.button1);
            this.Brigade.Controls.Add(this.label6);
            this.Brigade.Controls.Add(this.cmbUnit);
            this.Brigade.Controls.Add(this.label5);
            this.Brigade.Controls.Add(this.label4);
            this.Brigade.Controls.Add(this.cmbBrigade);
            this.Brigade.Location = new System.Drawing.Point(71, 209);
            this.Brigade.Name = "Brigade";
            this.Brigade.Size = new System.Drawing.Size(399, 229);
            this.Brigade.TabIndex = 22;
            this.Brigade.TabStop = false;
            this.Brigade.Enter += new System.EventHandler(this.Brigade_Enter);
            // 
            // CmbCoy
            // 
            this.CmbCoy.DisplayMember = "ID";
            this.CmbCoy.FormattingEnabled = true;
            this.CmbCoy.Location = new System.Drawing.Point(110, 93);
            this.CmbCoy.Name = "CmbCoy";
            this.CmbCoy.Size = new System.Drawing.Size(162, 21);
            this.CmbCoy.TabIndex = 10;
            this.CmbCoy.ValueMember = "ID";
            this.CmbCoy.SelectedIndexChanged += new System.EventHandler(this.CmbCoy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Company";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCoy
            // 
            this.txtCoy.Location = new System.Drawing.Point(110, 138);
            this.txtCoy.MaxLength = 30;
            this.txtCoy.Name = "txtCoy";
            this.txtCoy.Size = new System.Drawing.Size(162, 20);
            this.txtCoy.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Enter Company";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DisplayMember = "ID";
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(110, 54);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(162, 21);
            this.cmbUnit.TabIndex = 3;
            this.cmbUnit.ValueMember = "ID";
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Brigade";
            // 
            // cmbBrigade
            // 
            this.cmbBrigade.DisplayMember = "Brigade";
            this.cmbBrigade.FormattingEnabled = true;
            this.cmbBrigade.Location = new System.Drawing.Point(110, 16);
            this.cmbBrigade.Name = "cmbBrigade";
            this.cmbBrigade.Size = new System.Drawing.Size(162, 21);
            this.cmbBrigade.TabIndex = 0;
            this.cmbBrigade.SelectedIndexChanged += new System.EventHandler(this.cmbBrigade_SelectedIndexChanged);
            // 
            // EditCoy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(566, 472);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Brigade);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCoy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit  Coy";
            this.Load += new System.EventHandler(this.EditCoy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Brigade.ResumeLayout(false);
            this.Brigade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox Brigade;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCoy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBrigade;
        private System.Windows.Forms.ComboBox CmbCoy;
        private System.Windows.Forms.Label label1;
    }
}