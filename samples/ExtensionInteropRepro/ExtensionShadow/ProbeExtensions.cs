using InteropRepro;

namespace InteropRepro;

// Deliberately has the same fully-qualified type name as ExtensionProvider's
// ProbeExtensions, but it does not define Clear.
public static class ProbeExtensions
{
    public static string Shadow(this IProbe probe) => "shadow";
}
