# SerializersBenchmark

### Ever wanted to know if Newtonsoft is slower than other packages such as Jil and NetJSON?

Small list with primitive and nested complex types: 100 elements
Large list: 5000 elements

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i7-3632QM CPU 2.20GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview3-010431
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT


|                Method |       Mean |     Error |    StdDev | Ratio | RatioSD | Rank |     Gen 0 |     Gen 1 |     Gen 2 |   Allocated |
|---------------------- |-----------:|----------:|----------:|------:|--------:|-----:|----------:|----------:|----------:|------------:|
|        Jil_Small_List |   1.244 ms | 0.0241 ms | 0.0330 ms |  0.30 |    0.01 |    1 |         - |         - |         - |   456.63 KB |
|    NetJSON_Small_List |   1.537 ms | 0.0220 ms | 0.0206 ms |  0.37 |    0.01 |    2 |  197.2656 |   60.5469 |   33.2031 |    675.2 KB |
| Newtonsoft_Small_List |   4.200 ms | 0.0601 ms | 0.0533 ms |  1.00 |    0.00 |    3 |  171.8750 |   62.5000 |   31.2500 |   606.51 KB |
|         Jil_Long_List |  71.416 ms | 1.3603 ms | 1.2725 ms | 17.01 |    0.41 |    4 | 2000.0000 | 1000.0000 |         - | 23938.85 KB |
|     NetJSON_Long_List |  97.853 ms | 2.3910 ms | 2.2366 ms | 23.31 |    0.69 |    5 | 5000.0000 | 1400.0000 |  400.0000 | 35490.59 KB |
|  Newtonsoft_Long_List | 247.862 ms | 4.6033 ms | 4.3059 ms | 59.06 |    1.38 |    6 | 5000.0000 | 3000.0000 | 1000.0000 | 31087.89 KB |
```

### Conclusions

- Serialized ouputs of each library are different! So if you need to migrate existing solution from Newtonsoft to NetJSON or Jil, you might loose some data (in case you have serialized strings persisted in any batabase) due to how these frameworks behave during serialization with date format, nullable types, etc
- Currently Jil converts an enum item to its string representation, DeliveryType.OneWeek becomes "OneWeek". In Newtonsoft DeliveryType.OneWeek becomes 0. Jil Options class does not offer an option to serialize enums output as integers just by using Serialize method. 
- An ugly workaround to make Jil serialzie enum as int value would be add it `[EnumMember(Value="0")] OneWeek = 0`, but that does not work and it generates a string as in "DeliveryType": "0" and not "DeliveryType": 0 as Newtonsoft. System.Runtime has no way of setting EnumMember as an int value (it seems).
- NetJSON currently is not converting nullable int (int? PreferredCurrencyId) to null. So in NetJSON, serialized string becomes "PreferredCurrencyId": 0 instead of "PreferredCurrencyId": null as in Jil and Newtonsoft.
- If you do not care so much of null you can stick with NetJSON
- If you do not care about enums, you can stick with Jil
- If you do not care of processing time, you can still use Newtonsoft. It is said that to improve its performance you must create custom mapping, which may represent too many extra lines of code in your solution

### How about others serializers?

- ZeroFormatter not included since we must add custom attributes to DTOs :-O
- Hyperion not included since issues are not being resolved or answered by contributors
- Microsoft Bond and Google Protocolbuf not included since you would need to add extra schema / model files to make data platform independent
