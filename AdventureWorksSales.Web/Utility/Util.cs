using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Utility
{
    public class Util
    {
        public static int GenerateRandomNumber()
        {
            Random rand = new Random();
            int rrNum = rand.Next(5, 9999);

            return rrNum;
        }
    }
}