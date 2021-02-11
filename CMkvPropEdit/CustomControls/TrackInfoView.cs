using CMkvPropEdit.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CMkvPropEdit.CustomControls
{
    public partial class TrackInfoView : UserControl
    {
        private TrackType Type;
        private string DefaultTrackName;
        private readonly string EnabledProperty = "IsEnabled";
        private List<TrackInfo> trackInfos;
        internal List<TrackInfo> TrackInfos
        {
            get
            {
                return trackInfos;
            }
            set
            {
                trackInfos = value;
                CmBTrack.Items.Clear();
                if (trackInfos.Count != 0)
                {
                    CmBTrack.Items.AddRange(trackInfos.Select(info => info.Name).ToArray());
                    CmBTrack.SelectedIndex = 0;
                }
            }
        }
        private TrackInfo SelectedTrack;

        public TrackInfoView()
        {
            InitializeComponent();
            TrackInfos = new List<TrackInfo>();
        }

        internal void SetType(TrackType type)
        {
            Type = type;
            switch (type)
            {
                case TrackType.Video:
                    DefaultTrackName = "Video Track";
                    break;
                case TrackType.Audio:
                    DefaultTrackName = "Audio Track";
                    break;
                case TrackType.Subtitle:
                    DefaultTrackName = "Subtitle Track";
                    break;

                default:
                    break;
            }
            LblTrackName.Text = "To use it, add {num} to the name (e.g. \"My " + type.ToString() + " {num}\"). Use {file_name} to use the file name as the name.";
            CmBLanguage.DataSource = new BindingSource(StaticData.Languages, null);
            CmBLanguage.DisplayMember = "value";
            CmBLanguage.ValueMember = "key";
            BtnAdd_Click(null, null);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = $"{DefaultTrackName} {CmBTrack.Items.Count + 1}";
            TrackInfo info = new TrackInfo(Type, name);
            TrackInfos.Add(info);
            CmBTrack.Items.Add(name);

            CmBTrack.SelectedIndex = CmBTrack.Items.Count -1;
        }

        private void CmBTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTrack = TrackInfos[CmBTrack.SelectedIndex];
            SetSelectedItem(SelectedTrack);
            CBEditTrack_CheckedChanged(CBEditTrack, e);
        }

        private void SetSelectedItem(TrackInfo info)
        {
            ClearBindings(GetAllControls(this, typeof(CheckBox), typeof(RadioButton), typeof(ComboBox), typeof(NumericUpDown), typeof(TextBox)));

            SetEnabled(CBDefaultTrack, CBTrackName, CBLanguage, CBParameters, CBForcedTrack);
            
            CBEditTrack.DataBindings.Add(TwoWayBinding("Checked", info, EnabledProperty));
            CBDefaultTrack.DataBindings.Add(TwoWayBinding("Checked", info.DefaultTrack, EnabledProperty));
            CBForcedTrack.DataBindings.Add(TwoWayBinding("Checked", info.ForcedTrack, EnabledProperty));
            CBLanguage.DataBindings.Add(TwoWayBinding("Checked", info.Language, EnabledProperty));
            CBTrackName.DataBindings.Add(TwoWayBinding("Checked", info.TrackNameAndNumber.TrackName, EnabledProperty));
            CBParameters.DataBindings.Add(TwoWayBinding("Checked", info.Parameters, EnabledProperty));
            CBNumbering.DataBindings.Add(TwoWayBinding("Checked", info.TrackNameAndNumber.Numbering, EnabledProperty));

            RBDefaultTrackYes.DataBindings.Add(TwoWayBinding("Checked", info.DefaultTrack, "Value"));
            RBForcedYes.DataBindings.Add(TwoWayBinding("Checked", info.ForcedTrack, "Value"));

            TxtTrackName.DataBindings.Add(TwoWayBinding("Text", info.TrackNameAndNumber.TrackName, "Text"));
            TxtParameters.DataBindings.Add(TwoWayBinding("Text", info.Parameters, "Text"));
            
            NBStart.DataBindings.Add(TwoWayBinding("Value", info.TrackNameAndNumber.Numbering, "Start"));
            NBPadding.DataBindings.Add(TwoWayBinding("Value", info.TrackNameAndNumber.Numbering, "Padding"));
            CmBLanguage.DataBindings.Add(TwoWayBinding("SelectedValue", info.Language, "Text"));


            if (!info.DefaultTrack.Value)
            {
                RBDefaultTrackNo.Checked = true;
            }
            if (!info.ForcedTrack.Value)
            {
                RBForcedNo.Checked = true;
            }
        }

        public IEnumerable<Control> GetAllControls(Control control, params Type[] types)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, types))
                                      .Concat(controls)
                                      .Where(c => types.Contains(c.GetType()));
        }

        private Binding TwoWayBinding(string property, object source, string dataMember)
        {
            return new Binding(property, source, dataMember)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged
            };
        }

        private void ClearBindings(IEnumerable<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.DataBindings.Clear();
            }
        }

        private void SetEnabled(params Control[] controls)
        {
            foreach(Control control in controls)
            {
                control.DataBindings.Add(new Binding("Enabled", SelectedTrack, EnabledProperty)
                {
                    DataSourceUpdateMode = DataSourceUpdateMode.Never,
                    ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                });
            }
        }

        private void SetChildEnabled(object sender, params Control[] controls)
        {
            SetChildEnabled(((CheckBox)sender).Checked, controls);
        }

        private void SetChildEnabled(bool status, params Control[] controls)
        {
            status &= SelectedTrack.IsEnabled;
            foreach (Control control in controls)
            {
                control.Enabled = status;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (CmBTrack.SelectedIndex != -1)
            {
                int index = CmBTrack.SelectedIndex;
                TrackInfos.RemoveAt(index);
                CmBTrack.Items.RemoveAt(index);
                CmBTrack.SelectedIndex = index - 1;
            }
        }

        private void CBEditTrack_CheckedChanged(object sender, EventArgs e)
        {
            CBDefaultTrack_CheckedChanged(CBDefaultTrack, e);
            CBForcedTrack_CheckedChanged(CBForcedTrack, e);
            CBTrackName_CheckedChanged(CBTrackName, e);
            CBLanguage_CheckedChanged(CBLanguage, e);
            CBParameters_CheckedChanged(CBParameters, e);
        }

        private void CBDefaultTrack_CheckedChanged(object sender, EventArgs e)
        {
            SetChildEnabled(sender, RBDefaultTrackNo, RBDefaultTrackYes);
            
        }

        private void CBForcedTrack_CheckedChanged(object sender, EventArgs e)
        {
            SetChildEnabled(sender, RBForcedNo, RBForcedYes);
        }

        private void CBTrackName_CheckedChanged(object sender, EventArgs e)
        {
            SetChildEnabled(sender, TxtTrackName, CBNumbering);
            CBNumbering_CheckedChanged(CBNumbering, e);
        }

        private void CBNumbering_CheckedChanged(object sender, EventArgs e)
        {
            SetChildEnabled(CBTrackName.Checked && CBNumbering.Checked, NBPadding, NBStart);
        }

        private void CBLanguage_CheckedChanged(object sender, EventArgs e)
        {
            SetChildEnabled(sender, CmBLanguage);
        }

        private void CBParameters_CheckedChanged(object sender, EventArgs e)
        {
            SetChildEnabled(sender, TxtParameters);
        }
    }
}
