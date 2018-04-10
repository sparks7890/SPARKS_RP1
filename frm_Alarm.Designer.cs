namespace Alam_Function
{
    partial class frm_Alarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Alarm));
            this.panelTool = new System.Windows.Forms.Panel();
            this.radBtnAlarmHistory = new System.Windows.Forms.RadioButton();
            this.radBtnAlarmCurrent = new System.Windows.Forms.RadioButton();
            this.panelAlarmCurrent = new System.Windows.Forms.Panel();
            this.listBoxAlarmCurrent = new System.Windows.Forms.ListBox();
            this.labCurrentAlarm = new System.Windows.Forms.Label();
            this.panelAlarmHistory = new System.Windows.Forms.Panel();
            this.listBoxAlarmHistory = new System.Windows.Forms.ListBox();
            this.labHistoryAlarm = new System.Windows.Forms.Label();
            this.panelTool.SuspendLayout();
            this.panelAlarmCurrent.SuspendLayout();
            this.panelAlarmHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTool
            // 
            this.panelTool.BackColor = System.Drawing.Color.SeaGreen;
            this.panelTool.Controls.Add(this.radBtnAlarmHistory);
            this.panelTool.Controls.Add(this.radBtnAlarmCurrent);
            this.panelTool.Location = new System.Drawing.Point(831, 15);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(119, 608);
            this.panelTool.TabIndex = 2;
            // 
            // radBtnAlarmHistory
            // 
            this.radBtnAlarmHistory.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnAlarmHistory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radBtnAlarmHistory.BackgroundImage")));
            this.radBtnAlarmHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radBtnAlarmHistory.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmHistory.FlatAppearance.BorderSize = 0;
            this.radBtnAlarmHistory.FlatAppearance.CheckedBackColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radBtnAlarmHistory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBtnAlarmHistory.Location = new System.Drawing.Point(22, 101);
            this.radBtnAlarmHistory.Name = "radBtnAlarmHistory";
            this.radBtnAlarmHistory.Size = new System.Drawing.Size(75, 57);
            this.radBtnAlarmHistory.TabIndex = 3;
            this.radBtnAlarmHistory.TabStop = true;
            this.radBtnAlarmHistory.Text = "历史报警";
            this.radBtnAlarmHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnAlarmHistory.UseVisualStyleBackColor = true;
            this.radBtnAlarmHistory.CheckedChanged += new System.EventHandler(this.radBtnAlarmHistory_CheckedChanged);
            // 
            // radBtnAlarmCurrent
            // 
            this.radBtnAlarmCurrent.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnAlarmCurrent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radBtnAlarmCurrent.BackgroundImage")));
            this.radBtnAlarmCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radBtnAlarmCurrent.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmCurrent.FlatAppearance.BorderSize = 0;
            this.radBtnAlarmCurrent.FlatAppearance.CheckedBackColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmCurrent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmCurrent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.radBtnAlarmCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radBtnAlarmCurrent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBtnAlarmCurrent.Location = new System.Drawing.Point(22, 23);
            this.radBtnAlarmCurrent.Name = "radBtnAlarmCurrent";
            this.radBtnAlarmCurrent.Size = new System.Drawing.Size(75, 57);
            this.radBtnAlarmCurrent.TabIndex = 4;
            this.radBtnAlarmCurrent.TabStop = true;
            this.radBtnAlarmCurrent.Text = "当前报警";
            this.radBtnAlarmCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnAlarmCurrent.UseVisualStyleBackColor = true;
            this.radBtnAlarmCurrent.CheckedChanged += new System.EventHandler(this.radBtnAlarmCurrent_CheckedChanged);
            // 
            // panelAlarmCurrent
            // 
            this.panelAlarmCurrent.BackColor = System.Drawing.Color.Chocolate;
            this.panelAlarmCurrent.Controls.Add(this.listBoxAlarmCurrent);
            this.panelAlarmCurrent.Controls.Add(this.labCurrentAlarm);
            this.panelAlarmCurrent.Location = new System.Drawing.Point(210, 15);
            this.panelAlarmCurrent.Name = "panelAlarmCurrent";
            this.panelAlarmCurrent.Size = new System.Drawing.Size(582, 308);
            this.panelAlarmCurrent.TabIndex = 3;
            // 
            // listBoxAlarmCurrent
            // 
            this.listBoxAlarmCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxAlarmCurrent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxAlarmCurrent.FormattingEnabled = true;
            this.listBoxAlarmCurrent.ItemHeight = 21;
            this.listBoxAlarmCurrent.Location = new System.Drawing.Point(26, 52);
            this.listBoxAlarmCurrent.Name = "listBoxAlarmCurrent";
            this.listBoxAlarmCurrent.Size = new System.Drawing.Size(517, 231);
            this.listBoxAlarmCurrent.TabIndex = 2;
            // 
            // labCurrentAlarm
            // 
            this.labCurrentAlarm.BackColor = System.Drawing.Color.Transparent;
            this.labCurrentAlarm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCurrentAlarm.ForeColor = System.Drawing.Color.White;
            this.labCurrentAlarm.Location = new System.Drawing.Point(22, 9);
            this.labCurrentAlarm.Name = "labCurrentAlarm";
            this.labCurrentAlarm.Size = new System.Drawing.Size(123, 40);
            this.labCurrentAlarm.TabIndex = 1;
            this.labCurrentAlarm.Text = "当前报警窗";
            this.labCurrentAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAlarmHistory
            // 
            this.panelAlarmHistory.BackColor = System.Drawing.Color.Chocolate;
            this.panelAlarmHistory.Controls.Add(this.listBoxAlarmHistory);
            this.panelAlarmHistory.Controls.Add(this.labHistoryAlarm);
            this.panelAlarmHistory.Location = new System.Drawing.Point(210, 329);
            this.panelAlarmHistory.Name = "panelAlarmHistory";
            this.panelAlarmHistory.Size = new System.Drawing.Size(582, 294);
            this.panelAlarmHistory.TabIndex = 4;
            // 
            // listBoxAlarmHistory
            // 
            this.listBoxAlarmHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxAlarmHistory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxAlarmHistory.FormattingEnabled = true;
            this.listBoxAlarmHistory.ItemHeight = 21;
            this.listBoxAlarmHistory.Location = new System.Drawing.Point(26, 58);
            this.listBoxAlarmHistory.Name = "listBoxAlarmHistory";
            this.listBoxAlarmHistory.Size = new System.Drawing.Size(517, 210);
            this.listBoxAlarmHistory.TabIndex = 2;
            // 
            // labHistoryAlarm
            // 
            this.labHistoryAlarm.BackColor = System.Drawing.Color.Transparent;
            this.labHistoryAlarm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHistoryAlarm.ForeColor = System.Drawing.Color.White;
            this.labHistoryAlarm.Location = new System.Drawing.Point(22, 15);
            this.labHistoryAlarm.Name = "labHistoryAlarm";
            this.labHistoryAlarm.Size = new System.Drawing.Size(123, 40);
            this.labHistoryAlarm.TabIndex = 1;
            this.labHistoryAlarm.Text = "历史报警窗";
            this.labHistoryAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 639);
            this.Controls.Add(this.panelTool);
            this.Controls.Add(this.panelAlarmCurrent);
            this.Controls.Add(this.panelAlarmHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Alarm";
            this.Text = "frm_Alarm";
            this.panelTool.ResumeLayout(false);
            this.panelAlarmCurrent.ResumeLayout(false);
            this.panelAlarmHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.Resize += new System.EventHandler(this.frm_Alarm_Resize);

        }

        #endregion

        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.RadioButton radBtnAlarmHistory;
        private System.Windows.Forms.RadioButton radBtnAlarmCurrent;
        private System.Windows.Forms.Panel panelAlarmCurrent;
        private System.Windows.Forms.ListBox listBoxAlarmCurrent;
        private System.Windows.Forms.Label labCurrentAlarm;
        private System.Windows.Forms.Panel panelAlarmHistory;
        private System.Windows.Forms.ListBox listBoxAlarmHistory;
        private System.Windows.Forms.Label labHistoryAlarm;

    }
}