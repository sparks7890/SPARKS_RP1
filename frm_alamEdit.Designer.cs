namespace Alam_Function
{
    partial class frm_alamEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAlamFiles = new System.Windows.Forms.DataGridView();
            this.panel_AlamEdit = new System.Windows.Forms.Panel();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnEXIT = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlamFiles)).BeginInit();
            this.panel_AlamEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAlamFiles
            // 
            this.dgvAlamFiles.AllowDrop = true;
            this.dgvAlamFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlamFiles.Location = new System.Drawing.Point(12, 21);
            this.dgvAlamFiles.Name = "dgvAlamFiles";
            this.dgvAlamFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAlamFiles.RowTemplate.Height = 23;
            this.dgvAlamFiles.Size = new System.Drawing.Size(535, 515);
            this.dgvAlamFiles.TabIndex = 2;
            // 
            // panel_AlamEdit
            // 
            this.panel_AlamEdit.Controls.Add(this.btnimport);
            this.panel_AlamEdit.Controls.Add(this.btnEXIT);
            this.panel_AlamEdit.Controls.Add(this.btnedit);
            this.panel_AlamEdit.Controls.Add(this.btnsave);
            this.panel_AlamEdit.Controls.Add(this.dgvAlamFiles);
            this.panel_AlamEdit.Location = new System.Drawing.Point(40, 27);
            this.panel_AlamEdit.Name = "panel_AlamEdit";
            this.panel_AlamEdit.Size = new System.Drawing.Size(690, 543);
            this.panel_AlamEdit.TabIndex = 3;
            // 
            // btnimport
            // 
            this.btnimport.Location = new System.Drawing.Point(571, 139);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(100, 54);
            this.btnimport.TabIndex = 6;
            this.btnimport.Text = "导入";
            this.btnimport.UseVisualStyleBackColor = true;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
            // 
            // btnEXIT
            // 
            this.btnEXIT.Location = new System.Drawing.Point(571, 297);
            this.btnEXIT.Name = "btnEXIT";
            this.btnEXIT.Size = new System.Drawing.Size(100, 54);
            this.btnEXIT.TabIndex = 5;
            this.btnEXIT.Text = "退出";
            this.btnEXIT.UseVisualStyleBackColor = true;
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(571, 215);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(100, 54);
            this.btnedit.TabIndex = 4;
            this.btnedit.Text = "编辑";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(571, 70);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 54);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // frm_alamEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 582);
            this.Controls.Add(this.panel_AlamEdit);
            this.Name = "frm_alamEdit";
            this.Text = "frm_alamEdit";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlamFiles)).EndInit();
            this.panel_AlamEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlamFiles;
        private System.Windows.Forms.Panel panel_AlamEdit;
        private System.Windows.Forms.Button btnEXIT;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnimport;
    }
}