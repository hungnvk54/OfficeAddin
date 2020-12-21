
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SplitRepresentative = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative_Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SplitRepresentative)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGV_SplitRepresentative, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TB_Search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 24);
            this.panel1.TabIndex = 0;
            // 
            // TB_Search
            // 
            this.TB_Search.Location = new System.Drawing.Point(74, 1);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(222, 20);
            this.TB_Search.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
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
            this.DGV_SplitRepresentative.Location = new System.Drawing.Point(3, 33);
            this.DGV_SplitRepresentative.Name = "DGV_SplitRepresentative";
            this.DGV_SplitRepresentative.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SplitRepresentative.Size = new System.Drawing.Size(794, 414);
            this.DGV_SplitRepresentative.TabIndex = 1;
            this.DGV_SplitRepresentative.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.On_CellContentDoubleClick);
            this.DGV_SplitRepresentative.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.On_CellDoubleClick);
            // 
            // STT
            // 
            this.STT.FillWeight = 50F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Representative_Name
            // 
            this.Representative_Name.HeaderText = "Tên";
            this.Representative_Name.Name = "Representative_Name";
            this.Representative_Name.ReadOnly = true;
            this.Representative_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Representative_Duty
            // 
            this.Representative_Duty.HeaderText = "Chức vụ";
            this.Representative_Duty.Name = "Representative_Duty";
            this.Representative_Duty.ReadOnly = true;
            this.Representative_Duty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RepresentativeSplitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RepresentativeSplitForm";
            this.Text = "RepresentativeSplitForm";
            this.tableLayoutPanel1.ResumeLayout(false);
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
    }
}