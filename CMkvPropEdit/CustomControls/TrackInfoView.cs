using CMkvPropEdit.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMkvPropEdit.CustomControls
{
    public partial class TrackInfoView : UserControl
    {
        private readonly TrackType Type;
        private readonly string DefaultTrackName;
        internal readonly List<TrackInfo> TrackInfos;
        private TrackInfo SelectedTrack;

        public bool IsDefaultEnabled {
            get
            {
                return SelectedTrack.IsEnabled;
            }
            set
            {
                SelectedTrack.IsEnabled = value;
                IsDefaultTrackChildEnabled = false;
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
        private bool isDefaultTrackChildEnabled;
        public bool IsDefaultTrackChildEnabled
        {
            get
            {
                return isDefaultTrackChildEnabled;
            }
            set
            {
                isDefaultTrackChildEnabled = SelectedTrack.IsEnabled && SelectedTrack.DefaultTrack.IsEnabled;
            }
        }

        internal TrackInfoView(TrackType type)
        {
            InitializeComponent();
            TrackInfos = new List<TrackInfo>();
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
            BtnAdd_Click(null, null);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = $"{DefaultTrackName} {CmBTrack.Items.Count + 1}";
            TrackInfo info = new TrackInfo(Type, name);
            TrackInfos.Add(info);
            CmBTrack.Items.Add(name);

            CmBTrack.SelectedIndex = 0;
        }

        private void CmBTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTrack = TrackInfos[CmBTrack.SelectedIndex];
            SetSelectedItem(SelectedTrack);
        }

        private void SetSelectedItem(TrackInfo info)
        {
            CBEditTrack.DataBindings.Clear();
            RBDefaultTrackYes.DataBindings.Clear();
            CBDefaultTrack.DataBindings.Clear();
            RBDefaultTrackNo.DataBindings.Clear();
            isDefaultTrackChildEnabled = info.DefaultTrack.IsEnabled;

            CBDefaultTrack.DataBindings.Add(new Binding("Enabled", this, "IsDefaultEnabled")
            {
                DataSourceUpdateMode = DataSourceUpdateMode.Never,
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged
            });

            RBDefaultTrackYes.DataBindings.Add(new Binding("Enabled", this, "IsDefaultTrackChildEnabled")
            {
                DataSourceUpdateMode = DataSourceUpdateMode.Never,
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
            });

            RBDefaultTrackNo.DataBindings.Add(new Binding("Enabled", this, "IsDefaultTrackChildEnabled")
            {
                DataSourceUpdateMode = DataSourceUpdateMode.Never,
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
            });


            CBEditTrack.DataBindings.Add(new Binding("Checked", this, "IsDefaultEnabled")
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged
            });


            CBDefaultTrack.DataBindings.Add(new Binding("Checked", this, "IsDefaultTrackEnabled")
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged
            });
            

            
            RBDefaultTrackYes.DataBindings.Add("Checked", info.DefaultTrack, "Value");
            
            if (!info.DefaultTrack.Value)
            {
                RBDefaultTrackNo.Checked = true;
            }
        }
    }
}
