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
        private static string EscapeBackslashes(string text)
        {
            return text;
        }

        private static string PadNumber(int pad, int number)
        {
            int numberLength = number.ToString().Length;
            return new string('0', pad - numberLength) + number;
        }

        private static string EscapeName(string text)
        {
            //return text.Replace("\"", "####escaped__quotes#####").Replace("\\", "\\\\");
            return text;
        }

        private static string[] SetCmdLineGeneral(GeneralInfo info, string[] fileNames)
        {
            string[] cmdLineGeneralOpt = new string[fileNames.Length];
            int currentNumber = info.TrackNameAndNumber.Numbering.Start;

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
                                builder.Append('\"').Append(EscapeName(info.Tags.FilePath)).Append('\"');
                            }
                            break;
                        case ModifyAction.ActionType.Match:
                            string tmpTags = Path.GetFileNameWithoutExtension(fileNames[i]) + info.Tags.Match.Text + info.Tags.Match.Extension;
                            builder.Append('\"').Append(EscapeName(tmpTags)).Append('\"');
                            break;

                        default:
                            break;
                    }
                }

                if (info.Tags.IsEnabled)
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
                                builder.Append('\"').Append(EscapeName(info.Chapters.FilePath)).Append('\"');
                            }
                            break;
                        case ModifyAction.ActionType.Match:
                            string tmpChaps = Path.GetFileNameWithoutExtension(fileNames[i]) +
                                              info.Chapters.Match.Text + info.Chapters.Match.Extension;

                            builder.Append('\"').Append(EscapeName(tmpChaps)).Append('\"');
                            break;
                    }
                }

                if (info.TrackNameAndNumber.TrackName.IsEnabled)
                {
                    builder.Append(" --edit info");

                    string newTitle = info.TrackNameAndNumber.TrackName.Text;

                    if (info.TrackNameAndNumber.Numbering.IsEnabled)
                    {
                        int pad = 0;
                        pad = info.TrackNameAndNumber.Numbering.Padding;
                        newTitle = newTitle.Replace("{num}", PadNumber(pad, currentNumber));

                        currentNumber++;
                    }

                    newTitle = newTitle.Replace("{file_name}", Path.GetFileNameWithoutExtension(fileNames[i]));

                    builder.Append(" --set title=\"").Append(EscapeName(newTitle)).Append('\"');
                }

                if (info.Parameters.IsEnabled && !string.IsNullOrWhiteSpace(info.Parameters.Text))
                {
                    builder.Append(" ").Append(EscapeName(info.Parameters.Text));
                }
                cmdLineGeneralOpt[i] = builder.ToString();
            }
            return cmdLineGeneralOpt;
        }

        private static string[] SetCmdLineTrack(TrackInfo[] infos, string[] fileNames)
        {
            string[] cmdLineOpt = new string[fileNames.Length];
            string[] tmpCmdLineOpt = new string[infos.Length];
            int[] numStart = new int[infos.Length];
            int[] numPad = new int[infos.Length];

            for (int i = 0; i < fileNames.Length; i++)
            {
                cmdLineOpt[i] = "";

                for (int j = 0; j < infos.Length; j++)
                {
                    TrackInfo info = infos[j];
                    tmpCmdLineOpt[j] = "";
                    if (info.IsEnabled)
                    {
                        numStart[j] = info.TrackNameAndNumber.Numbering.Start;
                        numPad[j] = info.TrackNameAndNumber.Numbering.Padding;
                        StringBuilder builder = new StringBuilder();

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
                            builder.Append(" --set name=\"").Append(EscapeName(info.TrackNameAndNumber.TrackName.Text)).Append("\"");
                        }
                        
                        if (info.Language.IsEnabled)
                        {
                            builder.Append(" --set language=\"").Append(info.Language.Text).Append("\"");
                        }

                        if (info.Parameters.IsEnabled && !string.IsNullOrWhiteSpace(info.Parameters.Text))
                        {
                            builder.Append(" ").Append(EscapeBackslashes(info.Parameters.Text));
                        }

                        if (builder.Length != 0)
                        {
                            tmpCmdLineOpt[j] = $" --edit track:{info.Type}" + (j + 1) + builder.ToString();
                        }
                    }
                }
            }

            for (int i = 0; i < infos.Length; i++)
            {
                TrackInfo info = infos[i];
                for (int j = 0; j < fileNames.Length; j++)
                {
                    string tmpText2 = tmpCmdLineOpt[i];

                    if (info.TrackNameAndNumber.TrackName.IsEnabled && info.TrackNameAndNumber.Numbering.IsEnabled)
                    {
                        tmpText2 = tmpText2.Replace("{num}", PadNumber(numPad[i], numStart[i]));
                        numStart[i]++;
                    }

                    tmpText2 = tmpText2.Replace("{file_name}", Path.GetFileNameWithoutExtension(fileNames[j]));

                    cmdLineOpt[j] += tmpText2;
                }
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


                SetMeta(name, desc, mime, attachments);
                attachments.Append(" --add-attachment \"").Append(EscapeName(file)).Append('\"');
            }
            return attachments.ToString();
        }

        private static void SetMeta(string name, string desc, string mime, StringBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                builder.Append(" --attachment-name \"").Append(EscapeName(name)).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(mime))
            {
                builder.Append(" --attachment-description \"").Append(EscapeName(desc)).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(desc))
            {
                builder.Append(" --attachment-mime-type \"").Append(EscapeName(mime)).Append('\"');
            }
        }

        private static string SetCmdLineAttachmentsReplace(DataTable table)
        {
            StringBuilder attachmentsDelete = new StringBuilder();

            foreach(DataRow row in table.AsEnumerable())
            {
                AttachmentType type = (AttachmentType)row[0];
                string orig = row[1].ToString();
                string replace = row[2].ToString();
                string name = row[3].ToString();
                string desc = row[4].ToString();
                string mime = row[5].ToString();


                SetMeta(name, desc, mime, attachmentsDelete);

                switch (type)
                {
                    case AttachmentType.Name:
                        attachmentsDelete.Append(" --replace-attachment \"name:").Append(EscapeName(orig)).Append(':').Append(EscapeName(replace)).Append('\"');
                        break;
                    case AttachmentType.Id:
                        attachmentsDelete.Append(" --replace-attachment \"").Append(orig).Append(':').Append(EscapeName(replace)).Append('\"');
                        break;
                    case AttachmentType.Type:
                        attachmentsDelete.Append(" --replace-attachment \"mime-type:").Append(EscapeName(orig)).Append(':').Append(EscapeName(replace)).Append('\"');
                        break;
                }
            }
            return attachmentsDelete.ToString();
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
                        attachmentDelete.Append(" --delete-attachment \"name:").Append(EscapeName(value)).Append('\"');
                        break;
                    case AttachmentType.Id:
                        attachmentDelete.Append(" --delete-attachment \"").Append(value).Append('\"');
                        break;
                    case AttachmentType.Type:
                        attachmentDelete.Append(" --delete-attachment \"mime-type:").Append(EscapeName(value)).Append('\"');
                        break;
                }
            }
            return attachmentDelete.ToString();
        }

        internal static void SetCmdLine(GeneralInfo generalInfo, TrackInfo[] videoInfo, TrackInfo[] audioInfo, TrackInfo[] subtitleInfo, Attachments attachments, string[] fileNames, Action update)
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

                cmdLineBatchOpt[i] = "\"" + EscapeName(fileNames[i]) + "\"" + cmdLineAllOpt;
            }

            ExecuteBatch(cmdLineBatchOpt, fileNames, update);
        }

        private static void ExecuteBatch(string[] cmdLineBatchOpt, string[] filesNames, Action update)
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
                                FileName = Properties.Settings.Default.MKVPropeditPath,
                                Arguments = cmdLineBatchOpt[i]
                            }
                        };
                        process.Start();
                        process.WaitForExit();
                        update();
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
