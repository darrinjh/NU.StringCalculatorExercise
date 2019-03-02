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
        List<string> numberList = new List<string>();
        
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0) Console.WriteLine("0");
                else
                {
                    int val = Add(args[0]);
                    Console.WriteLine(val);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static int Add(string numbers)
        {
            int retval = 0;
            if (numbers.Contains(",\\n")) return retval; // not sure if you wanted a full carrage return so I went with what it said.

            string[] numbersList = findNumbers(numbers);
            //Check for negative numbers
            negativeCheck(numbersList);

            if (numbers.Length > 0)
            {
                foreach (string x in numbersList)
                {
                    if (x != "")
                    {
                        try
                        {
                            int v = Int32.Parse(x);
                            if(v <= 1000) retval += v;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            return retval;
        }

        //Step 7
        static int Step7Add(string numbers)
        {
            int retval = 0;
            if (numbers.Contains(",\\n")) return retval; // not sure if you wanted a full carrage return so I went with what it said.

            string[] numbersList = findNumbers(numbers);
            //Check for negative numbers
            negativeCheck(numbersList);

            if (numbers.Length > 0)
            {
                foreach (string x in numbersList)
                {
                    if (x != "")
                    {
                        try
                        {
                            int v = Int32.Parse(x);
                            if (v <= 1000) retval += v;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            return retval;
        }

        //Step 6
        static int Step6Add(string numbers)
        {
            int retval = 0;
            if (numbers.Contains(",\\n")) return retval; // not sure if you wanted a full carrage return so I went with what it said.

            string[] numbersList = findNumbers(numbers);
            //Check for negative numbers
            negativeCheck(numbersList);

            if (numbers.Length > 0)
            {
                foreach (string x in numbersList)
                {
                    if (x != "")
                    {
                        try
                        {
                            int v = Int32.Parse(x);
                            if (v <= 1000) retval += v;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            return retval;
        }

        //Step 5
        static int Step5Add(string numbers)
        {
            int retval = 0;
            if (numbers.Contains(",\\n")) return retval; // not sure if you wanted a full carrage return so I went with what it said.

            string[] numbersList = findNumbers(numbers);
            //Check for negative numbers
            negativeCheck(numbersList);

            if (numbers.Length > 0)
            {
                foreach (string x in numbersList)
                {
                    if (x != "")
                    {
                        try
                        {
                            retval += Int32.Parse(x);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            return retval;
        }
        static void negativeCheck(string[] numbers)
        {
            string negs = "";
            foreach (string x in numbers)
            {
               int v = Int32.Parse(x);
               if( v < 0) negs += x +" ";
            }
            if(negs.Length > 0) throw new System.ArgumentException("negatives not allowed " + negs);
        }
  
        //Step 4
        static int Step4Add(string numbers)
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
            string delim =",";
            string[] retval1 = Regex.Split(t, @"\D+"); 

            int i = t.IndexOf("\\n");

            if (t.Length > i)
            {
                if (t.Substring(0, 2) == "//" && t.Substring(i, 2) == "\\n")
                {
                    if (t.Contains("[") && t.Contains("]")) //multi delimiter
                    {
                        string ss = Regex.Match(t, @"\[(.*?%)\]").ToString();
                        ss = ss.Replace("[", "");
                        string[] delims = ss.Split(']');
                        delims = delims.Take(delims.Count() - 1).ToArray();
                        string g = t.Substring(i + 2, t.Length-i-2);

                        foreach (string c in delims) 
                        {
                            g = g.Replace(c, "~"); // make the delimiters the same one!
                        }
                        retval1 = g.Split('~');
                    } else
                    {
                        delim = t.Substring(2, i - 2);
                        retval1 = t.Substring(i + 2).Split(new string[] { delim }, StringSplitOptions.None);
                    }
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
