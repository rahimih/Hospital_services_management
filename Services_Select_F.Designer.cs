namespace PIHO_DAYCLINIC_SOFTWARE
{
    partial class Services_Select_F
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor2 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Ins_Button = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Ins_Button);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(881, 85);
            this.panel3.TabIndex = 41;
            // 
            // Ins_Button
            // 
            this.Ins_Button.BackgroundImage = global::PIHO_DAYCLINIC_SOFTWARE.Properties.Resources.images;
            this.Ins_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ins_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Ins_Button.Location = new System.Drawing.Point(3, 3);
            this.Ins_Button.Name = "Ins_Button";
            this.Ins_Button.Size = new System.Drawing.Size(75, 75);
            this.Ins_Button.TabIndex = 31;
            this.Ins_Button.Text = "ثبت";
            this.Ins_Button.UseVisualStyleBackColor = true;
            this.Ins_Button.Click += new System.EventHandler(this.Ins_Button_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(675, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(192, 30);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "انتخاب تمامی خدمات سطح 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radGridView2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 473);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "خدمات";
            // 
            // radGridView2
            // 
            this.radGridView2.AutoScroll = true;
            this.radGridView2.AutoSizeRows = true;
            this.radGridView2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.radGridView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.radGridView2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView2.GroupExpandAnimationType = Telerik.WinControls.UI.GridExpandAnimationType.Slide;
            this.radGridView2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView2.Location = new System.Drawing.Point(3, 27);
            // 
            // radGridView2
            // 
            this.radGridView2.MasterTemplate.AllowAddNewRow = false;
            this.radGridView2.MasterTemplate.AllowDeleteRow = false;
            this.radGridView2.MasterTemplate.AllowDragToGroup = false;
            this.radGridView2.MasterTemplate.AutoExpandGroups = true;
            this.radGridView2.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView2.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            gridViewCheckBoxColumn2.AllowFiltering = false;
            gridViewCheckBoxColumn2.AllowHide = false;
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.HeaderText = "  ";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "column1";
            gridViewCheckBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn2.Width = 834;
            this.radGridView2.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn2});
            this.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
            sortDescriptor2.PropertyName = "levels";
            groupDescriptor2.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.radGridView2.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor2});
            this.radGridView2.MasterTemplate.ShowHeaderCellButtons = true;
            this.radGridView2.MasterTemplate.ShowParentGroupSummaries = true;
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView2.ShowHeaderCellButtons = true;
            this.radGridView2.Size = new System.Drawing.Size(875, 443);
            this.radGridView2.TabIndex = 36;
            this.radGridView2.Text = "radGridView2";
            this.radGridView2.SelectionChanging += new Telerik.WinControls.UI.GridViewSelectionCancelEventHandler(this.radGridView2_SelectionChanging);
            // 
            // Services_Select_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(881, 558);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Services_Select_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "انتخاب گروهی خدمت";
            this.Load += new System.EventHandler(this.Services_Select_F_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button Ins_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        public Telerik.WinControls.UI.RadGridView radGridView2;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}