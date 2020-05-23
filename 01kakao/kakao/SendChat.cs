using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace kakao
{
    class SendChat
    {

        private static SendChat _instance = null;
        private SendChat()
        {

        }
        public static SendChat Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SendChat();
                }
                return _instance;
            }
        }
        #region ini
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);

        [DllImport("user32.dll")]
        public static extern int PostMessage(int hwnd, int wMsg, int wParam, int lParam);


        [DllImport("user32.dll")]
        public static extern int GetWindow(int hWnd, int uCmd);

        [DllImport("user32.dll")]
        public static extern void keybd_event(int vk, uint scan, uint flags, uint extraInfo);
        
        


        const int BM_CLICK = 0x00F5;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int VK_CONTROL = 0x11;
        const int VK_V = 0x56;
        const int VK_C = 0x43;
        const int VK_A = 0x41;


        #endregion

        public int chat1, chat2, chat3;
        public int chat4, chat5, chat6;

        private void Info()
        {
            chat1 = FindWindow(null, "BOT_TWEET");
            chat2 = GetWindow(chat1, 5);
            chat3 = GetWindow(chat2, 2);

            chat4 = FindWindow(null, "HOTDEAL");
            chat5 = GetWindow(chat4, 5);
            chat6 = GetWindow(chat5, 2);
        }
        public void kakao(string _sndmessage,string _info)
        {
            Info();
            if (_info == "HOTDEAL")
            {
                sendchat2(_sndmessage);
            }

            Thread.Sleep(3000);
            sendchat(_sndmessage);
        }

        private void ConC()
        {
            SendMessage(chat2, BM_CLICK, 0, 1);
            Ctrlinput(VK_A);
            Ctrlinput(VK_C);
        }
        private void sendchat(string _chat)
        {
            SendMessage(chat2, 0x000c, 0, _chat);
            PostMessage(chat2, 0x0100, 0xd, 0x01c001);
        }
        private void sendchat2(string _chat)
        {
            SendMessage(chat5, 0x000c, 0, _chat);
            PostMessage(chat5, 0x0100, 0xd, 0x01c001);
        }
        private void Keyinput(int key)
        {
            keybd_event(key, 0, 0x00, 0);
            keybd_event(key, 0, 0x02, 0);
        }
        private void Ctrlinput(int key)
        {
            keybd_event(VK_CONTROL, 0, 0x00, 0);
            keybd_event(key, 0, 0x00, 0);
            keybd_event(VK_CONTROL, 0, 0x02, 0);
            //keybd_event(key, 0, 0x00, 0);
        }
    }
}
