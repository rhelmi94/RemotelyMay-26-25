namespace RaefTech.Shared.Primitives;
public class NoopDisposable : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
