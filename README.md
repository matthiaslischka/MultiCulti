# MultiCulti
[![](https://github.com/matthiaslischka/MultiCulti/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/matthiaslischka/MultiCulti/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/nuget/v/MultiCulti)](https://www.nuget.org/packages/MultiCulti/)


```powershell  
PM> Install-Package MultiCulti
```

```c#
Console.WriteLine(endOfTheWorld.ToShortDateString()); // -> 12/31/1999

using (new CultureInfo("de-DE").AsCurrent())
{
    Console.WriteLine(endOfTheWorld.ToShortDateString()); // -> 31.12.1999
}

Console.WriteLine(endOfTheWorld.ToShortDateString()); // -> 12/31/1999

```
