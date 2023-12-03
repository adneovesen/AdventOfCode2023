// See https://aka.ms/new-console-template for more information

using AdventOfCode2023.Day00;
using AdventOfCode2023.Day01;
using AdventOfCode2023.Day02;
using AdventOfCode2023.Day03;


// Initial Test
var path = @"..\..\..\Day00\sample.txt";
Console.WriteLine($"Number of lines in sample.txt {Test.GetNumberOfLines(path)}");

// Day 1
path = @"..\..\..\Day01\input.txt";
Console.WriteLine($"What is the sum of all of the calibration values? {Trebuchet.PartOne(path)}");
Console.WriteLine($"What is the sum of all of the calibration values? {Trebuchet.PartTwo(path)}");

// Day 2
path = @"..\..\..\Day02\input.txt";
Console.WriteLine($"What is the sum of the IDs of those games? {CubeConundrum.PartOne(path)}");
Console.WriteLine($"What is the sum of the power of these sets? {CubeConundrum.PartTwo(path)}");

// Day 3
path = @"..\..\..\Day03\input.txt";
Console.WriteLine($"What is the sum of all of the part numbers in the engine schematic? {GearRatios.PartOne(path)}"); 
Console.WriteLine($"What is the sum of all of the gear ratios in your engine schematic? {GearRatios.PartTwo(path)}");