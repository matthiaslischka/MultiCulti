# MultiCulti

```c#
Console.WriteLine(endOfTheWorld.ToShortDateString()); // -> 12/31/1999

using (new CultureInfo("de-DE").AsCurrent())
{
    Console.WriteLine(endOfTheWorld.ToShortDateString()); // -> 31.12.1999
}

Console.WriteLine(endOfTheWorld.ToShortDateString()); // -> 12/31/1999

```
