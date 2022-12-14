using System;
using System.IO;

namespace Day1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get and read file
            // put steam into a string
            // parse the string into an array

            string puzzleInputPath = "../puzzle-input.txt";
            List<int> topCalarieCounts = new List<int>();

            using (StreamReader reader = File.OpenText(puzzleInputPath)) {
                string readLine = reader.ReadToEnd();
                string[] individualCounts = readLine.Split("\n");

                int runningCalorieCount = 0;
                foreach (string calarieCount in individualCounts) {
                    if (string.IsNullOrEmpty(calarieCount)) {

                        topCalarieCounts.Add(runningCalorieCount);

                        runningCalorieCount = 0;
                        continue;
                    }

                    if (Int32.TryParse(calarieCount, out int count)) {
                        runningCalorieCount  += count;
                    }
                }
            }

            Console.WriteLine(GetTop3Calories(topCalarieCounts));
        }

        private static int GetTop3Calories(List<int> topCalorieCounts) {
            topCalorieCounts.Sort((a, b) => b.CompareTo(a));
            int topCaloriesSum = topCalorieCounts[0] + topCalorieCounts[1] + topCalorieCounts[2];
            return topCaloriesSum;
        }
    }
}
