namespace PIHO_DAYCLINIC_SOFTWARE
{
    partial class User_edit_F
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
            this.Department_comboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Post_comboBox = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Ins_Button = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Department_comboBox
            // 
            this.Department_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Department_comboBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Department_comboBox.FormattingEnabled = true;
            this.Department_comboBox.Location = new System.Drawing.Point(318, 73);
            this.Department_comboBox.Name = "Department_comboBox";
            this.Department_comboBox.Size = new System.Drawing.Size(199, 34);
            this.Department_comboBox.TabIndex = 186;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label21.Location = new System.Drawing.Point(547, 76);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 26);
            this.label21.TabIndex = 187;
            this.label21.Text = "نام بخش";
            // 
            // Post_comboBox
            // 
            this.Post_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Post_comboBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Post_comboBox.FormattingEnabled = true;
            this.Post_comboBox.Location = new System.Drawing.Point(318, 130);
            this.Post_comboBox.Name = "Post_comboBox";
            this.Post_comboBox.Size = new System.Drawing.Size(199, 34);
            this.Post_comboBox.TabIndex = 188;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(563, 135);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 26);
            this.label22.TabIndex = 189;
            this.label22.Text = "سمت";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 187);
            this.groupBox2.TabIndex = 221;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "----";
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView1.Location = new System.Drawing.Point(3, 16);
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
            this.radGridView1.Size = new System.Drawing.Size(620, 168);
            this.radGridView1.TabIndex = 221;
            this.radGridView1.Text = "radGridView1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Ins_Button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(626, 58);
            this.panel3.TabIndex = 222;
            // 
            // Ins_Button
            // 
            this.Ins_Button.BackgroundImage = global::PIHO_DAYCLINIC_SOFTWARE.Properties.Resources.Insicons2;
            this.Ins_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ins_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Ins_Button.Location = new System.Drawing.Point(3, 3);
            this.Ins_Button.Name = "Ins_Button";
            this.Ins_Button.Size = new System.Drawing.Size(60, 50);
            this.Ins_Button.TabIndex = 10;
            this.Ins_Button.Text = "ثبت";
            this.Ins_Button.UseVisualStyleBackColor = true;
            // 
            // User_edit_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(626, 359);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Post_comboBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.Department_comboBox);
            this.Controls.Add(this.label21);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "User_edit_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ویرایش کاربر";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Department_comboBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox Post_comboBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button Ins_Button;
    }
}