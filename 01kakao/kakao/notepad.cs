using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace kakao
{
    class notepad
    {
        
        string strNoteNum = RegistryManager.Instance.getReg("DAY").ToString();
        private static notepad _instance = null;
        private notepad()
        {
            if(Convert.ToInt32(RegistryManager.Instance.getReg("DAY"))<10)
            {
                strNoteNum = "0" + RegistryManager.Instance.getReg("DAY").ToString();
            }
        }
        public static notepad Instance
        {
            get
                {
                if (_instance == null)
                {
                    _instance = new notepad();
                }
                return _instance;
            }
        }

        //private string path = @"d:\test.txt";
        private List<string> note = new List<string>();

        public int EndLinecount(string _str)
        {
            int count = 0;
            if (_str == "tweet")
            {
                CheckNextday();                
                string[] line = File.ReadAllLines(@"c:\tweet\tweet" + strNoteNum + ".txt");
                for (int i = 0; i < line.Length; i++)
                {
                    count++;
                }
                
            }
            else
            {
                string[] line = File.ReadAllLines(@"c:\tweet\hotdeal.txt");
                for (int i = 0; i < line.Length; i++)
                {
                    count++;
                }
                
            }
            return count;
        }

        private void CheckNextday()
        {
            DateTime now = DateTime.Now;

            if(string.Format("{0:dd}",now)!= strNoteNum)
            {
                if(RegistryManager.Instance.getReg("START").ToString() == RegistryManager.Instance.getReg("END").ToString() )
                {
                    strNoteNum = DateTime.Now.ToString("dd");
                    RegistryManager.Instance.writereg("DAY", strNoteNum);
                    RegistryManager.Instance.writereg("START", 0);
                }
            }
        }
        public List<string> GetLine(int _i,string _str)
        {
            if (_str == "tweet") Read(_i);
            else if (_str == "hotdeal") HotdealRead(_i);
            return note;
        }
        public string GetFullLine(int _i)
        {
            Read(_i);
            return Sumstr(note);
        }

        private void Read(int _num)
        {
            note.Clear();
            string[] line = File.ReadAllLines(@"c:\tweet\tweet" + strNoteNum + ".txt");
            for (int i = _num; i < line.Length; ++i)
            {
                if (line[i] == "&eof&" || line[i] == "&stf&")
                {
                    RegistryManager.Instance.writereg("START", Convert.ToInt32(RegistryManager.Instance.getReg("START")) + 1);
                    if(line[i] == "&eof&") break;
                }
                
                if (line[i] != "&stf&") note.Add(line[i]);
            }

        }

        private void HotdealRead(int _num)
        {
            note.Clear();
            string[] line = File.ReadAllLines(@"c:\tweet\hotdeal.txt");
            for (int i = _num; i < line.Length; ++i)
            {
                if (line[i] == "&eof&" || line[i] == "&stf&")
                {
                    RegistryManager.Instance.writereg("HOT_START", Convert.ToInt32(RegistryManager.Instance.getReg("HOT_START")) + 1);
                    if (line[i] == "&eof&") break;
                }

                if (line[i] != "&stf&") note.Add(line[i]);
            }

        }

        private string Sumstr(List<string> _str)
        {
            string str = "";
            foreach(string line in _str)
            {
                str += line;
            }
            return str;
        }
        public void write(string _str)
        {
            using (StreamWriter outputFile = new StreamWriter(@"c:\tweet\tweet" + strNoteNum + ".txt", true))
            {
                outputFile.WriteLine(_str);
            }
        }
    }
}
