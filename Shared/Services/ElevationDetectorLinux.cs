﻿using System.Runtime.InteropServices;

namespace RaefTech.Shared.Services;

public class ElevationDetectorLinux : IElevationDetector
{
    [DllImport("libc", SetLastError = true)]
    private static extern uint geteuid();

    public bool IsElevated()
    {
        return geteuid() == 0;
    }
}
