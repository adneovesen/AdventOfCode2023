using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day02
{
    public class CubeConundrum
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

            return lines.Aggregate(0, (current, line) => current + FewestGames(line));
        }

        public static int Solve(string path)
        {
            var lines = File.ReadAllLines(path);

            return lines.Aggregate(0, (current, line) => current + PossibleGames(line));
        }

        private static int PossibleGames(string line)
        {
            var games = line.Split(':',';');

            for (var i = 1; i < games.Length; i++)
            {
                var game = games[i].Trim().Split(' ');

                for (var j = 0; j < game.Length; j+=2)
                {
                    if (game[j + 1].StartsWith('r'))
                    {
                        if (int.Parse(game[j]) > 12) return 0;
                    } else if (game[j + 1].StartsWith('g'))
                    {
                        if (int.Parse(game[j]) > 13) return 0;
                    }
                    else if (game[j + 1].StartsWith('b'))
                    {
                        if (int.Parse(game[j]) > 14) return 0;
                    }
                }
            }
            return  int.Parse(games[0].Split(' ')[1]);
        }

        private static int FewestGames(string line)
        {
            var games = line.Split(':', ';');

            var red = 0;
            var green = 0;
            var blue = 0;

            for (var i = 1; i < games.Length; i++)
            {
                var game = games[i].Trim().Split(' ');

                for (var j = 0; j < game.Length; j += 2)
                {
                    if (game[j + 1].StartsWith('r'))
                    {
                        if (int.Parse(game[j]) > red) red = int.Parse(game[j]);
                    }
                    else if (game[j + 1].StartsWith('g'))
                    {
                        if (int.Parse(game[j]) > green) green = int.Parse(game[j]);
                    }
                    else if (game[j + 1].StartsWith('b'))
                    {
                        if (int.Parse(game[j]) > blue) blue = int.Parse(game[j]);
                    }
                }
            }
            return red * green * blue;
        }
    }
}
