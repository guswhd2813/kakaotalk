using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace kakao
{
    class RegistryManager
    {
        private static RegistryManager instance = null;
        public static RegistryManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new RegistryManager();
                }
                return instance;
            }
        }
        private RegistryManager()
        {

        }

        public object getReg(string str)
        {
            RegistryKey reg = Registry.LocalMachine;
            reg = reg.OpenSubKey(@"SOFTWARE\test",true);
            if (reg == null)
            {
                writereg(str,0);
            }
            return Convert.ToInt32(reg.GetValue(str));
        }
        public void writereg(string key, object val)
        {
            RegistryKey reg = Registry.LocalMachine;
            reg = reg.CreateSubKey(@"SOFTWARE\test", RegistryKeyPermissionCheck.ReadWriteSubTree);
            reg.SetValue(key, val);
            reg.Close();
        }
        

    }
}
