using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
public static class Randomiser
    {
        // GET: Randomiser
        public static int RandomNumber(int max, int min)
        {
            var random = new Random();
            var result = random.Next(max, min);

        return result;
        }
    }
