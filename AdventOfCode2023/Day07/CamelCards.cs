using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day07
{
    public class CamelCards
    {
        public static long PartOne(string path)
        {
            return Solve(path);
        }

        public static long PartTwo(string path)
        {
            return SolvePartTwo(path);
        }

        private static long SolvePartTwo(string path)
        {
            var lines = File.ReadAllLines(path);

            var somethingChanged = true;

            while (somethingChanged)
            {
                somethingChanged = false;

                for (var i = 0; i < lines.Length - 1; i++)
                {
                    if (somethingChanged) _ = CompareHandsJoker(ref lines, i);
                    else
                    {
                        somethingChanged = CompareHandsJoker(ref lines, i);
                    }
                }
            }

            return CalculateResult(lines); 
        }

        private static bool CompareHandsJoker(ref string[] lines, int i)
        {
            var hand1 = CheckHandJoker(lines[i]);
            var hand2 = CheckHandJoker(lines[i + 1]);
            if (hand1 < hand2)
            {
                (lines[i], lines[i + 1]) = (lines[i + 1], lines[i]);
                return true;
            }
            if (hand1 != hand2) return false;

            for (var j = 0; j < 5; j++)
            {
                var val1 = GetValueJoker(lines[i], j);
                var val2 = GetValueJoker(lines[i + 1], j);
                if (val1 < val2)
                {
                    (lines[i], lines[i + 1]) = (lines[i + 1], lines[i]);
                    return true;
                }
                if (val1 == val2) continue;
                return false;
            }

            return false;
        }

        private static int CheckHandJoker(string line)
        {
            if (!line.Contains('J')) return CheckHand(line);

            var hand = line.Split(' ')[0];
            var distincts = hand.Distinct();
            var jCount = hand.Count(x  => x == 'J');
            switch (distincts.Count())
            {
                case 1:
                    return 20;
                case 2:
                    return 20;
                case 3:
                {
                    if (jCount is 2 or 3) return 19;

                    var someChar = 'J';
                    var k = 0;
                    while (someChar is 'J')
                    {
                        someChar = hand[k++];
                    }
                    var count = hand.Count(letter => someChar == letter) + jCount;

                    return count is 3 ? 18 : 19;
                }
                case 4:
                {
                    return 17;
                }
                default:
                {
                    return 15; 
                }
            }
        }


        private static long Solve(string path)
        {
            var lines = File.ReadAllLines(path);

            var somethingChanged = true;

            while (somethingChanged)
            {
                somethingChanged = false;

                for (var i = 0; i < lines.Length - 1; i++)
                {
                    if(somethingChanged) _ = CompareHands(ref lines, i);
                    else
                    {
                        somethingChanged = CompareHands(ref lines, i);
                    }
                }
            }

            return CalculateResult(lines);
        }

        private static long CalculateResult(string[] lines)
        {
            return lines.Select((t, i) => long.Parse(t.Split(' ')[1]) * (lines.Length - i)).Sum();
        }

        private static bool CompareHands(ref string[] lines, int i)
        {
            var hand1 = CheckHand(lines[i]);
            var hand2 = CheckHand(lines[i + 1]);
            if (hand1 < hand2)
            {
                (lines[i], lines[i + 1]) = (lines[i + 1], lines[i]);
                return true;
            }
            if (hand1 != hand2) return false;

            for (var j = 0; j < 5; j++)
            {
                var val1 = GetValue(lines[i], j);
                var val2 = GetValue(lines[i + 1], j);
                if (val1 < val2)
                {
                    (lines[i], lines[i + 1]) = (lines[i + 1], lines[i]);
                    return true;
                }
                if (val1 == val2) continue;
                return false;
            }

            return false;
        }

        private static int CheckHand(string line)
        {
            var hand = line.Split(' ')[0];
            var distincts = hand.Distinct();
            switch (distincts.Count())
            {
                case 1:
                    return 20;
                case 2:
                {
                    var someChar = hand[0];
                    var count = hand.Count(letter => someChar == letter);

                    return count is 2 or 3 ? 18 : 19;
                }
                case 3:
                {
                    var groups = hand.GroupBy(x => x).Select(x => new { Letter = x.Key, Count = x.Count() }).ToList();
                    var count = groups.Max(g2 => g2.Count);

                    return count is 3 ? 17 : 16;
                }
                case 4:
                    return 15;
                default:
                {
                    return 14;
                }
            }
        }

        private static int GetValue(string line, int position)
        {
            var character = line[position];

            return character switch
            {
                'A' => 14,
                'K' => 13,
                'Q' => 12,
                'J' => 11,
                'T' => 10,
                _ => (int)char.GetNumericValue(character)
            };
        }

        private static int GetValueJoker(string line, int position)
        {
            var character = line[position];

            return character switch
            {
                'A' => 14,
                'K' => 13,
                'Q' => 12,
                'J' => 1,
                'T' => 10,
                _ => (int)char.GetNumericValue(character)
            };
        }
    }
}
