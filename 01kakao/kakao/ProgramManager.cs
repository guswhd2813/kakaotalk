using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace kakao
{
    class ProgramManager
    {
        private static ProgramManager instance = null;
        public static ProgramManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProgramManager();
                }
                return instance;
            }
        }
        private ProgramManager()
        {

        }

        public bool Processkill(string _processname)
        {
            foreach(Process process in Process.GetProcesses())
            {
                if(process.ProcessName.StartsWith(_processname))
                {
                    process.Kill();
                    return true;
                }
            }
            return false;
        }

        public void ProcessStart(string _ProcessPath, string _ProcessName)
        {
            if(!ProcessFind(_ProcessName))
            { 
                Process.Start(_ProcessPath + _ProcessName+".exe"); 
            }
        }

        public bool ProcessFind(string _ProcessName)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.StartsWith(_ProcessName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
