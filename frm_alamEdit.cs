using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DeltaWoodSystem.SanTuo.Utility;

namespace Alam_Function
{
    public partial class frm_alamEdit : Form
    {
        List<string> alamAddres = new List<string>();
        List<string> alamgetting = new List<string>();
        List<string> alamval = new List<string>();
        Alarm_Data alarmData = new Alarm_Data();
        public static string alamFilesPath = System.Environment.CurrentDirectory + @"\File\alamFiles.ini";
        Ini sa_Ini = new Ini(alamFilesPath);
        private List<string> alamprocessFiles=new List<string>();
        public frm_alamEdit()
        {
            InitializeComponent();
            alamdata1();
            alamdata2();
            InitDataGridView();
        }
        //开料文件DataGridView的控件初始化
        private void InitDataGridView()
        {
            //DataGridViewCheckBoxColumn decheck = new DataGridViewCheckBoxColumn();
            //decheck.DataPropertyName = "check";
            //decheck.HeaderText = " ";
            //decheck.Name = "Index1";
            //dgvProcessFiles.Columns.Add(decheck);
            //this.dgvProcessFiles.Columns.Add("Index1", "勾选");
            this.dgvAlamFiles.Columns.Add("Index", "序号");
            this.dgvAlamFiles.Columns.Add("Index1", "IMP地址");
            this.dgvAlamFiles.Columns.Add("FileName", "文件名");
            this.dgvAlamFiles.BackgroundColor = Color.White;
            this.dgvAlamFiles.GridColor = Color.Black ;
            this.dgvAlamFiles.BorderStyle = BorderStyle.FixedSingle  ;
            this.dgvAlamFiles.ColumnHeadersVisible = true;
            this.dgvAlamFiles.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dgvAlamFiles.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            this.dgvAlamFiles.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvAlamFiles.RowHeadersVisible = false ;
            this.dgvAlamFiles.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvAlamFiles.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvAlamFiles.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvAlamFiles.RowHeadersWidth = 80;
            this.dgvAlamFiles.MultiSelect = false;
            this.dgvAlamFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
            //this.dgvAlamFiles.ReadOnly = true;
            this.dgvAlamFiles.Columns[0].ReadOnly = true;
            this.dgvAlamFiles.Columns[1].ReadOnly = true;
            this.dgvAlamFiles.Columns[2].ReadOnly = true;
            this.dgvAlamFiles.AllowUserToAddRows = false;
            this.dgvAlamFiles.AllowUserToDeleteRows = false;
            this.dgvAlamFiles.AllowUserToResizeColumns = false;
            this.dgvAlamFiles.AllowUserToResizeRows = false;
            this.dgvAlamFiles.ScrollBars = ScrollBars.Vertical;

            int width = this.dgvAlamFiles.Width;
            int columnOneWidth = 40;
            int columnTwoWidth = 40;
            int columnThreeWidth = width - columnOneWidth - columnTwoWidth;
            this.dgvAlamFiles.Columns[0].Width = columnOneWidth;
            this.dgvAlamFiles.Columns[1].Width = columnTwoWidth;
            this.dgvAlamFiles.Columns[2].Width = columnThreeWidth;

        }
        private void import()
        {


            this.dgvAlamFiles.Rows.Clear();
            this.alamprocessFiles.Clear();

            string filePath = "";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Save_settingFilePath_ToFile(alamFilesPath);
        }
        /// <summary>
        /// 保存成文件
        /// </summary>
        /// <param name="fileInfo"></param>
        public void Save_settingFilePath_ToFile(string fileInfo)
        {
            this.dgvAlamFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //this.dgvAlamFiles.ReadOnly = true;
            this.dgvAlamFiles.Columns[0].ReadOnly = true;
            this.dgvAlamFiles.Columns[1].ReadOnly = true;
            this.dgvAlamFiles.Columns[2].ReadOnly = true;
            getcell();
        
            if (File.Exists(fileInfo))
            {
                if (alamprocessFiles != null)
                {
                        for (int i = 0; i < alamAddres.Count; i++)
                {
                    try
                    {
                        sa_Ini.WriteString("0000", alamAddres[i].ToString(), alamprocessFiles[i].ToString());
                    }
                    catch
                    {
                        return;
                    }
                }

            }
                else
                {
                    for (int i = 0; i < alamAddres.Count; i++)
                    {
                        try
                        {
                            sa_Ini.WriteString("0000", alamAddres[i].ToString(), alamval[i].ToString());
                        }
                        catch
                        {
                            return;
                        }
                    }
                    return;
                }
                }
                
            else
            {
                Create_File(fileInfo);
                sa_Ini.WriteString("0000", "1", "1");
            }
        }
        /// <summary>
        /// 判断文件是否存在可用Filehelp
        /// </summary>
        /// <param name="filePath"></param>
        private void Create_File(string filePath)
        {
            File.WriteAllText(filePath, " ", Encoding.Default);

        }
        /// <summary>
        /// IMP地址默认1000
        /// </summary>
        private void alamdata1()
        {
            int i = 0;
            for (i = 0; i < 1000; i++)
            {
                alamAddres.Add(i.ToString());
            }

        }
        /// <summary>
        /// 对应报警信息
        /// </summary>
        private void alamdata2()
        {
            int i = 0;

            for (i = 0; i < alarmData.AlarmMessage.Length; i++)
            {
                alamval.Add(alarmData.AlarmMessage[i].ToString());
            }
            for (int k = alarmData.AlarmMessage.Length;k< 1000;k++)
            {
                alamval.Add("0");
            }
        }
        /// <summary>
        /// 读取报警信息并显示在表格中
        /// </summary>
        private void Get_settingProcessFiles()
        {
            if (File.Exists(alamFilesPath))
            {
                alamgetting.Clear();
                string setting_value;
                for (int i = 0; i < alamAddres.Count ; i++)
                {
                    try
                    {
                        setting_value = sa_Ini.GetString("0000", alamAddres[i].ToString());
                        //alamprocessFiles.Add(setting_value);
                        this.dgvAlamFiles.Rows.Add(i ,alamAddres[i].ToString(), setting_value);
                    }
                    catch
                    {
                        return;
                    }
                }
           

            }
            else
            {
                Create_File(alamFilesPath);
                sa_Ini.WriteString("0000", "1", "1");
            }
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnimport_Click(object sender, EventArgs e)
        {
            Get_settingProcessFiles();
        }
        /// <summary>
        /// 编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnedit_Click(object sender, EventArgs e)
        {
            this.dgvAlamFiles.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.dgvAlamFiles.ReadOnly = false ;
            this.dgvAlamFiles.Columns[0].ReadOnly = true ;
            this.dgvAlamFiles.Columns[1].ReadOnly = true;
            this.dgvAlamFiles.Columns[2].ReadOnly = false;
        

        }
        /// <summary>
        /// 读取表格中的文件
        /// </summary>
        private void getcell()
        {
            alamprocessFiles.Clear();
            int i = 0;
            string val=null ;
            try 
            {
                for (i = 0; i < this.dgvAlamFiles.Rows.Count; i++)
                {
                    val = this.dgvAlamFiles.Rows[i].Cells[2].Value .ToString ();
                    alamprocessFiles.Add(val);
                }
            }
            catch
            {

            }

        }
    }
}
