﻿using RaefTech.Desktop.UI.Controls.Dialogs;

namespace RaefTech.Desktop.UI.Services;

public interface IDialogProvider
{
    Task<MessageBoxResult> Show(string message, string caption, MessageBoxType type);
}

internal class DialogProvider : IDialogProvider
{
    public async Task<MessageBoxResult> Show(string message, string caption, MessageBoxType type)
    {
        return await MessageBox.Show(message, caption, type);
    }
}
