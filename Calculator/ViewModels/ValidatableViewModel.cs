using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Calculator.ViewModels;

public abstract class ValidatableViewModel : ViewModelBase, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<ValidationResult>> _validationErrors = new();

    public bool HasErrors => _validationErrors.Count > 0;

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
            return _validationErrors.Values.SelectMany(static errors => errors);

        if (_validationErrors.TryGetValue(propertyName, out var errors))
            return errors;

        return Enumerable.Empty<ValidationResult>();
    }
    
    protected void AddError(string propertyName, string errorMessage)
    {
        ArgumentException.ThrowIfNullOrEmpty(propertyName);

        if (_validationErrors.TryGetValue(propertyName, out var errors))
            errors.Add(new ValidationResult(errorMessage));
        else
            _validationErrors.Add(propertyName, new List<ValidationResult> { new(errorMessage) });

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }

    protected void ClearErrors(string propertyName = "")
    {
        if (string.IsNullOrEmpty(propertyName))
            _validationErrors.Clear();

        _validationErrors.Remove(propertyName);

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }
}