using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kakao
{
    class Hotdeal
    {
        private static Hotdeal _instance = null;
        private Hotdeal()
        {

        }
        public static Hotdeal Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Hotdeal();
                }
                return _instance;
            }
        }
        public void go()
        {
            List<string> send = new List<string>();
            string strChat = "";

            try
            {
                ProgramManager.Instance.ProcessStart(@"c:\tweet\", "hotdeal");

                RegistryManager.Instance.writereg("HOT_END", notepad.Instance.EndLinecount("hotdeal"));
                while (Convert.ToInt32(RegistryManager.Instance.getReg("HOT_START")) < Convert.ToInt32(RegistryManager.Instance.getReg("HOT_END")))
                {
                    strChat = "";
                    send.Clear();
                    send = notepad.Instance.GetLine(Convert.ToInt32(RegistryManager.Instance.getReg("HOT_START")),"hotdeal");

                    foreach (string str in send)
                    {
                        strChat += (str + "\n");
                        RegistryManager.Instance.writereg("HOT_START", Convert.ToInt32(RegistryManager.Instance.getReg("HOT_START")) + 1);
                    }
                   // SendChat.Instance.kakao(strChat,"BOT_TWEET");
                   // Thread.Sleep(5000);
                    SendChat.Instance.kakao(strChat, "HOTDEAL");
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
