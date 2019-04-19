using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GHV.Common
{
    public class AsyncAwait
    {
        Stopwatch sw = new Stopwatch();
        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();        
        }
        public int CountCharacters(int id,string uristring)
        {
            WebClient wc1 = new WebClient();
            var aa = String.Format("Starting call {0} : {1,4:No} ms",id,sw.Elapsed.TotalMilliseconds);
            string result = wc1.DownloadString(new Uri(uristring));
            var bb = String.Format("     Call {0} completed :  {1,4:No} ms", id, sw.Elapsed.TotalMilliseconds);

            return result.Length;
        }
        public void CountToALargeNumber(int id,int value)
        {
            for (long i = 0; i < value; i++)
            {

            }
        }
    }

}
