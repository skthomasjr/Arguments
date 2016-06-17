# Arguments.NET
[![Build](https://ci.appveyor.com/api/projects/status/4nj8qmykpc7fulov?svg=true)](https://ci.appveyor.com/project/skthomasjr/arguments)
[![Release](https://img.shields.io/github/release/skthomasjr/Arguments.svg?maxAge=2592000)](https://github.com/skthomasjr/Arguments/releases)
[![NuGet](https://img.shields.io/nuget/v/Arguments.NET.svg)](https://www.nuget.org/packages/Arguments.NET)
[![License](https://img.shields.io/github/license/skthomasjr/Arguments.svg?maxAge=2592000)](LICENSE.md)
[![Author](https://img.shields.io/badge/author-Scott%20K.%20Thomas%2C%20Jr.-blue.svg?maxAge=2592000)](https://www.linkedin.com/in/skthomasjr)

Arguments.NET is a library for interacting with command-line arguments passed into a .NET application. The library features a fluent interface and has provisions for inversion of control (IoC).

The syntax is easy to read and manage and frees the implementer from plumbing issues such as case-sensative comparisons, argument separators, and argument processing flow and chaining.

```C#
/// This code will process arguments "-a:5" or "/d".
static int Main(string[] args)
{
  var processedArguments = Arguments.NewArguments(args, arguments)
    .AddArgument("a")
      .WithAction(parameter => { Console.WriteLine($"Argument 'a' processed with value: {parameter}"); })
    .AddArgument("d")
      .WithAction(parameter => { Console.WriteLine("Argument 'd' processed"); })
    .Process()
}
```
