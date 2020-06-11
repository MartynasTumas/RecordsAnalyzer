using RecordsAnalyzerLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RecordsAnalyzerUnitTests
{
    public class InputHandlerUnitTests
    {
        InputHandler inputHandler;
        List<string> temperaturesStringListSucceed;
        List<string> temperaturesStringListFail;

        public InputHandlerUnitTests()
        {
            inputHandler = new InputHandler();
            temperaturesStringListSucceed = new List<string> { "1", "-2", "-8", "4", "5" };
            temperaturesStringListFail = new List<string> { "a", "b", "c", "d", "e" };
        }

        [Fact]
        private void SucceedConvertStringToInt()
        {
            int result = inputHandler.ConvertStringToInt("1");
            Assert.Equal(1, result);
        }

        [Fact]
        private void FailConvertStringToInt()
        {
            Assert.Throws<FormatException>(() => inputHandler.ConvertStringToInt("a"));
        }

        [Fact]
        private void SucceedSplitInputList()
        {
            List<string> result = inputHandler.SplitInputList("1 -2 -8 4 5");
            Assert.Equal(5, result.Count);
        }

        [Fact]
        private void FailSplitInputList()
        {
            List<string> result = inputHandler.SplitInputList("1  -2  -8  4  5");// double spaces
            Assert.NotEqual(5, result.Count);
        }

        [Fact]
        private void SucceedConvertStringListToIntList()
        {
            List<int> result = inputHandler.ConvertStringListToIntList(temperaturesStringListSucceed);
            Assert.Equal(temperaturesStringListSucceed.Count, result.Count);
        }

        [Fact]
        private void FailConvertStringListToIntList()
        {
            Assert.Throws<FormatException>(() => inputHandler.ConvertStringListToIntList(temperaturesStringListFail));
        }
    }
}
