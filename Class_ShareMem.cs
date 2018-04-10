using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace Alam_Function
{
    public class Class_ShareMem
    {
        public static bool ShareMemIsOpened;

        [DllImport("ShareMemDll.dll", EntryPoint = "ShareMem_Create")]     //ok return 0, fail return -1 
        public static extern int ShareMem_Create();
        [DllImport("ShareMemDll.dll", EntryPoint = "ShareMem_Destroy")]
        public static extern void ShareMem_Destroy();
        [DllImport("ShareMemDll.dll", EntryPoint = "ShareMem_Open")]       //ok return 0, fail return -1
        public static extern int ShareMem_Open();
        [DllImport("ShareMemDll.dll", EntryPoint = "ShareMem_Close")]
        public static extern void ShareMem_Close();

        [DllImport("ShareMemDll.dll", EntryPoint = "Set_DX")]
        public static extern int Set_DX(int node, int port, int bit, bool on);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_DX")]
        public static extern int Get_DX(int node, int port, int bit);
        [DllImport("ShareMemDll.dll", EntryPoint = "Set_DY")]
        public static extern int Set_DY(int node, int port, int bit, bool on);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_DY")]
        public static extern int Get_DY(int node, int port, int bit);
        [DllImport("ShareMemDll.dll", EntryPoint = "Set_M")]
        public static extern int Set_M(int pos, bool on);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_M")]
        public static extern int Get_M(int pos);
        [DllImport("ShareMemDll.dll", EntryPoint = "Set_R")]
        public static extern int Set_R(int pos, bool on);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_R")]
        public static extern int Get_R(int pos);
        [DllImport("ShareMemDll.dll", EntryPoint = "Set_D")]
        public static extern int Set_D(int pos, int val, bool IsDoubleWord);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_D")]
        public static extern int Get_D(int pos, bool IsDoubleWord);
        [DllImport("ShareMemDll.dll", EntryPoint = "Set_D_String")]
        public static extern int Set_D_String(int pos, string Input, int size);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_D_String")]
        public static extern int Get_D_String(int pos, StringBuilder Output, int size);

        [DllImport("ShareMemDll.dll", EntryPoint = "Set_W")]
        public static extern int Set_W(int pos, int val, bool IsDoubleWord);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_W")]
        public static extern int Get_W(int pos, bool IsDoubleWord);
        [DllImport("ShareMemDll.dll", EntryPoint = "Set_W_String")]
        public static extern int Set_W_String(int pos, string Input, int size);
        [DllImport("ShareMemDll.dll", EntryPoint = "Get_W_String")]
        public static extern int Get_W_String(int pos, StringBuilder Output, int size);
    }

    public class Class_ShareMemCustom
    {
        #region 二次封装共享内存的方法，代码少，方便调用。
        /// <summary>
        /// 往文数值输入框设置字符串
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        public static void SetDString(int pos, string value, int size)
        {
            Class_ShareMem.Set_D_String(pos, value, size);
        }

        /// <summary>
        /// 往W地址里面写入字符串
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        public static void SetWString(int pos, string value, int size)
        {
            Class_ShareMem.Set_W_String(pos, value, size);
        }

        /// <summary>
        /// 获取双字W
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int GetDoubleW(int pos)
        {
            return Class_ShareMem.Get_W(pos, true);

        }

        /// <summary>
        /// 获取指定地址的文数值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetDString(int pos, int size)
        {
            StringBuilder str = new StringBuilder("", size);
            Class_ShareMem.Get_D_String(pos, str, size);
            return str.ToString();
        }

        /// <summary>
        /// 读取指定M地址
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool GetM(int pos)
        {
            int value = Class_ShareMem.Get_M(pos);
            return value == 1 ? true : false;
        }
        /// <summary>
        /// 往指定M设真
        /// </summary>
        /// <param name="pos"></param>
        public static void BitOnM(int pos)
        {
            Class_ShareMem.Set_M(pos, true);
        }
        /// <summary>
        /// 往指定M设假
        /// </summary>
        /// <param name="pos"></param>
        public static void BitOffM(int pos)
        {
            Class_ShareMem.Set_M(pos, false);
        }
        /// <summary>
        /// 获取单个字的D
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int GetSingleD(int pos)
        {
            return Class_ShareMem.Get_D(pos, false);
        }

        /// <summary>
        /// 往指定单个字的W写值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        public static int GetSingleW(int pos)
        {
           return Class_ShareMem.Get_W(pos,false);
        }

        /// <summary>
        /// 获取双字的D
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int GetDoubleD(int pos)
        {
            return Class_ShareMem.Get_D(pos, true);
        }
        /// <summary>
        /// 往指定单个字的D写值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        public static void SetSingleD(int pos, int value)
        {
            Class_ShareMem.Set_D(pos, value, false);
        }

        /// <summary>
        /// 往指定单个字的W写值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        public static void SetSingleW(int pos, int value)
        {
            Class_ShareMem.Set_W(pos, value, false);
        }

        /// <summary>
        /// 往指定双字的W写值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        public static void SetDoubleW(int pos, int value)
        {
            Class_ShareMem.Set_W(pos, value, true);
        }

        /// <summary>
        /// 往指定双字的D写值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        public static void SetDoubleD(int pos, int value)
        {
            Class_ShareMem.Set_D(pos, value, true);
        }

        /// <summary>
        ///GET_DX
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        public static bool GetDX(int port, int bit)
        {
            int value = Class_ShareMem.Get_DX(11, port, bit);
            return value == 1 ? true : false;
        }
        #endregion

    }
   
}
