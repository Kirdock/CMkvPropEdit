
namespace CMkvPropEdit.Classes
{
    class TrackInfo : CheckItem
    {
        internal string Name;
        internal BoolCheck DefaultTrack;
        internal BoolCheck Forcedtrack;
        internal TrackNumberCheck TrackNameAndNumber;
        internal TextCheck Language; //language code
        internal TextCheck Parameters;
        internal char Type;


        internal TrackInfo(TrackType type, string name)
        {
            DefaultTrack = new BoolCheck();
            Forcedtrack = new BoolCheck();
            TrackNameAndNumber = new TrackNumberCheck(type);
            Language = new TextCheck();
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
