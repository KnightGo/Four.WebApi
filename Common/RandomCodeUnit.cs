using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class RandomCodeUnit
    {
        /// <summary>
        /// 得到随机数字符串
        /// </summary>
        /// <param name="CodeCount">随机数的长度</param>
        /// <returns>得到指定长度的随机数</returns>
        public static string GetRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(33);

                while (temp == t)
                {
                    t = rand.Next(33);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }
        /// <summary>
        /// 得到纯数字随机数字符串
        /// </summary>
        /// <param name="CodeCount">随机数的长度</param>
        /// <returns>得到指定长度的随机数</returns>
        public static string GetNumberRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(10);

                while (temp == t)
                {
                    t = rand.Next(10);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }
    }
}
