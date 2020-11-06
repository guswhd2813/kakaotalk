using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kakao
{
    class LogManager
    {
        private static LogManager _instance = null;
        private LogManager()
        {
           
        }
        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogManager();
                }
                return _instance;
            }
        }
        public void AddLog(string addr, string log)
        {   
            string path = @"..\Log\" + addr + "\addr" + DateTime.Now.Date + ".txt";
            //StringBuilder sbLog = {0},log;
            System.IO.File.AppendAllText(path, log.ToString());
        }
    }
}
