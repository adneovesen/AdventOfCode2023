using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day00
{
    public class Test
    {
        public static int GetNumberOfLines(string path)
        {
            return File.ReadAllLines(path).Length;
        }
    }
}
