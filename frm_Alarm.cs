
using DeltaWoodSystem.SanTuo.UI.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alam_Function
{
    public partial class frm_Alarm : Form
    {
        Alarm_Data alarm_Data = new Alarm_Data();

        //便于外部获取的当前报警listbox
        public ListBox ListBoxAlarmCurrent
        {
            get { return this.listBoxAlarmCurrent; }
        }

        //便于外部获取的历史报警listbox
        public ListBox ListBoxAlarmHistory
        {
            get { return this.listBoxAlarmHistory; }
        }

        public frm_Alarm()
        {
            InitializeComponent();

            this.panelAlarmHistory.Hide();
            this.radBtnAlarmCurrent.Checked = true;
        }
        //由于userctrl的大小是在对象new出来后再设置的，所以UI的初始化不能放到构造方法中
        private void frm_Alarm_Resize(object sender, EventArgs e)
        {
            UIInitialization();
        }

        //整个usercontrol的UI初始化
        private void UIInitialization()
        {
            int xPadding = 10;
            int yPadding = 10;
            int width = this.Width - 2 * xPadding;
            int height = this.Height - 2 * yPadding;
            int rightPanelWidth = width / 10;
            int leftPanelWidth = width - rightPanelWidth;
            int bottomPanelHeight = height / 8;
            int topPanelHeight = height - bottomPanelHeight;
            //右部工具栏UI初始化
            ToolUIInitialization(leftPanelWidth + xPadding, yPadding, rightPanelWidth, height);
            //左部报警panel的UI初始化
            AlarmPanelUIInitialization(xPadding, yPadding, leftPanelWidth, height);
        }

        //右部工具栏UI初始化
        private void ToolUIInitialization(int xLocation, int yLocation, int width, int height)
        {
            WinformUILayoutHelper.SetControlPosition(this.panelTool, xLocation, yLocation, width, height);
            int buttonHeight = 60;
            //“当前报警”
            WinformUILayoutHelper.SetControlPosition(this.radBtnAlarmCurrent, 0, 0, width, buttonHeight);
            //“历史报警”
            WinformUILayoutHelper.SetControlPosition(this.radBtnAlarmHistory, 0, buttonHeight, width, buttonHeight);
        }

        //“当前警报”panel的UI初始化
        private void AlarmPanelUIInitialization(int xLocation, int yLocation, int width, int height)
        {
            //panel定位
            WinformUILayoutHelper.SetControlPosition(this.panelAlarmCurrent, xLocation, yLocation, width, height);
            WinformUILayoutHelper.SetControlPosition(this.panelAlarmHistory, xLocation, yLocation, width, height);

            int xPadding = 4;
            int yPadding = 4;
            int xlocation = xPadding;
            int ylocation = yPadding;
            int labWidth = width - 2 * xPadding;
            int labHeight = 60;
            int gridViewWidth = width - 2 * xPadding;
            int gridViewHeight = height - yPadding - labHeight;

            //panel中的label定位
            WinformUILayoutHelper.SetControlPosition(this.labCurrentAlarm, xlocation, ylocation, labWidth, labHeight);
            WinformUILayoutHelper.SetControlPosition(this.labHistoryAlarm, xlocation, ylocation, labWidth, labHeight);

            //panel中的datagridview定位
            ylocation = ylocation + labHeight + 2 * yPadding + 1;
            //WinformUILayoutHelper.SetControlPosition(this.gridViewAlarmCurrent, xlocation, ylocation, labWidth, gridViewHeight);
            //WinformUILayoutHelper.SetControlPosition(this.gridViewAlarmHistory, xlocation, ylocation, labWidth, gridViewHeight);

            //panel中的listbox定位
            WinformUILayoutHelper.SetControlPosition(this.listBoxAlarmCurrent, xlocation, ylocation, labWidth, gridViewHeight);
            WinformUILayoutHelper.SetControlPosition(this.listBoxAlarmHistory, xlocation, ylocation, labWidth, gridViewHeight);
        }

        //“当前报警”radioButtond的CheckedChanged事件，来切换画面
        private void radBtnAlarmCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radBtnAlarmCurrent.Checked)
            {
                this.panelAlarmCurrent.Show();
            }
            else
            {
                this.panelAlarmCurrent.Hide();
            }

            WinformUIEventHelper.CheckedChanged_ChangeBackgroundImage(sender, Alam_Function.Properties.Resources.outlineone, Alam_Function.Properties.Resources.outlineone1);
            WinformUIEventHelper.CheckedChanged_ChangeForeColor(sender, Color.Black, Color.White);
        }

        //“历史报警”radioButtond的CheckedChanged事件，来切换画面
        private void radBtnAlarmHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radBtnAlarmHistory.Checked)
            {
                this.panelAlarmHistory.Show();
            }
            else
            {
                this.panelAlarmHistory.Hide();
            }

            WinformUIEventHelper.CheckedChanged_ChangeBackgroundImage(sender, Alam_Function.Properties.Resources.outlineone, Alam_Function.Properties.Resources.outlineone1);
            WinformUIEventHelper.CheckedChanged_ChangeForeColor(sender, Color.Black, Color.White);
        }

        private void panelAlarmCurrent_Paint(object sender, PaintEventArgs e)
        {
            WinformUILayoutHelper.DrawControlBorder(e.Graphics, 0, 0, this.panelAlarmCurrent.Width, this.panelAlarmCurrent.Height, 4, Color.Green);
        }

        private void panelAlarmHistory_Paint(object sender, PaintEventArgs e)
        {
            WinformUILayoutHelper.DrawControlBorder(e.Graphics, 0, 0, this.panelAlarmCurrent.Width, this.panelAlarmCurrent.Height, 4, Color.Green);
        }

    }
}
