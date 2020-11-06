using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace kakao
{
    class Driver
    {
        private string driverName
        {
            get { return this.driverName; }
            set
            {
                this.driverName = value;
            }
        }
        private string driverFileName
        {
            get { return this.driverFileName; }
            set
            {
                this.driverFileName = value;
            }
        }
        private string textSaveFile
        {
            get { return this.textSaveFile; }
            set
            {
                this.textSaveFile = value;
            }
        }
        private string chatRoomName
        {
            get { return this.chatRoomName; }
            set
            {
                this.chatRoomName = value;
            }
        }
        private string splitString
        {
            get { return this.splitString; }
            set
            {
                this.splitString = value;
            }
        }
        private string lastSendTime
        {
            get { return this.lastSendTime; }
            set
            {
                this.lastSendTime = value;
            }
        }
        private int delayTime
        {
            get { return this.delayTime; }
            set
            {
                this.delayTime = value;
            }
        }






    }
}
