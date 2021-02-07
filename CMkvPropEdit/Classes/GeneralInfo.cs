namespace CMkvPropEdit.Classes
{
    class GeneralInfo
    {
        internal TrackNumberCheck TrackNameAndNumber;
        internal ModifyAction Chapters;
        internal ModifyAction Tags;
        internal TextCheck Parameters;
        //textBox1.DataBindings.Add("Text", bookProperty[0], "bookTitle", true, DataSourceUpdateMode.OnPropertyChanged);

        internal GeneralInfo()
        {
            TrackNameAndNumber = new TrackNumberCheck(TrackType.General);
            Chapters = new ModifyAction(ModifyAction.ModifyType.Chapter);
            Tags = new ModifyAction(ModifyAction.ModifyType.Tag);
            Parameters = new TextCheck();
        }
    }

    class ModifyAction : CheckItem
    {
        internal enum ActionType
        {
            Remove,
            From,
            Match
        }

        internal enum ModifyType
        {
            Chapter,
            Tag
        }

        internal ActionType Action;
        internal string FilePath;
        internal string Name;
        private readonly string DefaultSuffix;
        internal MatchItem Match;
        
        public ModifyAction(ModifyType type)
        {
            DefaultSuffix = type == ModifyType.Chapter ? "-chapters" : "-tags";
            Match = new MatchItem(DefaultSuffix);
        }
    }

    class MatchItem
    {
        
        internal string Extension;
        internal string Text;

        internal MatchItem(string defaultText)
        {
            Text = defaultText;
            Extension = StaticData.MachExtensions[0];
        }
    }
}
