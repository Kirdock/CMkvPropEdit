using CMkvPropEdit.Classes;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CMkvPropEdit.CustomControls
{
    public partial class AttachmentView : UserControl
    {
        internal Attachments Attachments => new Attachments
        {
            ReplaceAttachments = ReplaceAttachments.ToArray(),
            AddAttachments = AddAttachments.ToArray(),
            DeleteAttachments = DeleteAttachments.ToArray()
        };
        private BindingList<ReplaceAttachment> ReplaceAttachments;
        private BindingList<AddAttachment> AddAttachments;
        private BindingList<DeleteAttachment> DeleteAttachments;
        public AttachmentView()
        {
            InitializeComponent();
            AddAttachments = new BindingList<AddAttachment>()
            {
                AllowNew = true,
                AllowEdit = true
            };
            DeleteAttachments = new BindingList<DeleteAttachment>()
            {
                AllowNew = true,
                AllowEdit = true
            };
            ReplaceAttachments = new BindingList<ReplaceAttachment>()
            {
                AllowNew = true,
                AllowEdit = true
            };
            DGVAdd.DataSource = AddAttachments;
            DGVDelete.DataSource = DeleteAttachments;

            DGVDelete.Columns[0].Visible = false;
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn
            {
                Name = "Type",
                HeaderText = "Type",
                DataSource = Enum.GetValues(typeof(AttachmentType)),
                ValueType = typeof(AttachmentType),
                DataPropertyName = "Type",
            };

            DGVDelete.Columns.Insert(0,col);

            DGVReplace.DataSource = ReplaceAttachments;
        }

        private void DGVDelete_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                switch ((AttachmentType)DGVDelete[0, e.RowIndex].Value)
                {
                    case AttachmentType.Name:
                        if (! (DGVDelete[0, e.RowIndex] is DataGridViewTextBoxCell))
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            
                            DGVDelete.BeginInvoke(new MethodInvoker(() =>
                            {
                                DGVDelete[1, e.RowIndex] = cell;
                                DGVDelete[1, e.RowIndex].Value = string.Empty;
                            }));
                        }
                        break;
                    case AttachmentType.Id:
                        if (DGVDelete[0, e.RowIndex] is DataGridViewComboBoxCell)
                        {
                            NumericUpDownCell cell = new NumericUpDownCell(0, 1000000);
                            DGVDelete.BeginInvoke(new MethodInvoker(() =>
                            {
                                DGVDelete[1, e.RowIndex] = cell;
                                DGVDelete[1, e.RowIndex].Value = 0;
                            }));
                        }
                        break;
                    case AttachmentType.Type:

                        DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                        comboBoxCell.Items.AddRange(StaticData.mimeTypes.Skip(1).ToArray());
                        DGVDelete.BeginInvoke(new MethodInvoker(() =>
                        {
                            DGVDelete[1, e.RowIndex] = comboBoxCell;
                            DGVDelete[1, e.RowIndex].Value = StaticData.mimeTypes[1];
                        }));
                        break;
                }
                
            }
        }
    }
}
