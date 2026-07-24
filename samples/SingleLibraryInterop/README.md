# One C# class library: `A` and `B`

`ClassLibrary1` contains only these two public types:

- `A`: the receiver type.
- `B`: declares the C# extension method `Call(this A)`.

The G# app calls `A().Call()` successfully:

```powershell
dotnet run --project samples/SingleLibraryInterop/GsharpApp/GsharpApp.gsproj
```

This is a control case, not a reproduction of `MissingMethodException`.
That failure requires two referenced assemblies to define the same fully
qualified extension-host type name; `A` and `B` alone cannot create that
assembly-identity collision.
