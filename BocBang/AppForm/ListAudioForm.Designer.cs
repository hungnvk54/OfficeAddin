
namespace BocBang.AppForm
{
    partial class ListAudioForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV_ListAudio = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranslateStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReviewStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MergedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ListAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.DGV_ListAudio, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV_ListAudio
            // 
            this.DGV_ListAudio.AllowUserToAddRows = false;
            this.DGV_ListAudio.AllowUserToDeleteRows = false;
            this.DGV_ListAudio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ListAudio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_ListAudio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ListAudio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.AudioName,
            this.TranslateStatus,
            this.ReviewStatus,
            this.Reviewer,
            this.MergedStatus});
            this.DGV_ListAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ListAudio.Location = new System.Drawing.Point(3, 23);
            this.DGV_ListAudio.MultiSelect = false;
            this.DGV_ListAudio.Name = "DGV_ListAudio";
            this.DGV_ListAudio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_ListAudio.Size = new System.Drawing.Size(794, 424);
            this.DGV_ListAudio.TabIndex = 0;
            this.DGV_ListAudio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ListAudio_CellContentClick);
            // 
            // Order
            // 
            this.Order.FillWeight = 50F;
            this.Order.HeaderText = "STT";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AudioName
            // 
            this.AudioName.FillWeight = 150F;
            this.AudioName.HeaderText = "Tên băng";
            this.AudioName.Name = "AudioName";
            this.AudioName.ReadOnly = true;
            this.AudioName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TranslateStatus
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TranslateStatus.DefaultCellStyle = dataGridViewCellStyle1;
            this.TranslateStatus.HeaderText = "Trạng thái dịch";
            this.TranslateStatus.Name = "TranslateStatus";
            this.TranslateStatus.ReadOnly = true;
            this.TranslateStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ReviewStatus
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReviewStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReviewStatus.HeaderText = "Trạng thái duyệt";
            this.ReviewStatus.Name = "ReviewStatus";
            this.ReviewStatus.ReadOnly = true;
            this.ReviewStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Reviewer
            // 
            this.Reviewer.HeaderText = "Người duyệt";
            this.Reviewer.Name = "Reviewer";
            this.Reviewer.ReadOnly = true;
            this.Reviewer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MergedStatus
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MergedStatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.MergedStatus.HeaderText = "Trạng thái tổng hợp";
            this.MergedStatus.Name = "MergedStatus";
            this.MergedStatus.ReadOnly = true;
            this.MergedStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ListAudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ListAudioForm";
            this.Text = "ListAudioForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ListAudio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DGV_ListAudio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranslateStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn MergedStatus;
    }
}