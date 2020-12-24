
namespace BocBang
{
    partial class BocBang : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public BocBang()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.G_Control = this.Factory.CreateRibbonGroup();
            this.Btn_Setting = this.Factory.CreateRibbonButton();
            this.Btn_Login = this.Factory.CreateRibbonButton();
            this.G_Session = this.Factory.CreateRibbonGroup();
            this.Btn_ListSession = this.Factory.CreateRibbonButton();
            this.Btn_SessionInfo = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.Btn_ListAudio = this.Factory.CreateRibbonButton();
            this.Btn_Merge = this.Factory.CreateRibbonButton();
            this.G_Reperentative = this.Factory.CreateRibbonGroup();
            this.Btn_Insert = this.Factory.CreateRibbonButton();
            this.Btn_Spit = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.Btn_Save = this.Factory.CreateRibbonButton();
            this.G_3G = this.Factory.CreateRibbonGroup();
            this.Btn_Export = this.Factory.CreateRibbonButton();
            this.Btn_Undo = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.Btn_FormatRepresentative = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.btn_ResetAll = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.G_Control.SuspendLayout();
            this.G_Session.SuspendLayout();
            this.group1.SuspendLayout();
            this.G_Reperentative.SuspendLayout();
            this.group3.SuspendLayout();
            this.G_3G.SuspendLayout();
            this.group2.SuspendLayout();
            this.group4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.G_Control);
            this.tab1.Groups.Add(this.G_Session);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.G_Reperentative);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.G_3G);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Label = "Bóc Băng";
            this.tab1.Name = "tab1";
            // 
            // G_Control
            // 
            this.G_Control.Items.Add(this.Btn_Setting);
            this.G_Control.Items.Add(this.Btn_Login);
            this.G_Control.Label = "Điều khiển";
            this.G_Control.Name = "G_Control";
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Setting.Image = global::BocBang.Properties.Resources.setting;
            this.Btn_Setting.KeyTip = "S";
            this.Btn_Setting.Label = "Cài đặt";
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.ShowImage = true;
            this.Btn_Setting.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.On_Btn_Setting);
            // 
            // Btn_Login
            // 
            this.Btn_Login.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Login.Image = global::BocBang.Properties.Resources.login;
            this.Btn_Login.Label = "Đăng nhập";
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.ShowImage = true;
            this.Btn_Login.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.On_Btn_Login);
            // 
            // G_Session
            // 
            this.G_Session.Items.Add(this.Btn_ListSession);
            this.G_Session.Items.Add(this.Btn_SessionInfo);
            this.G_Session.Label = "Tác nghiệp";
            this.G_Session.Name = "G_Session";
            // 
            // Btn_ListSession
            // 
            this.Btn_ListSession.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_ListSession.Enabled = false;
            this.Btn_ListSession.Image = global::BocBang.Properties.Resources._480px_List_Icon_svg;
            this.Btn_ListSession.Label = "Danh Sách Phiên";
            this.Btn_ListSession.Name = "Btn_ListSession";
            this.Btn_ListSession.ShowImage = true;
            this.Btn_ListSession.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_ListSession_Click);
            // 
            // Btn_SessionInfo
            // 
            this.Btn_SessionInfo.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_SessionInfo.Enabled = false;
            this.Btn_SessionInfo.Image = global::BocBang.Properties.Resources.information;
            this.Btn_SessionInfo.Label = "Thông tin phiên";
            this.Btn_SessionInfo.Name = "Btn_SessionInfo";
            this.Btn_SessionInfo.ShowImage = true;
            this.Btn_SessionInfo.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_SessionInfo_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.Btn_ListAudio);
            this.group1.Items.Add(this.Btn_Merge);
            this.group1.Label = "Danh sách băng";
            this.group1.Name = "group1";
            // 
            // Btn_ListAudio
            // 
            this.Btn_ListAudio.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_ListAudio.Enabled = false;
            this.Btn_ListAudio.Image = global::BocBang.Properties.Resources.items_icon_14;
            this.Btn_ListAudio.Label = "Danh sách băng";
            this.Btn_ListAudio.Name = "Btn_ListAudio";
            this.Btn_ListAudio.ShowImage = true;
            this.Btn_ListAudio.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_ListAudio_Click);
            // 
            // Btn_Merge
            // 
            this.Btn_Merge.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Merge.Enabled = false;
            this.Btn_Merge.Image = global::BocBang.Properties.Resources.merge_pngrepo_com;
            this.Btn_Merge.Label = "Tổng hợp";
            this.Btn_Merge.Name = "Btn_Merge";
            this.Btn_Merge.ShowImage = true;
            this.Btn_Merge.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Merge_Click);
            // 
            // G_Reperentative
            // 
            this.G_Reperentative.Items.Add(this.Btn_Insert);
            this.G_Reperentative.Items.Add(this.Btn_Spit);
            this.G_Reperentative.Label = "Đại biểu";
            this.G_Reperentative.Name = "G_Reperentative";
            // 
            // Btn_Insert
            // 
            this.Btn_Insert.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Insert.Enabled = false;
            this.Btn_Insert.Image = global::BocBang.Properties.Resources.insert;
            this.Btn_Insert.Label = "Chèn Đại biểu";
            this.Btn_Insert.Name = "Btn_Insert";
            this.Btn_Insert.ShowImage = true;
            this.Btn_Insert.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Insert_Click);
            // 
            // Btn_Spit
            // 
            this.Btn_Spit.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Spit.Enabled = false;
            this.Btn_Spit.Image = global::BocBang.Properties.Resources.split;
            this.Btn_Spit.Label = "Tách Lời";
            this.Btn_Spit.Name = "Btn_Spit";
            this.Btn_Spit.ShowImage = true;
            this.Btn_Spit.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Spit_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.Btn_Save);
            this.group3.Label = "Tệp";
            this.group3.Name = "group3";
            // 
            // Btn_Save
            // 
            this.Btn_Save.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Save.Enabled = false;
            this.Btn_Save.Image = global::BocBang.Properties.Resources.save;
            this.Btn_Save.Label = "Lưu";
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.ShowImage = true;
            this.Btn_Save.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Save_Click);
            // 
            // G_3G
            // 
            this.G_3G.Items.Add(this.Btn_Export);
            this.G_3G.Items.Add(this.Btn_Undo);
            this.G_3G.Label = "3G";
            this.G_3G.Name = "G_3G";
            // 
            // Btn_Export
            // 
            this.Btn_Export.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Export.Enabled = false;
            this.Btn_Export.Image = global::BocBang.Properties.Resources.export;
            this.Btn_Export.Label = "Xuất Bản";
            this.Btn_Export.Name = "Btn_Export";
            this.Btn_Export.ShowImage = true;
            this.Btn_Export.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Export_Click);
            // 
            // Btn_Undo
            // 
            this.Btn_Undo.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_Undo.Enabled = false;
            this.Btn_Undo.Image = global::BocBang.Properties.Resources.redo;
            this.Btn_Undo.Label = "Thu Hồi";
            this.Btn_Undo.Name = "Btn_Undo";
            this.Btn_Undo.ShowImage = true;
            this.Btn_Undo.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Undo_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.Btn_FormatRepresentative);
            this.group2.Items.Add(this.button2);
            this.group2.Label = "Định dạng";
            this.group2.Name = "group2";
            // 
            // Btn_FormatRepresentative
            // 
            this.Btn_FormatRepresentative.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_FormatRepresentative.Image = global::BocBang.Properties.Resources.RepresentativeFormat;
            this.Btn_FormatRepresentative.Label = "Đại biểu";
            this.Btn_FormatRepresentative.Name = "Btn_FormatRepresentative";
            this.Btn_FormatRepresentative.ShowImage = true;
            this.Btn_FormatRepresentative.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_FormatRepresentative_Click);
            // 
            // button2
            // 
            this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button2.Image = global::BocBang.Properties.Resources.ContentFormat;
            this.button2.Label = "Nội dung";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_ContentFormat_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.btn_ResetAll);
            this.group4.Label = "Tổng hợp lại";
            this.group4.Name = "group4";
            // 
            // btn_ResetAll
            // 
            this.btn_ResetAll.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_ResetAll.Enabled = false;
            this.btn_ResetAll.Image = global::BocBang.Properties.Resources.Loadmore;
            this.btn_ResetAll.Label = "Tổng hợp toàn bộ";
            this.btn_ResetAll.Name = "btn_ResetAll";
            this.btn_ResetAll.ShowImage = true;
            this.btn_ResetAll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_ResetAll_Click);
            // 
            // BocBang
            // 
            this.Name = "BocBang";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.BocBang_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.G_Control.ResumeLayout(false);
            this.G_Control.PerformLayout();
            this.G_Session.ResumeLayout(false);
            this.G_Session.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.G_Reperentative.ResumeLayout(false);
            this.G_Reperentative.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.G_3G.ResumeLayout(false);
            this.G_3G.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup G_Control;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Login;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Setting;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup G_Session;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_ListSession;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Insert;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Export;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Undo;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup G_Reperentative;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Spit;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup G_3G;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_ListAudio;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Merge;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_FormatRepresentative;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Save;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_SessionInfo;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_ResetAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
    }

    partial class ThisRibbonCollection
    {
        internal BocBang BocBang
        {
            get { return this.GetRibbon<BocBang>(); }
        }
    }
}
