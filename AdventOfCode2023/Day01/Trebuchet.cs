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
                    var count = 1;
                    foreach (var number in numbers)
                    {
                        if (line.Contains(number))
                        {
                            partTwoLine = line.Replace(number, count.ToString());
                            continue;
                        }
                        count++;
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

            return score;
        }

        private static void ItterateLine(string line, ref string first, ref string last)
        {
            foreach (var letter in line)
            {
                if (char.IsDigit(letter))
                {
                    if (first is "")
                        first += letter;
                    else
                        last = "";
                    last += letter;
                }
            }
        }

        private static string[] getNumbers()
        {
            return ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        }
    }
}
