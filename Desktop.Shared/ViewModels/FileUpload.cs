﻿using RaefTech.Desktop.Shared.Reactive;

namespace RaefTech.Desktop.Shared.ViewModels;

public partial class FileUpload : ObservableObject
{
    public string FilePath
    {
        get => Get(defaultValue: string.Empty);
        set => Set(value);
    }


    public double PercentProgress
    {
        get => Get<double>();
        set => Set(value);
    }

    public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

    public string DisplayName => Path.GetFileName(FilePath);
}
