using RecordsAnalyzerLibrary;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecordsAnalyzerUnitTests
{
    public class ValidatorUnitTests
    {
        Validator validator;
        List<string> temperaturesStringList;
        List<int> temperatures;
        int minTemp;
        int maxTemp;
        public ValidatorUnitTests()
        {
            validator = new Validator();

            temperaturesStringList = new List<string> { "1", "-2", "-8", "4", "5" };
            temperatures = new List<int> { 1, -2, -8, 4, 5 };

            minTemp = -273;
            maxTemp = 5526;
        }

        //Boundary value testing
        [InlineData(-1, 0, 10000, false)]
        [InlineData(0, 0, 10000, true)]
        [InlineData(1, 0, 10000, true)]
        [InlineData(5, 0, 10000, true)]
        [InlineData(9999, 0, 10000, true)]
        [InlineData(10000, 0, 10000, false)]
        [Theory]
        private void ValidateNoToAnalyze(int noToValidate, int minValue, int maxValue, bool shouldSucceed)
        {
            bool isValid = validator.ValidateNoToAnalyze(noToValidate, minValue, maxValue);

            if (shouldSucceed)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }

        //Boundary value testing
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [Theory]
        private void ValidateListCount(int noToValidate, bool shouldSucceed)
        {
            bool isValid = validator.ValidateListCount(temperaturesStringList, noToValidate);

            if (shouldSucceed)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }

        [Fact]
        private void ValidateLowestValue()
        {
            bool isValid = validator.ValidateLowestValue(temperatures, minTemp);

            Assert.True(isValid);
        }

        [Fact]
        private void ValidateHighestValue()
        {
            bool isValid = validator.ValidateHighestValue(temperatures, maxTemp);

            Assert.True(isValid);
        }
    }
}
