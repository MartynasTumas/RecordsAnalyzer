using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RecordsAnalyzerLibrary
{
    public class InputHandler
    {
        public int ConvertStringToInt(string input)
        {
            int number = int.Parse(input);
            return number;
        }

        public List<string> SplitInputList(string input)
        {
            List<string> splittedInputArray = input.Split(" ").ToList();
            return splittedInputArray;
        }

        public List<int> ConvertStringListToIntList(List<string> splittedInputArray)
        {
            List<int> temperatures = new List<int>();
            foreach (string splittedInputItem in splittedInputArray)
            {
                int temp = 0;
                try
                {
                    temp = ConvertStringToInt(splittedInputItem);     
                }
                catch
                {
                    throw;
                }
                temperatures.Add(temp);
            }

            return temperatures;
        }

    }
}
