using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kakao
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Tweet.Instance.Go();
                Hotdeal.Instance.go();
            }
        }
        
    }
    

}
