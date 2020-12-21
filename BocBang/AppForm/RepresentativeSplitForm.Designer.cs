
namespace BocBang.AppForm
{
    partial class RepresentativeSplitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepresentativeSplitForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RB_Duty = new System.Windows.Forms.RadioButton();
            this.RB_Name = new System.Windows.Forms.RadioButton();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SplitRepresentative = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative_Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SplitRepresentative)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGV_SplitRepresentative, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1600, 866);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RB_Duty);
            this.panel1.Controls.Add(this.RB_Name);
            this.panel1.Controls.Add(this.TB_Search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1588, 46);
            this.panel1.TabIndex = 0;
            // 
            // RB_Duty
            // 
            this.RB_Duty.AutoSize = true;
            this.RB_Duty.Location = new System.Drawing.Point(732, 7);
            this.RB_Duty.Name = "RB_Duty";
            this.RB_Duty.Size = new System.Drawing.Size(106, 29);
            this.RB_Duty.TabIndex = 3;
            this.RB_Duty.Text = "Chức vụ";
            this.RB_Duty.UseVisualStyleBackColor = true;
            // 
            // RB_Name
            // 
            this.RB_Name.AutoSize = true;
            this.RB_Name.Checked = true;
            this.RB_Name.Location = new System.Drawing.Point(644, 7);
            this.RB_Name.Name = "RB_Name";
            this.RB_Name.Size = new System.Drawing.Size(68, 29);
            this.RB_Name.TabIndex = 2;
            this.RB_Name.TabStop = true;
            this.RB_Name.Text = "Tên";
            this.RB_Name.UseVisualStyleBackColor = true;
            // 
            // TB_Search
            // 
            this.TB_Search.Location = new System.Drawing.Point(146, 6);
            this.TB_Search.Margin = new System.Windows.Forms.Padding(6);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(440, 30);
            this.TB_Search.TabIndex = 1;
            this.TB_Search.TextChanged += new System.EventHandler(this.TB_Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            // 
            // DGV_SplitRepresentative
            // 
            this.DGV_SplitRepresentative.AllowUserToAddRows = false;
            this.DGV_SplitRepresentative.AllowUserToDeleteRows = false;
            this.DGV_SplitRepresentative.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_SplitRepresentative.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_SplitRepresentative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SplitRepresentative.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Representative_Name,
            this.Representative_Duty});
            this.DGV_SplitRepresentative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_SplitRepresentative.Location = new System.Drawing.Point(6, 64);
            this.DGV_SplitRepresentative.Margin = new System.Windows.Forms.Padding(6);
            this.DGV_SplitRepresentative.MultiSelect = false;
            this.DGV_SplitRepresentative.Name = "DGV_SplitRepresentative";
            this.DGV_SplitRepresentative.ReadOnly = true;
            this.DGV_SplitRepresentative.RowHeadersVisible = false;
            this.DGV_SplitRepresentative.RowHeadersWidth = 51;
            this.DGV_SplitRepresentative.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SplitRepresentative.Size = new System.Drawing.Size(1588, 776);
            this.DGV_SplitRepresentative.TabIndex = 1;
            this.DGV_SplitRepresentative.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.On_CellContentDoubleClick);
            this.DGV_SplitRepresentative.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.On_CellDoubleClick);
            this.DGV_SplitRepresentative.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // STT
            // 
            this.STT.FillWeight = 50F;
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Representative_Name
            // 
            this.Representative_Name.HeaderText = "Tên";
            this.Representative_Name.MinimumWidth = 6;
            this.Representative_Name.Name = "Representative_Name";
            this.Representative_Name.ReadOnly = true;
            this.Representative_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Representative_Duty
            // 
            this.Representative_Duty.HeaderText = "Chức vụ";
            this.Representative_Duty.MinimumWidth = 6;
            this.Representative_Duty.Name = "Representative_Duty";
            this.Representative_Duty.ReadOnly = true;
            this.Representative_Duty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 849);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 14);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // RepresentativeSplitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 866);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "RepresentativeSplitForm";
            this.Text = "Danh sách lời đại biểu";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SplitRepresentative)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGV_SplitRepresentative;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative_Duty;
        private System.Windows.Forms.RadioButton RB_Duty;
        private System.Windows.Forms.RadioButton RB_Name;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}