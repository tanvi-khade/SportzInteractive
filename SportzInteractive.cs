using System;
using System.Collections.Generic;
using System.Linq;

namespace SportzInteractive
{
    public static class SportzInteractive
    {
        public static int SumOfEven(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                if (item % 2 == 0)
                    sum += item;
            }

            return sum;
        }

        public static void ValarMorghulis()
        {

            for (int i = 1; i <= 100; i++)
            {
                bool isDivisibleByThree = i % 3 == 0;
                bool isDivisibleByFive = i % 5 == 0;
                if (isDivisibleByThree && isDivisibleByFive)
                {
                    Console.WriteLine("valar morghulis");
                    continue;
                }
                if (isDivisibleByThree)
                {
                    Console.WriteLine("valar");
                    continue;
                }
                if (isDivisibleByFive)
                {
                    Console.WriteLine("morghulis");
                    continue;
                }

                Console.WriteLine(i);
            }
        }

        public static void SwapTwoNumbers(int num1, int num2)
        {
            Console.WriteLine($"Original Numbers: x = {num1} y = {num2}");
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine($"After swapping Numbers: x = {num1} y = {num2}");

        }

        public static void FibonacciSeries(int n)
        {
            int a = 0, b = 1, c = 0;
            n -= 2;
            Console.Write("{0} {1}", a, b);
            for (int i = 0; i < n; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
            Console.WriteLine();
        }

        public static double CalculateCircumference(double radius)
        {
            return (2 * Math.PI * radius);
        }

        public static int CalculatePower(int number, int power, int product)
        {
            int x = power;

            if (x == 0)
            {
                return product;
            }

            return CalculatePower(number, x - 1, number * product);
        }

        public static void IterateThroughEnum(Type enumType)
        {
            foreach (var value in Enum.GetValues(enumType))
            {
                Console.WriteLine(value);
            }
        }

        public static int Area(int side)
        {
            return side * side;
        }

        public static int Area(int lenght, int width)
        {
            return lenght * width;
        }

        public static Player GetBestBattingMomentum(List<Player> players)
        {
            double higestMomentum = double.MinValue;

            var bestBatsman = new Player();

            foreach (var player in players)
            {
                var momentum = player.RunsScored * player.StrikeRate;
                if (momentum > higestMomentum)
                {
                    higestMomentum = momentum;
                    bestBatsman = player;
                }
            }

            return bestBatsman;
        }

        public static void ToggleIsRetiredFlag(ref List<Player> players)
        {
            players = players.Select(x => new Player()
            {
                Batsman = x.Batsman,
                IsRetired = !x.IsRetired
            }).ToList();
        }

        public static void DisplayPlayerStats(List<LineUp> lineUps, List<BowlingStat> stats)
        {
            var result = lineUps.GroupJoin(stats,
                        lineup => lineup.PlayerId,
                        stat => stat.PlayerId,
                        (line, stat) => new
                        {
                            line.PlayerId,
                            line.PlayerName,
                            Wickets = stat.FirstOrDefault() == null ? 0 : stat.FirstOrDefault().Wickets
                        });

            foreach (var player in result)
            {
                Console.WriteLine(player);
            }
        }
    }
}
