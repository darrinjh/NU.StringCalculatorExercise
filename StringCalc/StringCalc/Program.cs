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
            if (numbers.Contains(",\\n")) return retval; // not sure if you wanted a full carrage return so I went with what it said.

            string[] numbersList = findNumbers(numbers);
            if (numbers.Length > 0)
            {
                foreach (string x in numbersList)
                {
                    if (x != "")
                    {
                        try
                        {
                            retval += Int32.Parse(x);
                        } catch (Exception ex)
                        {
                        }                       
                    }
                }
            }
            return retval;
        }

        static string[] findNumbers(string t)
        {
            char delim =',';
            string[] retval1 = Regex.Split(t, @"\D+"); ;

            if (t.Length > 5)
            {
                if (t.Substring(0, 2) == "//" && t.Substring(3, 2) == "\\n")
                {
                    delim = t.Substring(2, 1)[0];
                    retval1 = t.Substring(5).Split(delim);
                }
            }
            return retval1;
        }

        //Step 3
        static int Step3Add(string numbers)
        {
            int retval = 0;
            if (numbers.Contains(",\\n")) return retval; // not sure if you wanted a full carrage return so I went with what it said.
          
            string[] numbersList = Regex.Split(numbers, @"\D+");
            if (numbers.Length > 0)
            {
                foreach (string x in numbersList)
                {
                    if (x != "")
                    {
                        retval += Int32.Parse(x);
                    }
                }
            }
            return retval;
        }

        //Step 2
        static int Step2Add(string numbers)
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
