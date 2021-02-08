
using System;

namespace CMkvPropEdit.Classes
{
    [Serializable]
    class TrackInfo : CheckItem
    {
        public string Name;
        public BoolCheck DefaultTrack;
        public BoolCheck ForcedTrack;
        public TrackNumberCheck TrackNameAndNumber;
        public TextCheck Language; //language code
        public TextCheck Parameters;
        public char Type;


        internal TrackInfo(TrackType type, string name)
        {
            DefaultTrack = new BoolCheck();
            ForcedTrack = new BoolCheck();
            TrackNameAndNumber = new TrackNumberCheck(type);
            Language = new TextCheck() { Text = "und" };
            Parameters = new TextCheck();
            Name = name;
            switch (type)
            {
                case TrackType.Video:
                    Type = 'v';
                    break;
                case TrackType.Audio:
                    Type = 'a';
                    break;
                
                case TrackType.Subtitle:
                default:
                    Type = 's';
                    break;
            }
        }
    }
}
