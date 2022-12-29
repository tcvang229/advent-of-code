using System;
using System.Collections.Generic;
using System.IO;

namespace Day2 
{
    internal class Program
    {
        public static Dictionary<string, string> ShapeCounters = new Dictionary<string, string>()
        {
            {"A", "paper"},
            {"B", "scissors"},
            {"C", "rock"}
        };

        public static Dictionary<string, int> ResultScores = new Dictionary<string, int>()
        {
            {"X", 0},
            {"Y", 3},
            {"Z", 6}
        };

        public static Dictionary<string, int> ShapeScores = new Dictionary<string, int>()
        {
            {"A", 1},
            {"B", 2},
            {"C", 3}
        };

        static void Main(string[] args)
        {
            // x = lose
            // y = tie
            // z = win

            // a = rock
            // b = paper
            // c = scissors

            string puzzleInputPath = "../input.txt";
            int runningScore = 0;
            using (StreamReader reader = File.OpenText(puzzleInputPath))
            {
                string readText = reader.ReadToEnd();

                string[] gameRounds = readText.Split("\n");
                foreach (string shapes in gameRounds)
                {
                    string[] shapesArray = shapes.Split(" ");

                    if (shapesArray.Length < 2) 
                    {
                        continue;
                    }

                    // result winnings
                    runningScore += ResultScores[shapesArray[1]];

                    // shape winnings
                    switch (shapesArray[1]) 
                    {
                        case "X":
                            runningScore += GetLosingShapePoints(shapesArray[0]);
                            break;
                        case "Y":
                            runningScore += GetTieShapePoints(shapesArray[0]);
                            break;
                        case "Z":
                            runningScore += GetWinningShapePoints(shapesArray[0]);
                            break;
                    }
                }

                Console.WriteLine(runningScore);
            }
        }

        private static int GetLosingShapePoints(string opponentShape) 
        {
            switch (opponentShape) 
            {
                case "A":
                    return 3;
                case "B":
                    return 1;
                case "C":
                    return 2;
            }

            return 0;
        }

        private static int GetTieShapePoints(string opponentShape) 
        {
            return ShapeScores[opponentShape];
        }

        private static int GetWinningShapePoints(string opponentShape) 
        {
            switch (opponentShape) 
            {
                case "A":
                    return 2;
                case "B":
                    return 3;
                case "C":
                    return 1;
            }

            return 0;
        }
    }
}