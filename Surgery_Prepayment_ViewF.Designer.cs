namespace PIHO_DAYCLINIC_SOFTWARE
{
    partial class Surgery_Prepayment_ViewF
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ins_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.Ins_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 78);
            this.panel1.TabIndex = 32;
            // 
            // Ins_Button
            // 
            this.Ins_Button.BackgroundImage = global::PIHO_DAYCLINIC_SOFTWARE.Properties.Resources.images;
            this.Ins_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ins_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Ins_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Ins_Button.Location = new System.Drawing.Point(4, 5);
            this.Ins_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Ins_Button.Name = "Ins_Button";
            this.Ins_Button.Size = new System.Drawing.Size(70, 67);
            this.Ins_Button.TabIndex = 0;
            this.Ins_Button.Text = "انتخاب";
            this.Ins_Button.UseVisualStyleBackColor = true;
            this.Ins_Button.Click += new System.EventHandler(this.Ins_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radGridView2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 525);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // radGridView2
            // 
            this.radGridView2.AutoScroll = true;
            this.radGridView2.AutoSizeRows = true;
            this.radGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView2.Location = new System.Drawing.Point(3, 27);
            // 
            // radGridView2
            // 
            this.radGridView2.MasterTemplate.AllowAddNewRow = false;
            this.radGridView2.MasterTemplate.AllowDeleteRow = false;
            this.radGridView2.MasterTemplate.AllowDragToGroup = false;
            this.radGridView2.MasterTemplate.AllowEditRow = false;
            this.radGridView2.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView2.MasterTemplate.EnableFiltering = true;
            this.radGridView2.MasterTemplate.EnableGrouping = false;
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.Size = new System.Drawing.Size(884, 495);
            this.radGridView2.TabIndex = 11;
            this.radGridView2.Text = "radGridView2";
            this.radGridView2.DoubleClick += new System.EventHandler(this.radGridView2_DoubleClick);
            // 
            // SurgeryPrepayment_ViewF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(890, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SurgeryPrepayment_ViewF";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "مشاهده  افراد";
            this.Load += new System.EventHandler(this.SurgeryPrepayment_ViewF_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button Ins_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView radGridView2;
    }
}