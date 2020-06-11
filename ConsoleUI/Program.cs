using RecordsAnalyzerLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Insert integer number of temperatures to analyze");
                InputHandler inputHandler = new InputHandler();
                Validator validator = new Validator();
                int target = 0;
                int minTemp = -273;
                int maxTemp = 5526;

                //get number of temperatures to analyze
                string input = Console.ReadLine();
                int noToAnalyze = 0;
                try
                {
                    noToAnalyze = inputHandler.ConvertStringToInt(input);
                }
                catch
                {
                    Console.WriteLine($"Provided input: {input} is not an integer number");
                    Console.WriteLine();
                    continue;
                }

                bool isValid = validator.ValidateNoToAnalyze(noToAnalyze, 0, 10000);
                if (!isValid)
                {
                    Console.WriteLine($"Number {noToAnalyze} is out of range. Must be between 0 and 10 000");
                    Console.WriteLine();
                    continue;
                }

                //get actual temperatures
                Console.WriteLine("Insert temperature values separated by ONE space character");
                input = Console.ReadLine();

                if(noToAnalyze==0 && string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("0");
                    Console.WriteLine();
                    continue;
                }

                List<string> temperaturesStringList = new List<string>();
                try
                {
                    temperaturesStringList = inputHandler.SplitInputList(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine();
                    continue;
                }

                isValid = validator.ValidateListCount(temperaturesStringList, noToAnalyze);

                if (!isValid)
                {
                    Console.WriteLine("Number of temperatures to analyze does not match with the actual number provided");
                    Console.WriteLine();
                    continue;
                }

                List<int> temperatures = null;
                try
                {
                    temperatures = inputHandler.ConvertStringListToIntList(temperaturesStringList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine();
                    continue;
                }

                if (temperatures == null)
                {
                    Console.WriteLine("No temperature values");
                    Console.WriteLine();
                    continue;
                }

                isValid = validator.ValidateLowestValue(temperatures, minTemp);
                if (!isValid)
                {
                    Console.WriteLine("Lowest temperature is out of range");
                    Console.WriteLine();
                    continue;
                }

                isValid = validator.ValidateHighestValue(temperatures, maxTemp);
                if (!isValid)
                {
                    Console.WriteLine("Highest temperature is out of range");
                    Console.WriteLine();
                    continue;
                }

                Analyzer analyzer = new Analyzer();

                int closest = analyzer.ReturnClosestToZero(temperatures, target);
                Console.WriteLine($"Closest to {target} temperature: {closest}");

                Console.ReadLine();
            }
        }
    }
}
