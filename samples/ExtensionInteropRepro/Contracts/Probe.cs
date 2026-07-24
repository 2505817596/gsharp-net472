namespace InteropRepro;

public interface IProbe
{
}

public sealed class Probe : IProbe
{
}

public static class Factory
{
    public static IProbe Create() => new Probe();
}
