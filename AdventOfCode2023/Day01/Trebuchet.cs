using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day01
{
    public class Trebuchet
    {
        public static int PartOne(string path)
        {
            return CalculateNumber(path);
        }

        public static int PartTwo(string path)
        {
            return CalculateNumber(path, true);
        }

        private static int CalculateNumber(string path, bool partTwo = false)
        {
            var lines = File.ReadAllLines(path);

            var score = 0;
            foreach(var line in lines)
            {
                var first = "";
                var last = "";
                var partTwoLine = "";

                if (partTwo)
                {
                    var numbers = getNumbers();
                    foreach (var t in line)
                    {
                        partTwoLine += t;
                        foreach (var number in numbers.Where(number => partTwoLine.Contains(number.Key)))
                        {
                            partTwoLine = partTwoLine.Replace(number.Key, number.Value);
                        }
                    }
                }
                if (partTwo)
                {
                    ItterateLine(partTwoLine, ref first, ref last);
                }
                else
                {
                    ItterateLine(line, ref first, ref last);
                }
                var twoDigitNumber = first + last;
                score += int.Parse(twoDigitNumber);
            }

            return score; // not 54533 54698 54518
        }

        private static void ItterateLine(string line, ref string first, ref string last)
        {
            foreach (var letter in line.Where(char.IsDigit))
            {
                if (first is "")
                    first += letter;
                else
                {
                    last = "";
                }
                last += letter;
            }
        }

        private static Dictionary<string, string> getNumbers()
        {
            return new Dictionary<string, string>
                { { "one", "1e" },{ "two", "2o" }, { "three", "3e" },{ "four", "4" }, { "five", "5e" },{ "six", "6" }, { "seven", "7n" },{ "eight", "8t" },{ "nine", "9e" } };
    }
    }
}
