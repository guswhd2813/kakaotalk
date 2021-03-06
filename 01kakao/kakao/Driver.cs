﻿using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace kakao
{
    class Driver
    {
        #region Singleton
        private static Driver _driver = null;
        public static Driver _instance
        {
            get
            {
                if (_driver == null) _driver = new Driver();
                return _driver;
            }
        }
        #endregion


        private Driver()
        {
            Initialize();
        }
        private List<string> _DriverName;
        public List<string> DriverName
        {
            get
            {
                return _DriverName;
            }
        }

        private void Initialize()
        {
            _DriverName = new List<string>();
            foreach (DataRow name in DBManager.Getinstance.GetDriverName())
            {                
                _DriverName.Add(name.ItemArray.GetValue(0).ToString());
            }
        }
        


    }
}
