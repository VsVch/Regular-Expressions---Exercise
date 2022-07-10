using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @">>(?<name>[A-Za-z]+)<<(?<price>\d+.\d+)!(?<quanty>\d+)";
            var items = new List<string>();
            double total = 0;

            while (input != "Purchase")
            {
                Match matchInput = Regex.Match(input, regex, RegexOptions.IgnoreCase);
                if (matchInput.Success)
                {
                    var names = matchInput.Groups["name"].Value;
                    var price = double.Parse(matchInput.Groups["price"].Value);
                    var quanty = int.Parse(matchInput.Groups["quanty"].Value);
                    items.Add(names);
                    total += price * quanty;
                }
                input = Console.ReadLine();
            }
            if (items.Count>0)
            {
                Console.WriteLine($"{string.Join(Environment.NewLine,items)}");
            }
            Console.WriteLine($"Total money spend: {total:F2}");
        }
    }
}
