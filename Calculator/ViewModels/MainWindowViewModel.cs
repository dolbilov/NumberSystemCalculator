using System;
using System.Globalization;
using Calculator.Models;
using ReactiveUI;

namespace Calculator.ViewModels;

public class MainWindowViewModel : ValidatableViewModel
{
    #region Fields

    private string? _input;
    private int _inputBase = 10;
    private string? _result;
    private int _resultBase = 10;

    #endregion


    public MainWindowViewModel()
    {
        this.WhenAnyValue(vm => vm.Input, vm => vm.InputBase, vm => vm.ResultBase)
            .Subscribe(_ => TransferNumberToAnotherBase());
    }


    #region Properties

    public string? Input
    {
        get => _input;
        set => this.RaiseAndSetIfChanged(ref _input, value);
    }

    public int InputBase
    {
        get => _inputBase;
        set => this.RaiseAndSetIfChanged(ref _inputBase, value);
    }

    public string? Result
    {
        get => _result;
        set => this.RaiseAndSetIfChanged(ref _result, value);
    }

    public int ResultBase
    {
        get => _resultBase;
        set => this.RaiseAndSetIfChanged(ref _resultBase, value);
    }

    public NumberFormatInfo NumberFormatInfo { get; } = new() { NumberDecimalDigits = 0 };

    #endregion


    #region Methods

    private void ValidateInput()
    {
        ClearErrors(nameof(Input));

        if (string.IsNullOrEmpty(Input))
            AddError(nameof(Input), "This field is required");
        else if (!NumberValidator.ValidateNumber(Input, InputBase))
            AddError(nameof(Input), $"Number is not invalid for {InputBase} base");
    }

    private void TransferNumberToAnotherBase()
    {
        ValidateInput();

        Result = HasErrors
            ? null
            : Models.Calculator.TransferNumberToAnotherBase(Input!, InputBase, ResultBase);
    }

    #endregion
}