using CMkvPropEdit.Classes;
using CMkvPropEdit.Helper;
using CMkvPropEdit.View;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CMkvPropEdit
{
    public partial class Form1 : Form
    {
        private string DefaultPresetPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CMkvPropEdit", "Presets");
        private readonly string FileExtension = ".mkv";
        public Form1()
        {
            InitializeComponent();
            videoTrackView.SetType(TrackType.Video);
            audioTrackView.SetType(TrackType.Audio);
            subtitleTrackView.SetType(TrackType.Subtitle);
            InitSettings();
        }

        private void InitSettings()
        {
            if (Properties.Settings.Default.MKVPropeditPath == string.Empty)
            {
                SetDefaultMkvPropedit();
            }
            else if (!File.Exists(Properties.Settings.Default.MKVPropeditPath))
            {
                MessageService.ShowWarning("mkvpropedit.exe not found\nReverting back to default");
                SetDefaultMkvPropedit();
            }
            if(Properties.Settings.Default.PresetPath == string.Empty)
            {
                SetDefaultPresetPath();
            }
            else if (!Directory.Exists(Properties.Settings.Default.PresetPath))
            {
                MessageService.ShowWarning("Preset directory not found\nReverting back to default");
                SetDefaultPresetPath();
            }

            TxtOptionsPresetPath.Text = Properties.Settings.Default.PresetPath;
            TxtOptionsPropeditPath.Text = Properties.Settings.Default.MKVPropeditPath;
            CmBOptionPresets.Items.AddRange(SaveService.GetPresetNames().ToArray());
            if (CmBOptionPresets.Items.Count != 0)
            {
                CmBOptionPresets.SelectedIndex = 0;
            }
        }

        private void CreateDirectoryIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        #region Input
        private void AddFiles(string[] files)
        {
            LBInput.Items.AddRange(files);
        }

        private void LBInput_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void LBInput_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AddFiles(files.SelectMany(file => Path.HasExtension(file) ? new string[] { file } : Directory.GetFiles(file, $"*{FileExtension}", SearchOption.AllDirectories)).Where(file => Path.GetExtension(file) == FileExtension).ToArray());
        }

        private void BtnInputClear_Click(object sender, EventArgs e)
        {
            LBInput.Items.Clear();
        }

        private void BtnInputAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = $"MKV Files (*{FileExtension})|*{FileExtension}",
                RestoreDirectory = true,
                Multiselect = true
            };
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                AddFiles(dialog.FileNames);
            }
        }

        private void BtnInputRemove_Click(object sender, EventArgs e)
        {
            if(LBInput.SelectedIndex != -1)
            {
                LBInput.Items.RemoveAt(LBInput.SelectedIndex);
            }
        }

        private void BtnInputFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                RestoreDirectory = true,
                IsFolderPicker = true,
                Multiselect = true
            };
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                AddFiles(dialog.FileNames.SelectMany(folder => Directory.GetFiles(folder, $"*{FileExtension}", SearchOption.AllDirectories)).ToArray());
            }
        }
        #endregion

        #region Options
        private void BtnOptionsBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = $"Executable File (*.exe)|*.exe",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.MKVPropeditPath = TxtOptionsPropeditPath.Text = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void SetDefaultPresetPath()
        {
            CreateDirectoryIfNotExists(DefaultPresetPath);
            TxtOptionsPresetPath.Text = Properties.Settings.Default.PresetPath = DefaultPresetPath;
            Properties.Settings.Default.Save();
        }

        private void SetDefaultMkvPropedit()
        {
            bool fileFound = false;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\MKVtoolnix") ?? Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\MKVtoolnix");
            
            if(key != null)
            {
                string value = key.GetValue("UninstallString")?.ToString();
                if (value != null)
                {
                    string path = Path.Combine(Directory.GetParent(value).FullName, "mkvpropedit.exe");
                    if (File.Exists(path))
                    {
                        TxtOptionsPropeditPath.Text = Properties.Settings.Default.MKVPropeditPath = path;
                        fileFound = true;
                    }
                }
            }
            if(!fileFound)
            {
                MessageService.ShowWarning("mkvpropedit.exe not found");
            }
            Properties.Settings.Default.Save();
        }

        private void BtnOptionsBrowsePreset_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                RestoreDirectory = true,
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Properties.Settings.Default.PresetPath = TxtOptionsPresetPath.Text = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }
        private void BtnOptionsRevertPropedit_Click(object sender, EventArgs e)
        {
            SetDefaultMkvPropedit();
        }

        private void BtnOptionsRevertPreset_Click(object sender, EventArgs e)
        {
            SetDefaultPresetPath();
        }

        private void BtnOptionSavePreset_Click(object sender, EventArgs e)
        {
            HashSet<string> fileNames = new HashSet<string>(SaveService.GetPresetNames());
            using (InsertText form = new InsertText("Enter preset name", "Enter name", permittedNames: fileNames))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Preset preset = new Preset(null, videoTrackView.TrackInfos.ToArray(), audioTrackView.TrackInfos.ToArray(), subtitleTrackView.TrackInfos.ToArray(), null);
                    if (SaveService.SavePreset(preset, form.NewText))
                    {
                        if (fileNames.Contains(form.NewText))
                        {
                            MessageService.ShowInformation("Overwritten");
                        }
                        else
                        {
                            CmBOptionPresets.Items.Add(form.NewText);
                            MessageService.ShowInformation("Saved");
                        }
                    }
                }
            }
        }

        private void BtnOptionRenamePreset_Click(object sender, EventArgs e)
        {
            if (CmBOptionPresets.SelectedIndex != -1)
            {
                string selectedPresetName = CmBOptionPresets.SelectedItem.ToString();
                HashSet<string> permittedNames = new HashSet<string>(CmBOptionPresets.Items.Cast<string>().Where(preset => preset != selectedPresetName));
                using (InsertText form = new InsertText("Rename preset name", "Enter name", selectedPresetName, permittedNames: permittedNames))
                {
                    if (form.ShowDialog() == DialogResult.OK && selectedPresetName != form.NewText)
                    {
                        if (SaveService.RenamePreset(selectedPresetName, form.NewText))
                        {
                            CmBOptionPresets.Items[CmBOptionPresets.SelectedIndex] = form.NewText;
                            MessageService.ShowInformation("Renamed");
                        }
                    }
                }
            }
        }

        private void BtnOptionDeletePreset_Click(object sender, EventArgs e)
        {
            if (CmBOptionPresets.SelectedIndex != -1)
            {
                if (SaveService.DeletePreset(CmBOptionPresets.SelectedItem.ToString()))
                {
                    int index = CmBOptionPresets.SelectedIndex;
                    CmBOptionPresets.Items.RemoveAt(CmBOptionPresets.SelectedIndex);
                    if (index > 1)
                    {
                        index--;
                    }
                    if (CmBOptionPresets.Items.Count != 0)
                    {
                        CmBOptionPresets.SelectedIndex = index;
                    }
                    MessageService.ShowInformation("Deleted");
                }
            }
        }

        private void BtnOptionLoadPreset_Click(object sender, EventArgs e)
        {
            if (CmBOptionPresets.SelectedIndex != -1)
            {
                Preset preset = SaveService.LoadPreset(CmBOptionPresets.SelectedItem.ToString());
                if (preset != null)
                {
                    videoTrackView.TrackInfos = preset.VideoInfo.ToList();
                    subtitleTrackView.TrackInfos = preset.SubtitleInfo.ToList();
                    audioTrackView.TrackInfos = preset.AudioInfo.ToList();
                    MessageService.ShowInformation("Loaded");
                }
            }
        }


        #endregion

        private void StartProgressBar(int count)
        {
            PgLoading.Value = 0;
            PgLoading.Maximum = count;
        }

        private void UpdateProgressbar()
        {
            PgLoading.Invoke(new MethodInvoker(()=>
            {
                if (PgLoading.Value < PgLoading.Maximum)
                {
                    PgLoading.Value++;
                    if(PgLoading.Value == PgLoading.Maximum)
                    {
                        MessageService.ShowInformation("Finished!");
                        PgLoading.Value = PgLoading.Maximum = 0;
                    }
                }
            }));
        }

        private void UpdateOutput(string command, string output)
        {
            RTxtOutput.Invoke(new MethodInvoker(() =>
            {
                RTxtOutput.SelectionFont = new System.Drawing.Font(RTxtOutput.Font, System.Drawing.FontStyle.Bold);
                RTxtOutput.AppendText("Command:");
                RTxtOutput.SelectionFont = new System.Drawing.Font(RTxtOutput.Font, System.Drawing.FontStyle.Regular);
                RTxtOutput.AppendText(Environment.NewLine + command);
                RTxtOutput.SelectionFont = new System.Drawing.Font(RTxtOutput.Font, System.Drawing.FontStyle.Bold);
                RTxtOutput.AppendText(Environment.NewLine + "Output:");
                RTxtOutput.SelectionFont = new System.Drawing.Font(RTxtOutput.Font, System.Drawing.FontStyle.Regular);
                RTxtOutput.AppendText(Environment.NewLine + output + Environment.NewLine);
            }));
        }

        private void Updates(string command, string output)
        {
            UpdateProgressbar();
            UpdateOutput(command, output);
        }

        private void BtnProcessFiles_Click(object sender, EventArgs e)
        {
            StartProgressBar(LBInput.Items.Count);
            ClearOutput();
            ExecuteService.SetCmdLine(null, videoTrackView.TrackInfos.ToArray(), audioTrackView.TrackInfos.ToArray(), subtitleTrackView.TrackInfos.ToArray(), null, LBInput.Items.Cast<string>().ToArray(), Updates);
        }

        private void ClearOutput()
        {
            RTxtOutput.Text = string.Empty;
        }
    }
}
