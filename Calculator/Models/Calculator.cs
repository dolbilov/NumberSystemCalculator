using System;
using System.Linq;
using System.Text;

namespace Calculator.Models;

public static class Calculator
{
    public const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyz";
    private const string ErrorMessage = "Can't convert this number";

    public static string TransferNumberToAnotherBase(string input, int inputBase, int resultBase)
    {
        input = input.ToLower();
        
        if (inputBase == resultBase)
            return input;

        try
        {
            var decimalValue = ConvertToDecimalBase(input, inputBase);
            return ConvertFromDecimalBase(decimalValue, resultBase);
        }
        catch (Exception e)
        {
            return ErrorMessage;
        }
    }

    private static long ConvertToDecimalBase(string input, int inputBase)
    {
        long res = 0;
        var len = input.Length;

        for (var i = 0; i < len; i++)
        {
            var symbol = input[i];
            var value = Alphabet.IndexOf(symbol);

            res += value * (long)Math.Pow(inputBase, len - i - 1);
        }

        return res;
    }

    private static string ConvertFromDecimalBase(long inputNumber, int resultBase)
    {
        StringBuilder sb = new();

        while (inputNumber > 0)
        {
            var value = (int)inputNumber % resultBase;
            var symbol = Alphabet[value];
            
            sb.Append(symbol);
            inputNumber /= resultBase;
        }

        return ReverseString(sb.ToString());
    }

    private static string ReverseString(string s)
    {
        var arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}