namespace CMkvPropEdit.Classes
{
    class TrackNumberCheck
    {
        internal TextCheck TrackName;
        internal Numeration Numbering;

        internal TrackNumberCheck(TrackType type)
        {
            TrackName = new TextCheck();
            Numbering = new Numeration(type);
        }
    }
}
