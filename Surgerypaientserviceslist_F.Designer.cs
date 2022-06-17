namespace PIHO_DAYCLINIC_SOFTWARE
{
    partial class Surgerypaientserviceslist_F
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Surgerypaientserviceslist_F));
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.persianDateTimePicker2 = new FreeControls.PersianDateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.Search_button1 = new System.Windows.Forms.Button();
            this.persianDateTimePicker1 = new FreeControls.PersianDateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 63);
            this.panel4.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.persianDateTimePicker2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Search_button1);
            this.groupBox1.Controls.Add(this.persianDateTimePicker1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(172, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 61);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(243, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "تا تاریخ";
            // 
            // persianDateTimePicker2
            // 
            this.persianDateTimePicker2.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.persianDateTimePicker2.Location = new System.Drawing.Point(299, 21);
            this.persianDateTimePicker2.Name = "persianDateTimePicker2";
            this.persianDateTimePicker2.ShowTime = false;
            this.persianDateTimePicker2.Size = new System.Drawing.Size(175, 31);
            this.persianDateTimePicker2.TabIndex = 1;
            this.persianDateTimePicker2.Text = "persianDateTimePicker2";
            this.persianDateTimePicker2.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker2.Value")));
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(484, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 24);
            this.label10.TabIndex = 11;
            this.label10.Text = "از تاریخ";
            // 
            // Search_button1
            // 
            this.Search_button1.BackgroundImage = global::PIHO_DAYCLINIC_SOFTWARE.Properties.Resources.arrow_icon71;
            this.Search_button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search_button1.Location = new System.Drawing.Point(16, 21);
            this.Search_button1.Name = "Search_button1";
            this.Search_button1.Size = new System.Drawing.Size(39, 35);
            this.Search_button1.TabIndex = 3;
            this.Search_button1.UseVisualStyleBackColor = true;
            this.Search_button1.Click += new System.EventHandler(this.Search_button1_Click);
            // 
            // persianDateTimePicker1
            // 
            this.persianDateTimePicker1.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.persianDateTimePicker1.Location = new System.Drawing.Point(56, 22);
            this.persianDateTimePicker1.Name = "persianDateTimePicker1";
            this.persianDateTimePicker1.ShowTime = false;
            this.persianDateTimePicker1.Size = new System.Drawing.Size(175, 31);
            this.persianDateTimePicker1.TabIndex = 13;
            this.persianDateTimePicker1.Text = "persianDateTimePicker1";
            this.persianDateTimePicker1.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker1.Value")));
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox3.Controls.Add(this.radGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(720, 462);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView1.Location = new System.Drawing.Point(3, 24);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(714, 435);
            this.radGridView1.TabIndex = 23;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.DoubleClick += new System.EventHandler(this.radGridView1_DoubleClick);
            // 
            // Surgerypaientserviceslist_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(720, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Surgerypaientserviceslist_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست خدمات استفاده شده بیماران";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Surgerypaientserviceslist_F_FormClosed);
            this.Load += new System.EventHandler(this.Surgerypaientserviceslist_F_Load);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        public FreeControls.PersianDateTimePicker persianDateTimePicker2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Search_button1;
        public FreeControls.PersianDateTimePicker persianDateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadGridView radGridView1;

    }
}