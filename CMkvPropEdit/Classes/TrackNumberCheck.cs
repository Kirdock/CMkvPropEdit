using System;

namespace CMkvPropEdit.Classes
{
    [Serializable]
    class TrackNumberCheck
    {
        public TextCheck TrackName;
        public Numeration Numbering;

        internal TrackNumberCheck(TrackType type)
        {
            TrackName = new TextCheck();
            Numbering = new Numeration(type);
        }
    }
}
