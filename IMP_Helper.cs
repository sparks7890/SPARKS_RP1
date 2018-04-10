using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using DeltaWoodSystem.SanTuo.Model;

namespace Alam_Function
{
    public class IMP_Helper
    {
        private Class_MarkLabel labelFile;
        private GCodeUI_Helper gcodeUI;
        private Panel panel_Draw;
        private PictureBox pic_Draw;

        float[] RGB_G00 = new float[3] { 255, 255, 255 };
        float[] RGB_G01 = new float[3] { 0, 255, 0 };
        float[] RGB_G02 = new float[3] { 255,0, 0 };
        float[] RGB_G03 = new float[3] { 0, 0, 255 };

        //控制是否绘制
        private bool is_Draw = false;
        public bool Is_Draw
        {
            set { this.is_Draw = value; }
            get { return this.is_Draw; }
        }
        //获取相对位置
        float x_Position = 0.0f;
        float y_Position = 0.0f;
        float z_position = 0.0f;

        public float X_Position_Workpiece
        {
            get
            {
                this.x_Position = this.GetAxisPosition(this.AxisAddress_Workpiece[0]) / 1000.0f;
                return this.x_Position;
            }
        }
        public float Y_Position_Workpiece
        {
            get
            {
                this.y_Position = this.GetAxisPosition(this.AxisAddress_Workpiece[1]) / 1000.0f;
                return this.y_Position;
            }
        }
        public float Z_position_Workpiece
        {
            get
            {
                this.z_position = this.GetAxisPosition(this.AxisAddress_Workpiece[2]) / 1000.0f;
                return this.z_position;
            }
        }

        //获取机械位置
        float x_Position_machine = 0.0f;
        float y_Position_machine = 0.0f;
        float z_position_machine = 0.0f;
        public float X_Position_Machine
        {
            get
            {
                this.x_Position_machine = GetAxisPosition(this.AxisAddress_Machine[0]) * 0.001f;
                return this.x_Position_machine;
            }
        }
        public float Y_Position_Machine
        {
            get
            {
                this.y_Position_machine = GetAxisPosition(this.AxisAddress_Machine[1]) * 0.001f;
                return this.y_Position_machine;
            }
        }
        public float Z_position_Machine
        {
            get
            {
                this.z_position_machine = GetAxisPosition(this.AxisAddress_Machine[2]) * 0.001f;
                return this.z_position_machine;
            }
        }

        //获取命令位置
        float x_Position_command = 0.0f;
        float y_Position_command = 0.0f;
        float z_position_command = 0.0f;
        public float X_Position_Command
        {
            get
            {
                this.x_Position_command = GetAxisPosition(IMP_Address.W32538) * 0.001f;
                return this.x_Position_command;
            }
        }
        public float Y_Position_Command
        {
            get
            {
                this.y_Position_command = GetAxisPosition(IMP_Address.W32540) * 0.001f;
                return this.y_Position_command;
            }
        }
        public float Z_position_Command
        {
            get
            {
                this.z_position_command = GetAxisPosition(IMP_Address.W32542) * 0.001f;
                return this.z_position_command;
            }
        }

        //外部传入SNC_Draw控件
        public Panel PanelDraw
        {
            get { return this.panel_Draw; }
            set 
            { 
                this.panel_Draw = value;
            }
        }
    
        public PictureBox PicDraw
        {
            get { return this.pic_Draw; }
            set 
            {
                this.pic_Draw = value;
            }
        }

        //警告地址
        private int[] warningAddress = new int[] {
            IMP_Address.M10065,IMP_Address.M10066,IMP_Address.M10067,IMP_Address.M10068,IMP_Address.M10069,
            IMP_Address.M10081,IMP_Address.M10082
        };

        public int[] WarningAddress {
            get { return this.warningAddress; }
        }

        //机械坐标地址
        int[] AxisAddress_Machine = new int[12]{
            IMP_Address.SNC_XFDAddW,IMP_Address.SNC_YFDAddW,IMP_Address.SNC_ZFDAddW,IMP_Address.SNC_AFDAddW,IMP_Address.SNC_BFDAddW,0,0,0,0,0,0,0
        };

        //相对坐标地址
        int[] AxisAddress_Relative = new int[12]{
            IMP_Address.SNC_XReCAddW,IMP_Address.SNC_YReCAddW,IMP_Address.SNC_ZReCAddW,0,0,0,0,0,0,0,0,0
        };

        //工件坐标
        int[] AxisAddress_Workpiece = new int[12]{
            IMP_Address.SNC_XWCAddW,IMP_Address.SNC_YWCAddW,IMP_Address.SNC_ZWCAddW,0,0,0,0,0,0,0,0,0
        };

        //剩余坐标
        int[] AxisAddress_Remain = new int[12]{
            IMP_Address.SNC_XRCAddW,IMP_Address.SNC_YRCAddW,IMP_Address.SNC_ZRCAddW,0,0,0,0,0,0,0,0,0
        };


        /// <summary>
        /// 无参构造
        /// </summary>
        /// <param name="gcodeUI"></param>
        /// <param name="labelfile"></param>
        /// <param name="drawPanel"></param>
        public IMP_Helper(GCodeUI_Helper gcodeUI,Class_MarkLabel labelfile,PictureBox drawPic)
        {
            this.gcodeUI = gcodeUI;
            this.labelFile = labelfile;
            this.pic_Draw = drawPic;
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        /// <param name="gcodeUI"></param>
        /// <param name="labelfile"></param>
        /// <param name="drawPanel"></param>
        public IMP_Helper(GCodeUI_Helper gcodeUI, Class_MarkLabel labelfile)
        {
            this.gcodeUI = gcodeUI;
            this.labelFile = labelfile;
        }

        /// <summary>
        /// 判断IMP是否已经开启，并且已经将D寄存器加载
        /// </summary>
        /// <returns></returns>
        public bool Get_IMP_Is_Ready()
        {
            //判断IMP是否开启，开启了才会打开本软件，否则关闭
            bool IMP_Is_On = Class_ShareMem.ShareMem_Open() == 0;
            bool IMP_R0 = Class_ShareMem.Get_D(IMP_Address.D50, false) == 1;
            if (!IMP_R0 || !IMP_Is_On)
            {
                return false;
            }
            else
            {
                Class_ShareMem.Set_D(IMP_Address.D50, 0, false);
                return true;
            }
        }

        /// <summary>
        /// 将IMP关闭
        /// </summary>
        public void Set_IMP_Close()
        {
            Class_ShareMem.Set_M(20, true);
        }

        //从寄存器中获取上次加工的文件路径
        public void Get_NcFilePath_From_DString()
        {
            StringBuilder sbTemp = new StringBuilder(255);
            // 贴标文件路径
            Class_ShareMem.Get_D_String(IMP_Address.D3050,sbTemp,255);
            Class_MarkLabel.CurrentLableFile = sbTemp.ToString();

            //开料文件路径
            StringBuilder sbTemp1 = new StringBuilder(255);
            Class_ShareMem.Get_D_String(IMP_Address.D3310, sbTemp1, 255);
            string temp0 = IMP_Helper.Get_Null_String();
            Class_ShareMem.Set_W_String(31100, temp0, 255);

            string xx = IMP_Helper.Get_Null_String(sbTemp1.ToString().Length);
            Class_ShareMem.Set_W_String(IMP_Address.SNC_LdAddW, sbTemp1.ToString() + xx, 255);
            Class_MarkLabel.CurrentNcFile = sbTemp1.ToString();
        }

        /// <summary>
        /// 判断文件路径寄存器中值是否是128个空格字符
        /// </summary>
        /// <param name="oriString"></param>
        /// <returns></returns>
        public static bool Get_Is_128String_Space(string oriString)
        {
            bool isAllSpace = true;
            int length = oriString.Length;
            for (int i = 0; i < length; i++)
            {
                if (oriString[i]!=' ')
                {
                    isAllSpace = false;
                    return isAllSpace;
                }
            }

            return isAllSpace;
        }

        //将当前开料文件路径和加工当前行行号一直写入到寄存器中
        public void Set_NcFile_To_ShareMem()
        {
            if (this.Get_Is_Start())
            {
                StringBuilder sbTemp = new StringBuilder(255);
                Class_ShareMem.Get_W_String(IMP_Address.SNC_LdAddW, sbTemp, 255);
                string temp = IMP_Helper.Get_Null_String(sbTemp.ToString().Length);
                Class_ShareMem.Set_D_String(IMP_Address.D3310, sbTemp.ToString() + temp, 255);
                //Class_ShareMem.Set_D(3002, Class_ShareMem.Get_W(32187, true), true);//将当前NC执行行数存至D3002内
            }
        }

        //将行号清零
        public void Set_NcFile_Lines_Zero()
        {
            Class_ShareMem.Set_D(IMP_Address.D3000,0,true);
            Class_ShareMem.Set_D(IMP_Address.D3002, 0, true);
        }

        public void OpenNcFile(string ncFilePathName)
        {

        }

        public void SaveNcFile(string ncFilePathName)
        {

        }

        /// <summary>
        /// 设置单点继续
        /// </summary>
        /// <param name="isContinue"></param>
        public void Set_Break_Continue(bool isContinue)
        {
            Class_ShareMem.Set_M(IMP_Address.M403, isContinue);

            if (this.Get_Process_Mode()==2)
            {
                
            }
        }

        /// <summary>
        /// 获取当前是否有警告
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Warning()
        {
            int res = Class_ShareMem.Get_M(IMP_Address.M20000);
            if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 将当前警告复位
        /// </summary>
        public void Set_Warning_Reset(int warningAddress)
        {
            Class_ShareMem.Set_M(warningAddress,false);
        }

        /// <summary>
        /// 单点继续是否被触发
        /// </summary>
        public bool Get_Is_Break_Continue()
        {
            return Class_ShareMem.Get_M(IMP_Address.M403) == 1;
        }

        /// <summary>
        /// 设置跳行模式
        /// </summary>
        /// <returns></returns>
        public void Set_JumpLine_Mode(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M300, isOn);
        }

        /// <summary>
        /// 跳行模式开始加工
        /// </summary>
        public void Set_JumpLine_Start()
        {
            Class_ShareMem.Set_M(IMP_Address.M540,true);
        }

        /// <summary>
        /// 获取跳行加工是否开始
        /// </summary>
        public bool Get_JumpLine_Is_Start()
        {
            return Class_ShareMem.Get_M(IMP_Address.M540)==1;
        }

        /// <summary>
        /// 获取是否跳行模式
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_JumpLine_Mode()
        {
            return Class_ShareMem.Get_M(IMP_Address.M300)==1;
        }

        /// <summary>
        /// 设置跳行的值
        /// </summary>
        /// <param name="lineValue"></param>
        public  void Set_JumpLine_Value(int lineValue)
        {
            Class_ShareMem.Set_W(IMP_Address.SNC_JumpLineAddW,lineValue,true);
        }

        /// <summary>
        /// 每次加载加工文件的一开始，将文件的行数读取出来，放到共享内存中
        /// </summary>
        public static void Set_LoadNcFilePath_To_ShareMem(int lines)
        {
            Class_ShareMem.Set_D(IMP_Address.D1524, lines, true);
        }

        /// <summary>
        /// 获取跳行的值
        /// </summary>
        /// <returns></returns>
        public int Get_JumpLine_Value()
        {
            return Class_ShareMem.Get_W(IMP_Address.SNC_JumpLineAddW,true);
        }

        /// <summary>
        /// 开始加工
        /// </summary>
        public void Start()
        {
            this.gcodeUI.IsProcessing = true;
            //isProcessing = true;

            int mode = Get_Process_Mode();

            Set_Process_Done();

            //同时加工
            if (mode == 0)
            {
                this.labelFile.Label_Process_Start();
                Class_ShareMemCustom.BitOnM(IMP_Address.M32);
            }
            //贴标
            else if (mode == 1)
            {
                this.labelFile.Label_Process_Start();
                Class_ShareMemCustom.BitOnM(IMP_Address.M32);
            }
            //开料
            else if (mode == 2)
            {
                //Class_ShareMemCustom.SetSingleW(IMP_Address.M32, 10);
                Class_ShareMemCustom.BitOnM(IMP_Address.M32);
            }

        }

        /// <summary>
        /// 开始是否被触发
        /// </summary>
        public bool Get_Is_Start()
        {
            return Class_ShareMem.Get_M(IMP_Address.M32)==1;
        }

        /// <summary>
        /// 复位
        /// </summary>
        public void Reset()
        {
            Class_ShareMem.Set_M(IMP_Address.M7,true);
        }

        /// <summary>
        /// 复位是否被触发
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Reset()
        {
            return Class_ShareMem.Get_M(IMP_Address.M7)==1;
        }

        /// <summary>
        /// 获取加工模式（0同时加工，1贴标，2开料）
        /// </summary>
        /// <returns></returns>
        public int Get_Process_Mode()
        {
            return Class_ShareMemCustom.GetSingleD(IMP_Address.D3004);
        }

        /// <summary>
        /// 获取系统加工状态
        /// </summary>
        /// <returns></returns>
        public bool Get_System_Process_Status()
        {
            return Class_ShareMem.Get_M(IMP_Address.M32)==1;
        }

        /// <summary>
        /// 获取系统是否回零
        /// </summary>
        /// <returns></returns>
        public bool Get_System_Home_Status()
        {
            return Class_ShareMem.Get_M(IMP_Address.M1996) == 1;
        }

        /// <summary>
        /// 获取系统是否有报警
        /// </summary>
        /// <returns></returns>
        public bool Get_System_Alarm_Status()
        {
            return Class_ShareMem.Get_M(IMP_Address.M20000)==1;
        }

        /// <summary>
        /// 暂停加工
        /// </summary>
        public void Stop()
        {
            //Class_ShareMemCustom.SetSingleW(IMP_Address.SNC_CtrAddW, 11);
            //int mode = Class_ShareMemCustom.GetSingleD(IMP_Address.D3004);
            //this.labelFile.Label_Process_Pause();

            //Class_ShareMemCustom.SetSingleW(IMP_Address.SNC_CtrAddW, 11);
            Class_ShareMem.Set_M(IMP_Address.M89,false);
        }

        /// <summary>
        /// 获取暂停加工是否触发
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Stop()
        {
            return Class_ShareMem.Get_M(IMP_Address.M89)==1;
        }

        /// <summary>
        /// 继续加工
        /// </summary>
        public void Continue()
        {
            //this.labelFile.Label_Process_continue();
            //Class_ShareMemCustom.SetSingleW(IMP_Address.SNC_CtrAddW, 12);
            Class_ShareMem.Set_M(IMP_Address.M89, true);
        }

        /// <summary>
        /// 取消加工
        /// </summary>
        public void Cancel()
        {
            this.gcodeUI.IsProcessing = false;
            //this.isProcessing = false;

            //Class_ShareMemCustom.SetSingleW(IMP_Address.SNC_CtrAddW, 13);
            //this.labelFile.Label_Process_Stop();
            Class_ShareMem.Set_M(IMP_Address.M59, true);
        }

        /// <summary>
        /// 取消贴标加工
        /// </summary>
        public void Set_Tiebiao_Cancel()
        {
            this.labelFile.Label_Process_Stop();
        }

        /// <summary>
        /// 取消加工是否被触发
        /// </summary>
        public bool Get_Is_Cancel()
        {
            return Class_ShareMem.Get_M(IMP_Address.M59)==1;
        }

        /// <summary>
        /// 判断是否停止，由外部触发，用于关闭打标机程序
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Cancel_Outside()
        {
            return Class_ShareMem.Get_M(IMP_Address.M541) == 1;
        }

        /// <summary>
        /// 将外部停止信号复位
        /// </summary>
        /// <returns></returns>
        public void Set_Cancel_Outside_Reset()
        {
            Class_ShareMem.Set_M(IMP_Address.M541, false);
        }

        /// <summary>
        /// 设置贴标回零
        /// </summary>
        public void Set_Axis_Tiebiao_Home()
        {
            Class_ShareMem.Set_M(IMP_Address.M75,true);
        }

        /// <summary>
        /// 贴标回零是否被触发
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Axis_Tiebiao_Home()
        {
            return Class_ShareMem.Get_M(IMP_Address.M75) == 1;
        }

        /// <summary>
        /// 设置开料回零
        /// </summary>
        public void Set_Axis_Kailiao_Home()
        {
            Class_ShareMem.Set_M(IMP_Address.M6, true);
        }

        /// <summary>
        /// 开料回零是否被触发
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Axis_Kailiao_Home()
        {
            return Class_ShareMem.Get_M(IMP_Address.M6)==1;
        }

        /// <summary>
        /// 设置X轴回零（开料）
        /// </summary>
        public void Set_Axis_X_Home()
        {
            Class_ShareMem.Set_M(IMP_Address.M71, true);     
        }

        /// <summary>
        /// X轴回零是否被触发（开料）
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Axis_X_Home()
        {
            return Class_ShareMem.Get_M(IMP_Address.M71) == 1;
        }

        /// 设置Y轴回零（开料）
        /// </summary>
        public void Set_Axis_Y_Home()
        {
            Class_ShareMem.Set_M(IMP_Address.M70, true);
        }

        /// <summary>
        /// Y轴回零是否被触发（开料）
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Axis_Y_Home()
        {
            return Class_ShareMem.Get_M(IMP_Address.M70) == 1;
        }

        /// 设置Z轴回零（开料）
        /// </summary>
        public void Set_Axis_Z_Home()
        {
            Class_ShareMem.Set_M(IMP_Address.M72, true);
        }

        /// <summary>
        /// Z轴回零是否被触发（开料）
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Axis_Z_Home()
        {
            return Class_ShareMem.Get_M(IMP_Address.M72) == 1;
        }

        /// 设置A轴回零（贴标）
        /// </summary>
        public void Set_Axis_A_Home()
        {
            Class_ShareMem.Set_M(IMP_Address.M73, true);
        }

        /// <summary>
        /// A轴回零是否被触发（贴标）
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Axis_A_Home()
        {
            return Class_ShareMem.Get_M(IMP_Address.M73) == 1;
        }

        /// 设置B轴回零（贴标）
        /// </summary>
        public void Set_Axis_B_Home()
        {
            Class_ShareMem.Set_M(IMP_Address.M74, true);
        }

        /// <summary>
        /// B轴回零是否被触发（贴标）
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_Axis_B_Home()
        {
            return Class_ShareMem.Get_M(IMP_Address.M74) == 1;
        }

        /// <summary>
        /// 开料加载NC加工文件
        /// </summary>
        /// <param name="ncFilePath"></param>
        /// <param name="fileNameSize"></param>
        public void Load_NCFilePath(string ncFilePath)
        {
            if (ncFilePath == "") return;

            //string name1 = Path.GetExtension(ncFilePath);
            //string name3 = Path.GetFileNameWithoutExtension(ncFilePath);
            //string name2 = Path.GetDirectoryName(ncFilePath);
            //string ss = name2 + "\\" + name3+name1;

            string temp = IMP_Helper.Get_Null_String();
            Class_ShareMem.Set_W_String(31100, temp, 255);
            //Class_ShareMem.Set_W_String(31100, CurrentNcFile, CurrentNcFile.Length + 4);
            Class_ShareMem.Set_W_String(31100, ncFilePath, 255);

            //Class_ShareMemCustom.SetWString(IMP_Address.SNC_LdAddW, "", 128);
            //Class_ShareMemCustom.SetWString(IMP_Address.SNC_LdAddW, ss, ss.Length+6);
        }

        public static string Get_Null_String()
        {
            string temp;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 255; i++)
            {
                sb.Append(" ");
            }
            temp = sb.ToString();
            return temp;
        }

        public static string Get_Null_String(int index)
        {
            string temp;
            StringBuilder sb = new StringBuilder();
            for (int i = index+1; i < 128; i++)
            {
                sb.Append(" ");
            }
            temp = sb.ToString();
            return temp;
        }

        /// <summary>
        /// 更新当前各轴的机械坐标
        /// </summary>
        /// <param name="controls"></param>
        public void UpadatePosition_Machine(Control[] controls)
        {
            if (controls != null)
            {
                for (int i = 0; i < controls.Length; i++)
                {
                    if (i < this.AxisAddress_Machine.Length)
                    {
                        double temp = GetAxisPosition(this.AxisAddress_Machine[i]) / 1000.0;
                        controls[i].Text = temp.ToString("#0.000");
                    }
                }
            }
        }

        /// <summary>
        /// 更新当前各轴的相对坐标
        /// </summary>
        /// <param name="controls"></param>
        public void UpadatePosition_Relative(Control[] controls)
        {
            if (controls != null)
            {
                for (int i = 0; i < controls.Length; i++)
                {
                    if (i < this.AxisAddress_Relative.Length)
                    {
                        double temp = GetAxisPosition(this.AxisAddress_Relative[i]) / 1000.0;
                        controls[i].Text = temp.ToString("#0.000");
                    }
                }
            }
        }

        /// <summary>
        /// 更新当前各轴的工件坐标
        /// </summary>
        /// <param name="controls"></param>
        public void UpadatePosition_Workpiece(Control[] controls)
        {
            if (controls != null)
            {
                for (int i = 0; i < controls.Length; i++)
                {
                    if (i < this.AxisAddress_Workpiece.Length)
                    {
                        double temp = GetAxisPosition(this.AxisAddress_Workpiece[i]) / 1000.0;
                        controls[i].Text = temp.ToString("#0.000");
                    }
                }
            }
        }

        /// <summary>
        /// 更新当前各轴的剩余坐标
        /// </summary>
        /// <param name="controls"></param>
        public void UpadatePosition_Remain(Control[] controls)
        {
            if (controls != null)
            {
                for (int i = 0; i < controls.Length; i++)
                {
                    if (i < this.AxisAddress_Remain.Length)
                    {
                        double temp = GetAxisPosition(this.AxisAddress_Remain[i]) / 1000.0;
                        controls[i].Text = temp.ToString("#0.000");
                    }
                }
            }
        }

        /// <summary>
        /// 设置加工模式（开料、贴标以及同时加工）
        /// </summary>
        /// <param name="mode"></param>
        public void Set_Process_Mode(int mode)
        {
            Class_ShareMemCustom.SetSingleD(IMP_Address.D3004,mode);
        }

        /// <summary>
        /// 设置单步加工使能
        /// </summary>
        /// <param name="on"></param>
        public void Set_Step_Status(bool on)
        {
            Class_ShareMem.Set_R(IMP_Address.SNC_StepEnableAddR, on);
        }

        /// <summary>
        /// 设置单步加工动作
        /// </summary>
        /// <param name="on"></param>
        public void Set_Step_Action(bool on)
        {
            Class_ShareMem.Set_R(IMP_Address.SNC_StepActionAddR, on);
        }

        /// <summary>
        /// 设置手轮状态，启动或停止
        /// </summary>
        /// <param name="on"></param>
        public void Set_MPG_Status(bool on)
        {
            Class_ShareMem.Set_M(IMP_Address.M1200,on);
        }

        /// <summary>
        /// 获取手轮模拟是否被触发
        /// </summary>
        /// <param name="on"></param>
        public bool Get_MPG_Status()
        {
            return Class_ShareMem.Get_M(IMP_Address.M1200)==1;
        }

        /// <summary>
        /// 获取当前加工是否完成
        /// </summary>
        public int Get_Process_Done()
        {
           return Class_ShareMem.Get_M(IMP_Address.M535);
        }

        /// <summary>
        /// 设置当前加工完成
        /// </summary>
        public int Set_Process_Done()
        {
            return Class_ShareMem.Set_M(IMP_Address.M535,false);
        }

        /// <summary>
        /// 贴标停止标志位
        /// </summary>
        public void Set_Tiebiao_Done()
        {
            Class_ShareMem.Set_M(IMP_Address.M402,true);
        }

        /// <summary>
        ///获取贴标是否在加工中，true为完成，false是在加工中
        /// </summary>
        public bool Get_Tiebiao_Done()
        {
            return Class_ShareMem.Get_M(IMP_Address.M402)==1;
        }

        /// <summary>
        /// 设置进给速率是否保持住
        /// </summary>
        /// <param name="hold"></param>
        public void Set_FeedSpeed_Hold(bool hold)
        {
            Class_ShareMem.Set_R(IMP_Address.SNC_FdAddR,hold);      
        }

        /// <summary>
        /// 获取进给速率是否被触发
        /// </summary>
        /// <returns></returns>
        public bool Get_Is_FeedSpeed_Hold()
        {
            return Class_ShareMem.Get_R(IMP_Address.SNC_FdAddR)==1;
        }

        /// <summary>
        /// 设置进给速率的值
        /// </summary>
        /// <param name="hold"></param>
        public void Set_FeedSpeed_Value(int feedSpeedValue)
        {
            Class_ShareMemCustom.SetSingleW(IMP_Address.SNC_FdAddW,feedSpeedValue);
        }

        /// <summary>
        /// 获取进给速率的值
        /// </summary>
        /// <param name="hold"></param>
        public int Get_FeedSpeed_Value()
        {
            return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_FdAddW);
        }

        /// <summary>
        /// 清除X轴相对坐标
        /// </summary>
        public void Clear_Axis_X_RelativePosition()
        {
            Class_ShareMem.Set_R(IMP_Address.SNC_XCLAddR,true);
        }

        /// <summary>
        /// 清除Y轴相对坐标
        /// </summary>
        public void Clear_Axis_Y_RelativePosition()
        {
            Class_ShareMem.Set_R(IMP_Address.SNC_YCLAddR, true);
        }

        /// <summary>
        /// 清除Z轴相对坐标
        /// </summary>
        public void Clear_Axis_Z_RelativePosition()
        {
            Class_ShareMem.Set_R(IMP_Address.SNC_ZCLAddR, true);
        }

        /// <summary>
        /// 从共享内存中获取当前轴位置
        /// </summary>
        /// <param name="asixAddress"></param>
        /// <returns></returns>
        private int GetAxisPosition(int asixAddress)
        {
            int temp = Class_ShareMemCustom.GetDoubleW(asixAddress);
            return temp;
        }

        /// <summary>
        /// 获取贴标GCode所有行
        /// </summary>
        /// <returns></returns>
        public int Get_Tiebiao_TotalLine()
        {
            return Class_ShareMemCustom.GetDoubleD(IMP_Address.D3008);
        }

        /// <summary>
        /// 获取贴标GCode加工当前行
        /// </summary>
        /// <returns></returns>
        public int Get_Tiebiao_CurrentLine()
        {
            return Class_ShareMemCustom.GetDoubleD(IMP_Address.D3000);
        }

        /// <summary>
        /// 获取开料GCode所有行
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_TotalLine()
        {
            return Class_ShareMemCustom.GetDoubleW(IMP_Address.SNC_TotalLAddW);
        }

        /// <summary>
        /// 获取开料GCode加工当前行
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_CurrentLine()
        {
            //return Class_ShareMemCustom.GetDoubleD(IMP_Address.D3002);
            return Class_ShareMem.Get_W(32187, true);
        }

        /// <summary>
        /// 获取开料预估加工时间
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_ScanTime()
        {
            return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_ScanTAddW);
        }

        /// <summary>
        /// 获取开料当前加工时间
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_RunTime()
        {
            return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_RunTAddW);
        }

        /// <summary>
        /// 获取开料当前加工进度
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_Percentage()
        {
            //return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_RunPAddW);
            return Class_ShareMem.Get_D(IMP_Address.D640,false);
        }

        /// <summary>
        /// 获取开料当前加工状态
        /// </summary>
        /// <returns></returns>
        public string Get_Kailiao_Process_Status()
        {
            int status = Get_Kailiao_Process_Status_Int();
            string strStatus = "";
            if (status == 0)
            {
                strStatus = "停止";
            }
            else if (status == 1)
            {
                strStatus = "暂停";
            }
            else
            {
                strStatus = "执行中";
            }
            return strStatus;
        }

        /// <summary>
        /// 获取开料当前加工状态
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_Status_Int()
        {
            return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_StufAddW);
        }

        /// <summary>
        /// 获取开料当前加工坐标系
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_Coordinate()
        {
            return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_RunCoAddW);
        }

        /// <summary>
        /// 获取开料加工当前报警错误码
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_Alarm()
        {
            return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_WroAddW);
        }

        /// <summary>
        /// 获取开料加工当前报警错异常行号
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_Alarm_Line()
        {
            return Class_ShareMemCustom.GetDoubleW(IMP_Address.SNC_WrongLineAddW);
        }

        /// <summary>
        /// 获取开料加工当前报警错误行数
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_AlarmLineNo()
        {
            return Class_ShareMemCustom.GetDoubleD(IMP_Address.SNC_RunLAddW);
        }

        /// <summary>
        /// 获取开料当前加工进给速率
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_FeedSpeed()
        {
            return Class_ShareMemCustom.GetDoubleW(IMP_Address.SNC_RunFAddW);
        }

        /// <summary>
        /// 获取开料加工当前刀号
        /// </summary>
        /// <returns></returns>
        public int Get_Kailiao_Process_CurrentKnifeNo()
        {
            return Class_ShareMemCustom.GetSingleW(IMP_Address.SNC_KnifNAddW);
        }


        /// <summary>
        /// 获取是否在连续加工模式下
        /// </summary>
        /// <returns></returns>
        public bool Get_Auto_Process_Is_On()
        {
            return Class_ShareMem.Get_M(IMP_Address.M543)==1;
        }

        /// <summary>
        /// 获取Z轴的负软极限值
        /// </summary>
        /// <returns></returns>
        public int Get_Z_Axis_Negative_SoftLimit()
        {
            return Class_ShareMem.Get_D(IMP_Address.D1294, true);
        }

        /// <summary>
        /// 获取换刀时的X轴的偏移量
        /// </summary>
        /// <returns></returns>
        public int Get_Z_Axis_Negative_SoftLimit(int spindleNo)
        {
            Class_ShareMem.Set_W(IMP_Address.W31030,spindleNo,false);
            Class_ShareMem.Set_W(IMP_Address.W31029,1,false);
            while (Class_ShareMem.Get_W(IMP_Address.W31029,false)!=0)
            {
                if (Class_ShareMem.Get_W(IMP_Address.W31029,false) == 99)
                {
                    return 0;
                }
            }

            return Class_ShareMem.Get_W(IMP_Address.W31035,true);
        }

        /// <summary>
        /// 获取连续加工是否完成
        /// </summary>
        /// <returns></returns>
        public int Get_AutoProcess_IsDone()
        {
            return Class_ShareMem.Get_M(IMP_Address.M406);
        }

        /// <summary>
        /// 将连续加工标志复位
        /// </summary>
        /// <returns></returns>
        public void Reset_AutoProcess()
        {
            Class_ShareMem.Set_M(IMP_Address.M406,false);
        }

        #region “定时锁机方法区”

        /// <summary>
        /// 获取注册模式
        /// </summary>
        /// <returns>0：未注册，1：注册有时间限制，2：永久</returns>
        public int Get_Register_Mode()
        {
            return IMP_Address.D4000;
      //      return Class_ShareMem.Get_D(IMP_Address.D4000, false);
        }

        /// <summary>
        /// 设置注册模式
        /// </summary>
        /// <param name="registerMode">0：未注册，1：注册有时间限制，2：永久</param>
        public void Set_Register_Mode(int registerMode)
        {
            IMP_Address.D4000 = registerMode;
      //      Class_ShareMem.Set_D(IMP_Address.D4000, registerMode, false);
        }

        /// <summary>
        /// 获取注册区的当前时间
        /// </summary>
        /// <returns></returns>
        public void Get_Register_Current_Date_ByJay()
        {
            if (!File.Exists(IMP_Address.Path))
            {
                IMP_Address.D4000 = 0;
                if (!Directory.Exists(IMP_Address.PathDir))
                    Directory.CreateDirectory(IMP_Address.PathDir);
                return;
            }
            using (StreamReader sr = new StreamReader(IMP_Address.Path))
            {
                int idx = 0;
                while (sr.Peek() >= 0)
                {
                    idx++;
                    string temp = sr.ReadLine();
                    if (idx == 37)
                    {
                        IMP_Address.D4000 = FileOperate_Helper.GetLicenseByString(temp);                 
                    }
                    if (idx == 94)
                    {
                        IMP_Address.D4010 = DateTime.Parse(temp);
                    }
                    if (idx == 181)
                    {
                        IMP_Address.D4030 = DateTime.Parse(temp);
                    }
                }           
            }
            //StringBuilder currentDate = new StringBuilder(20);
            //Class_ShareMem.Get_D_String(IMP_Address.D4010, currentDate, 20);
            //return currentDate.ToString();
        }

        /// <summary>
        /// 将当前时间设置到注册区
        /// </summary>
        /// <param name="currentDate">当前时间</param>
        public void Set_Register_Current_Date(DateTime currentDate)
        {

            IMP_Address.D4010 = currentDate;
            //string temp;
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < 20; i++)
            //{
            //    sb.Append(" ");
            //}
            //temp = sb.ToString();

            //Class_ShareMem.Set_D_String(IMP_Address.D4010, temp, 20);
            //Class_ShareMem.Set_D_String(IMP_Address.D4010, currentDate, 20);
        }

        /// <summary>
        /// 获取注册区的截止时间
        /// </summary>
        /// <returns></returns>
        //public string Get_Register_DeadLine_Date()
        //{
        //    StringBuilder deadlineDate = new StringBuilder(20);
        //    Class_ShareMem.Get_D_String(IMP_Address.D4030, deadlineDate, 20);
        //    return deadlineDate.ToString();
        //}

        /// <summary>
        /// 将截止时间设置到注册区
        /// </summary>
        /// <param name="currentDate">当前时间</param>
        public void Set_Register_DeadLine_Date(DateTime currentDate)
        {
            IMP_Address.D4030 = currentDate;
            //string temp;
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < 19; i++)
            //{
            //    sb.Append(" ");
            //}
            //temp = sb.ToString();

            //Class_ShareMem.Set_D_String(IMP_Address.D4030, temp, 20);
            //Class_ShareMem.Set_D_String(IMP_Address.D4030, currentDate, 20);

        }

        /// <summary>
        /// 将共享内存中的当前时间和截止日期清空
        /// </summary>
        public void Set_Register_Empty_Date()
        {
            IMP_Address.D4010 = DateTime.Now;
            IMP_Address.D4030 = DateTime.Now;
            //string temp;
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < 19; i++)
            //{
            //    sb.Append(" ");
            //}
            //temp = sb.ToString();

            //Class_ShareMem.Set_D_String(IMP_Address.D4010, temp, 20);
            //Class_ShareMem.Set_D_String(IMP_Address.D4030, temp, 20);
        }


        /// <summary>
        /// 程序一开始的时候检测是否到达指定的截止日期
        /// </summary>
        /// <returns>0：未注册，1：计算机时间写入共享内存成功，2：永久，3：当前时间大于共享内存中的时间，4：超过截止时间</returns>
        public int Check_Deadline_Date_First()
        {
            int mode = this.Get_Register_Mode();
            switch (mode)
            {
                case 0:
                    return 0;
                case 1:
                    this.Get_Register_Current_Date_ByJay();
                    DateTime current = IMP_Address.D4010;
                    DateTime deadline = IMP_Address.D4030;               
                    //计算机的当前时间
                    DateTime now = DateTime.Now;
                    //计算机的当前时间+5分钟
                    //DateTime currentAdd5Minutes = current.AddMinutes(5);

                    //计算机的当前时间与共享内存中的当前时间进行比较
                    bool result1 = this.Compute_Date(now, current);
                    //计算机的当前时间与共享内存中的截止时间进行比较
                    bool result2 = this.Compute_Date(deadline, now);
                    //计算机的当前时间与共享内存中的当前时间进行比较，如果超过5分钟，则计算机的时间被往后修改了，报错
                    //bool result3 = this.Compute_Date(currentAdd5Minutes, now);

                    //当前时间正确，将当前时间写入共享内存
                    if (result1 && result2)
                    {
                        this.Set_Register_Current_Date(now);
                        return 1;
                    }
                    //时间被往前修改了
                    else if (!result1)
                    {
                        return 3;
                    }
                    //时间被往后修改，并超过了截止日期
                    else
                    {
                        return 4;
                    }
                    //时间被往后修改，超过了共享内存中的时间5分钟
                    //else
                    //{
                    //    return 5;
                    //}
                case 2:
                    return 2;
                default:
                    return 0;
            }

        }

        ///// <summary>
        ///// 程序运行中，检测是否到达指定的截止日期
        ///// </summary>
        ///// <returns>0：未注册，1：计算机时间写入共享内存成功，2：永久，3：当前时间大于共享内存中的时间，4：超过截止时间，5：时间被往后修改了超过5分钟</returns>
        //public int Check_Deadline_Date()
        //{
        //    int mode = this.Get_Register_Mode();
        //    switch (mode)
        //    {
        //        case 0:
        //            return 0;
        //        case 1:
        //            string currentDate = this.Get_Register_Current_Date();
        //            string deadlineDate = this.Get_Register_DeadLine_Date();
        //            //共享内存中的当前时间
        //            DateTime current = DateTime.Parse(currentDate);
        //            //共享内存中的截止时间
        //            DateTime deadline = DateTime.Parse(deadlineDate);
        //            //计算机的当前时间
        //            DateTime now = DateTime.Now;
        //            //计算机的当前时间+1分钟
        //            DateTime currentAdd1Minutes = current.AddMinutes(1);

        //            //计算机的当前时间与共享内存中的当前时间进行比较
        //            bool result1 = this.Compute_Date(now, current);
        //            //计算机的当前时间与共享内存中的截止时间进行比较
        //            bool result2 = this.Compute_Date(deadline, now);
        //            //计算机的当前时间与共享内存中的当前时间进行比较，如果超过1分钟，则计算机的时间被往后修改了，报错
        //            bool result3 = this.Compute_Date(currentAdd1Minutes, now);

        //            //当前时间正确，将当前时间写入共享内存
        //            if (result1 && result2 && result3)
        //            {
        //                this.Set_Register_Current_Date(now.ToString("yyyy-MM-dd  HH:mm:ss"));
        //                return 1;
        //            }
        //            //时间被往前修改了
        //            else if (!result1)
        //            {
        //                return 3;
        //            }
        //            //时间被往后修改，并超过了截止日期
        //            else if(!result2)
        //            {
        //                return 4;
        //            }
        //            //时间被往后修改，超过了共享内存中的时间5分钟
        //            else
        //            {
        //                return 5;
        //            }
        //        case 2:
        //            return 2;
        //        default:
        //            return 0;
        //    }

        //}
        /// <summary>
        /// 程序运行中，检测是否到达指定的截止日期
        /// </summary>
        /// <returns>0：未注册，1：计算机时间写入共享内存成功，2：永久，3：当前时间大于共享内存中的时间，4：超过截止时间，5：获取共享内存中的时间错误</returns>
        public int Check_Deadline_Date()
        {
            int mode = this.Get_Register_Mode();
            switch (mode)
            {
                case 0:
                    return 0;
                case 1:
                //    this.Get_Register_Current_Date();
                    DateTime current = IMP_Address.D4010;
                    DateTime deadline = IMP_Address.D4030;            
                    //时间转换失败
                    //if (!DateTime.TryParse(currentDate, out current) || !DateTime.TryParse(deadlineDate, out deadline))
                    //{
                    //    this.Set_Register_Mode(0);
                    //    this.Set_Register_Empty_Date();
                    //    return 5;
                    //}

                    //计算机的当前时间
                    DateTime now = DateTime.Now;

                    //计算机的当前时间与共享内存中的当前时间进行比较
                    bool result1 = this.Compute_Date(now, current);
                    //计算机的当前时间与共享内存中的截止时间进行比较
                    bool result2 = this.Compute_Date(deadline, now);

                    //当前时间正确，将当前时间写入共享内存
                    if (result1 && result2)
                    {
                    //    this.Set_Register_Current_Date(now.ToString("yyyy-MM-dd HH:mm:ss"));
                        this.Set_Register_Current_Date(now);
                        return 1;
                    }
                    //时间被往前修改了
                    else if (!result1)
                    {
                        return 3;
                    }
                    //时间超过了截止日期
                    else
                    {
                        return 4;
                    }

                case 2:
                    return 2;
                default:
                    return 0;
            }

        }


        /// <summary>
        /// 程序运行中，且在打开注册窗体的时候，检测是否到达指定的截止日期
        /// </summary>
        /// <returns>0：未注册，1：计算机时间写入共享内存成功，2：永久，3：当前时间大于共享内存中的时间，4：超过截止时间</returns>
        public int Check_Deadline_Date_Without_Write()
        {
            int mode = this.Get_Register_Mode();
            switch (mode)
            {
                case 0:
                    return 0;
                case 1:
             //    this.Get_Register_Current_Date();
                 DateTime current= IMP_Address.D4010;
                 DateTime deadline = IMP_Address.D4030;                              
                    //计算机的当前时间
                    DateTime now = DateTime.Now;
                    //计算机的当前时间+5分钟
                    DateTime currentAdd5Minutes = current.AddMinutes(5);

                    //计算机的当前时间与共享内存中的当前时间进行比较
                    bool result1 = this.Compute_Date(now, current);
                    //计算机的当前时间与共享内存中的截止时间进行比较
                    bool result2 = this.Compute_Date(deadline, now);
                    //计算机的当前时间与共享内存中的当前时间进行比较，如果超过5分钟，则计算机的时间被往后修改了，报错
                    bool result3 = this.Compute_Date(currentAdd5Minutes, now);

                    //当前时间正确，将当前时间写入共享内存
                    if (result1 && result2 && result3)
                    {
                        //this.Set_Register_Current_Date(now.ToString("yyyy-MM-dd HH:mm:ss"));
                        return 1;
                    }
                    //时间被往前修改了
                    else if (!result1)
                    {
                        return 3;
                    }
                    //时间被往后修改，并超过了截止日期
                    else if (!result2)
                    {
                        return 4;
                    }
                    //时间被往后修改，超过了共享内存中的时间5分钟
                    else
                    {
                        return 5;
                    }
                case 2:
                    return 2;
                default:
                    return 0;
            }

        }

        /// <summary>
        /// 获取当前时间与截止时间的差值
        /// </summary>
        /// <returns></returns>
        public string Get_Current_Deadline_Days()
        {
          //  this.Get_Register_Current_Date();
              DateTime current= IMP_Address.D4010;
             DateTime deadline= IMP_Address.D4030;                
            TimeSpan ts = deadline - current;
            int days = ts.Days;
            int hours = ts.Hours;
            int second = ts.Seconds;
            string result;
            if (days>0)
            {
                result = days.ToString() + " 天 " + hours.ToString() + " 小时 " ;
            }
            else
            {
                result = hours.ToString() + " 小时 " + second + " 秒";
            }

            return result;
        }

        /// <summary>
        /// 计算两个时间之差
        /// </summary>
        /// <returns>true为date1>date2，false为date1<date2</returns>
        public bool Compute_Date(DateTime date1, DateTime date2)
        {
            TimeSpan ts = date1 - date2;
            double getSeconds = ts.TotalSeconds;
            if (getSeconds > 0.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region “参数设置”
        public void Set_Parameters_Save()
        {
            Class_ShareMem.Set_M(IMP_Address.M21, true);
        }

        public bool Get_Parameters_Is_Save()
        {
            return Class_ShareMem.Get_M(IMP_Address.M21) == 1;
        }
        #endregion

        #region GCode预览加工路径绘制



        /// <summary>
        /// 开启GCode路径绘制
        /// </summary>
        public void SNC_Draw_Init()
        {
            try
            {
                //CDraw.CSglClose(1);
                CDraw.CSglGroupInit(1);
                CDraw.CSglInit(0, 0, 0, this.pic_Draw.Width, this.pic_Draw.Height, this.pic_Draw.Handle);
                CDraw.CSglSetNet(0, 20);
                CDraw.CSglSetLookScale(0, 50);
                //CDraw.CSglSetRotate(0, 1, 90);
                float[] RGB0 = new float[3] { 0, 255, 0 };
                CDraw.CSglSetLineColor(0, this.RGB_G00);
            }
            catch (Exception e)
            {
                throw e;
            }


            //CDraw.CSglClose(0);
        }

        /// <summary>
        /// 关闭当前模拟窗口
        /// </summary>
        public void SNC_Draw_Close()
        {
            CDraw.CSglClose(0);
            CDraw.CSglGroupClose();
        }

        /// <summary>
        /// 模拟绘图，根据当前SNC执行时的各轴反馈位置进行绘图
        /// </summary>
        /// <param name="currentSncNo">需要进行绘图的snc组别</param>
        public void SNC_Draw_Simulate(ushort currentSncNo, bool on)
        {
            //SNC_Draw(currentSncNo);
            Class_ShareMemCustom.SetSingleW(IMP_Address.SNC_CtrAddW, 30);
        }

        /// <summary>
        /// SNC绘图，需要开一个线程来一直调用此方法来实时绘图
        /// </summary>
        /// <param name="currentSncNo"></param>
        public void SNC_Draw(bool isSimulate)
        {
            //double mode = SNC_Get_Parameter(currentSncNo, 869);       //判断是G00/G01,G02
            //判断是否加工
            if (this.Is_Draw)
            {
                int mode = Get_G_Mode();

                if (mode == 0)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G00);
                }
                else if (mode == 1)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G01);
                }
                else if (mode == 2)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G02);
                }
                else if (mode == 3)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G03);
                }

                if (!isSimulate)
                {
                    this.x_Position = GetAxisPosition(this.AxisAddress_Workpiece[0]) / 1000.0f;
                    this.y_Position = GetAxisPosition(this.AxisAddress_Workpiece[1]) / 1000.0f;
                    this.z_position = GetAxisPosition(this.AxisAddress_Workpiece[2]) / 1000.0f;
                    CDraw.CSglInData(0, this.x_Position, this.y_Position, this.z_position);
                }
                else
                {
                    this.x_Position_machine = GetAxisPosition(this.AxisAddress_Machine[0]) / 1000.0f;
                    this.y_Position_machine = GetAxisPosition(this.AxisAddress_Machine[1]) / 1000.0f;
                    this.z_position_machine = GetAxisPosition(this.AxisAddress_Machine[2]) / 1000.0f;
                    CDraw.CSglInData(0, this.x_Position_machine, this.y_Position_machine, this.z_position_machine);

                    //this.x_Position_machine = 0;
                    //this.y_Position_machine = 0;
                    //this.z_position_machine = 0;
                }


                //CDraw.CSglInDataLine(0, this.x_Position, this.y_Position, this.y_Position);
            }
        }

        /// <summary>
        /// SNC绘图预览，需要开一个线程来一直调用此方法来实时绘图
        /// </summary>
        /// <param name="currentSncNo"></param>
        public void SNC_Draw_Simulate(bool isDraw)
        {
            //判断是否加工
            if (this.Is_Draw)
            {
                int mode = Get_G_Mode();

                if (mode == 0)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G00);
                }
                else if (mode == 1)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G01);
                }
                else if (mode == 2)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G02);
                }
                else if (mode == 3)
                {
                    CDraw.CSglSetLineColor(0, this.RGB_G03);
                }

                if (isDraw)
                {
                    this.x_Position = GetAxisPosition(this.AxisAddress_Machine[0]) / 1000.0f;
                    this.y_Position = GetAxisPosition(this.AxisAddress_Machine[1]) / 1000.0f;
                    this.z_position = GetAxisPosition(this.AxisAddress_Machine[2]) / 1000.0f;
                }

                CDraw.CSglInData(0, this.x_Position, this.y_Position, this.z_position);
                //CDraw.CSglInDataLine(0, this.x_Position, this.y_Position, this.y_Position);
            }
        }

        /// <summary>
        /// 获取G01、G02、G03（返回值为0：G00，1：G01，2：G02，3：G03）
        /// </summary>
        /// <returns></returns>
        public int Get_G_Mode()
        {
            //return Class_ShareMemCustom.GetSingleD(IMP_Address.D1206);//?        
            return Class_ShareMem.Get_W(IMP_Address.SNC_SimuModeWAddW, false);
        }

        /// <summary>
        /// 预览绘图,根据当前GCode编辑框中的内容将路径一次性全部绘出
        /// </summary>
        /// <param name="cnc"></param>
        /// <param name="gcodeText"></param>
        public void SNC_PreviewDraw(bool isDraw)
        {
            //开始绘图
            SNC_Draw_Simulate(isDraw);
        }

        /// <summary>
        /// 清除所有panel上的绘图
        /// </summary>
        public void SNC_ClearDraw()
        {
            CDraw.CSglClearPoint(3);
        }

        #endregion

        #region “Jog”模式下的一些方法

        #region “贴标”

        /// <summary>
        /// 设置各轴jog速度。按指定的数值递增或递减
        /// </summary>
        public void Set_Jog_Axis_Speed_Add_Minus(int address, int value, bool isAdd)
        {
            //“+”
            if (isAdd)
            {
                int oriValue = Class_ShareMem.Get_D(address, true);
                oriValue = oriValue + value;
                Class_ShareMem.Set_D(address, oriValue, true);
            }
            //“-”
            else
            {
                int oriValue = Class_ShareMem.Get_D(address, true);
                int desValue = oriValue - value;
                if (desValue >= 0)
                {
                    Class_ShareMem.Set_D(address, desValue, true);
                }
            }
        }

        //贴标X轴Jog速度
        public void Set_Jog_Tiebiao_X_Speed(int value)
        {
            Class_ShareMem.Set_D(IMP_Address.D1500, value, true);
        }
        //贴标Y轴Jog速度
        public void Set_Jog_Tiebiao_Y_Speed_Add(int value)
        {
            Class_ShareMem.Set_D(IMP_Address.D1502, value, true);
        }
        //贴标X轴正向移动
        public void Set_Jog_Tiebiao_X_Move_Forward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M85, isOn);
        }
        //贴标X轴反向移动
        public void Set_Jog_Tiebiao_X_Move_Backward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M84, isOn);
        }
        //贴标Y轴正向移动
        public void Set_Jog_Tiebiao_Y_Move_Forward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M86, isOn);
        }
        //贴标Y轴反向移动
        public void Set_Jog_Tiebiao_Y_Move_Backward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M87, isOn);
        }

        //打开图片
        public void Set_Jog_Tiebiao_Open_Picture()
        {

        }
        //预览图片
        public void Set_Jog_Tiebiao_Preview_Picture()
        {

        }
        //贴标推料
        public void Set_Jog_Tiebiao_Push_Workpiece(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M50102, isOn);
        }
        //贴标动作
        public void Set_Jog_Tiebiao_Action(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M50200, isOn);
        }
        //贴标送料
        public void Set_Jog_Tiebiao_Send(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M50101, isOn);
        }

        //获取贴标推料是否触发
        public bool Get_Jog_Tiebiao_Is_Pushed()
        {
            return Class_ShareMem.Get_M(IMP_Address.M50102) == 1;
        }
        //获取贴标动作是否触发
        public bool Get_Jog_Tiebiao_Is_Action()
        {
            return Class_ShareMem.Get_M(IMP_Address.M50200) == 1;
        }
        //获取贴标送料是否触发
        public bool Get_Jog_Tiebiao_Is_Sent()
        {
            return Class_ShareMem.Get_M(IMP_Address.M50101) == 1;
        }

        #endregion

        #region “开料”
        //开料X轴Jog速度
        private void Set_Jog_Kailiao_X_Speed(int value)
        {
            Class_ShareMem.Set_D(IMP_Address.D1410, value, true);
        }
        //开料Y轴Jog速度
        private void Set_Jog_Kailiao_Y_Speed(int value)
        {
            Class_ShareMem.Set_D(IMP_Address.D1412, value, true);
        }
        //开料Z轴Jog速度
        private void Set_Jog_Kailiao_Z_Speed_Add(int value)
        {
            Class_ShareMem.Set_D(IMP_Address.D1414, value, true);
        }
        //开料X轴正向移动
        public void Set_Jog_Kailiao_X_Move_Forward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M80, isOn);
        }
        //开料X轴反向移动
        public void Set_Jog_Kailiao_X_Move_Backward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M81, isOn);
        }
        //开料Y轴正向移动
        public void Set_Jog_Kailiao_Y_Move_Forward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M78, isOn);
        }
        //开料Y轴反向移动
        public void Set_Jog_Kailiao_Y_Move_Backward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M79, isOn);
        }
        //开料Z轴正向移动
        public void Set_Jog_Kailiao_Z_Move_Forward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M82, isOn);
        }
        //开料Z轴反向移动
        public void Set_Jog_Kailiao_Z_Move_Backward(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M83, isOn);
        }
        //主轴Jog速度设置
        public void Set_Jog_Kailiao_Spindle_Speed(int spindleNo, int value)
        {
            if (spindleNo == 1)
            {
                Class_ShareMem.Set_D(IMP_Address.D502, value, false);
            }
            else if (spindleNo == 2)
            {
                Class_ShareMem.Set_D(IMP_Address.D504, value, false);
            }
        }

        //获取主轴转速
        public int Get_Current_Spindle_Speed()
        {
            return Class_ShareMem.Get_D(IMP_Address.D524, false);
        }

        //主轴正转
        public void Set_Jog_Kailiao_Spindle_Move_Foreward(int spindleNo)
        {
            if (spindleNo == 1)
            {
                Class_ShareMem.Set_M(IMP_Address.M91, true);
            }
            else if (spindleNo == 2)
            {
                Class_ShareMem.Set_M(IMP_Address.M93, true);
            }
        }
        //主轴反转
        public void Set_Jog_Kailiao_Spindle_Move_Backward(int spindleNo)
        {
            if (spindleNo == 1)
            {
                Class_ShareMem.Set_M(IMP_Address.M90, true);
            }
            else if (spindleNo == 2)
            {
                Class_ShareMem.Set_M(IMP_Address.M92, true);
            }
        }
        //主轴停止
        public void Set_Jog_Kailiao_Spindle_Stop(int spindleNo)
        {
            if (spindleNo == 1)
            {
                Class_ShareMem.Set_M(IMP_Address.M94, true);
            }
            else if (spindleNo == 2)
            {
                Class_ShareMem.Set_M(IMP_Address.M95, true);
            }
        }
        //换刀
        public void Set_Jog_Kailiao_Spindle_Change(int spindleNo)
        {
            //T1换刀
            if (spindleNo == 1)
            {
                Class_ShareMem.Set_M(IMP_Address.M533, true);
            }
            //T2换刀
            else if (spindleNo == 2)
            {
                Class_ShareMem.Set_M(IMP_Address.M534, true);
            }
        }
        //开始对刀
        public void Set_Jog_Kailiao_ToolSetting_Start()
        {
            Class_ShareMem.Set_M(IMP_Address.M536, true);
        }
        //停止对刀
        public void Set_Jog_Kailiao_ToolSetting_Stop()
        {
            Class_ShareMem.Set_M(IMP_Address.M537, true);
        }
        //手轮开启
        public void Set_Jog_Tiebiao_Mpg(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M1400, isOn);
        }
        //后定位
        public void Set_Jog_Tiebiao_Location_Back(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M6317, isOn);
        }
        //左定位
        public void Set_Jog_Tiebiao_Location_LeftFront(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M6313, isOn);
        }
        //前定位
        public void Set_Jog_Tiebiao_Location_FrontFront(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M6308, isOn);
        }
        //右前定位
        public void Set_Jog_Tiebiao_Location_RightFront(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M6314, isOn);
        }
        //台面吸附
        public void Set_Jog_Tiebiao_Table_Adsorption(bool isOn)
        {
            Class_ShareMem.Set_M(IMP_Address.M6315, isOn);
        }

        //获取主轴是否正转
        public bool Get_Jog_Kailiao_Is_Spindle_Foreward(int spindleNo)
        {
            bool res = false;
            if (spindleNo == 1)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M91) == 1;
            }
            else if (spindleNo == 2)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M93) == 1;
            }
            return res;
        }
        //获取主轴是否反转
        public bool Get_Jog_Kailiao_Is_Spindle_Backward(int spindleNo)
        {
            bool res = false;
            if (spindleNo == 1)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M90) == 1;
            }
            else if (spindleNo == 2)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M92) == 1;
            }
            return res;
        }
        //获取主轴是否停止
        public bool Get_Jog_Kailiao_Is_Spindle_Stop(int spindleNo)
        {
            bool res = false;
            if (spindleNo == 1)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M94) == 1;
            }
            else if (spindleNo == 2)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M95) == 1;
            }
            return res;
        }
        //获取主轴换刀是否触发
        public bool Get_Jog_Kailiao_Is_Spindle_Change(int spindleNo)
        {
            //T1换刀被触发
            bool res = false;
            if (spindleNo == 1)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M533) == 1;
            }
            else if (spindleNo == 2)
            {
                res = Class_ShareMem.Get_M(IMP_Address.M534) == 1;
            }
            return res;
        }
        //获取开始对刀是否触发
        public bool Get_Jog_Kailiao_Is_ToolSetting_Start()
        {
            return Class_ShareMem.Get_M(IMP_Address.M536) == 1;
        }
        //获取停止对刀是否触发
        public bool Get_Jog_Kailiao_Is_ToolSetting_Stop()
        {
            return Class_ShareMem.Get_M(IMP_Address.M537) == 1;
        }
        //获取手轮模式是否被触发
        public bool Get_Jog_Kailiao_Is_Mpg()
        {
            return Class_ShareMem.Get_M(IMP_Address.M1400) == 1;
        }
        //获取后定位是否被触发
        public bool Get_Jog_Kailiao_Is_Location_Back()
        {
            return Class_ShareMem.Get_M(IMP_Address.M6317) == 1;
        }
        //获取左定位是否被触发
        public bool Get_Jog_Kailiao_Is_Location_LeftFront()
        {
            return Class_ShareMem.Get_M(IMP_Address.M6313) == 1;
        }

        //获取前定位是否被触发
        public bool Get_Jog_Kailiao_Is_Location_FrontFront()
        {
            return Class_ShareMem.Get_M(IMP_Address.M6308) == 1;
        }

        //获取右前定位是否被触发
        public bool Get_Jog_Kailiao_Is_Location_RightFront()
        {
            return Class_ShareMem.Get_M(IMP_Address.M6314) == 1;
        }
        //获取台面吸附是否被触发
        public bool Get_Jog_Kailiao_Is_Table_Adsorption()
        {
            return Class_ShareMem.Get_M(IMP_Address.M6315) == 1;
        }
        #endregion

        #endregion

        #region “Call IMP参数设置”

        //系统设置
        public void Call_IMP_System_Setting()
        {
            string filepath = "D:\\NandFlash\\IPC Motion Platform\\IMP base\\Tools\\User_Iterface.exe";
            Class_ShareMem.Set_W(9000, 3000, false);
            System.Diagnostics.Process.Start(filepath);
        }

        //刀具偏移设置
        public void Call_IMP_ToolOffset_Setting()
        {
            string filepath = "D:\\NandFlash\\IPC Motion Platform\\IMP base\\Tools\\User_Iterface.exe";
            Class_ShareMem.Set_W(9000, 3040, false);
            System.Diagnostics.Process.Start(filepath);
        }

        //坐标系设置
        public void Call_IMP_Coordinates_Setting()
        {
            string filepath = "D:\\NandFlash\\IPC Motion Platform\\IMP base\\Tools\\User_Iterface.exe";
            Class_ShareMem.Set_W(9000, 3020, false);
            System.Diagnostics.Process.Start(filepath);
        }

        //刀长刀径设置
        public void Call_IMP_ToolLengthDiameter_Setting()
        {
            string filepath = "D:\\NandFlash\\IPC Motion Platform\\IMP base\\Tools\\User_Iterface.exe";
            Class_ShareMem.Set_W(9000, 3030, false);
            System.Diagnostics.Process.Start(filepath);
        }

        //对刀仪设置
        public void Call_IMP_ToolCorrect_Setting()
        {
            string filepath = "D:\\NandFlash\\IPC Motion Platform\\IMP base\\Tools\\User_Iterface.exe";
            Class_ShareMem.Set_W(9000, 3050, false);
            System.Diagnostics.Process.Start(filepath);
        }

        #endregion

        #region “扫描警告”
        public bool Get_Is_Warning_From_M_Address(int mAddress)
        {
            return Class_ShareMem.Get_M(mAddress) == 1;
        }
        #endregion
    }
}
