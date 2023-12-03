using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2023.Day03
{
    public class GearRatios
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

            var sum = 0;
            var star = '*';

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var currentNumber = "";
                var adjacent = false;
                for (var j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    char adjacentChar;
                    if (character == star)
                    {
                        // check line above
                        var numbers = new List<string>();
                        var number = "";
                        if (i > 0)
                        {
                            if (j > 0)
                            {
                                adjacentChar = lines[i - 1][j - 1];
                                if (char.IsDigit(adjacentChar))
                                {
                                    if (j - 1 > 0)
                                    {
                                        if(char.IsDigit(lines[i - 1][j - 2]))
                                        {
                                            if (j - 2 > 0)
                                            {
                                                if (char.IsDigit(lines[i - 1][j - 3]))
                                                {
                                                    number += lines[i - 1][j - 3];
                                                }
                                            }
                                            number += lines[i - 1][j - 2];
                                        }
                                    }
                                    number += lines[i - 1][j - 1];
                                }
                            }

                            adjacentChar = lines[i - 1][j];
                            if (char.IsDigit(adjacentChar))
                            {
                                number += adjacentChar;
                            }
                            else
                            {
                                if (number.Length > 0)
                                {
                                    numbers.Add(number);
                                    number = "";
                                }
                            }

                            if (j < line.Length - 1)
                            {
                                adjacentChar = lines[i - 1][j + 1];
                                if (char.IsDigit(adjacentChar))
                                {
                                    number += lines[i - 1][j + 1];
                                    if (j < line.Length - 2)
                                    {
                                        if (char.IsDigit(lines[i - 1][j + 2]))
                                        {
                                            number += lines[i - 1][j + 2];
                                            if (j < line.Length - 3)
                                            {
                                                if (char.IsDigit(lines[i - 1][j + 3]))
                                                {
                                                    number += lines[i - 1][j + 3];
                                                }
                                            }
                                        }
                                    }
                                    

                                    numbers.Add(number);
                                    number = "";
                                }
                                if (number.Length > 0)
                                {
                                    numbers.Add(number);
                                    number = "";
                                }
                            }
                            else
                            {
                                if (number.Length > 0)
                                {
                                    numbers.Add(number);
                                    number = "";
                                }
                            }
                        }

                        // check line 
                        if (j > 0)
                        {
                            adjacentChar = lines[i][j - 1];
                            if (char.IsDigit(adjacentChar))
                            {
                                if (j - 1 > 0)
                                {
                                    if (char.IsDigit(lines[i][j - 2]))
                                    {
                                        if (j - 2 > 0)
                                        {
                                            if (char.IsDigit(lines[i][j - 3]))
                                            {
                                                number += lines[i][j - 3];
                                            }
                                        }
                                        number += lines[i][j - 2];
                                    }
                                }
                                number += lines[i][j - 1];

                                numbers.Add(number);
                                number = "";
                            }
                        }

                        if (j < line.Length - 1)
                        {
                            adjacentChar = lines[i][j + 1];
                            if (char.IsDigit(adjacentChar))
                            {
                                number += lines[i][j + 1];

                                if (j < line.Length - 2)
                                {
                                    if (char.IsDigit(lines[i][j + 2]))
                                    {
                                        number += lines[i][j + 2];

                                        if (j < line.Length - 3)
                                        {
                                            if (char.IsDigit(lines[i][j + 3]))
                                            {
                                                number += lines[i][j + 3];
                                            }
                                        }
                                    }
                                }

                                numbers.Add(number);
                                number = "";
                            }
                        }

                        // check line below
                        if (i < lines.Length - 1)
                        {
                            if (j > 0)
                            {
                                adjacentChar = lines[i + 1][j - 1];
                                if (char.IsDigit(adjacentChar))
                                {
                                    if (j - 1 > 0)
                                    {
                                        if (char.IsDigit(lines[i + 1][j - 2]))
                                        {
                                            if (j - 2 > 0)
                                            {
                                                if (char.IsDigit(lines[i + 1][j - 3]))
                                                {
                                                    number += lines[i + 1][j - 3];
                                                }
                                            }
                                            number += lines[i + 1][j - 2];
                                        }
                                    }
                                    number += lines[i + 1][j - 1];
                                }
                            }

                            adjacentChar = lines[i + 1][j];
                            if (char.IsDigit(adjacentChar))
                            {
                                number += adjacentChar;
                            }
                            else
                            {
                                if (number.Length > 0)
                                {
                                    numbers.Add(number);
                                    number = "";
                                }
                            }

                            if (j < line.Length - 1)
                            {
                                adjacentChar = lines[i + 1][j + 1];
                                if (char.IsDigit(adjacentChar))
                                {
                                    number += lines[i + 1][j + 1];

                                    if (j < line.Length - 2)
                                    {
                                        if (char.IsDigit(lines[i + 1][j + 2]))
                                        {
                                            number += lines[i + 1][j + 2];

                                            if (j < line.Length - 3)
                                            {
                                                if (char.IsDigit(lines[i + 1][j + 3]))
                                                {
                                                    number += lines[i + 1][j + 3];
                                                }
                                            }
                                        }
                                    }

                                    numbers.Add(number);
                                    number = "";
                                }
                                if (number.Length > 0)
                                {
                                    numbers.Add(number);
                                    number = "";
                                }
                            }
                            else
                            {
                                if (number.Length > 0)
                                {
                                    numbers.Add(number);
                                    number = "";
                                }
                            }
                        }

                        if (numbers.Count == 2)
                        {
                            sum += numbers.Aggregate(1, (current, num) => current * int.Parse(num));
                        }

                    }


                }
            }

            return sum;
        }

        private static int Solve(string path)
        {
            var lines = File.ReadAllLines(path);

            var sum = 0;

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var currentNumber = "";
                var adjacent = false;
                for (var j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    if (char.IsDigit(character))
                    {
                        currentNumber += character;

                        // check line above
                        adjacent = CheckLineAbove(i, j, lines, adjacent, line);

                        // check line below
                        adjacent = CheckLineBelow(i, lines, j, adjacent, line);

                        // check line
                        adjacent = CheckSameLine(j, lines, i, adjacent, line);
                    }
                    else
                    {
                        if (adjacent)
                        {
                            sum += int.Parse(currentNumber);
                            adjacent = false;
                        }

                        currentNumber = "";
                    }

                    //end of line check
                    if (j + 1 != line.Length) continue;
                    if (adjacent)
                    {
                        sum += int.Parse(currentNumber);
                        adjacent = false;
                    }

                    currentNumber = "";
                }
            }

            return sum;
        }

        private static bool CheckSameLine(int j, string[] lines, int i, bool adjacent, string line)
        {
            char adjacentChar;
            if (j > 0)
            {
                adjacentChar = lines[i][j - 1];
                if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                {
                    adjacent = true;
                }
            }

            if (j < line.Length - 1)
            {
                adjacentChar = lines[i][j + 1];
                if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                {
                    adjacent = true;
                }
            }

            return adjacent;
        }
        private static bool CheckLineBelow(int i, string[] lines, int j, bool adjacent, string line)
        {
            char adjacentChar;
            if (i < lines.Length -1)
            {
                if (j > 0)
                {
                    adjacentChar = lines[i + 1][j - 1];
                    if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                    {
                        adjacent = true;
                    }
                }

                adjacentChar = lines[i + 1][j];
                if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                {
                    adjacent = true;
                }

                if (j < line.Length -1)
                {
                    adjacentChar = lines[i + 1][j + 1];
                    if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                    {
                        adjacent = true;
                    }
                }
            }

            return adjacent;
        }

        private static bool CheckLineAbove(int i, int j, string[] lines, bool adjacent, string line)
        {
            char adjacentChar;
            if (i > 0)
            {
                if (j > 0)
                {
                    adjacentChar = lines[i - 1][j - 1];
                    if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                    {
                        adjacent = true;
                    }
                }

                adjacentChar = lines[i - 1][j];
                if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                {
                    adjacent = true;
                }

                if (j < line.Length - 1)
                {
                    adjacentChar = lines[i - 1][j + 1];
                    if ((!char.IsDigit(adjacentChar) && adjacentChar != '.') || adjacent)
                    {
                        adjacent = true;
                    }
                }
            }

            return adjacent;
        }
    }
}
