using System.Globalization;
using ReactiveUI;

namespace Calculator.ViewModels;

public class MainWindowViewModel : ValidatableViewModel
{
    #region Fields

    private string? _input;
    private int _inputNumericSystem = 10;
    private string? _result;
    private int _outputNumberNumericSystem = 10;

    #endregion


    public MainWindowViewModel()
    {
    }

    #region Properties

    public string? Input
    {
        get => _input;
        set => this.RaiseAndSetIfChanged(ref _input, value);
    }

    public int InputNumericSystem
    {
        get => _inputNumericSystem;
        set => this.RaiseAndSetIfChanged(ref _inputNumericSystem, value);
    }

    public string? Result
    {
        get => _result;
        set => this.RaiseAndSetIfChanged(ref _result, value);
    }

    public int ResultNumericSystem
    {
        get => _outputNumberNumericSystem;
        set => this.RaiseAndSetIfChanged(ref _outputNumberNumericSystem, value);
    }

    public NumberFormatInfo NumberFormatInfo { get; } = new() { NumberDecimalDigits = 0 };

    #endregion
    
}