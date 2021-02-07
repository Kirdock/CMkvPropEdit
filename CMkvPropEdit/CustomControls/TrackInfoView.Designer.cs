
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
            this.panel1.SuspendLayout();
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
            // TrackInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CBDefaultTrack);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.CmBTrack);
            this.Controls.Add(this.CBEditTrack);
            this.Name = "TrackInfoView";
            this.Size = new System.Drawing.Size(746, 266);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}
