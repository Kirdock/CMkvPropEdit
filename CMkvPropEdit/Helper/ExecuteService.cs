using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using CMkvPropEdit.Classes;
using System.Data;
using System.Windows.Forms;

namespace CMkvPropEdit.Helper
{
    static class ExecuteService
    {
        private static string PadNumber(int pad, int number)
        {
            int numberLength = number.ToString().Length;
            return new string('0', pad - numberLength) + number;
        }

        private static StringBuilder GetGeneralLine(GeneralInfo info, string fileName, int index)
        {
            StringBuilder builder = new StringBuilder();

            if (info.Tags.IsEnabled)
            {
                builder.Append(" --tags all:");
                switch (info.Tags.Action)
                {
                    case ModifyAction.ActionType.From:
                        if (!string.IsNullOrWhiteSpace(info.Tags.FilePath))
                        {
                            builder.Append($"\"{info.Tags.FilePath}\"");
                        }
                        break;
                    case ModifyAction.ActionType.Match:
                        string tmpTags = Path.GetFileNameWithoutExtension(fileName) + info.Tags.Match.Text + info.Tags.Match.Extension;
                        builder.Append($"\"{tmpTags}\"");
                        break;

                    default:
                        break;
                }
            }

            if (info.Chapters.IsEnabled)
            {
                builder.Append(" --chapters ");
                switch (info.Chapters.Action)
                {
                    case ModifyAction.ActionType.Remove:
                        builder.Append("''");
                        break;
                    case ModifyAction.ActionType.From:
                        if (string.IsNullOrWhiteSpace(info.Chapters.FilePath))
                        {
                            builder.Append("''");
                        }
                        else
                        {
                            builder.Append($"\"{info.Chapters.FilePath}\"");
                        }
                        break;
                    case ModifyAction.ActionType.Match:
                        string tmpChaps = Path.GetFileNameWithoutExtension(fileName) +
                                            info.Chapters.Match.Text + info.Chapters.Match.Extension;

                        builder.Append($"\"{tmpChaps}\"");
                        break;
                }
            }

            if (info.TrackNameAndNumber.TrackName.IsEnabled)
            {
                builder.Append(" --edit info");

                string newTitle = info.TrackNameAndNumber.TrackName.Text;

                if (info.TrackNameAndNumber.Numbering.IsEnabled)
                {
                    newTitle = newTitle.Replace("{num}", PadNumber(info.TrackNameAndNumber.Numbering.Padding, info.TrackNameAndNumber.Numbering.Start + index));
                }

                newTitle = newTitle.Replace("{file_name}", Path.GetFileNameWithoutExtension(fileName));

                builder.Append($" --set title=\"{newTitle}\"");
            }

            if (info.Parameters.IsEnabled && !string.IsNullOrWhiteSpace(info.Parameters.Text))
            {
                builder.Append(" ").Append(info.Parameters.Text);
            }
            return builder;
        }

        private static StringBuilder GetTrackLine(TrackInfo[] infos, string fileName, int index)
        {
            StringBuilder fileCmd = new StringBuilder();

            for (int j = 0; j < infos.Length; j++)
            {
                TrackInfo info = infos[j];
                    
                StringBuilder builder = new StringBuilder();
                if (info.IsEnabled)
                {
                    if (info.DefaultTrack.IsEnabled)
                    {
                        builder.Append(" --set flag-default=").Append(info.DefaultTrack.Value ? '1' : '0');
                    }

                    if (info.ForcedTrack.IsEnabled)
                    {
                        builder.Append(" --set flag-forced=").Append(info.ForcedTrack.Value ? '1' : '0');
                    }

                    if (info.TrackNameAndNumber.TrackName.IsEnabled)
                    {
                        string text = info.TrackNameAndNumber.TrackName.Text.Replace("{file_name}", Path.GetFileNameWithoutExtension(fileName));
                        if (info.TrackNameAndNumber.TrackName.IsEnabled && info.TrackNameAndNumber.Numbering.IsEnabled)
                        {
                            text = text.Replace("{num}", PadNumber(info.TrackNameAndNumber.Numbering.Padding, info.TrackNameAndNumber.Numbering.Start + index));
                        }
                        builder.Append($" --set name=\"{text}\"");
                    }
                        
                    if (info.Language.IsEnabled)
                    {
                        builder.Append($" --set language=\"{info.Language.Text}\"");
                    }

                    if (info.Parameters.IsEnabled && !string.IsNullOrWhiteSpace(info.Parameters.Text))
                    {
                        builder.Append(" ").Append(info.Parameters.Text);
                    }

                    if (builder.Length != 0)
                    {
                        builder.Insert(0, $" --edit track:{info.Type}{j + 1}");
                    }
                }
                fileCmd.Append(builder);
            }
            return fileCmd;
        }

        private static string GetAddAttachmentLine(AddAttachment[] attachments)
        {
            StringBuilder command = new StringBuilder();

            foreach(AddAttachment attachment in attachments)
            {
                SetAttachmentMeta(attachment.Name, attachment.Description, attachment.MimeType, command);
                command.Append($" --add-attachment \"{attachment.File}\"");
            }
            return command.ToString();
        }

        private static void SetAttachmentMeta(string name, string desc, string mime, StringBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                builder.Append($" --attachment-name \"{name}\"");
            }

            if (!string.IsNullOrWhiteSpace(mime))
            {
                builder.Append($" --attachment-description \"{desc}\"");
            }

            if (!string.IsNullOrWhiteSpace(desc))
            {
                builder.Append($" --attachment-mime-type \"{mime}\"");
            }
        }

        private static string GetReplaceAttachmentLine(ReplaceAttachment[] attachments)
        {
            StringBuilder command = new StringBuilder();

            foreach(ReplaceAttachment attachment in attachments)
            {
                SetAttachmentMeta(attachment.Name, attachment.Description, attachment.MimeType, command);

                switch (attachment.Type)
                {
                    case AttachmentType.Name:
                        command.Append($" --replace-attachment \"name:{attachment.Value}:{attachment.Replacement}\"");
                        break;
                    case AttachmentType.Id:
                        command.Append($" --replace-attachment \"{attachment.Value}:{attachment.Replacement}\"");
                        break;
                    case AttachmentType.Type:
                        command.Append($" --replace-attachment \"mime-type:{attachment.Value}:{attachment.Replacement}\"");
                        break;
                }
            }
            return command.ToString();
        }

        private static string GetDeleteAttachmentLine(DeleteAttachment[] attachments)
        {
            StringBuilder command = new StringBuilder();

            foreach(DeleteAttachment attachment in attachments)
            {
                switch (attachment.Type)
                {
                    case AttachmentType.Name:
                        command.Append(" --delete-attachment \"name:{value}\"");
                        break;
                    case AttachmentType.Id:
                        command.Append($" --delete-attachment \"{attachment.Value}\"");
                        break;
                    case AttachmentType.Type:
                        command.Append($" --delete-attachment \"mime-type:{attachment.Value}\"");
                        break;
                }
            }
            return command.ToString();
        }

        internal static void Execute(GeneralInfo generalInfo, TrackInfo[] videoInfo, TrackInfo[] audioInfo, TrackInfo[] subtitleInfo, Attachments attachments, string[] fileNames, Action<string, string> update)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    string cmdLineAttachmentsAddOpt = GetAddAttachmentLine(attachments.AddAttachments);
                    string cmdLineAttachmentsReplaceOpt = GetReplaceAttachmentLine(attachments.ReplaceAttachments);
                    string cmdLineAttachmentsDeleteOpt = GetDeleteAttachmentLine(attachments.DeleteAttachments);

                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        string fileName = fileNames[i];
                        string command = $"\"{fileName}\""
                                        + GetGeneralLine(generalInfo, fileName, i)
                                        + cmdLineAttachmentsDeleteOpt
                                        + cmdLineAttachmentsAddOpt
                                        + cmdLineAttachmentsReplaceOpt
                                        + GetTrackLine(videoInfo, fileName, i)
                                        + GetTrackLine(audioInfo, fileName, i)
                                        + GetTrackLine(subtitleInfo, fileName, i);
                        using (System.Diagnostics.Process process = new System.Diagnostics.Process
                        {
                            StartInfo = new System.Diagnostics.ProcessStartInfo
                            {
                                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                                RedirectStandardOutput = true,
                                UseShellExecute = false,
                                CreateNoWindow = true,
                                FileName = Properties.Settings.Default.MKVPropeditPath,
                                Arguments = command,
                                StandardOutputEncoding = Encoding.UTF8
                            },
                        })
                        {
                            process.Start();
                            string output = process.StandardOutput.ReadToEnd();
                            process.WaitForExit();
                            update(command, output);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageService.ShowError(ex.Message);
                }
            });
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
