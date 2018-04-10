using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alam_Function
{
     public class IMP_Address
    {
       

        #region SNC地址
        /// <summary>
        /// 开料SNC的NC文件路径
        /// </summary>
        public static int SNC_LdAddW = 31100;

        /// <summary>
        /// 开料SNC控制字
        /// </summary>
        public static int SNC_CtrAddW = 31000;

        /// <summary>
        /// 开料SNC主轴刀号
        /// </summary>
        public static int SNC_KnifNAddW = 31005;

        /// <summary>
        /// 跳行值的地址（DW）
        /// </summary>
        public static int SNC_JumpLineAddW = 31007;

        /// <summary>
        /// 开料SNC异常码
        /// </summary>
        public static int SNC_WroAddW = 31009;

        /// <summary>
        /// 开料SNC异常行数(DW)
        /// </summary>
        public static int SNC_WrongLineAddW = 32178;

        /// <summary>
        /// 开料SNC异常类型
        /// </summary>
        public static int SNC_WroSAddW = 31010;

        /// <summary>
        /// SNC路径模拟控制字
        /// </summary>
        public static int SNC_SimuAddW = 32999;

        /// <summary>
        /// SNC模拟图长
        /// </summary>
        public static int SNC_SimuLAddW = 32994;

        /// <summary>
        /// SNC模拟图宽
        /// </summary>
        public static int SNC_SimuWAddW = 32995;

        /// <summary>
        /// SNC模拟图中当前加工模式（G01，G02，G03）
        /// </summary>
        public static int SNC_SimuModeWAddW = 32996;

        /// <summary>
        /// SNC模拟图X位置
        /// </summary>
        public static int SNC_SimuXAddW = 32997;

        /// <summary>
        /// SNC模拟图Y位置
        /// </summary>
        public static int SNC_SimuYAddW = 32998;

        /// <summary>
        /// SNC进给倍率致能
        /// </summary>
        public static int SNC_FdAddR = 32997;

        /// <summary>
        /// SNC开启单步
        /// </summary>
        public static int SNC_StepEnableAddR = 32981;

        /// <summary>
        /// SNC单步动作
        /// </summary>
        public static int SNC_StepActionAddR = 32982;

        /// <summary>
        /// SNC进给倍率
        /// </summary>
        public static int SNC_FdAddW = 32480;

        /// <summary>
        /// SNC参数档名位址（读取其中50个word）
        /// </summary>
        public static int SNC_SetsAddW = 9020;

        /// <summary>
        /// SNC参数触发位址
        /// </summary>
        public static int SNC_SetfAddW = 9000;

        /// <summary>
        /// SNC状态位(0:停止 1:暂停 2:执行中)
        /// </summary>
        public static int SNC_StufAddW = 31011;

        /// <summary>
        /// SNC执行行数(doubleword)
        /// </summary>
        public static int SNC_RunLAddW = 32187;

        /// <summary>
        /// SNC总行数(doubleword)
        /// </summary>
        public static int SNC_TotalLAddW = 32193;

        /// <summary>
        /// SNC预估花费总时间
        /// </summary>
        public static int SNC_ScanTAddW = 32230;

        /// <summary>
        /// SNC运行时间
        /// </summary>
        public static int SNC_RunTAddW = 32231;

        /// <summary>
        /// SNC剩余时间
        /// </summary>
        public static int SNC_RestTAddW = 32233;

        /// <summary>
        /// SNC执行率（%）
        /// </summary>
        public static int SNC_RunPAddW = 32236;

        /// <summary>
        /// SNC目前进给速度（mm/min）(DW)
        /// </summary>
        public static int SNC_RunFAddW = 32774;

        /// <summary>
        /// SNC目前坐标系
        /// </summary>
        public static int SNC_RunCoAddW = 32754;

        /// <summary>
        /// SNC X轴相对坐标清零BIT
        /// </summary>
        public static int SNC_XCLAddR = 32986;

        /// <summary>
        /// SNC Y轴相对坐标清零BIT
        /// </summary>
        public static int SNC_YCLAddR = 32987;

        /// <summary>
        /// SNC Z轴相对坐标清零BIT
        /// </summary>
        public static int SNC_ZCLAddR = 32988;

        /// <summary>
        /// SNC X轴机械坐标(doubleword)
        /// </summary>
        public static int SNC_XFDAddW = 32520;

        /// <summary>
        /// SNC Y轴机械坐标(doubleword)
        /// </summary>
        public static int SNC_YFDAddW = 32522;

        /// <summary>
        /// SNC Z轴机械坐标(doubleword)
        /// </summary>
        public static int SNC_ZFDAddW = 32524;

        /// <summary>
        /// SNC A轴机械坐标(doubleword)
        /// </summary>
        public static int SNC_AFDAddW = 10502;

        /// <summary>
        /// SNC B轴机械坐标(doubleword)
        /// </summary>
        public static int SNC_BFDAddW = 10602;

        /// <summary>
        /// SNC X轴工作坐标(doubleword)
        /// </summary>
        public static int SNC_XWCAddW = 32556;

        /// <summary>
        /// SNC Y轴工作坐标(doubleword)
        /// </summary>
        public static int SNC_YWCAddW = 32558;

        /// <summary>
        /// SNC Z轴工作坐标(doubleword)
        /// </summary>
        public static int SNC_ZWCAddW = 32560;

        /// <summary>
        /// SNC X轴坐标剩余距离(doubleword)
        /// </summary>
        public static int SNC_XRCAddW = 32574;

        /// <summary>
        /// SNC Y轴坐标剩余距离(doubleword)
        /// </summary>
        public static int SNC_YRCAddW = 32576;

        /// <summary>
        /// SNC Z轴坐标剩余距离(doubleword)
        /// </summary>
        public static int SNC_ZRCAddW = 32578;

        /// <summary>
        /// SNC X轴相对坐标值(doubleword)
        /// </summary>
        public static int SNC_XReCAddW = 32736;

        /// <summary>
        /// SNC Y轴相对坐标值(doubleword)
        /// </summary>
        public static int SNC_YReCAddW = 32738;

        /// <summary>
        /// SNC Z轴相对坐标值(doubleword)
        /// </summary>
        public static int SNC_ZReCAddW = 32740;

         /// <summary>
         /// 贴标机动作触发地址
         /// </summary>
        public static int M50200 = 50200;

        /// <summary>
        /// 贴标机送料触发地址
        /// </summary>
        public static int M50101 = 50101;

         /// <summary>
         /// 贴标机推料触发地址
         /// </summary>
        public static int M50102 = 50102;

        #endregion

        #region DMC地址

        #region M地址区
        /// <summary>
        /// 开料自动
        /// </summary>
        public static int M0 = 0;

        /// <summary>
        /// 开料编辑
        /// </summary>
        public static int M1 = 1;

        /// <summary>
        /// 手动
        /// </summary>
        public static int M2 = 2;

        /// <summary>
        /// 设置
        /// </summary>
        public static int M3 = 3;

        /// <summary>
        /// 开料回原点
        /// </summary>
        public static int M6 = 6;

        /// <summary>
        /// 复位
        /// </summary>
        public static int M7 = 7;

        /// <summary>
        /// 自动生效位元
        /// </summary>
        public static int M10 = 10;

        /// <summary>
        /// MDI生效位元
        /// </summary>
        public static int M11 = 11;

        /// <summary>
        /// 手动生效位元
        /// </summary>
        public static int M12 = 12;

        /// <summary>
        /// 退出按钮
        /// </summary>
        public static int M20 = 20;

        /// <summary>
        /// 参数保存按钮
        /// </summary>
        public static int M21 = 21;

        /// <summary>
        /// 开料程序启动
        /// </summary>
        public static int M32 = 32;

        /// <summary>
        /// 开料SNC停止
        /// </summary>
        public static int M59 = 59;

        /// <summary>
        /// 开料X轴回原点
        /// </summary>
        public static int M70 = 70;

        /// <summary>
        /// 开料Y轴回原点
        /// </summary>
        public static int M71 = 71;

        /// <summary>
        /// 开料Z轴回原点
        /// </summary>
        public static int M72 = 72;

        /// <summary>
        /// 贴标X轴回原点
        /// </summary>
        public static int M73 = 73;

        /// <summary>
        /// 贴标Y轴回原点
        /// </summary>
        public static int M74 = 74;

        /// <summary>
        /// 贴标原点复归
        /// </summary>
        public static int M75 = 75;

        /// <summary>
        ///开料Y轴手动+
        /// </summary>
        public static int M78 = 78;

        /// <summary>
        ///开料Y轴手动-
        /// </summary>
        public static int M79 = 79;

        /// <summary>
        /// 开料X轴手动+
        /// </summary>
        public static int M80 = 80;

        /// <summary>
        /// 开料X轴手动-
        /// </summary>
        public static int M81 = 81;

        /// <summary>
        ///开料Z轴手动+
        /// </summary>
        public static int M82 = 82;

        /// <summary>
        /// 开料Z轴手动-
        /// </summary>
        public static int M83 = 83;

        /// <summary>
        /// 贴标X轴-
        /// </summary>
        public static int M84 = 84;

        /// <summary>
        /// 贴标X轴+
        /// </summary>
        public static int M85 = 85;

        /// <summary>
        /// 贴标Y轴+
        /// </summary>
        public static int M86 = 86;

        /// <summary>
        /// 贴标Y轴-
        /// </summary>
        public static int M87 = 87;

        /// <summary>
        /// 开料暂停
        /// </summary>
        public static int M89 = 89;

        /// <summary>
        /// 手动主轴1反转
        /// </summary>
        public static int M90 = 90;

        /// <summary>
        /// 手动主轴1正转
        /// </summary>
        public static int M91 = 91;

        /// <summary>
        /// 手动主轴2反转
        /// </summary>
        public static int M92 = 92;

        /// <summary>
        /// 手动主轴2正转
        /// </summary>
        public static int M93 = 93;

        /// <summary>
        /// 主轴1停止
        /// </summary>
        public static int M94 = 94;

        /// <summary>
        /// 主轴2停止
        /// </summary>
        public static int M95 = 95;

        /// <summary>
        /// 跳行
        /// </summary>
        public static int M300 = 300;

        /// <summary>
        /// 贴标停止标志位 
        /// </summary>
        public static int M402 = 402;

        /// <summary>
        /// 断点继续标志位
        /// </summary>
        public static int M403 = 403;

        /// <summary>
        /// IMP中连续加工时删除文件标志
        /// </summary>
        public static int M406 = 406;

        /// <summary>
        /// 点击连续加工完成删除文件标志位
        /// </summary>
        public static int M407 = 407;

        /// <summary>
        /// 连续加工完成标志位
        /// </summary>
        public static int M408 = 408;

        /// <summary>
        /// 手动换刀T1
        /// </summary>
        public static int M533 = 533;

        /// <summary>
        /// 手动换刀T2
        /// </summary>
        public static int M534 = 534;

        /// <summary>
        /// 当前程序加工完成标志位
        /// </summary>
        public static int M535 = 535;

        /// <summary>
        /// 开始对刀
        /// </summary>
        public static int M536 = 536;

        /// <summary>
        /// 停止对刀
        /// </summary>
        public static int M537 = 537;

        /// <summary>
        /// GCode行号高亮显示开始标志位
        /// </summary>
        public static int M538 = 538;

        /// <summary>
        /// GCode行号高亮显示结束标志位
        /// </summary>
        public static int M539 = 539;

        /// <summary>
        /// 跳行加工开始标志位
        /// </summary>
        public static int M540 = 540;

         /// <summary>
         /// 停止标志
         /// </summary>
        public static int M541 = 541;

        /// <summary>
        /// 连续加工标志位
        /// </summary>
        public static int M543 = 543;

        #region “部分IO输出地址”

        /// <summary>
        ///左定位
        /// </summary>
        public static int M6313 = 6313;

        /// <summary>
        ///前定位
        /// </summary>
        public static int M6308= 6308;

        /// <summary>
        ///右前定位
        /// </summary>
        public static int M6314 = 6314;

        /// <summary>
        ///台面吸附
        /// </summary>
        public static int M6315 = 6315;

        /// <summary>
        ///后推汽缸
        /// </summary>
        public static int M6317 = 6317;

        #endregion

        #region “输出测试”
        /// <summary>
        ///DY1
        /// </summary>
        public static int M8100 = 8100;

        /// <summary>
        ///DY2
        /// </summary>
        public static int M8101 = 8101;

        /// <summary>
        ///DY3
        /// </summary>
        public static int M8102 = 8102;

        /// <summary>
        ///DY4
        /// </summary>
        public static int M8103 = 8103;

        /// <summary>
        ///DY5
        /// </summary>
        public static int M8104 = 8104;

        /// <summary>
        ///DY6
        /// </summary>
        public static int M8105 = 8105;

        /// <summary>
        ///DY7
        /// </summary>
        public static int M8106 = 8106;

        /// <summary>
        ///DY8
        /// </summary>
        public static int M8107 = 8107;

        /// <summary>
        ///DY9
        /// </summary>
        public static int M8108 = 8108;

        /// <summary>
        ///DY10
        /// </summary>
        public static int M8109 = 8109;

        /// <summary>
        ///DY11
        /// </summary>
        public static int M8110 = 8110;

        /// <summary>
        ///DY12
        /// </summary>
        public static int M8111 = 8111;

        /// <summary>
        ///DY13
        /// </summary>
        public static int M8112 = 8112;

        /// <summary>
        ///DY14
        /// </summary>
        public static int M8113 = 8113;

        /// <summary>
        ///DY15
        /// </summary>
        public static int M8114 = 8114;

        /// <summary>
        ///DY16
        /// </summary>
        public static int M8115 = 8115;

        /// <summary>
        ///DY17
        /// </summary>
        public static int M8116 = 8116;

        /// <summary>
        ///DY18
        /// </summary>
        public static int M8117 = 8117;

        /// <summary>
        ///DY19
        /// </summary>
        public static int M8118 = 8118;

        /// <summary>
        ///DY20
        /// </summary>
        public static int M8119 = 8119;

        /// <summary>
        ///DY21
        /// </summary>
        public static int M8120 = 8120;

        /// <summary>
        ///DY22
        /// </summary>
        public static int M8121 = 8121;

        /// <summary>
        ///DY23
        /// </summary>
        public static int M8122 = 8122;

        /// <summary>
        ///DY24
        /// </summary>
        public static int M8123 = 8123;

        /// <summary>
        ///DY25
        /// </summary>
        public static int M8124 = 8124;

        /// <summary>
        ///DY26
        /// </summary>
        public static int M8125 = 8125;

        /// <summary>
        ///DY27
        /// </summary>
        public static int M8126 = 8126;

        /// <summary>
        ///DY28
        /// </summary>
        public static int M8127 = 8127;

        /// <summary>
        ///DY29
        /// </summary>
        public static int M8128 = 8128;

        /// <summary>
        ///DY30
        /// </summary>
        public static int M8129 = 8129;

        /// <summary>
        ///DY31
        /// </summary>
        public static int M8130 = 8130;

        /// <summary>
        ///DY32
        /// </summary>
        public static int M8131 = 8131;
        #endregion

        #region “输入取反”

        /// <summary>
        ///DX输入取反控制总开关
        /// </summary>
        public static int M2200 = 2200;

        /// <summary>
        ///DX1
        /// </summary>
        public static int M2000 = 2000;

        /// <summary>
        ///DX2
        /// </summary>
        public static int M2001 = 2001;

        /// <summary>
        ///DX3
        /// </summary>
        public static int M2002 = 2002;

        /// <summary>
        ///DX4
        /// </summary>
        public static int M2003 = 2003;

        /// <summary>
        ///DX5
        /// </summary>
        public static int M2004 = 2004;

        /// <summary>
        ///DX6
        /// </summary>
        public static int M2005 = 2005;

        /// <summary>
        ///DX7
        /// </summary>
        public static int M2006 = 2006;

        /// <summary>
        ///DX8
        /// </summary>
        public static int M2007 = 2007;

        /// <summary>
        ///DX9
        /// </summary>
        public static int M2008 = 2008;

        /// <summary>
        ///DX10
        /// </summary>
        public static int M2009 = 2009;

        /// <summary>
        ///DX11
        /// </summary>
        public static int M2010 = 2010;

        /// <summary>
        ///DX12
        /// </summary>
        public static int M2011 = 2011;

        /// <summary>
        ///DX13
        /// </summary>
        public static int M2012 = 2012;

        /// <summary>
        ///DX14
        /// </summary>
        public static int M2013 = 2013;

        /// <summary>
        ///DX15
        /// </summary>
        public static int M2014 = 2014;

        /// <summary>
        ///DX16
        /// </summary>
        public static int M2015 = 2015;

        /// <summary>
        ///DX17
        /// </summary>
        public static int M2016 = 2016;

        /// <summary>
        ///DX18
        /// </summary>
        public static int M2017 = 2017;

        /// <summary>
        ///DX19
        /// </summary>
        public static int M2018 = 2018;

        /// <summary>
        ///DX20
        /// </summary>
        public static int M2019 = 2019;

        /// <summary>
        ///DX21
        /// </summary>
        public static int M2020 = 2020;

        /// <summary>
        ///DX22
        /// </summary>
        public static int M2021 = 2021;

        /// <summary>
        ///DX23
        /// </summary>
        public static int M2022 = 2022;

        /// <summary>
        ///DX24
        /// </summary>
        public static int M2023 = 2023;

        /// <summary>
        ///DX25
        /// </summary>
        public static int M2024 = 2024;

        /// <summary>
        ///DX26
        /// </summary>
        public static int M2025 = 2025;

        /// <summary>
        ///DX27
        /// </summary>
        public static int M2026 = 2026;

        /// <summary>
        ///DX28
        /// </summary>
        public static int M2027 = 2027;

        /// <summary>
        ///DX29
        /// </summary>
        public static int M2028 = 2028;

        /// <summary>
        ///DX30
        /// </summary>
        public static int M2029 = 2029;

        /// <summary>
        ///DX31
        /// </summary>
        public static int M2030 = 2030;

        /// <summary>
        ///DX32
        /// </summary>
        public static int M2031 = 2031;
        #endregion

        #region “输出取反”

        /// <summary>
        ///DX强制控制总开关
        /// </summary>
        public static int M8200 = 8200;

        /// <summary>
        ///DY1
        /// </summary>
        public static int M2100 = 2100;

        /// <summary>
        ///DY2
        /// </summary>
        public static int M2101 = 2101;

        /// <summary>
        ///DY3
        /// </summary>
        public static int M2102 = 2102;

        /// <summary>
        ///DY4
        /// </summary>
        public static int M2103 = 2103;

        /// <summary>
        ///DY5
        /// </summary>
        public static int M2104 = 2104;

        /// <summary>
        ///DY6
        /// </summary>
        public static int M2105 = 2105;

        /// <summary>
        ///DY7
        /// </summary>
        public static int M2106 = 2106;

        /// <summary>
        ///DY8
        /// </summary>
        public static int M2107 = 2107;

        /// <summary>
        ///DY9
        /// </summary>
        public static int M2108 = 2108;

        /// <summary>
        ///DY10
        /// </summary>
        public static int M2109 = 2109;

        /// <summary>
        ///DY11
        /// </summary>
        public static int M2110 = 2110;

        /// <summary>
        ///DY12
        /// </summary>
        public static int M2111 = 2111;

        /// <summary>
        ///DY13
        /// </summary>
        public static int M2112 = 2112;

        /// <summary>
        ///DY14
        /// </summary>
        public static int M2113 = 2113;

        /// <summary>
        ///DY15
        /// </summary>
        public static int M2114 = 2114;

        /// <summary>
        ///DY16
        /// </summary>
        public static int M2115 = 2115;

        /// <summary>
        ///DY17
        /// </summary>
        public static int M2116 = 2116;

        /// <summary>
        ///DY18
        /// </summary>
        public static int M2117 = 2117;

        /// <summary>
        ///DY19
        /// </summary>
        public static int M2118 = 2118;

        /// <summary>
        ///DY21
        /// </summary>
        public static int M2119 = 2119;

        /// <summary>
        ///DY21
        /// </summary>
        public static int M2120 = 2120;

        /// <summary>
        ///DY22
        /// </summary>
        public static int M2121 = 2121;

        /// <summary>
        ///DY23
        /// </summary>
        public static int M2122 = 2122;

        /// <summary>
        ///DY24
        /// </summary>
        public static int M2123 = 2123;

        /// <summary>
        ///DY25
        /// </summary>
        public static int M2124 = 2124;

        /// <summary>
        ///DY26
        /// </summary>
        public static int M2125 = 2125;

        /// <summary>
        ///DY27
        /// </summary>
        public static int M2126 = 2126;

        /// <summary>
        ///DY28
        /// </summary>
        public static int M2127 = 2127;

        /// <summary>
        ///DY29
        /// </summary>
        public static int M2128 = 2128;

        /// <summary>
        ///DY30
        /// </summary>
        public static int M2129 = 2129;

        /// <summary>
        ///DY31
        /// </summary>
        public static int M2130 = 2130;

        /// <summary>
        ///DY32
        /// </summary>
        public static int M2131 = 2131;
        #endregion

        /// <summary>
        /// 急停报警
        /// </summary>
         public static int M10000 =10000;
 
         /// <summary>
         /// X轴异常
         /// </summary>
        public static int M10001 = 10001;
       
        /// <summary>
        /// Y轴异常
        /// </summary>
        public static int M10002 = 10002;

        /// <summary>
        /// Z轴异常
        /// </summary>
        public static int M10003 = 10003;

        /// <summary>
        /// A轴异常
        /// </summary>
        public static int M10004 = 10004;

        /// <summary>
        /// B轴异常
        /// </summary>
        public static int M10005 = 10005;

        /// <summary>
        /// C轴异常
        /// </summary>
        public static int M10006 = 10006;

        /// <summary>
        /// X轴低电压
        /// </summary>
        public static int M10007 = 10007;

        /// <summary>
        /// Y轴低电压
        /// </summary>
        public static int M10008 = 10008;

        /// <summary>
        /// Z轴低电压
        /// </summary>
        public static int M10009 = 10009;
         
        /// <summary>
        /// A轴低电压
        /// </summary>
        public static int M10010 = 10010;

        /// <summary>
        /// B轴低电压
        /// </summary>
        public static int M10011 = 10011;

        /// <summary>
        /// C轴低电压
        /// </summary>
        public static int M10012 = 10012;

        /// <summary>
        /// X轴正极限
        /// </summary>
        public static int M10013 = 10013;

        /// <summary>
        /// Y轴正极限
        /// </summary>
        public static int M10014 = 10014;

        /// <summary>
        /// Z轴正极限
        /// </summary>
        public static int M10015 = 10015;

        /// <summary>
        /// A轴正极限
        /// </summary>
        public static int M10016 = 10016;

        /// <summary>
        /// B轴正极限
        /// </summary>
        public static int M10017 = 10017;

        /// <summary>
        /// C轴正极限
        /// </summary>
        public static int M10018 = 10018;

        /// <summary>
        /// X轴过电压
        /// </summary>
        public static int M10019 = 10019;

        /// <summary>
        /// Y轴过电压
        /// </summary>
        public static int M10020 = 10020;

        /// <summary>
        /// Z轴过电压
        /// </summary>
        public static int M10021 = 10021;

        /// <summary>
        /// A轴过电压
        /// </summary>
        public static int M10022 = 10022;

        /// <summary>
        /// B轴过电压
        /// </summary>
        public static int M10023 = 10023;

        /// <summary>
        /// C轴过电压
        /// </summary>
        public static int M10024 = 10024;

        /// <summary>
        /// X轴过负荷
        /// </summary>
        public static int M10025 = 10025;

        /// <summary>
        /// Y轴过负荷
        /// </summary>
        public static int M10026 = 10026;

        /// <summary>
        /// Z轴过负荷
        /// </summary>
        public static int M10027 = 10027;

        /// <summary>
        /// A轴过负荷
        /// </summary>
        public static int M10028 = 10028;

        /// <summary>
        /// B轴过负荷
        /// </summary>
        public static int M10029 = 10029;

        /// <summary>
        /// C轴过负荷
        /// </summary>
        public static int M10030 = 10030;

        /// <summary>
        /// X轴位置误差过大
        /// </summary>
        public static int M10031 = 10031;

        /// <summary>
        /// Y轴位置误差过大
        /// </summary>
        public static int M10032 = 10032;

        /// <summary>
        /// Z轴位置误差过大
        /// </summary>
        public static int M10033 = 10033;

        /// <summary>
        /// A轴位置误差过大
        /// </summary>
        public static int M10034 = 10034;

        /// <summary>
        /// B轴位置误差过大
        /// </summary>
        public static int M10035 = 10035;

        /// <summary>
        /// C轴位置误差过大
        /// </summary>
        public static int M10036 = 10036;

        /// <summary>
        /// X轴正软极限
        /// </summary>
        public static int M10037 = 10037;

        /// <summary>
        /// X轴正负极限
        /// </summary>
        public static int M10038 = 10038;

        /// <summary>
        /// Y轴正软极限
        /// </summary>
        public static int M10039 = 10039;

        /// <summary>
        /// Y轴正负极限
        /// </summary>
        public static int M10040 = 10040;

        /// <summary>
        /// Z轴正软极限
        /// </summary>
        public static int M10041 = 10041;

        /// <summary>
        /// Z轴正负极限
        /// </summary>
        public static int M10042 = 10042;

        /// <summary>
        /// A轴正软极限
        /// </summary>
        public static int M10043 = 10043;

        /// <summary>
        /// A轴正负极限
        /// </summary>
        public static int M10044 = 10044;

        /// <summary>
        /// B轴正软极限
        /// </summary>
        public static int M10045 = 10045;

        /// <summary>
        /// B轴正负极限
        /// </summary>
        public static int M10046 = 10046;

        /// <summary>
        /// C轴正软极限
        /// </summary>
        public static int M10047 = 10047;

        /// <summary>
        /// C轴正负极限
        /// </summary>
        public static int M10048 = 10048;

        /// <summary>
        /// X轴未归零
        /// </summary>
        public static int M10049 = 10049;

        /// <summary>
        /// Y轴未归零
        /// </summary>
        public static int M10050 = 10050;

        /// <summary>
        /// Z轴未归零
        /// </summary>
        public static int M10051 = 10051;

        /// <summary>
        /// 贴标X轴未归零
        /// </summary>
        public static int M10052 = 10052;

        /// <summary>
        /// 贴标Y轴未归零
        /// </summary>
        public static int M10053 = 10053;

        /// <summary>
        /// X轴硬负极限
        /// </summary>
        public static int M10054 = 10054;

        /// <summary>
        /// Y轴硬负极限
        /// </summary>
        public static int M10055 = 10055;

        /// <summary>
        /// Z轴硬负极限
        /// </summary>
        public static int M10056 = 10056;

        /// <summary>
        /// A轴硬负极限
        /// </summary>
        public static int M10057 = 10057;

        /// <summary>
        /// B轴硬负极限
        /// </summary>
        public static int M10058 = 10058;

        /// <summary>
        /// C轴硬负极限
        /// </summary>
        public static int M10059 = 10059;

        /// <summary>
        /// 气压不足
        /// </summary>
        public static int M10060 = 10060;
     
        /// <summary>
        /// 主轴报警
        /// </summary>
        public static int M10061 = 10061;
       
        /// <summary>
        /// 程序启动时台面未吸附
        /// </summary>
        public static int M10062 = 10062;

        /// <summary>
        /// 开料GCode报警
        /// </summary>
        public static int M10063 = 10063;

        /// <summary>
        /// 主轴通讯异常
        /// </summary>
        public static int M10064 = 10064;

         /// <summary>
         /// 警告：上次结束不在断点中，无需断点继续
         /// </summary>
        public static int M10065 = 10065;

        /// <summary>
        /// 警告：贴标文件错误
        /// </summary>
        public static int M10066 = 10066;

        /// <summary>
        /// 警告：贴标文件为空
        /// </summary>
        public static int M10067 = 10067;

        /// <summary>
        /// 警告：主轴转速超出最大值
        /// </summary>
        public static int M10068 = 10068;

        /// <summary>
        /// 提示：请先Z轴回零
        /// </summary>
        public static int M10069 = 10069;

        /// <summary>
        /// 警告：GCode软极限报警
        /// </summary>
        public static int M10070 = 10070;

        /// <summary>
        /// 警告：未识别的GCode
        /// </summary>
        public static int M10071 = 10071;

        /// <summary>
        /// 警告：执行贴标动作时无标签
        /// </summary>
        public static int M10081 = 10081;

        /// <summary>
        /// 警告：吸标失败
        /// </summary>
        public static int M10082 = 10082;

        /// <summary>
        /// Z轴不在安全位置，换刀报警
        /// </summary>
        public static int M10130 = 10130;

        /// <summary>
        /// 程序是否有报警
        /// </summary>
        public static int M20000 = 20000;

        /// <summary>
        /// 手轮模拟
        /// </summary>
        public static int M1200 = 1200;

        /// <summary>
        /// 手轮开启
        /// </summary>
        public static int M1400 = 1400;

         /// <summary>
         /// 系统是否回零
         /// </summary>
        public static int M1996 = 1996;


        #region “按钮UI的状态标志位”

        #region “自动画面”
        /// <summary>
        /// M32开始加工(on)
        /// </summary>
        public static int M7000 = 7000;

        /// <summary>
        /// M32开始加工(off)
        /// </summary>
        public static int M7001 = 7001;

        /// <summary>
        /// M59停止加工(on)
        /// </summary>
        public static int M7002 = 7002;

        /// <summary>
        /// M59停止加工(off)
        /// </summary>
        public static int M7003 = 7003;

        /// <summary>
        /// M89暂停(on)
        /// </summary>
        public static int M7004 = 7004;

        /// <summary>
        /// M89暂停(off)
        /// </summary>
        public static int M7005 = 7005;

        /// <summary>
        /// M1200手轮模拟(on)
        /// </summary>
        public static int M7006 = 7006;

        /// <summary>
        /// M1200手轮模拟(off)
        /// </summary>
        public static int M7007 = 7007;

        /// <summary>
        /// M540跳行加工(on)
        /// </summary>
        public static int M7008 = 7008;

        /// <summary>
        /// M540跳行加工(off)
        /// </summary>
        public static int M7009 = 7009;

        /// <summary>
        /// M04断点继续(on)
        /// </summary>
        public static int M7010 = 7010;

        /// <summary>
        /// M04断点继续(off)
        /// </summary>
        public static int M7011 = 7011;
        #endregion

        #region “JOG手动画面”
        /// <summary>
        /// M71开料X轴回零(on)
        /// </summary>
        public static int M7012 = 7012;

        /// <summary>
        /// M71开料X轴回零(off)
        /// </summary>
        public static int M7013 = 7013;

        /// <summary>
        /// M70开料Y轴回零(on)
        /// </summary>
        public static int M7014 = 7014;

        /// <summary>
        /// M70开料Y轴回零(off)
        /// </summary>
        public static int M7015 = 7015;

        /// <summary>
        /// M72开料Z轴回零(on)
        /// </summary>
        public static int M7016 = 7016;

        /// <summary>
        /// M72开料Z轴回零(off)
        /// </summary>
        public static int M7017 = 7017;

        /// <summary>
        /// M6开料回原点(on)
        /// </summary>
        public static int M7018 = 7018;

        /// <summary>
        /// M6开料回原点(off)
        /// </summary>
        public static int M7019 = 7019;

        /// <summary>
        /// M75贴标回原点(on)
        /// </summary>
        public static int M7020 = 7020;

        /// <summary>
        /// M75贴标回原点(off)
        /// </summary>
        public static int M7021 = 7021;

        /// <summary>
        /// M91主轴1正转(on)
        /// </summary>
        public static int M7022 = 7022;

        /// <summary>
        /// M91主轴1正转(off)
        /// </summary>
        public static int M7023 = 7023;

        /// <summary>
        /// M94主轴1停止(on)
        /// </summary>
        public static int M7024 = 7024;

        /// <summary>
        /// M94主轴1停止(off)
        /// </summary>
        public static int M7025 = 7025;

        /// <summary>
        /// M93主轴2正转(on)
        /// </summary>
        public static int M7026 = 7026;

        /// <summary>
        /// M93主轴2正转(off)
        /// </summary>
        public static int M7027 = 7027;

        /// <summary>
        /// M95主轴2停止(on)
        /// </summary>
        public static int M7028 = 7028;

        /// <summary>
        /// M95主轴2停止(off)
        /// </summary>
        public static int M7029 = 7029;

        /// <summary>
        /// M533 T1换刀(on)
        /// </summary>
        public static int M7030 = 7030;

        /// <summary>
        /// M533 T1换刀(off)
        /// </summary>
        public static int M7031 = 7031;

        /// <summary>
        /// M534 T2换刀(on)
        /// </summary>
        public static int M7032 = 7032;

        /// <summary>
        /// M534 T2换刀(off)
        /// </summary>
        public static int M7033 = 7033;

        /// <summary>
        /// M536 开始对刀(on)
        /// </summary>
        public static int M7034 = 7035;

        /// <summary>
        /// M536 开始对刀(off)
        /// </summary>
        public static int M7035 = 7035;

        /// <summary>
        /// M537 停止对刀(on)
        /// </summary>
        public static int M7036 = 7036;

        /// <summary>
        /// M537 停止对刀(off)
        /// </summary>
        public static int M7037 = 7037;

        /// <summary>
        /// M1400 手轮(on)
        /// </summary>
        public static int M7038 = 7038;

        /// <summary>
        /// M1400 手轮(off)
        /// </summary>
        public static int M7039 = 7039;

        /// <summary>
        /// M6317 后定位(on)
        /// </summary>
        public static int M7040 = 7040;

        /// <summary>
        /// M6317 后定位(off)
        /// </summary>
        public static int M7041 = 7041;

        /// <summary>
        /// M6313 左定位(on)
        /// </summary>
        public static int M7042 = 7042;

        /// <summary>
        /// M6313 左定位(off)
        /// </summary>
        public static int M7043 = 7043;

         /// <summary>
        /// M6308前定位(on)
        /// </summary>
        public static int M6998 = 6998;

        /// <summary>
        /// M6308 前定位(off)
        /// </summary>
        public static int M6999 = 6999;

        /// <summary>
        /// M6314 右前定位(on)
        /// </summary>
        public static int M7044 = 7044;

        /// <summary>
        /// M6314 右前定位(off)
        /// </summary>
        public static int M7045 = 7045;

        /// <summary>
        /// M6315 台面吸附(on)
        /// </summary>
        public static int M7046 = 7046;

        /// <summary>
        /// M6315 台面吸附(off)
        /// </summary>
        public static int M7047 = 7047;

        /// <summary>
        /// M73 贴标X轴回原点(on)
        /// </summary>
        public static int M7048 = 7048;

        /// <summary>
        /// M73 贴标X轴回原点(off)
        /// </summary>
        public static int M7049 = 7049;

        /// <summary>
        /// M74 贴标Y轴回原点(on)
        /// </summary>
        public static int M7050 = 7050;

        /// <summary>
        /// M74 贴标Y轴回原点(off)
        /// </summary>
        public static int M7051 = 7051;

        /// <summary>
        /// M50102 贴标推料(on)
        /// </summary>
        public static int M7052 = 7052;

        /// <summary>
        /// M50102 贴标推料(off)
        /// </summary>
        public static int M7053 = 7053;

        /// <summary>
        /// M50200 贴标动作(on)
        /// </summary>
        public static int M7054 = 7054;

        /// <summary>
        /// M50200 贴标动作(off)
        /// </summary>
        public static int M7055 = 7055;

        /// <summary>
        /// M21 参数保存(on)
        /// </summary>
        public static int M7056 = 7056;

        /// <summary>
        /// M21 参数保存(off)
        /// </summary>
        public static int M7057 = 7057;

        #endregion

        #region “IO状态”

        #region “输入”

        /// <summary>
        /// DX1(on)
        /// </summary>
        public static int M7122 = 7122;

        /// <summary>
        /// DX1(off)
        /// </summary>
        public static int M7123 = 7123;

        /// <summary>
        /// DX2(on)
        /// </summary>
        public static int M7124 = 7124;

        /// <summary>
        /// DX2(off)
        /// </summary>
        public static int M7125 = 7125;

        /// <summary>
        /// DX3(on)
        /// </summary>
        public static int M7126 = 7126;

        /// <summary>
        /// DX3(off)
        /// </summary>
        public static int M7127 = 7127;

        /// <summary>
        /// DX4(on)
        /// </summary>
        public static int M7128 = 7128;

        /// <summary>
        /// DX4(off)
        /// </summary>
        public static int M7129 = 7129;

        /// <summary>
        /// DX5(on)
        /// </summary>
        public static int M7130 = 7130;

        /// <summary>
        /// DX5(off)
        /// </summary>
        public static int M7131 = 7131;

        /// <summary>
        /// DX6(on)
        /// </summary>
        public static int M7132 = 7132;

        /// <summary>
        /// DX6(off)
        /// </summary>
        public static int M7133 = 7133;

        /// <summary>
        /// DX7(on)
        /// </summary>
        public static int M7134 = 7134;

        /// <summary>
        /// DX7(off)
        /// </summary>
        public static int M7135 = 7135;

        /// <summary>
        /// DX8(on)
        /// </summary>
        public static int M7136 = 7136;

        /// <summary>
        /// DX8(off)
        /// </summary>
        public static int M7137 = 7137;

        /// <summary>
        /// DX9(on)
        /// </summary>
        public static int M7138 = 7138;

        /// <summary>
        /// DX9(off)
        /// </summary>
        public static int M7139 = 7139;

        /// <summary>
        /// DX10(on)
        /// </summary>
        public static int M7140 = 7140;

        /// <summary>
        /// DX10(off)
        /// </summary>
        public static int M7141 = 7141;

        /// <summary>
        /// DX11(on)
        /// </summary>
        public static int M7142 = 7142;

        /// <summary>
        /// DX11(off)
        /// </summary>
        public static int M7143 = 7143;

        /// <summary>
        /// DX12(on)
        /// </summary>
        public static int M7144 = 7144;

        /// <summary>
        /// DX12(off)
        /// </summary>
        public static int M7145 = 7145;

        /// <summary>
        /// DX13(on)
        /// </summary>
        public static int M7146 = 7146;

        /// <summary>
        /// DX13(off)
        /// </summary>
        public static int M7147 = 7147;

        /// <summary>
        /// DX14(on)
        /// </summary>
        public static int M7148 = 7148;

        /// <summary>
        /// DX14(off)
        /// </summary>
        public static int M7149 = 7149;

        /// <summary>
        /// DX15(on)
        /// </summary>
        public static int M7150 = 7150;

        /// <summary>
        /// DX15(off)
        /// </summary>
        public static int M7151 = 7151;

        /// <summary>
        /// DX16(on)
        /// </summary>
        public static int M7152 = 7152;

        /// <summary>
        /// DX16(off)
        /// </summary>
        public static int M7153 = 7153;


        /// <summary>
        /// DX17(on)
        /// </summary>
        public static int M7154 = 7154;

        /// <summary>
        /// DX17(off)
        /// </summary>
        public static int M7155 = 7155;

        /// <summary>
        /// DX18(on)
        /// </summary>
        public static int M7156 = 7156;

        /// <summary>
        /// DX18(off)
        /// </summary>
        public static int M7157 = 7157;

        /// <summary>
        /// DX19(on)
        /// </summary>
        public static int M7158 = 7158;

        /// <summary>
        /// DX19(off)
        /// </summary>
        public static int M7159 = 7159;

        /// <summary>
        /// DX20(on)
        /// </summary>
        public static int M7160 = 7160;

        /// <summary>
        /// DX20(off)
        /// </summary>
        public static int M7161 = 7161;

        /// <summary>
        /// DX21(on)
        /// </summary>
        public static int M7162 = 7162;

        /// <summary>
        /// DX21(off)
        /// </summary>
        public static int M7163 = 7163;

        /// <summary>
        /// DX22(on)
        /// </summary>
        public static int M7164 = 7164;

        /// <summary>
        /// DX22(off)
        /// </summary>
        public static int M7165 = 7165;

        /// <summary>
        /// DX23(on)
        /// </summary>
        public static int M7166 = 7166;

        /// <summary>
        /// DX23(off)
        /// </summary>
        public static int M7167 = 7167;

        /// <summary>
        /// DX24(on)
        /// </summary>
        public static int M7168 = 7168;

        /// <summary>
        /// DX24(off)
        /// </summary>
        public static int M7169 = 7169;

        /// <summary>
        /// DX25(on)
        /// </summary>
        public static int M7170 = 7170;

        /// <summary>
        /// DX25(off)
        /// </summary>
        public static int M7171 = 7171;

        /// <summary>
        /// DX26(on)
        /// </summary>
        public static int M7172 = 7172;

        /// <summary>
        /// DX26(off)
        /// </summary>
        public static int M7173 = 7173;

        /// <summary>
        /// DX27(on)
        /// </summary>
        public static int M7174 = 7174;

        /// <summary>
        /// DX27(off)
        /// </summary>
        public static int M7175 = 7175;

        /// <summary>
        /// DX28(on)
        /// </summary>
        public static int M7176 = 7177;

        /// <summary>
        /// DX28(off)
        /// </summary>
        public static int M7178 = 7178;

        /// <summary>
        /// DX29(on)
        /// </summary>
        public static int M7179 = 7179;

        /// <summary>
        /// DX29(off)
        /// </summary>
        public static int M7180 = 7180;

        /// <summary>
        /// DX30(on)
        /// </summary>
        public static int M7181 = 7181;

        /// <summary>
        /// DX30(off)
        /// </summary>
        public static int M7182 = 7182;

        /// <summary>
        /// DX31(on)
        /// </summary>
        public static int M7183 = 7183;

        /// <summary>
        /// DX31(off)
        /// </summary>
        public static int M7184 = 7184;

        /// <summary>
        /// DX32(on)
        /// </summary>
        public static int M7185 = 7185;

        /// <summary>
        /// DX32(off)
        /// </summary>
        public static int M7186 = 7186;

        /// <summary>
        /// JOG中的贴标送料标志位(on)
        /// </summary>
        public static int M6996 = 6996;

        /// <summary>
        /// JOG中的贴标送料标志位(off)
        /// </summary>
        public static int M6997 = 6997;

        #endregion

        #region “输出”
        /// <summary>
        /// DY1(前32on)
        /// </summary>
        public static int M7058 = 7058;

        /// <summary>
        /// DY1(后32on)
        /// </summary>
        public static int M7250 = 7250;

        /// <summary>
        /// DY1(前32off)
        /// </summary>
        public static int M7059 = 7059;

        /// <summary>
        /// DY1(后32off)
        /// </summary>
        public static int M7251 = 7251;

        /// <summary>
        /// DY2(on)
        /// </summary>
        public static int M7060 = 7060;

        /// <summary>
        /// DY2(off)
        /// </summary>
        public static int M7061 = 7061;

        /// <summary>
        /// DY3(on)
        /// </summary>
        public static int M7062 = 7062;

        /// <summary>
        /// DY3(off)
        /// </summary>
        public static int M7063 = 7063;

        /// <summary>
        /// DY4(on)
        /// </summary>
        public static int M7064 = 7064;

        /// <summary>
        /// DY4(off)
        /// </summary>
        public static int M7065 = 7065;

        /// <summary>
        /// DY5(on)
        /// </summary>
        public static int M7066 = 7066;

        /// <summary>
        /// DY5(off)
        /// </summary>
        public static int M7067 = 7067;

        /// <summary>
        /// DY6(on)
        /// </summary>
        public static int M7068 = 7068;

        /// <summary>
        /// DY6(off)
        /// </summary>
        public static int M7069 = 7069;

        /// <summary>
        /// DY7(on)
        /// </summary>
        public static int M7070 = 7070;

        /// <summary>
        /// DY7(off)
        /// </summary>
        public static int M7071 = 7071;

        /// <summary>
        /// DY8(on)
        /// </summary>
        public static int M7072 = 7072;

        /// <summary>
        /// DY8(off)
        /// </summary>
        public static int M7073 = 7073;

        /// <summary>
        /// DY9(on)
        /// </summary>
        public static int M7074 = 7074;

        /// <summary>
        /// DY9(off)
        /// </summary>
        public static int M7075 = 7075;

        /// <summary>
        /// DY10(on)
        /// </summary>
        public static int M7076 = 7076;

        /// <summary>
        /// DY10(off)
        /// </summary>
        public static int M7077 = 7077;

        /// <summary>
        /// DY11(on)
        /// </summary>
        public static int M7078 = 7078;

        /// <summary>
        /// DY11(off)
        /// </summary>
        public static int M7079 = 7079;

        /// <summary>
        /// DY12(on)
        /// </summary>
        public static int M7080 = 7080;

        /// <summary>
        /// DY12(off)
        /// </summary>
        public static int M7081 = 7081;

        /// <summary>
        /// DY13(on)
        /// </summary>
        public static int M7082 = 7082;

        /// <summary>
        /// DY13(off)
        /// </summary>
        public static int M7083 = 7083;

        /// <summary>
        /// DY14(on)
        /// </summary>
        public static int M7084 = 7084;

        /// <summary>
        /// DY14(off)
        /// </summary>
        public static int M7085 = 7085;

        /// <summary>
        /// DY15(on)
        /// </summary>
        public static int M7086 = 7086;

        /// <summary>
        /// DY15(off)
        /// </summary>
        public static int M7087 = 7087;

        /// <summary>
        /// DY16(on)
        /// </summary>
        public static int M7088 = 7088;

        /// <summary>
        /// DY16(off)
        /// </summary>
        public static int M7089 = 7089;


        /// <summary>
        /// DY17(on)
        /// </summary>
        public static int M7090 = 7090;

        /// <summary>
        /// DY17(off)
        /// </summary>
        public static int M7091 = 7091;

        /// <summary>
        /// DY18(on)
        /// </summary>
        public static int M7092 = 7092;

        /// <summary>
        /// DY18(off)
        /// </summary>
        public static int M7093 = 7093;

        /// <summary>
        /// DY19(on)
        /// </summary>
        public static int M7094 = 7094;

        /// <summary>
        /// DY19(off)
        /// </summary>
        public static int M7095 = 7095;

        /// <summary>
        /// DY20(on)
        /// </summary>
        public static int M7096 = 7096;

        /// <summary>
        /// DY20(off)
        /// </summary>
        public static int M7097 = 7097;

        /// <summary>
        /// DY21(on)
        /// </summary>
        public static int M7098 = 7098;

        /// <summary>
        /// DY21(off)
        /// </summary>
        public static int M7099 = 7099;

        /// <summary>
        /// DY22(on)
        /// </summary>
        public static int M7100 = 7100;

        /// <summary>
        /// DY22(off)
        /// </summary>
        public static int M7101 = 7101;

        /// <summary>
        /// DY23(on)
        /// </summary>
        public static int M7102 = 7102;

        /// <summary>
        /// DY23(off)
        /// </summary>
        public static int M7103 = 7103;

        /// <summary>
        /// DY24(on)
        /// </summary>
        public static int M7104 = 7104;

        /// <summary>
        /// DY24(off)
        /// </summary>
        public static int M7105 = 7105;

        /// <summary>
        /// DY25(on)
        /// </summary>
        public static int M7106 = 7106;

        /// <summary>
        /// DY25(off)
        /// </summary>
        public static int M7107 = 7107;

        /// <summary>
        /// DY26(on)
        /// </summary>
        public static int M7108 = 7108;

        /// <summary>
        /// DY26(off)
        /// </summary>
        public static int M7109 = 7109;

        /// <summary>
        /// DY27(on)
        /// </summary>
        public static int M7110 = 7110;

        /// <summary>
        /// DY27(off)
        /// </summary>
        public static int M7111 = 7111;

        /// <summary>
        /// DY28(on)
        /// </summary>
        public static int M7112 = 7112;

        /// <summary>
        /// DY28(off)
        /// </summary>
        public static int M7113 = 7113;

        /// <summary>
        /// DY29(on)
        /// </summary>
        public static int M7114 = 7114;

        /// <summary>
        /// DY29(off)
        /// </summary>
        public static int M7115 = 7115;

        /// <summary>
        /// DY30(on)
        /// </summary>
        public static int M7116 = 7116;

        /// <summary>
        /// DY30(off)
        /// </summary>
        public static int M7117 = 7117;

        /// <summary>
        /// DY31(on)
        /// </summary>
        public static int M7118 = 7118;

        /// <summary>
        /// DY31(off)
        /// </summary>
        public static int M7119 = 7119;

        /// <summary>
        /// DY32(on)
        /// </summary>
        public static int M7120 = 7120;

        /// <summary>
        /// DY32(off)
        /// </summary>
        public static int M7121 = 7121;

        #endregion

        #endregion

        #endregion

        #endregion

        #region 输入R继电器

        /// <summary>
        ///DY1
        /// </summary>
        public static int R6300 = 6300;

        /// <summary>
        ///DY2
        /// </summary>
        public static int R6301 = 6301;

        /// <summary>
        ///DY3
        /// </summary>
        public static int R6302 = 6302;

        /// <summary>
        ///DY4
        /// </summary>
        public static int R6303 = 6303;

        /// <summary>
        ///DY5
        /// </summary>
        public static int R6304 = 6304;

        /// <summary>
        ///DY6
        /// </summary>
        public static int R6305 = 6305;

        /// <summary>
        ///DY7
        /// </summary>
        public static int R6306 = 6306;

        /// <summary>
        ///DY8
        /// </summary>
        public static int R6307 = 6307;

        /// <summary>
        ///DY9
        /// </summary>
        public static int R6308 = 6308;

        /// <summary>
        ///DY10
        /// </summary>
        public static int R6309 = 6309;

        /// <summary>
        ///DY11
        /// </summary>
        public static int R6310 = 6310;

        /// <summary>
        ///DY12
        /// </summary>
        public static int R6311 = 6311;

        /// <summary>
        ///DY13
        /// </summary>
        public static int R6312 = 6312;

        /// <summary>
        ///DY14
        /// </summary>
        public static int R6313 = 6313;

        /// <summary>
        ///DY15
        /// </summary>
        public static int R6314 = 6314;

        /// <summary>
        ///DY16
        /// </summary>
        public static int R6315 = 6315;

        /// <summary>
        ///DY17
        /// </summary>
        public static int R6316 = 6316;

        /// <summary>
        ///DY18
        /// </summary>
        public static int R6317 = 6317;

        /// <summary>
        ///DY19
        /// </summary>
        public static int R6318 = 6318;

        /// <summary>
        ///DY20
        /// </summary>
        public static int R6319 = 6319;

        /// <summary>
        ///DY21
        /// </summary>
        public static int R6320 = 6320;

        /// <summary>
        ///DY22
        /// </summary>
        public static int R6321 = 6321;

        /// <summary>
        ///DY23
        /// </summary>
        public static int R6322 = 6322;

        /// <summary>
        ///DY24
        /// </summary>
        public static int R6323 = 6323;

        /// <summary>
        ///DY25
        /// </summary>
        public static int R6324 = 6324;

        /// <summary>
        ///DY26
        /// </summary>
        public static int R6325 = 6325;

        /// <summary>
        ///DY27
        /// </summary>
        public static int R6326 = 6326;

        /// <summary>
        ///DY28
        /// </summary>
        public static int R6327 = 6327;

        /// <summary>
        ///DY29
        /// </summary>
        public static int R6328 = 6328;

        /// <summary>
        ///DY30
        /// </summary>
        public static int R6329 = 6329;

        /// <summary>
        ///DY31
        /// </summary>
        public static int R6330 = 6330;

        /// <summary>
        ///DY32
        /// </summary>
        public static int R6331 = 6331;

        #endregion

        #region 输出R继电器
           /// <summary>
        ///DX1
        /// </summary>
        public static int R6200 = 6200;

        /// <summary>
        ///DX2
        /// </summary>
        public static int R6201 = 6201;

        /// <summary>
        ///DX3
        /// </summary>
        public static int R6202 = 6202;

        /// <summary>
        ///DX4
        /// </summary>
        public static int R6203 = 6203;

        /// <summary>
        ///DX5
        /// </summary>
        public static int R6204 = 6204;

        /// <summary>
        ///DX6
        /// </summary>
        public static int R6205 = 6205;

        /// <summary>
        ///DX7
        /// </summary>
        public static int R6206 = 6206;

        /// <summary>
        ///DX8
        /// </summary>
        public static int R6207 = 6207;

        /// <summary>
        ///DX9
        /// </summary>
        public static int R6208 = 6208;

        /// <summary>
        ///DX10
        /// </summary>
        public static int R6209 = 6209;

        /// <summary>
        ///DX11
        /// </summary>
        public static int R6210 = 6210;

        /// <summary>
        ///DX12
        /// </summary>
        public static int R6211 = 6211;

        /// <summary>
        ///DX13
        /// </summary>
        public static int R6212 = 6212;

        /// <summary>
        ///DX14
        /// </summary>
        public static int R6213 = 6213;

        /// <summary>
        ///DX15
        /// </summary>
        public static int R6214 = 6214;

        /// <summary>
        ///DX16
        /// </summary>
        public static int R6215 = 6215;

        /// <summary>
        ///DX17
        /// </summary>
        public static int R6216 = 6216;

        /// <summary>
        ///DX18
        /// </summary>
        public static int R6217 = 6217;

        /// <summary>
        ///DX19
        /// </summary>
        public static int R6218 = 6218;

        /// <summary>
        ///DX20
        /// </summary>
        public static int R6219 = 6219;

        /// <summary>
        ///DX21
        /// </summary>
        public static int R6220 = 6220;

        /// <summary>
        ///DX22
        /// </summary>
        public static int R6221 = 6221;

        /// <summary>
        ///DX23
        /// </summary>
        public static int R6222 = 6222;

        /// <summary>
        ///DX24
        /// </summary>
        public static int R6223 = 6223;

        /// <summary>
        ///DX25
        /// </summary>
        public static int R6224 = 6224;

        /// <summary>
        ///DX26
        /// </summary>
        public static int R6225 = 6225;

        /// <summary>
        ///DX27
        /// </summary>
        public static int R6226 = 6226;

        /// <summary>
        ///DX28
        /// </summary>
        public static int R6227 = 6227;

        /// <summary>
        ///DX29
        /// </summary>
        public static int R6228 = 6228;

        /// <summary>
        ///DX30
        /// </summary>
        public static int R6229 = 6229;

        /// <summary>
        ///DX31
        /// </summary>
        public static int R6230 = 6230;

        /// <summary>
        ///DX32
        /// </summary>
        public static int R6231 = 6231;     
        #endregion

        #region D地址区

        /// <summary>
        ///IMP开启状态位 
        /// </summary>
        public static int D50 =50;

        /// <summary>
        ///状态标志寄存器
        /// </summary>
        public static int D0 = 0;

        /// <summary>
        ///界面主轴1转速
        /// </summary>
        public static int D502 = 502;

        /// <summary>
        ///界面主轴2转速
        /// </summary>
        public static int D504 = 504;

         /// <summary>
         /// 当前主轴转速
         /// </summary>
        public static int D524 = 524;

        /// <summary>
        ///贴标G300 贴标定位X坐标(DW)
        /// </summary>
        public static int D582 = 582;

        /// <summary>
        ///贴标G300 贴标定位y坐标(DW)
        /// </summary>
        public static int D584 = 584;

        /// <summary>
        ///开料目前加工进度（百分比）
        /// </summary>
        public static int D640 = 640;

        /// <summary>
        ///贴标G300 贴标定位y坐标(DW)
        /// </summary>
        //public static int D584 = 584;

        /// <summary>
        ///开料X轴归零模式(DW)
        /// </summary>
        public static int D1206 = 1206;

        /// <summary>
        ///开料Y轴归零模式(DW)
        /// </summary>
        public static int D1208 = 1208;

        /// <summary>
        ///开料Z轴归零模式(DW)
        /// </summary>
        public static int D1210 = 1210;

        /// <summary>
        ///贴标x轴回零模式(DW)
        /// </summary>
        public static int D1212 = 1212;

        /// <summary>
        ///贴标y轴归零模式(DW)
        /// </summary>
        public static int D1214 = 1214;

        /// <summary>
        ///开料x轴归零偏移(DW)
        /// </summary>
        public static int D1218 = 1218;

        /// <summary>
        ///开料y轴归零偏移(DW)
        /// </summary>
        public static int D1220 = 1220;

        /// <summary>
        ///开料z轴归零偏移(DW)
        /// </summary>
        public static int D1222 = 1222;

        /// <summary>
        ///贴标x轴归零偏移(DW)
        /// </summary>
        public static int D1224 = 1224;

        /// <summary>
        ///贴标y轴归零偏移(DW)
        /// </summary>
        public static int D1226 = 1226;

        /// <summary>
        ///开料x轴归零低速(DW)
        /// </summary>
        public static int D1230 = 1230;

        /// <summary>
        ///开料y轴归零低速(DW)
        /// </summary>
        public static int D1232 = 1232;

        /// <summary>
        ///开料z轴归零低速(DW)
        /// </summary>
        public static int D1234 = 1234;

        /// <summary>
        ///贴标x轴归零低速(DW)
        /// </summary>
        public static int D1236 = 1236;

        /// <summary>
        ///贴标y轴归零低速(DW)
        /// </summary>
        public static int D1238 = 1238;

        /// <summary>
        ///开料x轴归零高速(DW)
        /// </summary>
        public static int D1242 = 1242;

        /// <summary>
        ///开料y轴归零高速(DW)
        /// </summary>
        public static int D1244 = 1244;

        /// <summary>
        ///开料z轴归零高速(DW)
        /// </summary>
        public static int D1246 = 1246;

        /// <summary>
        ///贴标x轴归零高速(DW)
        /// </summary>
        public static int D1248 = 1248;

        /// <summary>
        ///贴标y轴归零高速(DW)
        /// </summary>
        public static int D1250 = 1250;

        /// <summary>
        ///开料x轴加速时间(DW)
        /// </summary>
        public static int D1254 = 1254;

        /// <summary>
        ///开料y轴加速时间(DW)
        /// </summary>
        public static int D1256 = 1256;

        /// <summary>
        ///开料z轴加速时间(DW)
        /// </summary>
        public static int D1258 = 1258;

        /// <summary>
        ///贴标x轴加速时间(DW)
        /// </summary>
        public static int D1260 = 1260;

        /// <summary>
        ///贴标y轴加速时间(DW)
        /// </summary>
        public static int D1262 = 1262;

        /// <summary>
        ///开料x轴减速时间(DW)
        /// </summary>
        public static int D1266 = 1266;

        /// <summary>
        ///开料y轴减速时间(DW)
        /// </summary>
        public static int D1268 = 1268;

        /// <summary>
        ///开料z轴减速时间(DW)
        /// </summary>
        public static int D1270 = 1270;

        /// <summary>
        ///贴标x轴减速时间(DW)
        /// </summary>
        public static int D1272 = 1272;

        /// <summary>
        ///贴标y轴减速时间(DW)
        /// </summary>
        public static int D1274 = 1274;

        /// <summary>
        ///开料x轴正软极限(DW)
        /// </summary>
        public static int D1278 = 1278;

        /// <summary>
        ///开料y轴正软极限(DW)
        /// </summary>
        public static int D1280 = 1280;

        /// <summary>
        ///开料z轴正软极限(DW)
        /// </summary>
        public static int D1282 = 1282;

        /// <summary>
        ///贴标x轴正软极限(DW)
        /// </summary>
        public static int D1284 = 1284;

        /// <summary>
        ///贴标y轴正软极限(DW)
        /// </summary>
        public static int D1286 = 1286;

        /// <summary>
        ///开料x轴负软极限(DW)
        /// </summary>
        public static int D1290 = 1290;

        /// <summary>
        ///开料y轴负软极限(DW)
        /// </summary>
        public static int D1292 = 1292;

        /// <summary>
        ///开料z轴负软极限(DW)
        /// </summary>
        public static int D1294 = 1294;

        /// <summary>
        ///贴标x轴负软极限(DW)
        /// </summary>
        public static int D1296 = 1296;

        /// <summary>
        ///贴标y轴负软极限(DW)
        /// </summary>
        public static int D1298 = 1298;

        /// <summary>
        ///手轮逆回速度(DW)
        /// </summary>
        public static int D1300 = 1300;

        /// <summary>
        ///开料龙门轴下料位置(DW)
        /// </summary>
        public static int D1302 = 1302;

        /// <summary>
        ///开料龙门轴上料位置(DW)
        /// </summary>
        public static int D1304 = 1304;

        /// <summary>
        ///开料下料汽缸位置(DW)
        /// </summary>
        public static int D1306 = 1306;

        /// <summary>
        ///贴标M102推料1号点x坐标(DW)
        /// </summary>
        public static int D1308 = 1308;

        /// <summary>
        ///贴标M102推料1号点y坐标(DW)
        /// </summary>
        public static int D1310 = 1310;

        /// <summary>
        ///贴标M102推料2号点x坐标(DW)
        /// </summary>
        public static int D1312 = 1312;

        /// <summary>
        ///贴标M102推料2号点y坐标(DW)
        /// </summary>
        public static int D1314 = 1314;

        /// <summary>
        ///贴标M102推料5号点x坐标(DW)
        /// </summary>
        public static int D1316 = 1316;

        /// <summary>
        ///贴标M102推料5号点y坐标(DW)
        /// </summary>
        public static int D1318 = 1318;

        /// <summary>
        ///贴标M102推料6号点x坐标DW)
        /// </summary>
        public static int D1320 = 1320;

        /// <summary>
        ///贴标M102推料6号点y坐标DW)
        /// </summary>
        public static int D1322 = 1322;

        /// <summary>
        ///贴标M102推料1点速度(DW)
        /// </summary>
        public static int D1324 = 1324;

        /// <summary>
        ///贴标M102推料2点速度(DW)
        /// </summary>
        public static int D1326 = 1326;

        /// <summary>
        ///贴标M102推料5点速度(DW)
        /// </summary>
        public static int D1328 = 1328;

        /// <summary>
        ///贴标M102推料6点速度(DW)
        /// </summary>
        public static int D1330 = 1330;

        /// <summary>
        ///G300贴标定位速度(DW)
        /// </summary>
        public static int D1332 = 1332;

        /// <summary>
        ///贴标m101，安全位置7x坐标(DW)
        /// </summary>
        public static int D1334 = 1334;

        /// <summary>
        ///贴标m101，安全位置7y坐标(DW)
        /// </summary>
        public static int D1336 = 1336;

        /// <summary>
        ///贴标M101启动 开料前，送板材至8位置Y坐标(DW)
        /// </summary>
        public static int D1338 = 1338;

        /// <summary>
        ///X轴手动速度(DW)
        /// </summary>
        public static int D1410 = 1410;

        /// <summary>
        ///Y轴手动速度(DW)
        /// </summary>
        public static int D1412 = 1412;

        /// <summary>
        ///Z轴手动速度(DW)
        /// </summary>
        public static int D1414 = 1414;

        /// <summary>
        ///贴标x轴寸动速度(DW)
        /// </summary>
        public static int D1500 = 1500;

        /// <summary>
        ///贴标y轴寸动速度(DW)
        /// </summary>
        public static int D1502 = 1502;

        /// <summary>
        ///开料龙门退料位置(DW)
        /// </summary>
        public static int D1508 = 1508;

        /// <summary>
        ///推料3位置X坐标(DW)
        /// </summary>
        public static int D1512 = 1512;

        /// <summary>
        ///推料3位置Y坐标(DW)
        /// </summary>
        public static int D1514 = 1514;

        /// <summary>
        ///推料3位置进给速度(DW)
        /// </summary>
        public static int D1516 = 1516;

        /// <summary>
        ///推料4位置X坐标(DW)
        /// </summary>
        public static int D1518 = 1518;

        /// <summary>
        ///推料4位置Y坐标(DW)
        /// </summary>
        public static int D1520 = 1520;

        /// <summary>
        ///推料4位置进给速度(DW)
        /// </summary>
        public static int D1522 = 1522;

        /// <summary>
        ///每次加载加工文件时获取的文件总行数(DW)
        /// </summary>
        public static int D1524 = 1524;

        /// <summary>
        ///推料7位置进给速度(DW)
        /// </summary>
        public static int D1526 = 1526;

        /// <summary>
        ///推料8位置进给速度(DW)
        /// </summary>
        public static int D1528 = 1528;

        /// <summary>
        ///贴标零点偏移X(DW)
        /// </summary>
        public static int D1530 = 1530;

        /// <summary>
        ///贴标零点偏移Y(DW)
        /// </summary>
        public static int D1532 = 1532;

        /// <summary>
        ///贴标GCode总行数（DW）
        /// </summary>
        public static int D3008 = 3008;

        /// <summary>
        ///贴标GCode执行行数（DW）
        /// </summary>
        public static int D3000 = 3000;

        /// <summary>
        ///开料GCode执行行数（DW）
        /// </summary>
        public static int D3002 = 3002;

        /// <summary>
        ///加工模式（0同时加工，1贴标，2开料）
        /// </summary>
        public static int D3004 = 3004;

        /// <summary>
        ///贴标文件路径
        /// </summary>
        public static int D3050 = 3050;

        /// <summary>
        ///打印机纸张长度（DW）
        /// </summary>
        public static int D3010 = 3010;

        /// <summary>
        ///打印机纸张宽度（DW）
        /// </summary>
        public static int D3012 = 3012;

        /// <summary>
        ///打印图片距左边距离（DW）
        /// </summary>
        public static int D3014 = 3014;

        /// <summary>
        ///打印图片距顶边距离（DW）
        /// </summary>
        public static int D3016 = 3016;

        /// <summary>
        ///缩放百分比（DW）
        /// </summary>
        public static int D3018 = 3018;

        /// <summary>
        ///开料文件路径
        /// </summary>
        public static int D3310= 3310;

        /// <summary>
        /// 程序注册标志位，0：未注册，1：注册有时间限制，2：永久
        /// </summary>
        public static int D4000 = 0;

        /// <summary>
        /// 当前时间
        /// </summary>
        public static DateTime D4010 ;

        /// <summary>
        /// 截止时间
        /// </summary>
        public static DateTime D4030  ;

        /// <summary>
        /// 保存授权信息文件的路径
        /// </summary>
        public static string Path = @"C:\Program Files\Delta Industrial Automation\PCI-DMC\ddtt.txt";

        /// <summary>
        /// 保存授权信息文件夹
        /// </summary>
        public static string PathDir = @"C:\Program Files\Delta Industrial Automation\PCI-DMC";

        #endregion

        #region “W地址区”

        /// <summary>
        ///X轴命令位置(DW)
        /// </summary>
        public static int W32538 = 32538;

        /// <summary>
        ///Y轴命令位置(DW)
        /// </summary>
        public static int W32540 = 32540;

        /// <summary>
        ///Z轴命令位置(DW)
        /// </summary>
        public static int W32542 = 32542;

        /// <summary>
        ///读取刀具信息控制字
        /// </summary>
        public static int W31029 = 31029;

        /// <summary>
        ///目标刀号
        /// </summary>
        public static int W31030 = 31030;

        /// <summary>
        ///读取刀具X坐标偏移量(DW)
        /// </summary>
        public static int W31035 = 31035;

        #endregion

        #endregion
    }
}
