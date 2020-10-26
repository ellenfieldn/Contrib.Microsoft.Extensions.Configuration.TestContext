# Microsoft.Extensions.Configuration.Contrib.TestContext
Allows using TestContext for asp.net core configuration.. It is built on top of the Microsoft.Extensions.Configuration nuget package and supports .NET Core 2.0+ and .Net Framework 4.7+.

## Usage
1. Create your runsettings file and fill it with properties. Note that ":" is used as the delimiter.
```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <TestRunParameters>
    <Parameter name="NormalSetting" value="Value1" />
    <Parameter name="ComplexObject:PropertyOnObject" value="VarValueInProperty" />
  </TestRunParameters>
</RunSettings>
```

2. Add TestContext configuration
```csharp
var builder = new ConfigurationBuilder()
    .AddTestContext(testContext);
Configuration = builder.Build();
```

3. Use it like any other configuration source.
```csharp
// Like this
Assert.AreEqual("Value1", Configuration["NormalSetting"]);

// Or this
var appConfig = Configuration.GetSection("ComplexObject").Get<MyPoco>();
Assert.AreEqual("VarValueInProperty", appConfig.PropertyOnObject);
```

## Installation
### Prerequisites
.netcore 2.0+ OR .NET 4.7+
### Installation
Nuget:
`PM> Install-Package Microsoft.Extensions.Configuration.Contrib.TestContext`