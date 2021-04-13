using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SportzInteractive
{
    class Program
    {
        static void Main(string[] args)
        {
            var choice = string.Empty;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the Question Number you would like to test:");
                PrintQuestions();
                choice = Console.ReadLine();

                if (choice == "Q" || choice == "q")
                {
                    break;
                }

                int questionNumber;
                int.TryParse(choice, out questionNumber);

                switch (questionNumber)
                {
                    case 1:
                        Question1();
                        break;

                    case 2:
                        Console.Clear();
                        SportzInteractive.ValarMorghulis();
                        Console.WriteLine("Press 'Enter' for questions");
                        Console.ReadLine();
                        break;

                    case 3:
                        Question3();
                        break;
                    case 4:
                        Question4();
                        break;

                    case 5:
                        Question5();
                        break;

                    case 6:
                        Question6();
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("Iterating through Enum Colors\n\n");
                        SportzInteractive.IterateThroughEnum(typeof(Colors));
                        Console.WriteLine("Press 'Enter' for questions");
                        Console.ReadLine();
                        break;

                    case 8:
                        Question8();

                        break;
                    case 9:
                        Question9();
                        break;

                    case 10:
                        Question10();
                        break;

                    case 11:
                        Question11();
                        break;

                    case 12:
                        Question12();
                        break;
                }


            } while (true);

        }


        private static void InvalidChoice()
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Press Enter to restart...");
            Console.ReadLine();
        }

        private static void Question12()
        {
            Console.Clear();
            var lineups = new List<LineUp>()
                        {
                            new LineUp(){ PlayerId = 21,PlayerName= "Y. Chahal"},
                            new LineUp(){ PlayerId = 22,PlayerName= "Bhuvneshwar Kumar"},
                            new LineUp(){ PlayerId = 23,PlayerName= "Jasprit Bumrah"},
                            new LineUp(){ PlayerId = 24,PlayerName= "Hardik Pandya"},
                            new LineUp(){ PlayerId = 25,PlayerName= "Ravindra Jadeja"},
                            new LineUp(){ PlayerId = 26,PlayerName= "Mohammed Shami"}
                        };

            var bowlingStats = new List<BowlingStat>()
                        {
                            new BowlingStat(){PlayerId = 21, Wickets= 2},
                            new BowlingStat(){PlayerId = 22, Wickets= 1},
                            new BowlingStat(){PlayerId = 23, Wickets= 3},
                            new BowlingStat(){PlayerId = 26, Wickets= 1}
                        };

            SportzInteractive.DisplayPlayerStats(lineups, bowlingStats);
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question11()
        {
            Console.Clear();
            var teamDetails = new Team()
            {
                NameFull = "Sunrisers Hyderabad",
                NameShort = "SRH",
                Players = new Dictionary<string, TeamPlayer>()
            };

            teamDetails.Players.Add("5380", new TeamPlayer() { Position = "1", NameFull = "David Warner", IsCaptain = true });
            teamDetails.Players.Add("3722", new TeamPlayer() { Position = "2", NameFull = "Shikhar Dhawan", IsCaptain = false });
            /*
                We could simply decorate our Team class members with [JsonProperty] attribute and hard code the desired Json Proptery names 
                like [JsonProperty("Name_Full")], or write a custom Naming Strategy like below to avoid Magic Strings.
             */
            var json = JsonConvert.SerializeObject(teamDetails, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new PascalSnakeNamingStrategy(),
                    }
                });

            Console.WriteLine(json);
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question10()
        {
            Console.Clear();
            var team = new List<Player>()
                        {
                            new Player(){Batsman= "Virat Kholi", IsRetired= true},
                            new Player(){Batsman= "M.S. Dhoni",IsRetired = true},
                            new Player(){Batsman= "Hardik Pandya", IsRetired= true},
                            new Player(){Batsman= "Rohit Sharma", IsRetired= true},
                            new Player(){Batsman= "Sachin Tendulkar", IsRetired= false},
                            new Player(){Batsman= "Rahul Dravid", IsRetired= false},
                            new Player(){Batsman= "Sourav Ganguly", IsRetired= false},
                            new Player(){Batsman= "VVS Laxman", IsRetired= false}
                        };
            Console.WriteLine("Players list before updating retired flags:\n\t");
            team.ForEach(player => Console.WriteLine(player));
            SportzInteractive.ToggleIsRetiredFlag(ref team);
            Console.WriteLine($"Players list after updating retired flags:\n\t");
            team.ForEach(player => Console.WriteLine(player));
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question9()
        {
            Console.Clear();
            var team = new List<Player>()
                        {
                            new Player()
                            {
                                Batsman = "Virat Kholi",
                                RunsScored = 50,
                                StrikeRate = 78.30
                            },
                            new Player()
                            {
                                Batsman= "M.S.Dhoni",
                                RunsScored= 61,
                                StrikeRate= 58.90
                            },
                            new Player()
                            {
                                Batsman= "Rohit Sharma",
                                RunsScored= 13,
                                StrikeRate= 124.0
                            }
                    };

            var best = SportzInteractive.GetBestBattingMomentum(team);
            Console.WriteLine("The Batsman with the best batting momentum is:\n");
            Console.WriteLine(best);
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question8()
        {
            Console.Clear();
            Console.WriteLine("Please select one: ");
            Console.WriteLine("1. Square");
            Console.WriteLine("2. Rectangle");
            var input = Console.ReadLine();
            int selectedShape;
            if (!int.TryParse(input, out selectedShape))
            {
                InvalidChoice();
                return;
            }
            int length, width;
            if (selectedShape == 1)
            {
                Console.WriteLine("Please enter the square dimension:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out length))
                {
                    InvalidChoice();
                    return;
                }
                Console.WriteLine($"Area of square with sides {length} units is: {SportzInteractive.Area(length)} sq. units");
            }
            else if (selectedShape == 2)
            {
                Console.WriteLine("Please enter the rectangle's length:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out length))
                {
                    InvalidChoice();
                    return;
                }
                Console.WriteLine("Please enter the rectangle's breadth:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out width))
                {
                    InvalidChoice();
                    return;
                }
                Console.WriteLine($"Area of rectangle with length {length} units and breadth {width} units is: {SportzInteractive.Area(length, width)} sq. units");
            }
            else
                InvalidChoice();

            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question6()
        {
            Console.Clear();
            int power, number;
            Console.WriteLine("Please enter the number: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                InvalidChoice();
                return;
            }
            Console.WriteLine("Please enter the power:");
            input = Console.ReadLine();

            if (!int.TryParse(input, out power))
            {
                InvalidChoice();
                return;
            }
            Console.WriteLine($"{number} raised to the power {power} = {SportzInteractive.CalculatePower(number, power, 1)}");
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question5()
        {
            Console.Clear();
            Console.WriteLine("Enter radius of Circle:");
            double radius;
            var input = Console.ReadLine();
            if (!double.TryParse(input, out radius))
            {
                InvalidChoice();
                return;
            }
            Circle circle = new Circle(radius);
            var circumference = circle.Calculate(SportzInteractive.CalculateCircumference);
            Console.WriteLine($"Circumference of circle with radius of {radius} units is: {circumference}");
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question4()
        {
            Console.Clear();
            Console.WriteLine("Enter N: ");
            int number;
            var input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                InvalidChoice();
                return;
            }
            SportzInteractive.FibonacciSeries(number);
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void Question3()
        {
            Console.Clear();
            Console.WriteLine("Enter First Number (X):");
            int x, y;
            var input = Console.ReadLine();
            if (!int.TryParse(input, out x))
            {
                Console.WriteLine("Invalid Input!");
                Console.WriteLine("Press Enter to restart......");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter Second Number (Y):");
            input = Console.ReadLine();
            if (!int.TryParse(input, out y))
            {
                InvalidChoice();
                return;
            }
            SportzInteractive.SwapTwoNumbers(x, y);
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();

        }

        private static void Question1()
        {
            Console.Clear();
            List<int> numbers = new List<int>();
            Console.WriteLine("Please input your array: (Press Q to stop input)");
            var input = Console.ReadLine();
            while (!(input == "Q" || input == "q"))
            {
                int number;
                if (int.TryParse(input, out number))
                    numbers.Add(number);
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all even numbers is: {SportzInteractive.SumOfEven(numbers.ToArray())}");
            Console.WriteLine("Press 'Enter' for questions");
            Console.ReadLine();
        }

        private static void PrintQuestions()
        {
            Console.WriteLine("1. Given an array of integers, write a C# method to total all the values that are even numbers.");
            Console.WriteLine("2. Valar Morghulis Problem");
            Console.WriteLine("3. Swaping of two numbers without using a temp variable.");
            Console.WriteLine("4. Print Nth fibonacci number in series");
            Console.WriteLine("5. Delegates test.");
            Console.WriteLine("6. Calculate power of number using tail recursion");
            Console.WriteLine("7. Iterate through Enum values");
            Console.WriteLine("8. Use of Over loaded function to calculate an area of a square or a rectangle");
            Console.WriteLine("9. Get Best Batting Momentum from pre-defined array");
            Console.WriteLine("10. Update the “IsRetired” flag for all players, without using any loops.");
            Console.WriteLine("11. Json serialization.");
            Console.WriteLine("12. Display all players from lineup and their wickets");
            Console.WriteLine("Press 'Q' to exit.");
        }
    }

 
}
