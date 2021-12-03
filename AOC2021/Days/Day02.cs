using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static class Day02
    {
        public static void SolvePart1()
        {
            var input = File.ReadAllLines(Path.Combine("Input", "day02.txt"));
            int horizontal = 0;
            int depth = 0;

            foreach (var item in input)
            {
                var data = item.Split(' ');
                var action = data[0];
                var value = data[1];

                if (action == "forward")
                {
                    horizontal += int.Parse(value);
                }
                else if (action == "down")
                {
                    depth += int.Parse(value);
                }
                else
                {
                    depth -= int.Parse(value);
                }
            }

            Console.WriteLine($"Horizontal: {horizontal} Depth: {depth}");
            Console.WriteLine($"Answer: {horizontal * depth}");
        }

        public static void SolvePart2()
        {
            var input = File.ReadAllLines(Path.Combine("Input", "day02.txt"));

            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var item in input)
            {
                var data = item.Split(' ');
                var action = data[0];
                var value = int.Parse(data[1]);

                Console.WriteLine($"{action} {value}");

                if (action == "forward")
                {
                    horizontal += value;
                    if (aim != 0)
                    {
                        depth += aim * value;
                    }
                }
                else if (action == "down")
                {
                    aim += value;
                }
                else
                {
                    aim -= value;
                }

                Console.WriteLine($"Forward: {horizontal} Depth: {depth} Aim: {aim}");
            }

            Console.WriteLine($"Horizontal: {horizontal} Depth: {depth}");
            Console.WriteLine($"Answer: {horizontal * depth}");

        }
    }
}
