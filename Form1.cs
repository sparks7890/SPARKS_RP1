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
    public partial class Form1 : Form
    {
        frm_Alarm frm_alam = null;
        private Alarm_Helper alarmHelper;     
        public Form1()
        {
            InitializeComponent();
            Class_ShareMem.ShareMem_Create();//0409
          
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
          
            try
            {
                this.alarm_Panel = new Panel();
                //this.alarm_Panel.Location = panel_alam.Location;
                this.alarm_Panel.Location = new Point(panel_alam.Location.X, panel_alam.Location.Y + 60);
  
                this.alarm_Panel.Width = this.panel_alam .Width;
                this.alarm_Panel.Height = this.panel_alam.Height;
                this.alarm_Panel.BackColor = this.panel_alam.BackColor;
                //this.userCtrlAlarm = new userCtrl_Alarm();
                this.frm_alam = new frm_Alarm();
         


                //this.Controls.Add(this.alarm_Panel);
                this.frm_alam.Width = this.alarm_Panel.Width;
                this.frm_alam.Height = this.alarm_Panel.Height;
                this.frm_alam.Location = new Point(0, 0);
                //this.fa.BackColor = Color.Transparent;
                //this.userCtrlAlarm.Show();
                //this.userCtrlAlarm.BringToFront();
                this.Controls.Add(this.alarm_Panel);
            }
            catch
            {

            }
            this.alarmHelper = new Alarm_Helper(this.alarm_Panel, this.frm_alam.ListBoxAlarmCurrent, this.frm_alam.ListBoxAlarmHistory);
        }


        public Panel alarm_Panel { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.alarm_Panel.Show();

            frm_alam.TopLevel = false;
        
            alarm_Panel.Controls.Add(frm_alam);
            frm_alam.Show();
            this.alarm_Panel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class_ShareMem .Set_M (IMP_Address.M20000,true ) ;
            Class_ShareMem.Set_M(IMP_Address.M10000, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.alarmHelper.StartProcess = true;
            this.alarmHelper.Update_Alarm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_alamEdit frmalamedit = new frm_alamEdit();
            frmalamedit.Show();
        }
    }
}
