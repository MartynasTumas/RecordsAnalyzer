using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordsAnalyzerLibrary
{
    public class Validator
    {
        public bool ValidateNoToAnalyze(int noToAnalyze, int minAmount, int maxAmount)
        {
            if (noToAnalyze >= minAmount && noToAnalyze < maxAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateListCount(List<string> temperatures, int noToAnalyze)
        {
            if (temperatures.Count == noToAnalyze)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateLowestValue(List<int> temperatures, int minTemp)
        {
            if (temperatures.Min(x => x) >= minTemp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateHighestValue(List<int> temperatures, int maxTemp)
        {
            if (temperatures.Max(x => x) <= maxTemp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
