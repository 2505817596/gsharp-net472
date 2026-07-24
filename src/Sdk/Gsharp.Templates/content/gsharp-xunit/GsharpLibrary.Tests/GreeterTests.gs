// file: GreeterTests.gs
//
// xUnit tests written in GSharp. Test methods live inside a public class and
// carry Kotlin-style attribute applications (@Fact, @Theory, @InlineData) that
// gsc emits as the corresponding xUnit attributes, so the standard VSTest
// runner discovers and executes them through `dotnet test`.

包 GsharpLibrary.Tests

导入 Xunit
导入 GsharpLibrary

类 GreeterTests {
    @Fact
    函数 Greet_Returns_Hello_With_Name() {
        变 greeter = Greeter()

        Assert.Equal("Hello, World!", greeter.Greet("World"))
    }

    @Theory
    @InlineData("Alice", "Hello, Alice!")
    @InlineData("Bob", "Hello, Bob!")
    函数 Greet_Formats_Each_Name(name 字符串, expected 字符串) {
        变 greeter = Greeter()

        Assert.Equal(expected, greeter.Greet(name))
    }
}
