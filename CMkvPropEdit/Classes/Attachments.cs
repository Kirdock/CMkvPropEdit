using System;
using System.Data;

namespace CMkvPropEdit.Classes
{
    [Serializable]
    class Attachments
    {
        public AddAttachment[] AddAttachments;
        public ReplaceAttachment[] ReplaceAttachments;
        public DeleteAttachment[] DeleteAttachments;

        internal Attachments()
        {
            AddAttachments = new AddAttachment[0];
            ReplaceAttachments = new ReplaceAttachment[0];
            DeleteAttachments = new DeleteAttachment[0];
        }
    }

    enum AttachmentType
    {
        Name,
        Id,
        Type
    }

    [Serializable]
    class AddAttachment
    {
        public string File { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [System.ComponentModel.DisplayName("MIME Type")]
        public string MimeType { get; set; } //combobox
    }

    [Serializable]
    class ReplaceAttachment
    {
        public AttachmentType Type { get; set; } //Depending on the type the value is string, integer or MimeType (combobox)
        [System.ComponentModel.DisplayName("Original value")]
        public string Value { get; set; } //Cell type depends on AttachmentType
        public string Replacement { get; set; } //File
        public string Name { get; set; }
        public string Description { get; set; }
        [System.ComponentModel.DisplayName("MIME Type")]
        public string MimeType { get; set; } //combobox
    }

    [Serializable]
    class DeleteAttachment
    {
        public AttachmentType Type { get; set; }
        public string Value { get; set; } //combobox
    }
}
