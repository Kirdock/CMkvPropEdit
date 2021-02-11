using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMkvPropEdit.Classes
{
    [Serializable]
    class Numeration : CheckItem
    {
        public int Start { get; set; }
        public int Padding { get; set; } //Padding for leading zeroes; could be discarded. Can always be added, just take start number and add file count => # of digits - # of digits of current number
        public string Name;
        internal Numeration(TrackType type)
        {
            Start = Padding = 1;
            switch (type)
            {
                case TrackType.General:
                    Name = "Title";
                    break;

                case TrackType.Video:
                    Name = "Video";
                    break;

                case TrackType.Audio:
                    Name = "Audio";
                    break;

                case TrackType.Subtitle:
                default:
                    Name = "Subtitle";
                    break;
            }
        }
    }

    enum TrackType
    {
        General,
        Video,
        Audio,
        Subtitle
    }
}
