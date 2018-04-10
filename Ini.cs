using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Runtime.InteropServices;
using System.IO;

namespace DeltaWoodSystem.SanTuo.Utility
{
    public class Ini
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

  
        
        private string _filePath = string.Empty;
        /// <summary>
        /// 文件路径.
        /// </summary>
        public string FilePath
        {
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                }
            }
            get
            {
                if (_filePath == null)
                {
                    return string.Empty;
                }
                else
                {
                    return _filePath;
                }
            }
        }

        public Ini(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// 写入String.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void WriteString(string section, string key, string val)
        {
            string value;
            //Encoding.GetEncoding("GB2312").;
           value= encoding(val);
           WritePrivateProfileString(section, key, value, FilePath);
      
        }
  public string  encoding(string str)
  {
      Encoding unicode = Encoding.Unicode;
      Encoding utf_8 = Encoding.GetEncoding("BIG5");
      byte[] unicodeBytes = unicode.GetBytes(str);
      byte[] utf8Bytes = Encoding.Convert(unicode, utf_8, unicodeBytes);
      string value = utf_8.GetString(utf8Bytes);
      return value;

  }

        /// <summary>
        /// 读取String.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetString(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, FilePath);
            string value;
            //Encoding.GetEncoding("GB2312").;
            value = encoding(temp.ToString());
            return value;
        }
    }
}
