using System.Data;

namespace CMkvPropEdit.Classes
{
    class Attachments
    {
        internal DataTable AddTable;
        internal DataTable ReplaceTable;
        internal DataTable DeleteTable;

        internal Attachments()
        {
            InitAddTable();
            InitReplaceTable();
            InitDeleteTable();
        }

        private void InitAddTable()
        {
            AddTable = new DataTable("AttachmentAdd");
            AddTable.Columns.Add("File", typeof(string));
            AddTable.Columns.Add("Name", typeof(string));
            AddTable.Columns.Add("Description", typeof(string));
            AddTable.Columns.Add("MIME Type", typeof(string)); //combobox
        }

        private void InitReplaceTable()
        {
            ReplaceTable = new DataTable("AttachmentReplace");
            ReplaceTable.Columns.Add("Type", typeof(AttachmentType));
            ReplaceTable.Columns.Add("Original Value", typeof(string));
            ReplaceTable.Columns.Add("Replacement", typeof(string)); //File
            ReplaceTable.Columns.Add("Name", typeof(string));
            ReplaceTable.Columns.Add("Description", typeof(string));
            ReplaceTable.Columns.Add("MIME Type", typeof(string)); //combobox
        }

        private void InitDeleteTable()
        {
            DeleteTable = new DataTable("AttachmentDelete");
            DeleteTable.Columns.Add("Type", typeof(AttachmentType));
            DeleteTable.Columns.Add("Value", typeof(string)); //combobox
        }
    }

    enum AttachmentType
    {
        Name,
        Id,
        Type
    }
}
