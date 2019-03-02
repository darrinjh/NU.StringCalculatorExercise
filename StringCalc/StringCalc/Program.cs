using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) Console.WriteLine("0");
            else
            {
                int val = Add(args[0]);
                Console.WriteLine(val);
            }
        }
        static int Add(string numbers)
        {
            int retval = 0;
            string[] numbersList = Regex.Split(numbers, @"\D+");
            if (numbers.Length > 0)
            {
                foreach (string x in numbersList)
                {
                    if(x != "")
                    {
                        retval += Int32.Parse(x);
                    }
                }
            }
            return retval;
        }

        //Step 1
        static int Step1Add(string numbers)
        {
            int retval = 0;
            string[] numbersList = Regex.Split(numbers, @"\D+");
            if (numbers.Length > 0)
            {
                int limit = 2; //limit to a maximum of 2 number as per request
                foreach (string x in numbersList)
                {
                    if (x != "")
                    {
                        retval += Int32.Parse(x);
                        limit--;
                        if (limit == 0) break;
                    }
                }
            }
            return retval;
        }
    }
}
