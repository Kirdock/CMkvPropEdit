using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMkvPropEdit.Classes
{
    class Numeration : CheckItem
    {
        internal int Start;
        internal int Padding; //Padding for leading zeroes; could be discarded. Can always be added, just take start number and add file count => # of digits - # of digits of current number
        internal string Name;
        //internal string Description => "To use it, add {num} to the name (e.g. \"My "+ Name + " {num}\"). Use {file_name} to use the file name as the name.";
        internal Numeration(TrackType type)
        {
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
