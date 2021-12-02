using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static class Day01
    {
        public static void SolvePart1()
        {
            var input = File.ReadAllLines(Path.Combine("Input", "day01_part1.txt"));

            var increases = 0;
            var lastMeasure = -1;

            foreach (var line in input)
            {
                var measurement = int.Parse(line.Trim());
                if (lastMeasure == -1)
                {
                    lastMeasure = measurement;
                }
                else
                {
                    if (measurement > lastMeasure)
                    {
                        increases++;
                    }
                    lastMeasure = measurement;
                }
            }

            Console.WriteLine($"Total Increases: {increases}");

        }

        public static void SolvePart2()
        {
            var input = File.ReadAllLines(Path.Combine("Input", "day01_part1.txt"));
            List<ThreeMeasureWindow> readings = new();

            foreach (var item in input)
            {
                foreach (var reading in readings)
                {
                    if (reading.Measures != 3)
                    {
                        reading.Value += int.Parse(item);
                        reading.Measures++;
                    }
                }

                // create a new 3 measures instance
                var measure = new ThreeMeasureWindow();
                measure.Measures++;
                measure.Value += int.Parse(item);

                readings.Add(measure);

            }

            var increases = 0;
            var lastMeasure = -1;

            foreach (var reading in readings)
            {
                Console.WriteLine(reading.Value);
                if (lastMeasure == -1)
                {
                    lastMeasure = reading.Value;
                }
                else
                {
                    if (reading.Value > lastMeasure)
                    {
                        increases++;
                    }
                    lastMeasure = reading.Value;
                }
            }

            Console.WriteLine($"Total Increases: {increases}");
        }

        public class ThreeMeasureWindow
        {
            public int Value { get; set; } = 0;
            public int Measures { get; set; } = 0; // number of readings
        }
    }
}
