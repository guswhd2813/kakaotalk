using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kakao
{
    class Tweet
    {
        private static Tweet _instance = null;
        private Tweet()
        {

        }
        public static Tweet Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Tweet();
                }
                return _instance;
            }
        }
        public void Go()
        {
            List<string> send = new List<string>();
            string strChat;            
            try
            {
                ProgramManager.Instance.ProcessStart(@"c:\tweet\", "tweet1.1");
                RegistryManager.Instance.writereg("END", notepad.Instance.EndLinecount("tweet"));
                while (Convert.ToInt32(RegistryManager.Instance.getReg("START")) < Convert.ToInt32(RegistryManager.Instance.getReg("END")))
                {
                    strChat = "";
                    send.Clear();
                    send = notepad.Instance.GetLine(Convert.ToInt32(RegistryManager.Instance.getReg("START")),"tweet");
                    foreach (string str in send)
                    {
                        strChat += (str + "\n");
                        RegistryManager.Instance.writereg("START", Convert.ToInt32(RegistryManager.Instance.getReg("START")) + 1);
                    }                    
                    SendChat.Instance.kakao(strChat,"BOT_TWEET");
                    Thread.Sleep(5000);
                }
            }
            catch
            {
                Thread.Sleep(5000);
            }
            
        }
    }
}
