using System;
using System.Text.RegularExpressions;

namespace P03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string pattern = @"%(?<name>[A-Za-z]+)%<(?<products>\w+)>\|(?<quant>\d+)\|(?<price>\d)+\.(\d+)\$";
            double total = 0;

            while (line != "end of shift")
            {
                if (Regex.IsMatch(line, pattern))
                {
                    Match match = Regex.Match(line, pattern);
                    var customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double money = price * count;
                    Console.WriteLine($"{customer}: {product} - {money:F2}");
                    total += money;
                }
                line = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {total:F2}");
        }  }
}
