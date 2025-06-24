
namespace CMkvPropEdit.CustomControls
{
    partial class AttachmentView
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DGVAdd = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGVDelete = new System.Windows.Forms.DataGridView();
            this.DGVReplace = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAdd)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReplace)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(499, 331);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DGVAdd);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Attachments";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DGVAdd
            // 
            this.DGVAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVAdd.Location = new System.Drawing.Point(3, 3);
            this.DGVAdd.Name = "DGVAdd";
            this.DGVAdd.Size = new System.Drawing.Size(485, 299);
            this.DGVAdd.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGVReplace);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(491, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Replace Attachments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DGVDelete);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(491, 305);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete Attachments";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DGVDelete
            // 
            this.DGVDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDelete.Location = new System.Drawing.Point(0, 0);
            this.DGVDelete.Name = "DGVDelete";
            this.DGVDelete.Size = new System.Drawing.Size(491, 305);
            this.DGVDelete.TabIndex = 0;
            this.DGVDelete.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDelete_CellEndEdit);
            // 
            // DGVReplace
            // 
            this.DGVReplace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVReplace.Location = new System.Drawing.Point(3, 3);
            this.DGVReplace.Name = "DGVReplace";
            this.DGVReplace.Size = new System.Drawing.Size(485, 299);
            this.DGVReplace.TabIndex = 0;
            // 
            // AttachmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "AttachmentView";
            this.Size = new System.Drawing.Size(499, 331);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAdd)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReplace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView DGVAdd;
        private System.Windows.Forms.DataGridView DGVDelete;
        private System.Windows.Forms.DataGridView DGVReplace;
    }
}
