using RecordsAnalyzerLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RecordsAnalyzerUnitTests
{
    public class AnalyzerUnitTests
    {
        Analyzer analyzer;
        List<int> temperatures;
        int target;
        public AnalyzerUnitTests()
        {
            analyzer = new Analyzer();
            temperatures = new List<int> { 2, -2, -8, 4, 5 };
            target = 0;
        }

        [Fact]
        private void ReturnClosestToZero()
        {
            int result = analyzer.ReturnClosestToZero(temperatures, target);
            Assert.Equal(2, result);
        }
    }
}
