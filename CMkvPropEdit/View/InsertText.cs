using CMkvPropEdit.Helper;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMkvPropEdit.View
{
    public partial class InsertText : Form
    {
        internal string NewText => TxTName.Text;
        private readonly HashSet<string> PermittedNames;

        internal InsertText(string header, string description, string oldName = "", HashSet<string> permittedNames = null)
        {
            InitializeComponent();
            Text = header;
            LblDescription.Text = description;
            TxTName.Text = oldName;
            PermittedNames = permittedNames;
        }

        private void TxTName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Confirm();
            }
        }

        private void Confirm()
        {
            if (PermittedNames != null && PermittedNames.Contains(TxTName.Text))
            {
                MessageService.ShowWarning("Name is already taken!");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnConfirm_Click(object sender, System.EventArgs e)
        {
            Confirm();
        }
    }
}
