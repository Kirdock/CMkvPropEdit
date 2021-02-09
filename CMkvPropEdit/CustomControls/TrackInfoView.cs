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

        #region ugly code; have to find a better solution. Maybe just do it with OnChange instead of bindings
        public bool IsDefaultEnabled {
            get
            {
                return SelectedTrack.IsEnabled;
            }
            set
            {
                SelectedTrack.IsEnabled = value;
                IsForcedTrackChildEnabled = IsDefaultTrackChildEnabled = false;
            }
        }

        public bool IsForcedTrackEnabled
        {
            get
            {
                return SelectedTrack.ForcedTrack.IsEnabled;
            }
            set
            {
                SelectedTrack.ForcedTrack.IsEnabled = value;
                IsForcedTrackChildEnabled = false;
            }
        }
        public bool IsDefaultTrackEnabled
        {
            get
            {
                return SelectedTrack.DefaultTrack.IsEnabled;
            }
            set
            {
                SelectedTrack.DefaultTrack.IsEnabled = value;
                IsDefaultTrackChildEnabled = false;
            }
        }
        private bool isForcedTrackChildEnabled;
        public bool IsForcedTrackChildEnabled
        {
            get
            {
                return isForcedTrackChildEnabled;
            }
            set
            {
                if (SelectedTrack != null) //I hate you Form Designer; JUST DON'T SET IT!!!!
                    isForcedTrackChildEnabled = SelectedTrack.IsEnabled && SelectedTrack.ForcedTrack.IsEnabled;
            }
        }
        private bool isDefaultTrackChildEnabled;
        public bool IsDefaultTrackChildEnabled
        {
            get
            {
                return isDefaultTrackChildEnabled;
            }
            set
            {
                if(SelectedTrack != null) //I hate you Form Designer; JUST DON'T SET IT!!!!
                    isDefaultTrackChildEnabled = SelectedTrack.IsEnabled && SelectedTrack.DefaultTrack.IsEnabled;
            }
        }
        #endregion

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
        }

        private void SetSelectedItem(TrackInfo info)
        {
            ClearBindings(CBEditTrack, RBDefaultTrackNo, RBDefaultTrackYes, CBDefaultTrack, CBForcedTrack, CBTrackName, RBForcedNo, RBForcedYes, CmBLanguage, NBStart, NBPadding, CBNumbering, CBParameters, TxtParameters, TxtTrackName, CBLanguage);
            isDefaultTrackChildEnabled = info.DefaultTrack.IsEnabled;
            isForcedTrackChildEnabled = info.ForcedTrack.IsEnabled;
            SetEnabled("IsDefaultEnabled", CBDefaultTrack, CBTrackName, CBLanguage, CBParameters, CBForcedTrack);
            SetEnabled("IsDefaultTrackChildEnabled", RBDefaultTrackYes, RBDefaultTrackNo);
            SetEnabled("IsForcedTrackChildEnabled", RBForcedYes, RBForcedNo);

            CBEditTrack.DataBindings.Add(TwoWayBinding("Checked", this, "IsDefaultEnabled"));
            CBDefaultTrack.DataBindings.Add(TwoWayBinding("Checked", this, "IsDefaultTrackEnabled"));
            CBForcedTrack.DataBindings.Add(TwoWayBinding("Checked", this, "IsForcedTrackEnabled"));

            CBLanguage.DataBindings.Add(TwoWayBinding("Checked", info.Language, "IsEnabled"));
            CBTrackName.DataBindings.Add(TwoWayBinding("Checked", info.TrackNameAndNumber.TrackName, "IsEnabled"));
            CBParameters.DataBindings.Add(TwoWayBinding("Checked", info.Parameters, "IsEnabled"));

            RBDefaultTrackYes.DataBindings.Add(TwoWayBinding("Checked", info.DefaultTrack, "Value"));
            RBForcedYes.DataBindings.Add(TwoWayBinding("Checked", info.ForcedTrack, "Value"));
            TxtTrackName.DataBindings.Add("Text", info.TrackNameAndNumber.TrackName, "Text");
            TxtParameters.DataBindings.Add("Text", info.Parameters, "Text");
            CBNumbering.DataBindings.Add(TwoWayBinding("Checked", info.TrackNameAndNumber.Numbering, "IsEnabled"));
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

        private Binding TwoWayBinding(string property, object source, string dataMember)
        {
            return new Binding(property, source, dataMember)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged
            };
        }

        
        private void ClearBindings(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.DataBindings.Clear();
            }
        }

        private void SetEnabled(string property, params Control[] controls)
        {
            foreach(Control control in controls)
            {
                control.DataBindings.Add(new Binding("Enabled", this, property)
                {
                    DataSourceUpdateMode = DataSourceUpdateMode.Never,
                    ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                });
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
    }
}
