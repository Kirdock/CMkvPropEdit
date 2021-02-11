
namespace CMkvPropEdit.CustomControls
{
    partial class TrackInfoView
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.CBEditTrack = new System.Windows.Forms.CheckBox();
            this.CmBTrack = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.CBDefaultTrack = new System.Windows.Forms.CheckBox();
            this.RBDefaultTrackYes = new System.Windows.Forms.RadioButton();
            this.RBDefaultTrackNo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBTrackName = new System.Windows.Forms.CheckBox();
            this.TxtTrackName = new System.Windows.Forms.TextBox();
            this.CBNumbering = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NBStart = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NBPadding = new System.Windows.Forms.NumericUpDown();
            this.LblTrackName = new System.Windows.Forms.Label();
            this.CBLanguage = new System.Windows.Forms.CheckBox();
            this.CmBLanguage = new System.Windows.Forms.ComboBox();
            this.CBParameters = new System.Windows.Forms.CheckBox();
            this.TxtParameters = new System.Windows.Forms.TextBox();
            this.CBForcedTrack = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RBForcedNo = new System.Windows.Forms.RadioButton();
            this.RBForcedYes = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NBStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBPadding)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBEditTrack
            // 
            this.CBEditTrack.AutoSize = true;
            this.CBEditTrack.Location = new System.Drawing.Point(0, 40);
            this.CBEditTrack.Name = "CBEditTrack";
            this.CBEditTrack.Size = new System.Drawing.Size(93, 17);
            this.CBEditTrack.TabIndex = 0;
            this.CBEditTrack.Text = "Edit this track:";
            this.CBEditTrack.UseVisualStyleBackColor = true;
            this.CBEditTrack.CheckedChanged += new System.EventHandler(this.CBEditTrack_CheckedChanged);
            // 
            // CmBTrack
            // 
            this.CmBTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmBTrack.FormattingEnabled = true;
            this.CmBTrack.Location = new System.Drawing.Point(3, 3);
            this.CmBTrack.Name = "CmBTrack";
            this.CmBTrack.Size = new System.Drawing.Size(121, 21);
            this.CmBTrack.TabIndex = 1;
            this.CmBTrack.SelectedIndexChanged += new System.EventHandler(this.CmBTrack_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(130, 2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(211, 2);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnRemove.TabIndex = 3;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // CBDefaultTrack
            // 
            this.CBDefaultTrack.AutoSize = true;
            this.CBDefaultTrack.Location = new System.Drawing.Point(0, 74);
            this.CBDefaultTrack.Name = "CBDefaultTrack";
            this.CBDefaultTrack.Size = new System.Drawing.Size(90, 17);
            this.CBDefaultTrack.TabIndex = 4;
            this.CBDefaultTrack.Text = "Default track:";
            this.CBDefaultTrack.UseVisualStyleBackColor = true;
            this.CBDefaultTrack.CheckedChanged += new System.EventHandler(this.CBDefaultTrack_CheckedChanged);
            // 
            // RBDefaultTrackYes
            // 
            this.RBDefaultTrackYes.AutoSize = true;
            this.RBDefaultTrackYes.Location = new System.Drawing.Point(4, 11);
            this.RBDefaultTrackYes.Name = "RBDefaultTrackYes";
            this.RBDefaultTrackYes.Size = new System.Drawing.Size(43, 17);
            this.RBDefaultTrackYes.TabIndex = 5;
            this.RBDefaultTrackYes.Text = "Yes";
            this.RBDefaultTrackYes.UseVisualStyleBackColor = true;
            // 
            // RBDefaultTrackNo
            // 
            this.RBDefaultTrackNo.AutoSize = true;
            this.RBDefaultTrackNo.Location = new System.Drawing.Point(53, 11);
            this.RBDefaultTrackNo.Name = "RBDefaultTrackNo";
            this.RBDefaultTrackNo.Size = new System.Drawing.Size(39, 17);
            this.RBDefaultTrackNo.TabIndex = 6;
            this.RBDefaultTrackNo.Text = "No";
            this.RBDefaultTrackNo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.RBDefaultTrackNo);
            this.panel1.Controls.Add(this.RBDefaultTrackYes);
            this.panel1.Location = new System.Drawing.Point(126, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 32);
            this.panel1.TabIndex = 7;
            // 
            // CBTrackName
            // 
            this.CBTrackName.AutoSize = true;
            this.CBTrackName.Location = new System.Drawing.Point(0, 145);
            this.CBTrackName.Name = "CBTrackName";
            this.CBTrackName.Size = new System.Drawing.Size(86, 17);
            this.CBTrackName.TabIndex = 8;
            this.CBTrackName.Text = "Track name:";
            this.CBTrackName.UseVisualStyleBackColor = true;
            this.CBTrackName.CheckedChanged += new System.EventHandler(this.CBTrackName_CheckedChanged);
            // 
            // TxtTrackName
            // 
            this.TxtTrackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTrackName.Location = new System.Drawing.Point(130, 142);
            this.TxtTrackName.Name = "TxtTrackName";
            this.TxtTrackName.Size = new System.Drawing.Size(310, 20);
            this.TxtTrackName.TabIndex = 9;
            // 
            // CBNumbering
            // 
            this.CBNumbering.AutoSize = true;
            this.CBNumbering.Location = new System.Drawing.Point(130, 168);
            this.CBNumbering.Name = "CBNumbering";
            this.CBNumbering.Size = new System.Drawing.Size(80, 17);
            this.CBNumbering.TabIndex = 10;
            this.CBNumbering.Text = "Numbering:";
            this.CBNumbering.UseVisualStyleBackColor = true;
            this.CBNumbering.CheckedChanged += new System.EventHandler(this.CBNumbering_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start";
            // 
            // NBStart
            // 
            this.NBStart.Location = new System.Drawing.Point(254, 167);
            this.NBStart.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NBStart.Name = "NBStart";
            this.NBStart.Size = new System.Drawing.Size(56, 20);
            this.NBStart.TabIndex = 12;
            this.NBStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Padding";
            // 
            // NBPadding
            // 
            this.NBPadding.Location = new System.Drawing.Point(384, 167);
            this.NBPadding.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NBPadding.Name = "NBPadding";
            this.NBPadding.Size = new System.Drawing.Size(56, 20);
            this.NBPadding.TabIndex = 14;
            this.NBPadding.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblTrackName
            // 
            this.LblTrackName.AutoSize = true;
            this.LblTrackName.Location = new System.Drawing.Point(127, 197);
            this.LblTrackName.Name = "LblTrackName";
            this.LblTrackName.Size = new System.Drawing.Size(35, 13);
            this.LblTrackName.TabIndex = 15;
            this.LblTrackName.Text = "label3";
            // 
            // CBLanguage
            // 
            this.CBLanguage.AutoSize = true;
            this.CBLanguage.Location = new System.Drawing.Point(0, 220);
            this.CBLanguage.Name = "CBLanguage";
            this.CBLanguage.Size = new System.Drawing.Size(77, 17);
            this.CBLanguage.TabIndex = 16;
            this.CBLanguage.Text = "Language:";
            this.CBLanguage.UseVisualStyleBackColor = true;
            this.CBLanguage.CheckedChanged += new System.EventHandler(this.CBLanguage_CheckedChanged);
            // 
            // CmBLanguage
            // 
            this.CmBLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmBLanguage.FormattingEnabled = true;
            this.CmBLanguage.Location = new System.Drawing.Point(130, 216);
            this.CmBLanguage.Name = "CmBLanguage";
            this.CmBLanguage.Size = new System.Drawing.Size(254, 21);
            this.CmBLanguage.TabIndex = 17;
            // 
            // CBParameters
            // 
            this.CBParameters.AutoSize = true;
            this.CBParameters.Location = new System.Drawing.Point(0, 259);
            this.CBParameters.Name = "CBParameters";
            this.CBParameters.Size = new System.Drawing.Size(108, 17);
            this.CBParameters.TabIndex = 18;
            this.CBParameters.Text = "Extra parameters:";
            this.CBParameters.UseVisualStyleBackColor = true;
            this.CBParameters.CheckedChanged += new System.EventHandler(this.CBParameters_CheckedChanged);
            // 
            // TxtParameters
            // 
            this.TxtParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtParameters.Location = new System.Drawing.Point(130, 256);
            this.TxtParameters.Name = "TxtParameters";
            this.TxtParameters.Size = new System.Drawing.Size(310, 20);
            this.TxtParameters.TabIndex = 19;
            // 
            // CBForcedTrack
            // 
            this.CBForcedTrack.AutoSize = true;
            this.CBForcedTrack.Location = new System.Drawing.Point(0, 110);
            this.CBForcedTrack.Name = "CBForcedTrack";
            this.CBForcedTrack.Size = new System.Drawing.Size(90, 17);
            this.CBForcedTrack.TabIndex = 20;
            this.CBForcedTrack.Text = "Forced Track";
            this.CBForcedTrack.UseVisualStyleBackColor = true;
            this.CBForcedTrack.CheckedChanged += new System.EventHandler(this.CBForcedTrack_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.RBForcedNo);
            this.panel2.Controls.Add(this.RBForcedYes);
            this.panel2.Location = new System.Drawing.Point(126, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(111, 32);
            this.panel2.TabIndex = 8;
            // 
            // RBForcedNo
            // 
            this.RBForcedNo.AutoSize = true;
            this.RBForcedNo.Location = new System.Drawing.Point(53, 11);
            this.RBForcedNo.Name = "RBForcedNo";
            this.RBForcedNo.Size = new System.Drawing.Size(39, 17);
            this.RBForcedNo.TabIndex = 6;
            this.RBForcedNo.Text = "No";
            this.RBForcedNo.UseVisualStyleBackColor = true;
            // 
            // RBForcedYes
            // 
            this.RBForcedYes.AutoSize = true;
            this.RBForcedYes.Location = new System.Drawing.Point(4, 11);
            this.RBForcedYes.Name = "RBForcedYes";
            this.RBForcedYes.Size = new System.Drawing.Size(43, 17);
            this.RBForcedYes.TabIndex = 5;
            this.RBForcedYes.Text = "Yes";
            this.RBForcedYes.UseVisualStyleBackColor = true;
            // 
            // TrackInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CBForcedTrack);
            this.Controls.Add(this.TxtParameters);
            this.Controls.Add(this.CBParameters);
            this.Controls.Add(this.CmBLanguage);
            this.Controls.Add(this.CBLanguage);
            this.Controls.Add(this.LblTrackName);
            this.Controls.Add(this.NBPadding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NBStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBNumbering);
            this.Controls.Add(this.TxtTrackName);
            this.Controls.Add(this.CBTrackName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CBDefaultTrack);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.CmBTrack);
            this.Controls.Add(this.CBEditTrack);
            this.Name = "TrackInfoView";
            this.Size = new System.Drawing.Size(499, 331);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NBStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBPadding)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CBEditTrack;
        private System.Windows.Forms.ComboBox CmBTrack;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.CheckBox CBDefaultTrack;
        private System.Windows.Forms.RadioButton RBDefaultTrackYes;
        private System.Windows.Forms.RadioButton RBDefaultTrackNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CBTrackName;
        private System.Windows.Forms.TextBox TxtTrackName;
        private System.Windows.Forms.CheckBox CBNumbering;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NBStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NBPadding;
        private System.Windows.Forms.Label LblTrackName;
        private System.Windows.Forms.CheckBox CBLanguage;
        private System.Windows.Forms.ComboBox CmBLanguage;
        private System.Windows.Forms.CheckBox CBParameters;
        private System.Windows.Forms.TextBox TxtParameters;
        private System.Windows.Forms.CheckBox CBForcedTrack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton RBForcedNo;
        private System.Windows.Forms.RadioButton RBForcedYes;
    }
}
