using static Calculator.Models.Calculator;

namespace Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData("1010", 2)]
    [InlineData("hello", 36)]
    [InlineData("4F", 16)]
    [InlineData("4f", 16)]
    [InlineData("56", 10)]
    public void TransferNumberToAnotherBase_ShouldReturnInput_WhenBasesAreEqual(string input, int inputBase)
    {
        var res = TransferNumberToAnotherBase(input, inputBase, inputBase);

        res.Should().Be(input.ToLower());
    }

    [Theory]
    [InlineData("1010", 2, 10, "10")]
    [InlineData("4d", 16, 2, "1001101")]
    [InlineData("hello", 25, 16, "68dfd9")]
    [InlineData("10101010", 2, 36, "4q")]
    public void TransferNumberToAnotherBase_ShouldReturnExpected(string input, int inputBase, int resultBase,
        string expected)
    {
        var res = TransferNumberToAnotherBase(input, inputBase, resultBase);

        res.Should().Be(expected);
    }
}