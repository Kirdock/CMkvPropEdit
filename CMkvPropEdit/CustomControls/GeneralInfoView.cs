using CMkvPropEdit.Classes;
using CMkvPropEdit.Helper;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMkvPropEdit.CustomControls
{
    public partial class GeneralInfoView : UserControl
    {
        private GeneralInfo info;
        internal GeneralInfo Info {
            get
            {
                return info;
            }
            set
            {
                info = value;
                SetSelectedItem(info);
            }
        }
        public GeneralInfoView()
        {
            InitializeComponent();
            Info = new GeneralInfo();
        }

        private void SetSelectedItem(GeneralInfo info)
        {
            ClearBindings(ViewService.GetAllControls(this, typeof(TextBox), typeof(RadioButton), typeof(NumericUpDown), typeof(ComboBox), typeof(CheckBox)));
        }

        private void ClearBindings(IEnumerable<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.DataBindings.Clear();
            }
        }
    }
}
