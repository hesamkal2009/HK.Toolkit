using HK.Toolkit.Core;
using Shouldly;
using Xunit;

namespace HK.Toolkit.UnitTests.Core
{
    public class ExtensionsUnitTests
    {
        [Fact]
        public void WhenStringNumberIsGiven_ReturnsIntegerCorrectly()
        {
            int expected = 10;
            string given = "10";

            int result = given.To<int>();

            result.ShouldBe(expected);
        }

        [Fact]
        public void WhenStringBoolIsGiven_ReturnsBoolCorrectly()
        {
            bool expected = true;
            string given = "true";

            bool result = given.To<bool>();

            result.ShouldBe(expected);
        }

        [Fact]
        public void WhenArgumentsAreGiven_ReturnsCorrectPatternFilledByArguments()
        {
            string expected = "The number is: 10";
            string given = "The number is: {0}";

            string result = given.FillPattern(10);

            result.ShouldBe(expected);
        }
    }
}