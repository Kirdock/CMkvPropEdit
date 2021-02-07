
using CMkvPropEdit.CustomControls;

namespace CMkvPropEdit
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TPInput = new System.Windows.Forms.TabPage();
            this.BtnInputFolder = new System.Windows.Forms.Button();
            this.BtnInputRemove = new System.Windows.Forms.Button();
            this.BtnInputAdd = new System.Windows.Forms.Button();
            this.BtnInputClear = new System.Windows.Forms.Button();
            this.LBInput = new System.Windows.Forms.ListBox();
            this.TPGeneral = new System.Windows.Forms.TabPage();
            this.TPVideo = new System.Windows.Forms.TabPage();
            this.TPAudio = new System.Windows.Forms.TabPage();
            this.TPSubtitles = new System.Windows.Forms.TabPage();
            this.TPOptions = new System.Windows.Forms.TabPage();
            this.BtnOptionRenamePreset = new System.Windows.Forms.Button();
            this.BtnOptionDeletePreset = new System.Windows.Forms.Button();
            this.BtnOptionSavePreset = new System.Windows.Forms.Button();
            this.BtnOptionLoadPreset = new System.Windows.Forms.Button();
            this.CmBOptionPresets = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnOptionsRevertPreset = new System.Windows.Forms.Button();
            this.BtnOptionsRevertPropedit = new System.Windows.Forms.Button();
            this.BtnOptionsBrowsePreset = new System.Windows.Forms.Button();
            this.TxtOptionsPresetPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnOptionsBrowsePropedit = new System.Windows.Forms.Button();
            this.TxtOptionsPropeditPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TPOutput = new System.Windows.Forms.TabPage();
            this.BtnProcessFiles = new System.Windows.Forms.Button();
            this.videoTrackView = new TrackInfoView(Classes.TrackType.Video);
            this.audioTrackView = new TrackInfoView(Classes.TrackType.Audio);
            this.subtitleTrackView = new TrackInfoView(Classes.TrackType.Subtitle);
            this.tabControl1.SuspendLayout();
            this.TPInput.SuspendLayout();
            this.TPVideo.SuspendLayout();
            this.TPAudio.SuspendLayout();
            this.TPSubtitles.SuspendLayout();
            this.TPOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TPInput);
            this.tabControl1.Controls.Add(this.TPGeneral);
            this.tabControl1.Controls.Add(this.TPVideo);
            this.tabControl1.Controls.Add(this.TPAudio);
            this.tabControl1.Controls.Add(this.TPSubtitles);
            this.tabControl1.Controls.Add(this.TPOptions);
            this.tabControl1.Controls.Add(this.TPOutput);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 406);
            this.tabControl1.TabIndex = 0;
            // 
            // TPInput
            // 
            this.TPInput.Controls.Add(this.BtnInputFolder);
            this.TPInput.Controls.Add(this.BtnInputRemove);
            this.TPInput.Controls.Add(this.BtnInputAdd);
            this.TPInput.Controls.Add(this.BtnInputClear);
            this.TPInput.Controls.Add(this.LBInput);
            this.TPInput.Location = new System.Drawing.Point(4, 22);
            this.TPInput.Name = "TPInput";
            this.TPInput.Padding = new System.Windows.Forms.Padding(3);
            this.TPInput.Size = new System.Drawing.Size(790, 380);
            this.TPInput.TabIndex = 0;
            this.TPInput.Text = "Input";
            this.TPInput.UseVisualStyleBackColor = true;
            // 
            // BtnInputFolder
            // 
            this.BtnInputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnInputFolder.Location = new System.Drawing.Point(707, 35);
            this.BtnInputFolder.Name = "BtnInputFolder";
            this.BtnInputFolder.Size = new System.Drawing.Size(75, 23);
            this.BtnInputFolder.TabIndex = 4;
            this.BtnInputFolder.Text = "Folder";
            this.BtnInputFolder.UseVisualStyleBackColor = true;
            this.BtnInputFolder.Click += new System.EventHandler(this.BtnInputFolder_Click);
            // 
            // BtnInputRemove
            // 
            this.BtnInputRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnInputRemove.Location = new System.Drawing.Point(707, 64);
            this.BtnInputRemove.Name = "BtnInputRemove";
            this.BtnInputRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnInputRemove.TabIndex = 3;
            this.BtnInputRemove.Text = "Remove";
            this.BtnInputRemove.UseVisualStyleBackColor = true;
            this.BtnInputRemove.Click += new System.EventHandler(this.BtnInputRemove_Click);
            // 
            // BtnInputAdd
            // 
            this.BtnInputAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnInputAdd.Location = new System.Drawing.Point(707, 6);
            this.BtnInputAdd.Name = "BtnInputAdd";
            this.BtnInputAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnInputAdd.TabIndex = 2;
            this.BtnInputAdd.Text = "Add";
            this.BtnInputAdd.UseVisualStyleBackColor = true;
            this.BtnInputAdd.Click += new System.EventHandler(this.BtnInputAdd_Click);
            // 
            // BtnInputClear
            // 
            this.BtnInputClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnInputClear.Location = new System.Drawing.Point(707, 93);
            this.BtnInputClear.Name = "BtnInputClear";
            this.BtnInputClear.Size = new System.Drawing.Size(75, 23);
            this.BtnInputClear.TabIndex = 1;
            this.BtnInputClear.Text = "Clear";
            this.BtnInputClear.UseVisualStyleBackColor = true;
            this.BtnInputClear.Click += new System.EventHandler(this.BtnInputClear_Click);
            // 
            // LBInput
            // 
            this.LBInput.AllowDrop = true;
            this.LBInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBInput.FormattingEnabled = true;
            this.LBInput.HorizontalScrollbar = true;
            this.LBInput.Location = new System.Drawing.Point(0, 0);
            this.LBInput.Name = "LBInput";
            this.LBInput.Size = new System.Drawing.Size(701, 381);
            this.LBInput.TabIndex = 0;
            this.LBInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.LBInput_DragDrop);
            this.LBInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.LBInput_DragEnter);
            // 
            // TPGeneral
            // 
            this.TPGeneral.Location = new System.Drawing.Point(4, 22);
            this.TPGeneral.Name = "TPGeneral";
            this.TPGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TPGeneral.Size = new System.Drawing.Size(790, 380);
            this.TPGeneral.TabIndex = 1;
            this.TPGeneral.Text = "General";
            this.TPGeneral.UseVisualStyleBackColor = true;
            // 
            // TPVideo
            // 
            this.TPVideo.Controls.Add(this.videoTrackView);
            this.TPVideo.Location = new System.Drawing.Point(4, 22);
            this.TPVideo.Name = "TPVideo";
            this.TPVideo.Padding = new System.Windows.Forms.Padding(3);
            this.TPVideo.Size = new System.Drawing.Size(790, 380);
            this.TPVideo.TabIndex = 2;
            this.TPVideo.Text = "Video";
            this.TPVideo.UseVisualStyleBackColor = true;
            // 
            // videoTrackView
            // 
            this.videoTrackView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoTrackView.Location = new System.Drawing.Point(3, 3);
            this.videoTrackView.Name = "videoTrackView";
            this.videoTrackView.Size = new System.Drawing.Size(784, 374);
            this.videoTrackView.TabIndex = 0;
            // 
            // TPAudio
            // 
            this.TPAudio.Controls.Add(this.audioTrackView);
            this.TPAudio.Location = new System.Drawing.Point(4, 22);
            this.TPAudio.Name = "TPAudio";
            this.TPAudio.Padding = new System.Windows.Forms.Padding(3);
            this.TPAudio.Size = new System.Drawing.Size(790, 380);
            this.TPAudio.TabIndex = 3;
            this.TPAudio.Text = "Audio";
            this.TPAudio.UseVisualStyleBackColor = true;
            // 
            // audioTrackView
            // 
            this.audioTrackView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioTrackView.Location = new System.Drawing.Point(3, 3);
            this.audioTrackView.Name = "audioTrackView";
            this.audioTrackView.Size = new System.Drawing.Size(784, 374);
            this.audioTrackView.TabIndex = 0;
            // 
            // TPSubtitles
            // 
            this.TPSubtitles.Controls.Add(this.subtitleTrackView);
            this.TPSubtitles.Location = new System.Drawing.Point(4, 22);
            this.TPSubtitles.Name = "TPSubtitles";
            this.TPSubtitles.Padding = new System.Windows.Forms.Padding(3);
            this.TPSubtitles.Size = new System.Drawing.Size(790, 380);
            this.TPSubtitles.TabIndex = 4;
            this.TPSubtitles.Text = "Subtitles";
            this.TPSubtitles.UseVisualStyleBackColor = true;
            // 
            // subtitleTrackView
            // 
            this.subtitleTrackView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subtitleTrackView.Location = new System.Drawing.Point(3, 3);
            this.subtitleTrackView.Name = "subtitleTrackView";
            this.subtitleTrackView.Size = new System.Drawing.Size(784, 374);
            this.subtitleTrackView.TabIndex = 0;
            // 
            // TPOptions
            // 
            this.TPOptions.Controls.Add(this.BtnOptionRenamePreset);
            this.TPOptions.Controls.Add(this.BtnOptionDeletePreset);
            this.TPOptions.Controls.Add(this.BtnOptionSavePreset);
            this.TPOptions.Controls.Add(this.BtnOptionLoadPreset);
            this.TPOptions.Controls.Add(this.CmBOptionPresets);
            this.TPOptions.Controls.Add(this.label3);
            this.TPOptions.Controls.Add(this.BtnOptionsRevertPreset);
            this.TPOptions.Controls.Add(this.BtnOptionsRevertPropedit);
            this.TPOptions.Controls.Add(this.BtnOptionsBrowsePreset);
            this.TPOptions.Controls.Add(this.TxtOptionsPresetPath);
            this.TPOptions.Controls.Add(this.label2);
            this.TPOptions.Controls.Add(this.BtnOptionsBrowsePropedit);
            this.TPOptions.Controls.Add(this.TxtOptionsPropeditPath);
            this.TPOptions.Controls.Add(this.label1);
            this.TPOptions.Location = new System.Drawing.Point(4, 22);
            this.TPOptions.Name = "TPOptions";
            this.TPOptions.Padding = new System.Windows.Forms.Padding(3);
            this.TPOptions.Size = new System.Drawing.Size(790, 380);
            this.TPOptions.TabIndex = 6;
            this.TPOptions.Text = "Options";
            this.TPOptions.UseVisualStyleBackColor = true;
            // 
            // BtnOptionRenamePreset
            // 
            this.BtnOptionRenamePreset.Location = new System.Drawing.Point(264, 135);
            this.BtnOptionRenamePreset.Name = "BtnOptionRenamePreset";
            this.BtnOptionRenamePreset.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionRenamePreset.TabIndex = 15;
            this.BtnOptionRenamePreset.Text = "Rename";
            this.BtnOptionRenamePreset.UseVisualStyleBackColor = true;
            this.BtnOptionRenamePreset.Click += new System.EventHandler(this.BtnOptionRenamePreset_Click);
            // 
            // BtnOptionDeletePreset
            // 
            this.BtnOptionDeletePreset.Location = new System.Drawing.Point(345, 135);
            this.BtnOptionDeletePreset.Name = "BtnOptionDeletePreset";
            this.BtnOptionDeletePreset.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionDeletePreset.TabIndex = 14;
            this.BtnOptionDeletePreset.Text = "Delete";
            this.BtnOptionDeletePreset.UseVisualStyleBackColor = true;
            this.BtnOptionDeletePreset.Click += new System.EventHandler(this.BtnOptionDeletePreset_Click);
            // 
            // BtnOptionSavePreset
            // 
            this.BtnOptionSavePreset.Location = new System.Drawing.Point(264, 106);
            this.BtnOptionSavePreset.Name = "BtnOptionSavePreset";
            this.BtnOptionSavePreset.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionSavePreset.TabIndex = 13;
            this.BtnOptionSavePreset.Text = "Save";
            this.BtnOptionSavePreset.UseVisualStyleBackColor = true;
            this.BtnOptionSavePreset.Click += new System.EventHandler(this.BtnOptionSavePreset_Click);
            // 
            // BtnOptionLoadPreset
            // 
            this.BtnOptionLoadPreset.Location = new System.Drawing.Point(345, 106);
            this.BtnOptionLoadPreset.Name = "BtnOptionLoadPreset";
            this.BtnOptionLoadPreset.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionLoadPreset.TabIndex = 12;
            this.BtnOptionLoadPreset.Text = "Load";
            this.BtnOptionLoadPreset.UseVisualStyleBackColor = true;
            this.BtnOptionLoadPreset.Click += new System.EventHandler(this.BtnOptionLoadPreset_Click);
            // 
            // CmBOptionPresets
            // 
            this.CmBOptionPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmBOptionPresets.FormattingEnabled = true;
            this.CmBOptionPresets.Location = new System.Drawing.Point(137, 106);
            this.CmBOptionPresets.Name = "CmBOptionPresets";
            this.CmBOptionPresets.Size = new System.Drawing.Size(121, 21);
            this.CmBOptionPresets.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Presets";
            // 
            // BtnOptionsRevertPreset
            // 
            this.BtnOptionsRevertPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOptionsRevertPreset.Location = new System.Drawing.Point(709, 46);
            this.BtnOptionsRevertPreset.Name = "BtnOptionsRevertPreset";
            this.BtnOptionsRevertPreset.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionsRevertPreset.TabIndex = 9;
            this.BtnOptionsRevertPreset.Text = "Reset";
            this.BtnOptionsRevertPreset.UseVisualStyleBackColor = true;
            this.BtnOptionsRevertPreset.Click += new System.EventHandler(this.BtnOptionsRevertPreset_Click);
            // 
            // BtnOptionsRevertPropedit
            // 
            this.BtnOptionsRevertPropedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOptionsRevertPropedit.Location = new System.Drawing.Point(708, 6);
            this.BtnOptionsRevertPropedit.Name = "BtnOptionsRevertPropedit";
            this.BtnOptionsRevertPropedit.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionsRevertPropedit.TabIndex = 8;
            this.BtnOptionsRevertPropedit.Text = "Reset";
            this.BtnOptionsRevertPropedit.UseVisualStyleBackColor = true;
            this.BtnOptionsRevertPropedit.Click += new System.EventHandler(this.BtnOptionsRevertPropedit_Click);
            // 
            // BtnOptionsBrowsePreset
            // 
            this.BtnOptionsBrowsePreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOptionsBrowsePreset.Location = new System.Drawing.Point(627, 46);
            this.BtnOptionsBrowsePreset.Name = "BtnOptionsBrowsePreset";
            this.BtnOptionsBrowsePreset.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionsBrowsePreset.TabIndex = 6;
            this.BtnOptionsBrowsePreset.Text = "Browse";
            this.BtnOptionsBrowsePreset.UseVisualStyleBackColor = true;
            this.BtnOptionsBrowsePreset.Click += new System.EventHandler(this.BtnOptionsBrowsePreset_Click);
            // 
            // TxtOptionsPresetPath
            // 
            this.TxtOptionsPresetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOptionsPresetPath.Location = new System.Drawing.Point(137, 48);
            this.TxtOptionsPresetPath.Name = "TxtOptionsPresetPath";
            this.TxtOptionsPresetPath.ReadOnly = true;
            this.TxtOptionsPresetPath.Size = new System.Drawing.Size(484, 20);
            this.TxtOptionsPresetPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Preset folder:";
            // 
            // BtnOptionsBrowsePropedit
            // 
            this.BtnOptionsBrowsePropedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOptionsBrowsePropedit.Location = new System.Drawing.Point(627, 6);
            this.BtnOptionsBrowsePropedit.Name = "BtnOptionsBrowsePropedit";
            this.BtnOptionsBrowsePropedit.Size = new System.Drawing.Size(75, 23);
            this.BtnOptionsBrowsePropedit.TabIndex = 2;
            this.BtnOptionsBrowsePropedit.Text = "Browse";
            this.BtnOptionsBrowsePropedit.UseVisualStyleBackColor = true;
            this.BtnOptionsBrowsePropedit.Click += new System.EventHandler(this.BtnOptionsBrowse_Click);
            // 
            // TxtOptionsPropeditPath
            // 
            this.TxtOptionsPropeditPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOptionsPropeditPath.Location = new System.Drawing.Point(138, 8);
            this.TxtOptionsPropeditPath.Name = "TxtOptionsPropeditPath";
            this.TxtOptionsPropeditPath.ReadOnly = true;
            this.TxtOptionsPropeditPath.Size = new System.Drawing.Size(483, 20);
            this.TxtOptionsPropeditPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mkvpropedit executable:";
            // 
            // TPOutput
            // 
            this.TPOutput.Location = new System.Drawing.Point(4, 22);
            this.TPOutput.Name = "TPOutput";
            this.TPOutput.Padding = new System.Windows.Forms.Padding(3);
            this.TPOutput.Size = new System.Drawing.Size(790, 380);
            this.TPOutput.TabIndex = 5;
            this.TPOutput.Text = "Output";
            this.TPOutput.UseVisualStyleBackColor = true;
            // 
            // BtnProcessFiles
            // 
            this.BtnProcessFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProcessFiles.Location = new System.Drawing.Point(364, 415);
            this.BtnProcessFiles.Name = "BtnProcessFiles";
            this.BtnProcessFiles.Size = new System.Drawing.Size(75, 23);
            this.BtnProcessFiles.TabIndex = 1;
            this.BtnProcessFiles.Text = "Process files";
            this.BtnProcessFiles.UseVisualStyleBackColor = true;
            this.BtnProcessFiles.Click += new System.EventHandler(this.BtnProcessFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnProcessFiles);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMkvPropEdit";
            this.tabControl1.ResumeLayout(false);
            this.TPInput.ResumeLayout(false);
            this.TPVideo.ResumeLayout(false);
            this.TPAudio.ResumeLayout(false);
            this.TPSubtitles.ResumeLayout(false);
            this.TPOptions.ResumeLayout(false);
            this.TPOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TPInput;
        private System.Windows.Forms.TabPage TPGeneral;
        private System.Windows.Forms.TabPage TPVideo;
        private System.Windows.Forms.TabPage TPAudio;
        private System.Windows.Forms.TabPage TPSubtitles;
        private System.Windows.Forms.TabPage TPOutput;
        private System.Windows.Forms.ListBox LBInput;
        private System.Windows.Forms.Button BtnInputClear;
        private System.Windows.Forms.Button BtnInputFolder;
        private System.Windows.Forms.Button BtnInputRemove;
        private System.Windows.Forms.Button BtnInputAdd;
        private System.Windows.Forms.TabPage TPOptions;
        private System.Windows.Forms.Button BtnOptionsBrowsePropedit;
        private System.Windows.Forms.TextBox TxtOptionsPropeditPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnProcessFiles;
        private System.Windows.Forms.Button BtnOptionsBrowsePreset;
        private System.Windows.Forms.TextBox TxtOptionsPresetPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnOptionsRevertPropedit;
        private System.Windows.Forms.Button BtnOptionsRevertPreset;
        private System.Windows.Forms.Button BtnOptionSavePreset;
        private System.Windows.Forms.Button BtnOptionLoadPreset;
        private System.Windows.Forms.ComboBox CmBOptionPresets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnOptionRenamePreset;
        private System.Windows.Forms.Button BtnOptionDeletePreset;
        private TrackInfoView videoTrackView;
        private TrackInfoView audioTrackView;
        private TrackInfoView subtitleTrackView;
    }
}

