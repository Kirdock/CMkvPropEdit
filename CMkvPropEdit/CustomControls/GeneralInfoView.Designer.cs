
namespace CMkvPropEdit.CustomControls
{
    partial class GeneralInfoView
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
            this.NBPadding = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NBStart = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CBNumbering = new System.Windows.Forms.CheckBox();
            this.TxtTrackName = new System.Windows.Forms.TextBox();
            this.CBTrackName = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NBPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBStart)).BeginInit();
            this.SuspendLayout();
            // 
            // NBPadding
            // 
            this.NBPadding.Location = new System.Drawing.Point(387, 28);
            this.NBPadding.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NBPadding.Name = "NBPadding";
            this.NBPadding.Size = new System.Drawing.Size(56, 20);
            this.NBPadding.TabIndex = 21;
            this.NBPadding.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Padding";
            // 
            // NBStart
            // 
            this.NBStart.Location = new System.Drawing.Point(257, 28);
            this.NBStart.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NBStart.Name = "NBStart";
            this.NBStart.Size = new System.Drawing.Size(56, 20);
            this.NBStart.TabIndex = 19;
            this.NBStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Start";
            // 
            // CBNumbering
            // 
            this.CBNumbering.AutoSize = true;
            this.CBNumbering.Location = new System.Drawing.Point(133, 29);
            this.CBNumbering.Name = "CBNumbering";
            this.CBNumbering.Size = new System.Drawing.Size(80, 17);
            this.CBNumbering.TabIndex = 17;
            this.CBNumbering.Text = "Numbering:";
            this.CBNumbering.UseVisualStyleBackColor = true;
            // 
            // TxtTrackName
            // 
            this.TxtTrackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTrackName.Location = new System.Drawing.Point(133, 3);
            this.TxtTrackName.Name = "TxtTrackName";
            this.TxtTrackName.Size = new System.Drawing.Size(310, 20);
            this.TxtTrackName.TabIndex = 16;
            // 
            // CBTrackName
            // 
            this.CBTrackName.AutoSize = true;
            this.CBTrackName.Location = new System.Drawing.Point(3, 3);
            this.CBTrackName.Name = "CBTrackName";
            this.CBTrackName.Size = new System.Drawing.Size(86, 17);
            this.CBTrackName.TabIndex = 15;
            this.CBTrackName.Text = "Track name:";
            this.CBTrackName.UseVisualStyleBackColor = true;
            // 
            // GeneralInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NBPadding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NBStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBNumbering);
            this.Controls.Add(this.TxtTrackName);
            this.Controls.Add(this.CBTrackName);
            this.Name = "GeneralInfoView";
            this.Size = new System.Drawing.Size(499, 331);
            ((System.ComponentModel.ISupportInitialize)(this.NBPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NBPadding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NBStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CBNumbering;
        private System.Windows.Forms.TextBox TxtTrackName;
        private System.Windows.Forms.CheckBox CBTrackName;
    }
}
