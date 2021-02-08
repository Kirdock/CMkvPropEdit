using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMkvPropEdit.Classes
{
    [Serializable]
    class Preset
    {
        public GeneralInfo Info;
        public TrackInfo[] VideoInfo;
        public TrackInfo[] AudioInfo;
        public TrackInfo[] SubtitleInfo;
        public Attachments Attachments;

        internal Preset(GeneralInfo info, TrackInfo[] videoInfo, TrackInfo[] audioInfo, TrackInfo[] subtitleInfo, Attachments attachments)
        {
            Info = info;
            VideoInfo = videoInfo;
            AudioInfo = audioInfo;
            SubtitleInfo = subtitleInfo;
            Attachments = attachments;
        }
    }
}
