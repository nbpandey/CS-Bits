using System;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class RegExApp
    {
        private static void showMatch(string text, string expr)
        {
            Console.WriteLine("The Expression: " + expr);
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);   
            }
        }

        static void Main(string[] args)
        {
            // Match a string pattern
            Regex r1 = new Regex(@"j[aeiou]h?. \d:*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (r1.Match("John 3.16").Success)
                Console.WriteLine("Sucess in match");
            else
                Console.WriteLine("No match");

            // Find and remember all matching patterns
            string s = "My number is 305-1881, not 305-1818,";
            Regex r2 = new Regex("(\\d+-\\d+)");
            for (Match m = r2.Match(s); m.Success; m = m.NextMatch())
                Console.WriteLine("Found number: " + m.Groups[1] + " at postion " + m.Groups[1].Index);

            // Remember mulitple parts of matched pattern
            Regex r3 = new Regex(@"(\d\d):(\d\d) (am|pm)");
            Match m3 = r3.Match("We left at 03:15 pm.");
            if (m3.Success)
            {
                Console.WriteLine("Hour: " + m3.Groups[1]);
                Console.WriteLine("Min: " + m3.Groups[2]);
                Console.WriteLine("Ending: " + m3.Groups[3]);
            }

            // Replace all occurances of a pattern
            Regex r4 = new Regex("h\\w+?d", RegexOptions.IgnoreCase);
            Console.WriteLine(r4.Replace("I heard this was HARD!", "easy"));

            // Replace matched patterns
            Console.WriteLine(Regex.Replace("123 < 456", @"(\d+) . (\d+)", "$2 > $1"));

            // Split a string basted on a pattern
            string names = "Michael, Dwight, Jim, Pam";
            Regex r5 = new Regex(@",\s");
            foreach (string name in r5.Split(names))
            {
                Console.WriteLine(name);
            }
            
            
            string str = "A Thousand Splendid Suns";
            Console.WriteLine("Matching words that start with 'S': ");
            showMatch(str, @"\bS\S*");
            Console.ReadKey();
        }

    }
}
