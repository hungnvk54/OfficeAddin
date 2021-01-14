using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BocBang.DataMessage;
using BocBang.Common;


namespace BocBang.AppForm
{
    public partial class ExportForm : Form
    {
        private bool mIsDataLoaded;
        private List<GGGActivityEntitity> mGGGActivityEntitities;
        private List<GGGLocationEntity> mGGGLocationEntities;
        private List<GGGUserGroupEntity> mGGGUserGroupEntities;
        private List<CheckBox> mListUserGroupCheckbox;
        private Dictionary<string, GGGUserGroupEntity> mGroupNameAndGroupEntity;
        public ExportForm()
        {
            InitializeComponent();
            mIsDataLoaded = false;
            mGGGActivityEntitities = new List<GGGActivityEntitity>();
            mGGGLocationEntities = new List<GGGLocationEntity>();
            mGGGUserGroupEntities = new List<GGGUserGroupEntity>();
            mListUserGroupCheckbox = new List<CheckBox>();
            mGroupNameAndGroupEntity = new Dictionary<string, GGGUserGroupEntity>();
        }

        private void BT_XacNhan_Click(object sender, EventArgs e)
        {
            bool exportResult = true;
            if (IsDataValid() == false)
            {
                DialogResult = DialogResult.No;
            }
            Cursor.Current = Cursors.WaitCursor;
            GGGExportEntity gGGExportEntity = BuildExportEntity();

            if (!Utils.CheckActivityMapping(AppsSettings.GetInstance().Session.activity.type,
                gGGExportEntity.activity.code))
            {
                DialogResult result = CreateInformationDialog.CreateConfirmBoxWithTwoButton("Bạn đang chọn không đúng loại hoạt động.\n" +
                    "Bạn có muốn tiếp tục xuất bản?", "Xuất bản");
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            exportResult = Request.ExportSessionToGGGSystem(gGGExportEntity);
            Cursor.Current = Cursors.Default;
            if (exportResult == true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }

        private GGGExportEntity BuildExportEntity()
        {
            GGGExportEntity gGGExportEntity = new GGGExportEntity();
            gGGExportEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
            gGGExportEntity.activity = this.mGGGActivityEntitities.ElementAt(this.CBB_HoatDong.SelectedIndex);
            gGGExportEntity.locationId = this.mGGGLocationEntities.ElementAt(this.CBB_Location.SelectedIndex).place_id;

            if (!this.CB_CheDoMat.Checked)
            {
                gGGExportEntity.confidentialStatus = 0;
            }
            else
            {
                gGGExportEntity.confidentialStatus = 1;
                List<long> listGroupId = new List<long>();
                foreach(CheckBox checkBox in this.mListUserGroupCheckbox)
                {
                    if (checkBox.Checked)
                    {
                        GGGUserGroupEntity entity = this.mGroupNameAndGroupEntity[checkBox.Text];
                        listGroupId.Add(entity.group_id);
                    }
                }
                gGGExportEntity.allowedGroupIds = listGroupId;
            }

            return gGGExportEntity;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void LoadingData()
        {
            if (mIsDataLoaded == false)
            {
                mIsDataLoaded = true;
                this.mGGGActivityEntitities = Request.GetGGGActivityEntitities();
                this.mGGGLocationEntities = Request.GetGGGLocationEntitities();
                this.mGGGUserGroupEntities = Request.GetGGGUserGroupEntities();
                BindingData();
            }
        }

        private void BindingData()
        {
            if (IsDataValid() == false)
            {
                return;
            }
            else
            {
                foreach(GGGActivityEntitity entitity in this.mGGGActivityEntitities)
                {
                    this.CBB_HoatDong.Items.Add(entitity.name);
                }
                if (this.CBB_HoatDong.Items.Count > 0)
                {
                    this.CBB_HoatDong.SelectedIndex = 0;
                }

                foreach (GGGLocationEntity entitity in this.mGGGLocationEntities)
                {
                    this.CBB_Location.Items.Add(entitity.name);
                }

                if (this.CBB_Location.Items.Count > 0)
                {
                    this.CBB_Location.SelectedIndex = 0;
                }

                ///Create layout
                foreach (GGGUserGroupEntity entitity in this.mGGGUserGroupEntities)
                {
                    CheckBox group = CreateUserGroupCheckBox(entitity.group_name);
                    this.FP_Container.Controls.Add(group);
                    this.mListUserGroupCheckbox.Add(group);
                    this.mGroupNameAndGroupEntity.Add(entitity.group_name, entitity);
                }
            }
        }

        private CheckBox CreateUserGroupCheckBox(string checkboxName)
        {
            CheckBox group = new System.Windows.Forms.CheckBox();

            group.AutoSize = true;
            group.Location = new System.Drawing.Point(3, 2);
            group.Name = checkboxName;
            group.Size = new System.Drawing.Size(150, 21);
            group.TabIndex = 0;
            group.Text = checkboxName;
            group.UseVisualStyleBackColor = true;

            return group;
        }

        private void CB_CheDoMat_CheckedChanged(object sender, EventArgs e)
        {
            this.FP_Container.Enabled = this.CB_CheDoMat.Checked;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            } else if (e.KeyCode == Keys.F5)
            {
                this.mIsDataLoaded = false;
                LoadingData();
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }

        private bool IsDataValid()
        {
            if (this.mGGGUserGroupEntities == null ||
                this.mGGGActivityEntitities == null ||
                this.mGGGUserGroupEntities == null ||
                this.mGroupNameAndGroupEntity == null ||
                this.mListUserGroupCheckbox == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
