// See https://aka.ms/new-console-template for more information

using AdventOfCode2023.Day00;
using AdventOfCode2023.Day01;


// Initial Test
var path = "..\\..\\..\\Day00\\sample.txt";
Console.WriteLine($"Number of lines in sample.txt {Test.GetNumberOfLines(path)}");

// Day 1
path = "..\\..\\..\\Day01\\input.txt";
Console.WriteLine($"What is the sum of all of the calibration values? {Trebuchet.PartOne(path)}");
path = "..\\..\\..\\Day01\\input.txt";
Console.WriteLine($"What is the sum of all of the calibration values? {Trebuchet.PartTwo(path)}");
