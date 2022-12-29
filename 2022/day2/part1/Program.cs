using System;
using System.Collections.Generic;
using System.IO;

namespace Day2 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // calculate all my points

            // determine who wins
            // add points

            // Counters as in weaknesses, or opponents to lose to.
            Dictionary<string, string> ShapeCounters = new Dictionary<string, string>()
            {
                {"A", "Y"},
                {"B", "Z"},
                {"C", "X"},
                {"X", "B"},
                {"Y", "C"},
                {"Z", "A"}
            };

            // x = rock
            // y = paper
            // z = scissors

            // a = rock
            // b = paper
            // c = scissors

            Dictionary<string, string> ShapeEqualParts = new Dictionary<string, string>()
            {
                {"X", "A"},
                {"Y", "B"},
                {"Z", "C"}
            };

            string puzzleInputPath = "../input.txt";
            int runningScore = 0;
            using (StreamReader reader = File.OpenText(puzzleInputPath))
            {
                string readText = reader.ReadToEnd();

                string[] gameRounds = readText.Split("\n");
                Console.WriteLine(gameRounds.Length);
                foreach (string shapes in gameRounds)
                {
                    string[] shapesArray = shapes.Split(" ");

                    if (shapesArray.Length < 2) 
                    {
                        continue;
                    }

                    switch (shapesArray[1])
                    {
                        case "X":
                            runningScore+= 1;
                            break;

                        case "Y":
                            runningScore+= 2;
                            break;

                        case "Z":
                            runningScore+= 3;
                            break;
                        default:
                            Console.WriteLine("hit");
                            break;
                    }

                    if (ShapeEqualParts[shapesArray[1]] == shapesArray[0]) 
                    {
                        runningScore+= 3;
                        continue;
                    }

                    if (ShapeCounters[shapesArray[1]] != shapesArray[0]) 
                    {
                        // Winning case
                        runningScore+= 6;
                    }
                }

                Console.WriteLine(runningScore);
            }
        }
    }
}