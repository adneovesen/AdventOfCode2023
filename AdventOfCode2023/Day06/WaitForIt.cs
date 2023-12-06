using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day06
{
    public class WaitForIt
    {
        public static int PartOne(string path)
        {
            return Solve(path);
        }

        private static int Solve(string path)
        {
            var lines = File.ReadAllLines(path);
            var times = from m in Regex.Matches(lines[0], @"\d+") select int.Parse(m.Value);
            var distances = from m in Regex.Matches(lines[1], @"\d+") select int.Parse(m.Value);

            var score = 1;
            for (var i = 0; i < times.Count(); i++)
            {
                var time = times.ElementAt(i);
                var distance = distances.ElementAt(i);
                var tempScore = 0;
                for (var j = 1; j < time; j++)
                {
                    var temp = j * (time - j);

                    if (temp > distance) tempScore++;
                }

                score *= tempScore;
            }

            return score;
        }

        public static int PartTwo(string path)
        {
            return SolvePartTwo(path);
        }

        private static int SolvePartTwo(string path)
        {
            var lines = File.ReadAllLines(path);
            var time = long.Parse((from m in Regex.Matches(lines[0], @"\d+") select m.Value).Aggregate((a, b) => a + b));
            var distance = long.Parse((from m in Regex.Matches(lines[1], @"\d+") select m.Value).Aggregate((a, b) => a + b));

            var score = 0;
            for (var j = 1; j < time; j++)
            {
                var temp = j * (time - j);

                if (temp > distance) score++;
            }

            return score;
        }
    }
}
