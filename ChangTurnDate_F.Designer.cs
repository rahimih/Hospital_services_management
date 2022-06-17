namespace PIHO_DAYCLINIC_SOFTWARE
{
    partial class ChangTurnDate_F
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangTurnDate_F));
            this.label30 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.persianDateTimePicker1 = new FreeControls.PersianDateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label30.Location = new System.Drawing.Point(255, 82);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(45, 26);
            this.label30.TabIndex = 74;
            this.label30.Text = "تاریخ ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 62);
            this.panel1.TabIndex = 75;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::PIHO_DAYCLINIC_SOFTWARE.Properties.Resources.Insicons2;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(2, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 59);
            this.button3.TabIndex = 19;
            this.button3.Text = "ثبت  ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // persianDateTimePicker1
            // 
            this.persianDateTimePicker1.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.persianDateTimePicker1.Location = new System.Drawing.Point(54, 78);
            this.persianDateTimePicker1.Name = "persianDateTimePicker1";
            this.persianDateTimePicker1.ShowTime = false;
            this.persianDateTimePicker1.Size = new System.Drawing.Size(199, 31);
            this.persianDateTimePicker1.TabIndex = 76;
            this.persianDateTimePicker1.Text = "persianDateTimePicker1";
            this.persianDateTimePicker1.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker1.Value")));
            // 
            // ChangTurnDate_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 127);
            this.Controls.Add(this.persianDateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label30);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangTurnDate_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تغییر تاریخ";
            this.Load += new System.EventHandler(this.ChangTurnDate_F_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        public FreeControls.PersianDateTimePicker persianDateTimePicker1;
    }
}