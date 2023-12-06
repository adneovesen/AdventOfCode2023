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
            var times = Regex.Matches(lines[0], @"\d+").Select(x => int.Parse(x.Value));
            var distances = Regex.Matches(lines[1], @"\d+").Select(x => int.Parse(x.Value));

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

            var time = long.Parse(string.Join("", Regex.Matches(lines[0], @"\d+").Select(x => x.Value)));
            var distance = long.Parse(string.Join("", Regex.Matches(lines[1], @"\d+").Select(x => x.Value)));

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
