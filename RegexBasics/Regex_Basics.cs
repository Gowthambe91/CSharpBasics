using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexBasics
{
    class Regex_Basics
    {
        static void Main(string[] args)
        {
            /*\b - matches the beginning/end of a word, if "\brises1\b" means, "rises1" text will only return true*/
            /* . (dot/period) is a special code that matches any character other than a new line */
            string regexpression = "";
            string Text = @"The  sun rises1 in the east";
            //string regexpression = @"\brises1\b.\beast\b";
            regexpression = @"the\s+\w+"; /* '\s'- white space character, '*' - Quantifier ( 0 or more ), '+' - 1 or more times, '?' - 0 or 1 time */
            MatchCollection matchCollection = Regex.Matches(Text, regexpression,RegexOptions.IgnoreCase);
            foreach (Match m in matchCollection)
            {
                Console.WriteLine(m.ToString());
            }

            //Console.WriteLine(Regex.IsMatch(Text,regexpression));
            Console.ReadLine();
        }
    }
}
