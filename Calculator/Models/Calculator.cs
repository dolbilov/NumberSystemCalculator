using System;

namespace Calculator.Models;

public static class Calculator
{
    public static string TransferNumberToAnotherBase(string input, int inputBase, int resultBase)
    {
        if (inputBase == resultBase)
            return input;

        throw new NotImplementedException();
    }
}