using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.Comm
{
   public static class RegistryKeyHelp
    {

       public static readonly string u8path =  U8.Interface.Bus.SysInfo.u8path;  //@"Software\U8MesInterface";

        /// <summary>
        /// 获得要找到的注册表项
        /// </summary>
        /// <param name="path">注册表路经</param>
        /// <returns>返回注册表对象</returns>
        public static bool CreateItemRegEdit(string path)
        {
            try
            {
                Microsoft.Win32.RegistryKey obj = Microsoft.Win32.Registry.LocalMachine; 
                obj.CreateSubKey(path); 
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// 设置注册表项下面的值
        /// </summary>
        /// <param name="path">路经</param>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public static int SetValueRegEdit(string path, string name, string value)
        {
            try
            {
                Microsoft.Win32.RegistryKey obj = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey objItem = obj.OpenSubKey(path, true);
                objItem.SetValue(name, value);
            }
            catch 
            {
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 查看注册表指定项的值
        /// </summary>
        /// <param name="path">路经</param>
        /// <param name="name">项名称</param>
        /// <returns>项值</returns>
        public static  string getValueRegEdit(string path, string name)
        {
            string value;
            try
            {
                try
                {
                    Microsoft.Win32.RegistryKey obj = Microsoft.Win32.Registry.LocalMachine;
                    Microsoft.Win32.RegistryKey objItem = obj.OpenSubKey(path);
                    value = objItem.GetValue(name).ToString();
                }
                catch
                {
                    //32、64位注册表兼容处理  added by liuxzha 2015.07.27
                    value = RegUtility.Get64BitRegistryKey("HKEY_LOCAL_MACHINE", path, name);
                }
              
            }
            catch 
            {
                return "";
            }
            return value;
        }


        /// <summary>
        /// 查看注册表项是否存在
        /// </summary>
        /// <param name="value">路经</param>
        /// <param name="name">项名称</param>
        /// <returns>是否存在</returns>
        public static bool SearchItemRegEdit(string path, string name)
        {
            string[] subkeyNames;

            Microsoft.Win32.RegistryKey hkml = Microsoft.Win32.Registry.LocalMachine;

            Microsoft.Win32.RegistryKey software = hkml.OpenSubKey(path);

            subkeyNames = software.GetSubKeyNames();

            //取得该项下所有子项的名称的序列，并传递给预定的数组中  

            foreach (string keyName in subkeyNames)   //遍历整个数组   
            {

                if (keyName.ToUpper() == name.ToUpper()) //判断子项的名称   
                {
                    hkml.Close();
                    return true;
                }

            }

            hkml.Close();

            return false;

        }

        /// <summary>
        /// 查看注册表的值是否存在
        /// </summary>
        /// <param name="value">路经</param>
        /// <param name="value">查看的值</param>
        /// <returns>是否成功</returns>
        public static bool SearchValueRegEdit(string path, string value)
        {

            string[] subkeyNames;

            Microsoft.Win32.RegistryKey hkml = Microsoft.Win32.Registry.LocalMachine;

            Microsoft.Win32.RegistryKey software = hkml.OpenSubKey(path);

            subkeyNames = software.GetValueNames();

            //取得该项下所有键值的名称的序列，并传递给预定的数组中  

            foreach (string keyName in subkeyNames)
            {

                if (keyName.ToUpper() == value.ToUpper())   //判断键值的名称   
                {

                    hkml.Close();

                    return true;

                }

            }

            hkml.Close();

            return false;

        }
    }
}
