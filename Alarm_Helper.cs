using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Alam_Function
{
    public class Alarm_Helper
    {
        private Label Label;
        ListBox currentListBox;
        ListBox historyListBox;
        Panel panel;

        int left1 = 0;
        int right = 0;
        StringBuilder SB = new StringBuilder();
        public List<string> AlarmListWithoutT = new List<string>();

        //是否开启报警走马灯
        private bool startProcess = false;
        public bool StartProcess 
        {
            get { return this.startProcess; }
            set { this.startProcess = value; }
        }

        private bool isAlarm = false;
        delegate void UpdateScrolLights(int values);
        public int speed = 5;
        Font font;

        //报警信息模型
        Alarm_Data alarm_Data;

        /// <summary>
        /// panel: 走马灯使用的panel，current：当前警报列表，history:历史警报列表，alarmList：警报信息
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="current"></param>
        /// <param name="history"></param>
        /// <param name="alarmList"></param>
        private Alarm_Helper(Panel panel, ListBox current, ListBox history, Alarm_Data alarmData)
        {
            this.currentListBox = current;
            this.historyListBox = history;
            //this.AlarmList = alarmList;
            this.alarm_Data = alarmData;
            this.panel = panel;
            this.font = panel.Font;

            this.Create_ScrolLights();
        }

        /// <summary>
        /// panel: 走马灯使用的panel，current：当前警报列表，history:历史警报列表
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="current"></param>
        /// <param name="history"></param>
        public Alarm_Helper(Panel panel, ListBox current, ListBox history)
        {
            this.currentListBox = current;
            this.historyListBox = history;
            //this.AlarmList = alarmList;
            this.alarm_Data = new Alarm_Data();
            this.panel = panel;
            this.font = panel.Font;

            this.Create_ScrolLights();
            //将报警文件写入到listbox中
            this.Set_History_Alarm_To_ListBox();
        }

        /// <summary>
        /// 创建走马灯
        /// </summary>
        public void Create_ScrolLights()
        {
            Label = new Label();
            Label.TextChanged += new EventHandler(Alarm_Change);
            Label.AutoSize = true;
            int y = (panel.Height - Label.Height) / 2;      //文字放在走马灯中间
            Label.Location = new Point(0, y-4);
            Label.ForeColor = Color.DarkRed;
            Label.Font = font;
            panel.Controls.Add(Label);
            StartProcess = true;
        }

        /// <summary>
        /// 实时更新当前报警状态
        /// </summary>
        public void Update_Alarm()
        {
            if (StartProcess)
            {
                if (Label.Text != "")
                    left1 = left1 - speed;
                else
                    left1 = panel.Width;
                if (right < 5)
                {
                    left1 = panel.Width;
                }

                //扫描当前报警地址
                this.Scam_AlarmAddres();
                //扫描报警信息，加入到集合中
                this.Scan_AlarmMessage();

                this.Update_ScrolLights(left1);
            }
        }
   
        /// <summary>
        /// 扫描报警地址,触发对应的报警
        /// </summary>
        private void Scam_AlarmAddres()
        {
            //如果有报警再扫描
            if (Class_ShareMemCustom.GetM(this.alarm_Data.AlarmAddress[0]))
            {
                this.isAlarm = true;
                for (int i = 1; i < this.alarm_Data.AlarmAddress.Length; i++)
                {
                    if (Class_ShareMemCustom.GetM(this.alarm_Data.AlarmAddress[i]))
                    {
                        this.alarm_Data.AlarmStatus[i] = true;
                    }
                    else
                    {
                        this.alarm_Data.AlarmStatus[i] = false;
                    }
                }
            }
            else
            {
                this.isAlarm = false;
                for (int i = 1; i < this.alarm_Data.AlarmAddress.Length; i++)
                {
                    if (Class_ShareMemCustom.GetM(this.alarm_Data.AlarmAddress[i]))
                    {
                        this.alarm_Data.AlarmStatus[i] = true;
                    }
                    else
                    {
                        this.alarm_Data.AlarmStatus[i] = false;
                    }
                }
            }
        }

        /// <summary>
        /// 扫描当前的报警状态，看是否有新增报警
        /// </summary>
        private void Scan_AlarmMessage()
        {
            if (this.isAlarm)
            {
                for (int i = 0; i < this.alarm_Data.AlarmMessage.Length; i++)
                {
                    if (this.alarm_Data.AlarmStatus[i])
                    {
                        if (!AlarmListWithoutT.Contains(this.alarm_Data.AlarmMessage[i]))
                        {
                            this.alarm_Data.AlarmTime[i] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            AlarmListWithoutT.Add(this.alarm_Data.AlarmMessage[i]);             
                        }
                    }
                    else
                    {
                        if (AlarmListWithoutT.Contains(this.alarm_Data.AlarmMessage[i]))
                        {
                            this.alarm_Data.AlarmTime[i] = "";
                            AlarmListWithoutT.Remove(this.alarm_Data.AlarmMessage[i]);
                        }
                    }
                }
            }
            else
            {
                if (this.AlarmListWithoutT.Count>0)
                {
                     this. AlarmListWithoutT.Clear();
                     for (int i = 0; i < this.alarm_Data.IsAdded.Length; i++)
                     {
                         this.alarm_Data.IsAdded[i] = false;
                     }
                }
                if (this.currentListBox.Items.Count>0)
                {
                    this.currentListBox.Items.Clear();
                }
            }
        }

        /// <summary>
        /// 实时更新走马灯位置
        /// </summary>
        /// <param name="values"></param>
        private void Update_ScrolLights(int values)
        {
            Label.Left = values;
            foreach (string item in AlarmListWithoutT)
            {
                SB.Append(item);
                SB.Append("   ");
            }
            Label.Text = SB.ToString();
            left1 = Label.Left;
            right = Label.Right;
            SB.Clear();
        }

        /// <summary>
        /// 如果有新的报警，将其加入到历史报警listBox中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Alarm_Change(object sender, EventArgs e)
        {
            for (int i = 0; i < this.alarm_Data.AlarmMessage.Length; i++)
            {
                if (this.alarm_Data.AlarmStatus[i])
                {
                    if (!currentListBox.Items.Contains(this.alarm_Data.AlarmTime[i] + "：  " + this.alarm_Data.AlarmMessage[i]))
                    {
                        currentListBox.Items.Insert(0, this.alarm_Data.AlarmTime[i] + "：  " + this.alarm_Data.AlarmMessage[i]);
                    }

                    if (!this.alarm_Data.IsAdded[i])
                    {
                        historyListBox.Items.Insert(0, this.alarm_Data.AlarmTime[i] + "：  " + this.alarm_Data.AlarmMessage[i]);
                        this.alarm_Data.IsAdded[i] = true;
                        if (historyListBox.Items.Count>1000)
                        {
                            historyListBox.Items.RemoveAt(1000);
                        }
                    }
                }
                else
                {
                    currentListBox.Items.Remove(this.alarm_Data.AlarmTime[i] + "：  " + this.alarm_Data.AlarmMessage[i]);
                }
            }
        }

        /// <summary>
        /// 获取历史报警ListBox中的报警信息
        /// </summary>
        /// <returns></returns>
        public string Get_History_Alarm_Messages()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.historyListBox.Items.Count; i++)
            {
                if (i == this.historyListBox.Items.Count - 1)
                {
                    sb.Append(this.historyListBox.Items[i].ToString());
                }
                else
                {
                    sb.Append(this.historyListBox.Items[i].ToString() + "\r\n");
                }

            }
            return sb.ToString();
        }
        //报警文件路径
        public static string alarmPath = System.Environment.CurrentDirectory + @"\File\alarm.ini";
        /// <summary>
        /// 将历史报警的文件都进来写入到listbox中
        /// </summary>
        private void Set_History_Alarm_To_ListBox()
        {
           string[] strTemp = Read_File(alarmPath).Split(',');

           for (int i = 0; i < strTemp.Length; i++)
           {
               if (strTemp[i]!="")
               {
               this.historyListBox.Items.Add(strTemp[i]);                 
               }
           }
        }


        public static string Read_File(string filePath)
        {
            string res = "";
            StringBuilder sb = new StringBuilder();
            string[] strs;
            if (File.Exists(filePath))
            {
                strs = File.ReadAllLines(filePath, Encoding.UTF8);
                for (int i = 0; i < strs.Length; i++)
                {
                    sb.Append(strs[i] + ",");
                }
                res = sb.ToString();
            }
            return res;
        }
        public void Size_Change(int Width, int FirstX)
        {
            this.panel.Width = (int)(Width * 0.8 + 0.5);
            this.panel.Location = new Point(FirstX, 0);
        }

    }
}
