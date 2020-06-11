using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordsAnalyzerLibrary
{
    public class Analyzer
    {
        public int ReturnClosestToZero(List<int> temperatures, int target)
        {
            int closest = int.MaxValue;
            int minDifference = int.MaxValue;

            foreach (var temperature in temperatures)
            {
                int difference = Math.Abs(temperature - target);
                if (minDifference > difference)
                {
                    minDifference = difference;
                    closest = temperature;
                }
                //If two numbers are equally close to zero, positive integer has to be considered closest to zero
                else if (minDifference == difference && temperature > 0)
                {
                    minDifference = difference;
                    closest = temperature;
                }
            }

            //Shorter way to do it but also slower
            //int closest = temperatures.OrderBy(x => Math.Abs(x - target)).First();

            return closest;
        }
    }
}
