package SingleLibraryInterop

import System
import ClassLibrary1

var a = A()
a.Call()
Console.WriteLine("G# called B.Call from ClassLibrary1.")
