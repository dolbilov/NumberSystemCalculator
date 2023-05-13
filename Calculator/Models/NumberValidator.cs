using System;
using System.Text.RegularExpressions;

namespace Calculator.Models;

public static class NumberValidator
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyz";
    private const int MinAllowedBase = 2;
    private static readonly int MaxAllowedBase = Alphabet.Length;

    public static bool ValidateNumber(string number, int numberBase)
    {
        if (numberBase > MaxAllowedBase || numberBase < MinAllowedBase)
            throw new ArgumentOutOfRangeException(nameof(numberBase),
                $"Number base must be from {MinAllowedBase} to {MaxAllowedBase}");

        return GetValidationRegex(numberBase).IsMatch(number);
    }

    private static string GetAllowedSymbols(int numberBase) => Alphabet[..numberBase];

    private static Regex GetValidationRegex(int numberBase) =>
        new($"^[{GetAllowedSymbols(numberBase)}]+$", RegexOptions.IgnoreCase);
}