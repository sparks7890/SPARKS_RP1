using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alam_Function
{
    public  class Alarm_Data
    {
        //报警地址
        int[] alarmAddres = new int[70] {
            IMP_Address.M20000,
            IMP_Address.M10000,IMP_Address.M10001,IMP_Address.M10002,IMP_Address.M10003,IMP_Address.M10004,IMP_Address.M10005,
            IMP_Address.M10006,IMP_Address.M10007,IMP_Address.M10008,IMP_Address.M10009,IMP_Address.M10010,IMP_Address.M10011,
            IMP_Address.M10012,IMP_Address.M10013,IMP_Address.M10014,IMP_Address.M10015,IMP_Address.M10016,IMP_Address.M10017,
            IMP_Address.M10018,IMP_Address.M10019,IMP_Address.M10020,IMP_Address.M10021,IMP_Address.M10022,IMP_Address.M10023,
            IMP_Address.M10024,IMP_Address.M10025,IMP_Address.M10026,IMP_Address.M10027,IMP_Address.M10028,IMP_Address.M10029,
            IMP_Address.M10030,IMP_Address.M10031,IMP_Address.M10032,IMP_Address.M10033,IMP_Address.M10034,IMP_Address.M10035,
            IMP_Address.M10036,IMP_Address.M10037,IMP_Address.M10038,IMP_Address.M10039,IMP_Address.M10040,IMP_Address.M10041,
            IMP_Address.M10042,IMP_Address.M10043,IMP_Address.M10044,IMP_Address.M10045,IMP_Address.M10046,IMP_Address.M10047,
            IMP_Address.M10048,IMP_Address.M10049,IMP_Address.M10050,IMP_Address.M10051,IMP_Address.M10052,IMP_Address.M10053,
            IMP_Address.M10054,IMP_Address.M10055,IMP_Address.M10056,IMP_Address.M10057,IMP_Address.M10058,IMP_Address.M10059,
            IMP_Address.M10060,IMP_Address.M10061,IMP_Address.M10062,IMP_Address.M10063,IMP_Address.M10064,IMP_Address.M10068,
            IMP_Address.M10130,
            IMP_Address.M10070,IMP_Address.M10071
        };
        public int[] AlarmAddress
        {
            get { return this.alarmAddres; }
        }

        //报警信息
        string[] alrmMessage = new string[] { 
            "报警触发",
            "急停报警"
            , "开料Y1轴异常", "开料Y2轴异常", "开料Z轴异常", "开料X轴异常", "贴标X轴异常", "贴标Y轴异常"
            , "开料Y1轴低电压", "开料Y2轴低电压", "开料Z轴低电压", "开料X轴低电压", "贴标X轴低电压", "贴标Y轴低电压"
            , "开料Y1轴正极限", "开料Y2轴正极限", "开料Z轴正极限", "开料X轴正极限", "贴标X轴正极限", "贴标Y轴正极限"
            , "开料Y1轴过电压", "开料Y2轴过电压", "开料Z轴过电压", "开料X轴过电压", "贴标X轴过电压", "贴标Y轴过电压"
            , "开料Y1轴过负荷", "开料Y2轴过负荷", "开料Z轴过负荷", "开料X轴过负荷", "贴标X轴过负荷", "贴标Y轴过负荷"
            , "开料Y1轴位置误差过大", "开料Y2轴位置误差过大", "开料Z轴位置误差过大", "开料X轴位置误差过大", "贴标X轴位置误差过大", "贴标Y轴位置误差过大"
            , "开料Y1轴正软极限", "开料Y1轴正负极限", "开料Y2轴轴正软极限", "开料Y2轴正负极限", "开料Z轴正软极限", "开料Z轴正负极限", "开料X轴正软极限", "开料X轴正负极限", "贴标X轴正软极限"
            , "贴标X轴正负极限", "贴标Y轴正软极限", "贴标Y轴正负极限"
            , "开料X轴未归零", "开料Y轴未归零", "开料Z轴未归零", "贴标X轴未归零", "贴标Y轴未归零"
            , "开料Y1轴硬负极限", "开料Y2轴硬负极限", "开料Z轴硬负极限", "开料X轴硬负极限", "贴标X轴硬负极限", "贴标Y轴硬负极限"
            , "气压不足", "主轴报警", "程序启动时台面未吸附"    
            ,"开料GCode报警","主轴通讯异常","主轴转速超过最大值","开料Z轴不在安全位置，禁止换刀" ,"GCode软极限报警","未识别的GCode"
        };
        public string[] AlarmMessage 
        {
            get { return this.alrmMessage; }
        }

        //报警状态
        bool[] alarmStatus = new bool[70];
        public bool[] AlarmStatus
        {
            get { return this.alarmStatus; }
        }

        //报警时间
        string[] alarmTime = new string[70];
        public string[] AlarmTime
        {
            get { return this.alarmTime; }
            set { this.alarmTime = value; }
        }

        //是否加入到当前报警记录中
        bool[] isAdded = new bool[70];
        public bool[] IsAdded
        {
            set { this.isAdded = value; }
            get { return this.isAdded; }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public Alarm_Data()
        {
        }

        /// <summary>
        /// 获取当前报警信息
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Get_Alarm_Message(int index)
        {
            if (index < this.alrmMessage.Length)
            {
                return this.alrmMessage[index];
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 设置当前报警状态
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isAlarm"></param>
        public void Set_Alarm_Status(int index, bool isAlarm)
        {
            if (index < this.alarmStatus.Length)
            {
                this.alarmStatus[index] = isAlarm;
            }
        }

    }
}
