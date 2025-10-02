using RaefTech.Shared.Models;
using System;

namespace RaefTech.Desktop.Core.Interfaces
{
    public interface ICursorIconWatcher
    {
        event EventHandler<CursorInfo> OnChange;

        CursorInfo GetCurrentCursor();
    }

}
