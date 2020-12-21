
namespace BocBang.AppForm
{
    partial class RepresentativeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepresentativeForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV_RepresentativeList = new System.Windows.Forms.DataGridView();
            this.Representative_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative_Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative_Term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RB_Duty = new System.Windows.Forms.RadioButton();
            this.RB_Name = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RepresentativeList)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGV_RepresentativeList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1238, 866);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV_RepresentativeList
            // 
            this.DGV_RepresentativeList.AllowUserToAddRows = false;
            this.DGV_RepresentativeList.AllowUserToDeleteRows = false;
            this.DGV_RepresentativeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_RepresentativeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_RepresentativeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_RepresentativeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Representative_Order,
            this.Representative_Name,
            this.Representative_Duty,
            this.Representative_Term});
            this.DGV_RepresentativeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_RepresentativeList.Location = new System.Drawing.Point(6, 64);
            this.DGV_RepresentativeList.Margin = new System.Windows.Forms.Padding(6);
            this.DGV_RepresentativeList.MultiSelect = false;
            this.DGV_RepresentativeList.Name = "DGV_RepresentativeList";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_RepresentativeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_RepresentativeList.RowHeadersVisible = false;
            this.DGV_RepresentativeList.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGV_RepresentativeList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_RepresentativeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_RepresentativeList.Size = new System.Drawing.Size(1226, 796);
            this.DGV_RepresentativeList.TabIndex = 1;
            this.DGV_RepresentativeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.On_Representative_Selection);
            // 
            // Representative_Order
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Representative_Order.DefaultCellStyle = dataGridViewCellStyle1;
            this.Representative_Order.FillWeight = 35F;
            this.Representative_Order.HeaderText = "STT";
            this.Representative_Order.MinimumWidth = 6;
            this.Representative_Order.Name = "Representative_Order";
            this.Representative_Order.ReadOnly = true;
            this.Representative_Order.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Representative_Order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Representative_Name
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Representative_Name.DefaultCellStyle = dataGridViewCellStyle2;
            this.Representative_Name.FillWeight = 99.49239F;
            this.Representative_Name.HeaderText = "Tên";
            this.Representative_Name.MinimumWidth = 6;
            this.Representative_Name.Name = "Representative_Name";
            this.Representative_Name.ReadOnly = true;
            this.Representative_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Representative_Duty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Representative_Duty.DefaultCellStyle = dataGridViewCellStyle3;
            this.Representative_Duty.FillWeight = 99.49239F;
            this.Representative_Duty.HeaderText = "Chức Vụ";
            this.Representative_Duty.MinimumWidth = 6;
            this.Representative_Duty.Name = "Representative_Duty";
            this.Representative_Duty.ReadOnly = true;
            this.Representative_Duty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Representative_Term
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Representative_Term.DefaultCellStyle = dataGridViewCellStyle4;
            this.Representative_Term.FillWeight = 35F;
            this.Representative_Term.HeaderText = "Khóa";
            this.Representative_Term.MinimumWidth = 6;
            this.Representative_Term.Name = "Representative_Term";
            this.Representative_Term.ReadOnly = true;
            this.Representative_Term.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1226, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RB_Duty);
            this.panel1.Controls.Add(this.RB_Name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TB_Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 39);
            this.panel1.TabIndex = 3;
            // 
            // RB_Duty
            // 
            this.RB_Duty.AutoSize = true;
            this.RB_Duty.Location = new System.Drawing.Point(737, 4);
            this.RB_Duty.Name = "RB_Duty";
            this.RB_Duty.Size = new System.Drawing.Size(106, 29);
            this.RB_Duty.TabIndex = 4;
            this.RB_Duty.Text = "Chức vụ";
            this.RB_Duty.UseVisualStyleBackColor = true;
            // 
            // RB_Name
            // 
            this.RB_Name.AutoSize = true;
            this.RB_Name.Checked = true;
            this.RB_Name.Location = new System.Drawing.Point(645, 4);
            this.RB_Name.Name = "RB_Name";
            this.RB_Name.Size = new System.Drawing.Size(68, 29);
            this.RB_Name.TabIndex = 3;
            this.RB_Name.TabStop = true;
            this.RB_Name.Text = "Tên";
            this.RB_Name.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm kiếm";
            // 
            // TB_Search
            // 
            this.TB_Search.Location = new System.Drawing.Point(134, 4);
            this.TB_Search.Margin = new System.Windows.Forms.Padding(6);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(449, 30);
            this.TB_Search.TabIndex = 1;
            this.TB_Search.TextChanged += new System.EventHandler(this.TB_Search_TextChanged);
            // 
            // RepresentativeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 866);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "RepresentativeForm";
            this.Text = "Danh sách Đại biểu";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RepresentativeList)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView DGV_RepresentativeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative_Duty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative_Term;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RB_Duty;
        private System.Windows.Forms.RadioButton RB_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Search;
    }
}