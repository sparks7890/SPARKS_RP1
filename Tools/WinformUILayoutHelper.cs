using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DeltaWoodSystem.SanTuo.UI.Tools
{
    /// <summary>
    /// 自定义的用于绘制表格的数据结构
    /// </summary>
    public struct structTableInfo
    {      
        int rows;
        public int Rows
        {
            get { return this.rows; }
            set { this.rows = value; }
        }
        int columns;
        public int Columns
        {
            get { return this.columns; }
            set { this.columns = value; }
        }
        float[] eachColoumnLength;
        public float[] EachColoumnLength
        {
            get { return this.eachColoumnLength; }
            set { this.eachColoumnLength = value; }
        }
        float[] eachRowHeight;
        public float[] EachRowHeight
        {
            get { return this.eachRowHeight; }
            set { this.eachRowHeight = value; }
        }
        int startLocationX;
        public int StartLocationX
        {
            get { return this.startLocationX; }
            set { this.startLocationX = value; }
        }
        int startLocationY;
        public int StartLocationY
        {
            get { return this.startLocationY; }
            set { this.startLocationY = value; }
        }
        int width;
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        int height;
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        int borderWidth;
        public int BorderWidth
        {
            get { return this.borderWidth; }
            set { this.borderWidth = value; }
        }
        Color borderColor;
        public Color BorderColor
        {
            get { return this.borderColor; }
            set { this.borderColor = value; }
        }
    }

    /// <summary>
    /// 用于控件布局的帮助类
    /// </summary>
    public class WinformUILayoutHelper
    {
        /// <summary>
        /// 设置单个控件的定位
        /// </summary>
        /// <param name="control">控件对象</param>
        /// <param name="xLocation">控件的起始位置</param>
        /// <param name="yLocation">控件的起始位置</param>
        public static void SetControlPosition(Control control, int xLocation, int yLocation)
        {
            if (control != null)
            {
                control.Location = new System.Drawing.Point(xLocation, yLocation);
            }
        }

        /// <summary>
        /// 设置单个控件的定位
        /// </summary>
        /// <param name="control">控件对象</param>
        /// <param name="xLocation">控件的起始位置</param>
        /// <param name="yLocation">控件的起始位置</param>
        /// <param name="width">控件宽度</param>
        /// <param name="height">控件高度</param>
        public static void SetControlPosition(Control control,int xLocation,int yLocation,int width,int height)
        {
            if (control!=null)
            {
                control.Width = width;
                control.Height = height;
                control.Location = new System.Drawing.Point(xLocation,yLocation);                
            }
        }

        /// <summary>
        /// 设置一组control的布局（横向或者竖向排列）
        /// </summary>
        /// <param name="controls">控件数组</param>
        /// <param name="width">每个控件的宽度</param>
        /// <param name="height">每个控件的高度</param>
        /// <param name="startLocationX">第一个控件X方向的定位值</param>
        /// <param name="startLocationY">第一个控件Y方向的定位值</param>
        /// <param name="isHorization">是否水平排列</param>
        public static void SetControlsPosition(Control[] controls, int width, int height, int startLocationX, int startLocationY, bool isHorization)
        {
            if (controls != null)
            {
                int count = controls.Count();
                if (count > 0)
                {
                    int xLocation = startLocationX;
                    int yLocation = startLocationY;
                    for (int i = 0; i < count; i++)
                    {
                        if (controls[i] != null)
                        {
                            if (controls[i] is TextBox)
                            {
                                SetControlPosition(controls[i], xLocation, yLocation + (height - controls[i].Height)/2, width, height);           
                            }
                            else
                            {
                                SetControlPosition(controls[i], xLocation, yLocation, width, height);
                            }
                        }

                        //横向排列
                        if (isHorization)
                        {
                            xLocation = xLocation + width;
                        }
                        else
                        {
                            yLocation = yLocation + height;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 设置一组control的布局，需要设置控件的长度、宽度以及每个控件间的间距
        /// </summary>
        /// <param name="controls">控件数组</param>
        /// <param name="buttonWidth">控件宽度</param>
        /// <param name="buttonHeight">控件高度</param>
        /// <param name="startLocationX">第一个控件的定位位置</param>
        /// <param name="startLocationY">第一个控件的定位位置</param>
        /// <param name="spacing">控件间的间隔</param>
        /// <param name="isHorization">水平还是垂直排列</param>
        public static void SetControlsPosition(Control[] controls, int buttonWidth, int buttonHeight,int startLocationX, int startLocationY,int spacing, bool isHorization)
        {
            if (controls != null)
            {
                int count = controls.Count();
                if (count > 0)
                {
                    int xLocation = startLocationX;
                    int yLocation = startLocationY;
                    for (int i = 0; i < count; i++)
                    {
                        if (controls[i] != null)
                        {
                            if (isHorization)
                            {
                                SetControlPosition(controls[i], xLocation, yLocation, buttonWidth, buttonHeight);
                            }
                            else
                            {
                                SetControlPosition(controls[i], xLocation, yLocation, buttonWidth, buttonHeight);
                            }

                        }

                        //横向排列
                        if (isHorization)
                        {
                            xLocation = xLocation + spacing;
                        }
                        else
                        {
                            yLocation = yLocation + spacing;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 设置一组control的布局，需要设置控件的长度、宽度以及每个控件间的间距
        /// </summary>
        /// <param name="controls">控件数组</param>
        /// <param name="spacing">控件间与控件间的间隙</param>
        /// <param name="buttonWidth">控件宽度</param>
        /// <param name="buttonHeight">控件高度</param>
        /// <param name="startLocationX">第一个控件的定位位置</param>
        /// <param name="startLocationY">第一个控件的定位位置</param>
        /// <param name="isHorization">水平还是垂直排列</param>
        public static void SetControlsPosition(Control[] controls, int padding, bool isHorization, int width, int height, int startLocationX, int startLocationY)
        {
            if (controls != null)
            {
                int count = controls.Count();
                if (count > 0)
                {
                    int xLocation = startLocationX;
                    int yLocation = startLocationY;
                    int buttonWidth = width;
                    int buttonHeight = height;
                    if (isHorization)
                    {
                        buttonWidth = width - padding;
                    }
                    else
                    {
                        buttonHeight = height - padding;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        if (controls[i] != null)
                        {
                            if (controls[i] is TextBox)
                            {
                                SetControlPosition(controls[i], xLocation, yLocation + (buttonHeight - controls[i].Height) / 2, buttonWidth, buttonHeight);
                            }
                            else
                            {
                                SetControlPosition(controls[i], xLocation, yLocation, buttonWidth, buttonHeight);
                            }
                        }

                        //横向排列
                        if (isHorization)
                        {
                            xLocation = xLocation + width;
                        }
                        else
                        {
                            yLocation = yLocation + height;
                        }

                    }
                }
            }
        }


        private static void SetTableControlsPosition(Control[] controls, int width, int height, int startLocationX, int startLocationY, int rows, int columns, int borderWidth, bool isHorization)
        {

            if (isHorization)
            {

            }
            else
            {
                int xLocation = startLocationX + borderWidth;
                int yLocation = startLocationY + borderWidth;

                int rowHeight = (height - borderWidth) / rows;
                int rowHeightNew = rowHeight;
                int offsetHeight = (height - borderWidth) % rows;

                for (int j = 0; j < rows; j++)
                {
                    if (j > 0)
                    {
                        if (offsetHeight > 0)
                        {
                            rowHeightNew = rowHeight + 1;
                            yLocation = yLocation + rowHeightNew;
                            offsetHeight = offsetHeight - 1;
                        }
                        else
                        {
                            yLocation = yLocation + rowHeight;
                        }
                    }

                    if (controls[j] != null)
                    {
                        SetControlPosition(controls[j], xLocation, yLocation, width, rowHeight - borderWidth);
                    }

                }
            }
        }

        /// <summary>
        /// 自己重绘的表格，在其中放置的控件的定位
        /// </summary>
        /// <param name="tableInfo">自定义的用于绘制表格的数据结构</param>
        /// <param name="controls1">需要放入的控件对象数组</param>
        public static void SetTableControlsPosition(structTableInfo tableInfo, Control[][] controls1)
        {
            int height = tableInfo.Height;
            int labWidth = Convert.ToInt32(tableInfo.EachColoumnLength[0] * tableInfo.Width) - tableInfo.BorderWidth * 4;
            int labHeight = tableInfo.Height / tableInfo.Rows;
            int offsetHeight = tableInfo.Height % tableInfo.Rows;

            if (controls1 != null)
            {
                int xlocaiton = 0;
                int ylocaiton = 0;
                int buttonWidth = 0;
                for (int i = 0; i < controls1.GetLength(0); i++)
                {
                    Control[] controlsTemp = controls1[i];
                    buttonWidth = Convert.ToInt32(tableInfo.Width * tableInfo.EachColoumnLength[i]) - tableInfo.BorderWidth;
                    if (i == controls1.GetLength(0) - 1)
                    {
                        buttonWidth = Convert.ToInt32(tableInfo.Width * tableInfo.EachColoumnLength[i]) - 2 * tableInfo.BorderWidth;
                    }

                    //“DX1-16”标签
                    WinformUILayoutHelper.SetTableControlsPosition(controlsTemp, buttonWidth, height, xlocaiton, ylocaiton, 16, 0, tableInfo.BorderWidth, false);

                    xlocaiton = xlocaiton + tableInfo.BorderWidth + buttonWidth;
                }
            }
        }

        /// <summary>
        /// 在控件外绘制边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="box"></param>
        /// <param name="borderColor"></param>
        /// <param name="borderWidth"></param>
        /// <param name="borderMargin"></param>
        /// <param name="textBoxRec"></param>
        /// <param name="img"></param>
        private static void DrawBorder(Graphics g, Control box, Color borderColor, int borderWidth, int borderMargin, Rectangle textBoxRec,bool isBorderColorLinerChange, params Image[] img)
        {
            textBoxRec = new Rectangle();
            if (box == null) return;

            int offset = 1;//由于编辑框中的内容相对于边框顶部和底部总是不一样的，这个值用于补偿这个差值
            Point pt = box.Location;//获取当前编辑框的位置
            Size size = box.Size;//获取当前编辑框的大小

            Color clr = borderColor;
            if (img.Length > 0)//如果编辑框中有图片
            {
                int span = 10;//图片与编辑框之间的像素距离
                ImageAttributes imtt = new ImageAttributes();
                imtt.SetWrapMode(WrapMode.TileFlipXY);
                //g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //g.CompositingQuality = CompositingQuality.HighQuality;
                Rectangle imgRec = new Rectangle(pt.X - size.Height - span, pt.Y, size.Height, size.Height);
                g.DrawImage(img[0], imgRec, 0, 0, img[0].Width, img[0].Height, GraphicsUnit.Pixel, imtt);


                for (int i = 0; i < borderWidth; i++)
                {
                    if (isBorderColorLinerChange)
                    {
                        clr = Color.FromArgb(150 + 10 * i, borderColor.R, borderColor.G, borderColor.B);
                    }
                    textBoxRec = new Rectangle(imgRec.X - borderMargin + i, imgRec.Y - borderMargin + i, imgRec.Width + size.Width + span + 2 * borderMargin - 2 * i, size.Height + 2 * borderMargin - 2 * i - offset);
                    ControlPaint.DrawBorder(g, textBoxRec, clr, ButtonBorderStyle.Solid);
                }
            }
            else
            {
                for (int i = 0; i < borderWidth; i++)
                {
                    if (isBorderColorLinerChange)
                    {
                        clr = Color.FromArgb(150 + 10 * i, borderColor.R, borderColor.G, borderColor.B);
                    }
                    textBoxRec = new Rectangle(pt.X - borderMargin + i, pt.Y - borderMargin + i, size.Width + 2 * borderMargin - 2 * i, size.Height + 2 * borderMargin - 2 * i - offset);
                    ControlPaint.DrawBorder(g, textBoxRec, clr, ButtonBorderStyle.Solid);
                }
            }
        }

        /// <summary>
        /// 在控件外绘制边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="sCtrlBorInfo">structControlBorderInfo数据结构，表示所需要绘制的边框的一些信息</param>
        public static void DrawControlBorder(Graphics g, structControlBorderInfo sCtrlBorInfo)
        {
            if (sCtrlBorInfo.TargetControl != null)
            {
                if (sCtrlBorInfo.LeftTextImage != null)//是否包含图片
                {
                    if (!sCtrlBorInfo.IsActive)//是否处于激活状态
                    {
                        DrawBorder(g, sCtrlBorInfo.TargetControl, sCtrlBorInfo.NormalColor, sCtrlBorInfo.CtrlBorderWidth, sCtrlBorInfo.CtrlBorderMargin, sCtrlBorInfo.RecTextBorder,sCtrlBorInfo.IsBorderColorLinerChange, sCtrlBorInfo.LeftTextImage);
                    }
                    else
                    {
                        DrawBorder(g, sCtrlBorInfo.TargetControl, sCtrlBorInfo.ActiveBorder, sCtrlBorInfo.CtrlBorderWidth, sCtrlBorInfo.CtrlBorderMargin, sCtrlBorInfo.RecTextBorder, sCtrlBorInfo.IsBorderColorLinerChange, sCtrlBorInfo.LeftTextImage);
                    }

                }
                else
                {
                    if (!sCtrlBorInfo.IsActive)
                    {
                        DrawBorder(g, sCtrlBorInfo.TargetControl, sCtrlBorInfo.NormalColor, sCtrlBorInfo.CtrlBorderWidth, sCtrlBorInfo.CtrlBorderMargin, sCtrlBorInfo.RecTextBorder, sCtrlBorInfo.IsBorderColorLinerChange);
                    }
                    else
                    {
                        DrawBorder(g, sCtrlBorInfo.TargetControl, sCtrlBorInfo.ActiveBorder, sCtrlBorInfo.CtrlBorderWidth, sCtrlBorInfo.CtrlBorderMargin, sCtrlBorInfo.RecTextBorder, sCtrlBorInfo.IsBorderColorLinerChange);
                    }
                }
            }

        }

        /// <summary>
        /// 绘制一个表格
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="startLocationX"></param>
        /// <param name="startLocationY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="borderWidth"></param>
        /// <param name="borderColor"></param>
        private static void DrawTableBorder(Graphics g, int startLocationX, int startLocationY, int width, int height, int rows, int columns, float[] widthPercentage, float[] heightPercentage, int borderWidth, Color borderColor)
        {
            Pen tabeBorderColor = new Pen(new SolidBrush(borderColor), borderWidth);
            Rectangle rec = new Rectangle(startLocationX + borderWidth/2, startLocationY + borderWidth/2, width - borderWidth, height - borderWidth);
            //先画整个表格的外框矩形
            g.DrawRectangle(tabeBorderColor, rec);

            //画内部的行和列，用直线画
            int xLocation = startLocationX + borderWidth/2;
            int yLocation = startLocationY + borderWidth/2;

            Point pointSatrt = new Point(xLocation,yLocation);
            Point pointEnd = new Point(xLocation,yLocation);
            if (widthPercentage != null)
            {
                if (heightPercentage != null)
                {
                    
                }
                else
                {
                    int rowHeight = (height - borderWidth) / rows;
                    int rowHeightNew = rowHeight;
                    int offsetHeight = (height - borderWidth) % rows;

                    for (int i = 1; i < columns; i++)
                    {
                        for (int j = 1; j < rows; j++)
                        {
                            pointSatrt.X = xLocation;                                  
                            pointEnd.X = xLocation + width - borderWidth;

                            if (j == 0)
                            {
                                pointSatrt.Y = yLocation;
                                pointEnd.Y = yLocation;
                            }
                            else if (j > 0 && j < rows)
                            {
                                if (offsetHeight > 0)
                                {
                                    rowHeightNew = rowHeight + 1;
                                    yLocation = yLocation + rowHeightNew;
                                    pointSatrt.Y = yLocation;
                                    pointEnd.Y = yLocation;
                                    offsetHeight = offsetHeight - 1;
                                }
                                else
                                {
                                    yLocation = yLocation + rowHeight;
                                    pointSatrt.Y = yLocation;
                                    pointEnd.Y = yLocation;
                                }
                            }
                            else
                            {
                                yLocation = height -borderWidth;
                                pointSatrt.Y = yLocation;
                                pointEnd.Y = yLocation;
                            }

                            g.DrawLine(tabeBorderColor,pointSatrt,pointEnd);                      
                        }

                        if (i > 0)
                        {
                            xLocation = xLocation + Convert.ToInt32(widthPercentage[i-1] * width);
                        }

                        pointSatrt.X = xLocation;
                        pointSatrt.Y = startLocationY + borderWidth / 2;
                        pointEnd.X = xLocation;
                        pointEnd.Y = startLocationY + height - borderWidth / 2;

                        g.DrawLine(tabeBorderColor, pointSatrt, pointEnd);
                    }
                }
            }
            else
            {
                int columnWidth = width / columns;
                if (heightPercentage != null)
                {

                }
                else
                {
                    int rowHeight = height / rows;

                }

            }

        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="startLocationX"></param>
        /// <param name="startLocationY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="widthPercentage"></param>
        /// <param name="heightPercentage"></param>
        /// <param name="borderWidth"></param>
        /// <param name="borderColor"></param>
        public static void DrawControlBorder(Graphics g, int startLocationX, int startLocationY, int width, int height, int borderWidth, Color borderColor)
        {
            Pen tabeBorderColor = new Pen(new SolidBrush(borderColor), borderWidth);
            Rectangle rec = new Rectangle(startLocationX + borderWidth / 2, startLocationY + borderWidth / 2, width - borderWidth, height - borderWidth);
            //先画整个表格的外框矩形
            g.DrawRectangle(tabeBorderColor, rec);
        }

        /// <summary>
        /// 自行绘制一个表格
        /// </summary>
        public static void DrawTableBorder(Graphics g,structTableInfo tableInfo)
        {
            DrawTableBorder(g,tableInfo.StartLocationX,tableInfo.StartLocationY,tableInfo.Width,tableInfo.Height,tableInfo.Rows,tableInfo.Columns,tableInfo.EachColoumnLength,tableInfo.EachRowHeight,tableInfo.BorderWidth,tableInfo.BorderColor);
        }

    }
}
