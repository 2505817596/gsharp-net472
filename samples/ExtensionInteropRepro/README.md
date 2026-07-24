# G# / C# extension-method collision repro

This demo has three C# class libraries, one C# executable, and one G# executable:

- `Contracts` defines `IProbe` and `Factory`.
- `ExtensionProvider` defines `ProbeExtensions.Clear(this IProbe)`.
- `ExtensionShadow` (emitted as `AExtensionShadow.dll`) deliberately defines another `InteropRepro.ProbeExtensions`
  type, but without `Clear`, to model the duplicate extension-host type name
  involved in the `ClearProviders` failure.
- `CSharpApp` calls `Factory.Create().Clear()` successfully.
- `GsharpApp` makes the same call, but fails with `MissingMethodException`.

Run it from the repository root:

```powershell
dotnet run --project samples/ExtensionInteropRepro/CSharpApp/CSharpApp.csproj
# C# called the C# extension method.

dotnet run --project samples/ExtensionInteropRepro/GsharpApp/GsharpApp.gsproj
# Unhandled exception. System.MissingMethodException: Method not found:
# 'InteropRepro.IProbe InteropRepro.ProbeExtensions.Clear(InteropRepro.IProbe)'.
```

The G# output's `Clear` member reference targets `AExtensionShadow.dll`, even
though `Clear` is declared in `ExtensionProvider.dll`.
