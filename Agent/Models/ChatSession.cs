﻿using System.IO.Pipes;

namespace RaefTech.Agent.Models;

public class ChatSession
{
    public int ProcessID { get; set; }
    public NamedPipeClientStream? PipeStream { get; set; }
}
