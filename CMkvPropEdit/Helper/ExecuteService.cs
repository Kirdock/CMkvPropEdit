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

        private static string[] SetCmdLineGeneral(GeneralInfo info, string[] fileNames)
        {
            string[] cmdLineGeneralOpt = new string[fileNames.Length];

            for (int i = 0; i < fileNames.Length; i++)
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
                            string tmpTags = Path.GetFileNameWithoutExtension(fileNames[i]) + info.Tags.Match.Text + info.Tags.Match.Extension;
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
                            string tmpChaps = Path.GetFileNameWithoutExtension(fileNames[i]) +
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
                        newTitle = newTitle.Replace("{num}", PadNumber(info.TrackNameAndNumber.Numbering.Padding, info.TrackNameAndNumber.Numbering.Start + i));
                    }

                    newTitle = newTitle.Replace("{file_name}", Path.GetFileNameWithoutExtension(fileNames[i]));

                    builder.Append($" --set title=\"{newTitle}\"");
                }

                if (info.Parameters.IsEnabled && !string.IsNullOrWhiteSpace(info.Parameters.Text))
                {
                    builder.Append(" ").Append(info.Parameters.Text);
                }
                cmdLineGeneralOpt[i] = builder.ToString();
            }
            return cmdLineGeneralOpt;
        }

        private static string[] SetCmdLineTrack(TrackInfo[] infos, string[] fileNames)
        {
            string[] cmdLineOpt = new string[fileNames.Length];

            for (int i = 0; i < fileNames.Length; i++)
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
                            string text = info.TrackNameAndNumber.TrackName.Text.Replace("{file_name}", Path.GetFileNameWithoutExtension(fileNames[i]));
                            if (info.TrackNameAndNumber.TrackName.IsEnabled && info.TrackNameAndNumber.Numbering.IsEnabled)
                            {
                                text = text.Replace("{num}", PadNumber(info.TrackNameAndNumber.Numbering.Padding, info.TrackNameAndNumber.Numbering.Start + i));
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
                cmdLineOpt[i] = fileCmd.ToString();
            }
            return cmdLineOpt;
        }

        private static string SetCmdLineAttachmentsAdd(DataTable table)
        {
            StringBuilder attachments = new StringBuilder();

            foreach(DataRow row in table.AsEnumerable())
            {
                string file = row[0].ToString();
                string name = row[1].ToString();
                string desc = row[2].ToString();
                string mime = row[3].ToString();


                SetAttachmentMeta(name, desc, mime, attachments);
                attachments.Append($" --add-attachment \"{file}\"");
            }
            return attachments.ToString();
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

        private static string SetCmdLineAttachmentsReplace(DataTable table)
        {
            StringBuilder attachmentsReplace = new StringBuilder();

            foreach(DataRow row in table.AsEnumerable())
            {
                AttachmentType type = (AttachmentType)row[0];
                string orig = row[1].ToString();
                string replace = row[2].ToString();
                string name = row[3].ToString();
                string desc = row[4].ToString();
                string mime = row[5].ToString();


                SetAttachmentMeta(name, desc, mime, attachmentsReplace);

                switch (type)
                {
                    case AttachmentType.Name:
                        attachmentsReplace.Append($" --replace-attachment \"name:{orig}:{replace}\"");
                        break;
                    case AttachmentType.Id:
                        attachmentsReplace.Append($" --replace-attachment \"{orig}:{replace}\"");
                        break;
                    case AttachmentType.Type:
                        attachmentsReplace.Append($" --replace-attachment \"mime-type:{orig}:{replace}\"");
                        break;
                }
            }
            return attachmentsReplace.ToString();
        }

        private static string SetCmdLineAttachmentsDelete(DataTable table)
        {
            StringBuilder attachmentDelete = new StringBuilder();

            foreach(DataRow row in table.AsEnumerable())
            {
                AttachmentType type = (AttachmentType)row[0];
                string value = row[1].ToString();

                switch (type)
                {
                    case AttachmentType.Name:
                        attachmentDelete.Append(" --delete-attachment \"name:{value}\"");
                        break;
                    case AttachmentType.Id:
                        attachmentDelete.Append($" --delete-attachment \"{value}\"");
                        break;
                    case AttachmentType.Type:
                        attachmentDelete.Append($" --delete-attachment \"mime-type:{value}\"");
                        break;
                }
            }
            return attachmentDelete.ToString();
        }

        internal static void SetCmdLine(GeneralInfo generalInfo, TrackInfo[] videoInfo, TrackInfo[] audioInfo, TrackInfo[] subtitleInfo, Attachments attachments, string[] fileNames, Action<string, string> update)
        {
            //string[] cmdLineGeneralOpt = SetCmdLineGeneral(generalInfo, fileNames);
            string[] cmdLineVideoOpt = SetCmdLineTrack(videoInfo, fileNames);
            string[] cmdLineAudioOpt = SetCmdLineTrack(audioInfo, fileNames);
            string[] cmdLineSubtitleOpt = SetCmdLineTrack(subtitleInfo, fileNames);
            
            //string cmdLineAttachmentsAddOpt = SetCmdLineAttachmentsAdd(attachments.AddTable);
            //string cmdLineAttachmentsDeleteOpt = SetCmdLineAttachmentsReplace(attachments.ReplaceTable);
            //string cmdLineAttachmentsReplaceOpt = SetCmdLineAttachmentsDelete(attachments.DeleteTable);

            string[] cmdLineBatchOpt = new string[fileNames.Length];

            for (int i = 0; i < fileNames.Length; i++)
            {
                //string cmdLineAllOpt = cmdLineGeneralOpt[i] + cmdLineAttachmentsDeleteOpt + cmdLineAttachmentsAddOpt
                //        + cmdLineAttachmentsReplaceOpt + cmdLineVideoOpt[i] + cmdLineAudioOpt[i] + cmdLineSubtitleOpt[i];
                string cmdLineAllOpt = cmdLineVideoOpt[i] + cmdLineAudioOpt[i] + cmdLineSubtitleOpt[i];

                cmdLineBatchOpt[i] = "\"" + fileNames[i] + "\"" + cmdLineAllOpt;
            }

            ExecuteBatch(cmdLineBatchOpt, fileNames, update);
        }

        private static void ExecuteBatch(string[] cmdLineBatchOpt, string[] filesNames, Action<string, string> update)
        {
            Thread thread = new Thread(()=>
            {
                try
                {
                    for (int i = 0; i < cmdLineBatchOpt.Length; i++)
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process
                        {
                            StartInfo = new System.Diagnostics.ProcessStartInfo
                            {
                                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                                RedirectStandardOutput = true,
                                UseShellExecute = false,
                                FileName = Properties.Settings.Default.MKVPropeditPath,
                                Arguments = cmdLineBatchOpt[i]
                            }
                        };
                        process.Start();
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();
                        update(cmdLineBatchOpt[i], output);
                    }
                }
                catch (Exception ex)
                {
                    MessageService.ShowError(ex.Message);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
           
        }



    }
}
