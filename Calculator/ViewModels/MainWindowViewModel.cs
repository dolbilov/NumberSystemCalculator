using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace Calculator.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyDataErrorInfo
{
    #region Fields

    private readonly Dictionary<string, List<ValidationResult>> _validationErrors = new();
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

    #endregion

    public IEnumerable GetErrors(string? propertyName)
    {
        throw new NotImplementedException();
    }

    public bool HasErrors => _validationErrors.Count > 0;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    private void AddError(string propertyName, string errorMessage)
    {
        ArgumentException.ThrowIfNullOrEmpty(propertyName);

        if (_validationErrors.TryGetValue(propertyName, out var errors))
            errors.Add(new ValidationResult(errorMessage));
        else
            _validationErrors.Add(propertyName, new List<ValidationResult> { new(errorMessage) });

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }

    private void ClearErrors(string propertyName = "")
    {
        if (string.IsNullOrEmpty(propertyName))
            _validationErrors.Clear();

        _validationErrors.Remove(propertyName);

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }
    
}