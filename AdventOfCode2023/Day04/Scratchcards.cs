using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace AdventOfCode2023.Day04
{
    public class Scratchcards
    {
        public static int PartOne(string path)
        {
            return Solve(path);
        }

        public static int PartTwo(string path)
        {
            return SolvePartTwo(path);
        }

        private static int SolvePartTwo(string path)
        {
            var lines = File.ReadAllLines(path);

            var scoreArray = new int[lines.Length];

            for (var i = 0; i < lines.Length; i++)
            {
                var splitLine = lines[i].Split(':', '|');

                var winnningNumberString = splitLine[1].Trim().Split(' ');
                var winningNumbers = new List<int>();
                foreach (var num in winnningNumberString)
                {
                    if (int.TryParse(num, out var intNum))
                    {
                        winningNumbers.Add(intNum);
                    }
                }
                var scratchedNumberString = splitLine[2].Trim().Split(' ');
                var scratchedNumbers = new List<int>();
                foreach (var num in scratchedNumberString)
                {
                    if (int.TryParse(num, out var intNum))
                    {
                        scratchedNumbers.Add(intNum);
                    }
                }

                var score = scratchedNumbers.Count(number => winningNumbers.Contains(number));

                for (var j = 0; j < score; j++)
                {
                    scoreArray[i + j + 1] += 1 + scoreArray[i];
                }
            }

            return scoreArray.Sum() + scoreArray.Length;
        }

        private static int Solve(string path)
        {
            var lines = File.ReadAllLines(path);

            var sum = 0;

            foreach (var line in lines)
            {
                var splitLine = line.Split(':', '|');

                var winnningNumberString = splitLine[1].Trim().Split(' ');
                var winningNumbers = new List<int>();
                foreach (var num in winnningNumberString)
                {
                    if (int.TryParse(num, out var intNum))
                    {
                        winningNumbers.Add(intNum);
                    }
                }
                var scratchedNumberString = splitLine[2].Trim().Split(' ');
                var scratchedNumbers = new List<int>();
                foreach (var num in scratchedNumberString)
                {
                    if (int.TryParse(num, out var intNum))
                    {
                        scratchedNumbers.Add(intNum);
                    }
                }

                var score = 0;

                foreach (var number in scratchedNumbers.Where(number => winningNumbers.Contains(number)))
                {
                    if (score is 0 or 1) score++;
                    else score *= 2;
                }

                sum += score;
            }

            return sum;
        }
    }
}
