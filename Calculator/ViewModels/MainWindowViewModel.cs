using System.Globalization;
using ReactiveUI;

namespace Calculator.ViewModels;

public class MainWindowViewModel : ValidatableViewModel
{
    #region Fields

    private string? _firstNumber;
    private int _firstNumericSystem = 10;
    private string? _secondNumber;
    private int _secondNumericSystem = 10;

    #endregion


    public MainWindowViewModel()
    {
    }

    #region Properties

    public string? FirstNumber
    {
        get => _firstNumber;
        set => this.RaiseAndSetIfChanged(ref _firstNumber, value);
    }

    public int FirstNumericSystem
    {
        get => _firstNumericSystem;
        set => this.RaiseAndSetIfChanged(ref _firstNumericSystem, value);
    }

    public string? SecondNumber
    {
        get => _secondNumber;
        set => this.RaiseAndSetIfChanged(ref _secondNumber, value);
    }

    public int SecondNumericSystem
    {
        get => _secondNumericSystem;
        set => this.RaiseAndSetIfChanged(ref _secondNumericSystem, value);
    }

    public NumberFormatInfo NumberFormatInfo { get; } = new() { NumberDecimalDigits = 0 };

    #endregion
    
}