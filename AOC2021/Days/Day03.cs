using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static class Day03
    {
        public static void SolvePart1()
        {
            var input = File.ReadAllLines(Path.Combine("Input", "day03.txt"));
            var gammaRate = string.Empty;
            var epsilonRate = string.Empty;
            List<Bit> bits = GetBits(input.ToList());

            foreach (var bit in bits.OrderBy(x => x.Position))
            {
                if (bit.One > bit.Zero)
                {
                    gammaRate = $"{gammaRate}1";
                    epsilonRate = $"{epsilonRate}0";
                }
                else
                {
                    gammaRate = $"{gammaRate}0";
                    epsilonRate = $"{epsilonRate}1";
                }
            }

            Console.WriteLine($"GammaRate: {gammaRate} EpsilonRate: {epsilonRate}");
            var gammaRateDecimal = Convert.ToInt32(gammaRate, 2);
            var epsilonRateDecimal = Convert.ToInt32(epsilonRate, 2);
            Console.WriteLine($"GammaRate: {gammaRateDecimal} EpsilonRate: {epsilonRateDecimal}");
            Console.WriteLine($"Answer: {gammaRateDecimal * epsilonRateDecimal}");

        }

        public static void SolvePart2()
        {
            var input = File.ReadAllLines(Path.Combine("Input", "day03.txt"));
            var data = new List<string>();
            data = input.ToList();
            for (int i = 0; i < 12; i++)
            {
                var bits = GetBits(data);
                var posData = bits.Find(x => x.Position == i);
                if ((posData.One > posData.Zero) || (posData.One == posData.Zero))
                {
                    data = posData.OneValues.ToList();
                }
                else
                {
                    data = posData.ZeroValues.ToList();
                }
                if (data.Count == 1)
                {
                    break;
                }
            }
            var o2Rating = data[0];
            var o2RatingDecimal = Convert.ToInt32(data[0],2);
            Console.WriteLine($"O2 Generator Rating: {o2Rating} / {o2RatingDecimal}");
            data = input.ToList();
            for (int i = 0; i < 12; i++)
            {
                var bits = GetBits(data);
                var posData = bits.Find(x => x.Position == i);
                if ((posData.Zero < posData.One) || (posData.One == posData.Zero))
                {
                    data = posData.ZeroValues.ToList();
                }
                else
                {
                    data = posData.OneValues.ToList();
                }
                if (data.Count == 1)
                {
                    break;
                }
            }

            var co2Rating = data[0];
            var co2RatingDecimal = Convert.ToInt32(data[0], 2);
            Console.WriteLine($"CO2 Scrubber Rating: {co2Rating} / {co2RatingDecimal}");
            Console.WriteLine($"Answer: {o2RatingDecimal * co2RatingDecimal}");

        }

        private static List<Bit> GetBits(List<string> input)
        {
            List<Bit> bits = new();

            foreach (var line in input)
            {
                var data = line.ToCharArray();
                for (int i = 0; i < data.Length; i++)
                {
                    var bit = bits.FirstOrDefault(x => x.Position == i);
                    if (bit == null)
                    {
                        bit = new Bit()
                        {
                            Position = i
                        };
                        bits.Add(bit);
                    }

                    if (data[i] == '1')
                    {
                        bit.One++;
                        bit.OneValues.Add(line);
                    }
                    else
                    {
                        bit.Zero++;
                        bit.ZeroValues.Add(line);
                    }
                }
            }

            return bits;
        }

        public class Bit
        {
            public int Position { get; set; }
            public int One { get; set; }
            public int Zero { get; set; }

            public List<string> OneValues { get; set; }
            public List<string> ZeroValues { get; set; }

            public Bit()
            {
                OneValues = new List<string>();
                ZeroValues = new List<string>();
            }
        }
    }
}
