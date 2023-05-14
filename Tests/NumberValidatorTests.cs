using Calculator.Models;

namespace Tests;

public class NumberValidatorTests
{
    [Theory]
    [InlineData("101010101", 2)]
    [InlineData("101010101", 10)]
    [InlineData("hello", 36)]
    [InlineData("HeLlo", 36)]
    [InlineData("4F", 16)]
    [InlineData("aB", 12)]
    public void ValidateNumber_ShouldReturnTrue_WhenNumberIsValid(string number, int numberBase)
    {
        var res = NumberValidator.ValidateNumber(number, numberBase);

        res.Should().BeTrue();
    }

    [Theory]
    [InlineData("-12", 10)]
    [InlineData("hello", 16)]
    [InlineData("4f", 15)]
    [InlineData("F4", 15)]
    [InlineData("567", 7)]
    [InlineData(":%:", 36)]
    [InlineData(" ", 36)]
    [InlineData("", 36)]
    public void ValidateNumber_ShouldReturnFalse_WhenNumberIsInvalid(string number, int numberBase)
    {
        var res = NumberValidator.ValidateNumber(number, numberBase);

        res.Should().BeFalse();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(37)]
    [InlineData(-1)]
    [InlineData(-4)]
    [InlineData(145)]
    [InlineData(-145)]
    public void ValidateNumber_ShouldThrowException_WhenBaseIsInvalid(int numberBase)
    {
        Action act = () => NumberValidator.ValidateNumber("0", numberBase);

        act.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
}