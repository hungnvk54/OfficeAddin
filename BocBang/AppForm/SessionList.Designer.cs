
namespace BocBang.AppForm
{
    partial class SessionList
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
            this.DGV_SessionList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_SessionNumberSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LB_NoiDung = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LB_XuatBan = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LB_MaPhien = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LB_To = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LB_LeadConference = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LB_HoatDong = new System.Windows.Forms.Label();
            this.LB_Buoi = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LB_MeetingDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LB_kyhop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LB_term = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Session_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Session_MeetingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Session_Meeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Session_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Session_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Session_Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SessionList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.DGV_SessionList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV_SessionList
            // 
            this.DGV_SessionList.AllowUserToAddRows = false;
            this.DGV_SessionList.AllowUserToDeleteRows = false;
            this.DGV_SessionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_SessionList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_SessionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SessionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Session_Order,
            this.Session_MeetingDate,
            this.Session_Meeting,
            this.Session_Group,
            this.Session_Number,
            this.Session_Activity});
            this.DGV_SessionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_SessionList.Location = new System.Drawing.Point(3, 53);
            this.DGV_SessionList.Name = "DGV_SessionList";
            this.DGV_SessionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SessionList.Size = new System.Drawing.Size(514, 394);
            this.DGV_SessionList.TabIndex = 1;
            this.DGV_SessionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.On_CellClick);
            this.DGV_SessionList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.On_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_SessionNumberSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // TB_SessionNumberSearch
            // 
            this.TB_SessionNumberSearch.Location = new System.Drawing.Point(78, 13);
            this.TB_SessionNumberSearch.Name = "TB_SessionNumberSearch";
            this.TB_SessionNumberSearch.Size = new System.Drawing.Size(205, 20);
            this.TB_SessionNumberSearch.TabIndex = 1;
            this.TB_SessionNumberSearch.TextChanged += new System.EventHandler(this.TB_SessionNumberSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phiên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(523, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 35);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thông tin phiên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LB_NoiDung);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.LB_XuatBan);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.LB_MaPhien);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.LB_To);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.LB_LeadConference);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.LB_HoatDong);
            this.panel1.Controls.Add(this.LB_Buoi);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.LB_MeetingDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.LB_kyhop);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LB_term);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(523, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 394);
            this.panel1.TabIndex = 2;
            // 
            // LB_NoiDung
            // 
            this.LB_NoiDung.AutoSize = true;
            this.LB_NoiDung.Location = new System.Drawing.Point(104, 272);
            this.LB_NoiDung.Name = "LB_NoiDung";
            this.LB_NoiDung.Size = new System.Drawing.Size(0, 13);
            this.LB_NoiDung.TabIndex = 2;
            this.LB_NoiDung.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Nội dung họp";
            this.label13.Visible = false;
            // 
            // LB_XuatBan
            // 
            this.LB_XuatBan.AutoSize = true;
            this.LB_XuatBan.Location = new System.Drawing.Point(104, 243);
            this.LB_XuatBan.Name = "LB_XuatBan";
            this.LB_XuatBan.Size = new System.Drawing.Size(0, 13);
            this.LB_XuatBan.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Xuất bản";
            // 
            // LB_MaPhien
            // 
            this.LB_MaPhien.AutoSize = true;
            this.LB_MaPhien.Location = new System.Drawing.Point(104, 215);
            this.LB_MaPhien.Name = "LB_MaPhien";
            this.LB_MaPhien.Size = new System.Drawing.Size(0, 13);
            this.LB_MaPhien.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Mã phiên";
            // 
            // LB_To
            // 
            this.LB_To.AutoSize = true;
            this.LB_To.Location = new System.Drawing.Point(104, 185);
            this.LB_To.Name = "LB_To";
            this.LB_To.Size = new System.Drawing.Size(0, 13);
            this.LB_To.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tổ";
            // 
            // LB_LeadConference
            // 
            this.LB_LeadConference.AutoSize = true;
            this.LB_LeadConference.Location = new System.Drawing.Point(104, 159);
            this.LB_LeadConference.Name = "LB_LeadConference";
            this.LB_LeadConference.Size = new System.Drawing.Size(0, 13);
            this.LB_LeadConference.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Người chủ trì";
            // 
            // LB_HoatDong
            // 
            this.LB_HoatDong.AutoSize = true;
            this.LB_HoatDong.Location = new System.Drawing.Point(104, 130);
            this.LB_HoatDong.Name = "LB_HoatDong";
            this.LB_HoatDong.Size = new System.Drawing.Size(0, 13);
            this.LB_HoatDong.TabIndex = 2;
            // 
            // LB_Buoi
            // 
            this.LB_Buoi.AutoSize = true;
            this.LB_Buoi.Location = new System.Drawing.Point(104, 103);
            this.LB_Buoi.Name = "LB_Buoi";
            this.LB_Buoi.Size = new System.Drawing.Size(0, 13);
            this.LB_Buoi.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Hoạt động";
            // 
            // LB_MeetingDate
            // 
            this.LB_MeetingDate.AutoSize = true;
            this.LB_MeetingDate.Location = new System.Drawing.Point(104, 78);
            this.LB_MeetingDate.Name = "LB_MeetingDate";
            this.LB_MeetingDate.Size = new System.Drawing.Size(0, 13);
            this.LB_MeetingDate.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Buổi";
            // 
            // LB_kyhop
            // 
            this.LB_kyhop.AutoSize = true;
            this.LB_kyhop.Location = new System.Drawing.Point(104, 49);
            this.LB_kyhop.Name = "LB_kyhop";
            this.LB_kyhop.Size = new System.Drawing.Size(0, 13);
            this.LB_kyhop.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ngày họp";
            // 
            // LB_term
            // 
            this.LB_term.AutoSize = true;
            this.LB_term.Location = new System.Drawing.Point(104, 20);
            this.LB_term.Name = "LB_term";
            this.LB_term.Size = new System.Drawing.Size(0, 13);
            this.LB_term.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Kỳ họp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khóa";
            // 
            // Session_Order
            // 
            this.Session_Order.FillWeight = 50F;
            this.Session_Order.HeaderText = "STT";
            this.Session_Order.Name = "Session_Order";
            this.Session_Order.ReadOnly = true;
            this.Session_Order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Session_MeetingDate
            // 
            this.Session_MeetingDate.FillWeight = 80F;
            this.Session_MeetingDate.HeaderText = "Ngày họp";
            this.Session_MeetingDate.Name = "Session_MeetingDate";
            this.Session_MeetingDate.ReadOnly = true;
            this.Session_MeetingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Session_Meeting
            // 
            this.Session_Meeting.FillWeight = 80F;
            this.Session_Meeting.HeaderText = "Buổi họp";
            this.Session_Meeting.Name = "Session_Meeting";
            this.Session_Meeting.ReadOnly = true;
            this.Session_Meeting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Session_Group
            // 
            this.Session_Group.FillWeight = 80F;
            this.Session_Group.HeaderText = "Tổ";
            this.Session_Group.Name = "Session_Group";
            this.Session_Group.ReadOnly = true;
            this.Session_Group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Session_Number
            // 
            this.Session_Number.FillWeight = 80F;
            this.Session_Number.HeaderText = "Mã Phiên";
            this.Session_Number.Name = "Session_Number";
            this.Session_Number.ReadOnly = true;
            this.Session_Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Session_Activity
            // 
            this.Session_Activity.HeaderText = "Hoạt động";
            this.Session_Activity.Name = "Session_Activity";
            this.Session_Activity.ReadOnly = true;
            this.Session_Activity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SessionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SessionList";
            this.Text = "SessionList";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SessionList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TB_SessionNumberSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_SessionList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LB_NoiDung;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LB_XuatBan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LB_MaPhien;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LB_To;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LB_LeadConference;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LB_HoatDong;
        private System.Windows.Forms.Label LB_Buoi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LB_MeetingDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LB_kyhop;
        private System.Windows.Forms.Label LB_term;
        private System.Windows.Forms.DataGridViewTextBoxColumn Session_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Session_MeetingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Session_Meeting;
        private System.Windows.Forms.DataGridViewTextBoxColumn Session_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Session_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Session_Activity;
    }
}