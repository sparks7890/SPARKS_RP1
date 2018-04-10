using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DeltaWoodSystem.SanTuo.Utility;

namespace DeltaWoodSystem.SanTuo.UI.Tools
{

    /// <summary>
    /// 用于控件中一些常见事件来改变控件外观的方法集合
    /// </summary>
    public class WinformUIEventHelper
    {
        //Button控件click事件，切换背景图片，需要两个标志位
        public static void Click_ChangeBackgroundImage_Two_Address(Control control,int addressOn,int addressOff,Image oriImage,Image changeImage)
        {
            bool on = Class_ShareMem.Get_M(addressOn)==1;
            bool off = Class_ShareMem.Get_M(addressOff) == 1;

            if (on)
            {
                control.BackgroundImage = changeImage;
                Class_ShareMem.Set_M(addressOn,false);
            }
            if (off)
            {
                control.BackgroundImage = oriImage;
                Class_ShareMem.Set_M(addressOn, false);
            }
        }

        //Button控件click事件，切换前景颜色，需要两个标志位
        public static void Click_ChangeForeColor_Two_Address(Control control, int addressOn, int addressOff, Color oriColor, Color changeColor)
        {
            bool on = Class_ShareMem.Get_M(addressOn) == 1;
            bool off = Class_ShareMem.Get_M(addressOff) == 1;
            if (on)
            {
                control.BackColor = changeColor;
                Class_ShareMem.Set_M(addressOn, false);
            }
            if (off)
            {
                control.BackColor = oriColor;
                Class_ShareMem.Set_M(addressOn, false);
            }
        }

        //Button控件click事件，切换背景图片
        public static void Click_ChangeBackgroundImage(object sender,Image oriImage,Image changeImage,bool isChange)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (isChange)
                {
                    button.BackgroundImage = changeImage;
                }
                else
                {
                    button.BackgroundImage = oriImage;
                }
            }
        }

        //Button控件click事件，切换背景颜色
        public static void Click_ChangeForeColor(object sender, Color oriColor, Color changeColor, bool isChange)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (isChange)
                {
                    button.ForeColor = changeColor;
                }
                else
                {
                    button.ForeColor = oriColor;
                }
            }
        }

        //控件MouseDown事件，切换背景图片
        public static void MouseDown_ChangeBackgroundImage(object sender, Image changeImage)
        {
            Control control = sender as Control;
            try
            {
                control.BackgroundImage = changeImage;
            }
            catch (Exception ex)
            {
                
                throw ex.InnerException;
            }
        }

        //控件MouseDown事件，切换背景色
        public static void MouseDown_ChangeBackColor(object sender, Color changeBackColor)
        {
            Control control = sender as Control;
            try
            {
                control.BackColor = changeBackColor;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        //控件MouseDown事件，切换前景色
        public static void MouseDown_ChangeForeColor(object sender, Color changeForeColor)
        {
            Control control = sender as Control;
            try
            {
                control.ForeColor = changeForeColor;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        //控件MouseUp事件，切换背景图片
        public static void MouseUp_ChangeBackgroundImage(object sender, Image changeImage)
        {
            MouseDown_ChangeBackgroundImage(sender, changeImage);
        }

        //控件MouseUp事件，切换背景色
        public static void MouseUp_ChangeBackColor(object sender, Color changeBackColor)
        {
            Control control = sender as Control;
            try
            {
                control.BackColor = changeBackColor;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        //CheckedBox和RadioButton控件的CheckedChanged事件，切换背景图片
        public static void CheckedChanged_ChangeBackgroundImage(object sender, Image backgroundImage,Image changeImage)
        {
            RadioButton control = sender as RadioButton;
            if (control != null)
            {
                try
                {
                    if (control.Checked)
                    {
                        control.BackgroundImage = changeImage;
                    }
                    else
                    {
                        control.BackgroundImage = backgroundImage;
                    }
                }
                catch (Exception e)
                {

                    throw e.InnerException;
                }
            }
            else
            {
                CheckBox controlNew = sender as CheckBox;
                if (controlNew != null)
                {
                    try
                    {
                        if (controlNew.Checked)
                        {
                            controlNew.BackgroundImage = changeImage;
                        }
                        else
                        {
                            controlNew.BackgroundImage = backgroundImage;
                        }
                    }
                    catch (Exception e)
                    {

                        throw e.InnerException;
                    }
                }
            }

        }

        //CheckedBox和RadioButton控件的CheckedChanged事件，改变前景色
        public static void CheckedChanged_ChangeForeColor(object sender, Color originForeColor, Color changeForeColor)
        {
            RadioButton control = sender as RadioButton;
            if (control != null)
            {
                if (control.Checked)
                {
                    control.ForeColor = changeForeColor;
                }
                else
                {
                    control.ForeColor = originForeColor;
                }
            }
            else
            {
                CheckBox controlNew = sender as CheckBox;
                if (controlNew != null)
                {
                    if (controlNew.Checked)
                    {
                        controlNew.ForeColor = changeForeColor;
                    }
                    else
                    {
                        controlNew.ForeColor = originForeColor;
                    }
                }
            }
        }

        //CheckedBox和RadioButton控件的CheckedChanged事件，改变背景色
        public static void CheckedChanged_ChangeBackColor(object sender, Color originBackColor, Color changeBackColor)
        {
            RadioButton control = sender as RadioButton;
            if (control != null)
            {
                if (control.Checked)
                {
                    control.ForeColor = changeBackColor;
                }
                else
                {
                    control.ForeColor = originBackColor;
                }
            }
            else
            {
                CheckBox controlNew = sender as CheckBox;
                if (controlNew != null)
                {
                    if (controlNew.Checked)
                    {
                        controlNew.ForeColor = changeBackColor;
                    }
                    else
                    {
                        controlNew.ForeColor = originBackColor;
                    }
                }
            }
        }

        //CheckedBox控件的MouseEntered事件，改变背景色
        public static void MouseEnter_ChangeBackColor(object sender, Color enterColor)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.BackColor = enterColor;
            }
        }

        //CheckedBox控件的MouseEntered事件，改变背景色
        public static void MouseLeave_ChangeBackColor(object sender, Color leaveColor)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.BackColor = leaveColor;
            }
        }

        //在RadioButton的CheckedChanged事件中改变RichTextBox的ReadOnly
        public static void CheckedChanged_ChangeReadOnly(object sender, RichTextBox richBox)
        {
            RadioButton radButton = sender as RadioButton;
            if (radButton != null && richBox != null)
            {
                if (radButton.Checked)
                {
                    richBox.ReadOnly = false;
                }
                else
                {
                    richBox.ReadOnly = true;
                }
            }
        }
    }

    
}
