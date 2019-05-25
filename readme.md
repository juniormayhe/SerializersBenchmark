# SerializersBenchmark

### Ever wanted to know if Newtonsoft is slower than other packages such as Jil, NetJSON and ServiceStack?

![](https://media.giphy.com/media/MJGxL8fxrQBfq/giphy.gif)

Small list with primitive and nested complex types: 100 elements
Large list: 5000 elements

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i7-3632QM CPU 2.20GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview3-010431
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT


|                        Method |       Mean |     Error |    StdDev | Ratio | RatioSD | Rank |     Gen 0 |     Gen 1 |     Gen 2 |   Allocated |
|------------------------------ |-----------:|----------:|----------:|------:|--------:|-----:|----------:|----------:|----------:|------------:|
|                Jil_Small_List |   1.279 ms | 0.0251 ms | 0.0466 ms |  0.29 |    0.01 |    1 |         - |         - |         - |   456.64 KB |
|      NetJSONNative_Small_List |   1.451 ms | 0.0235 ms | 0.0197 ms |  0.34 |    0.01 |    2 |  181.6406 |   60.5469 |   31.2500 |   620.07 KB |
|            NetJSON_Small_List |   1.598 ms | 0.0252 ms | 0.0197 ms |  0.37 |    0.01 |    3 |  197.2656 |   60.5469 |   33.2031 |   675.45 KB |
| ServiceStackNative_Small_List |   4.243 ms | 0.1037 ms | 0.2890 ms |  1.02 |    0.08 |    4 |         - |         - |         - |    671.3 KB |
|         Newtonsoft_Small_List |   4.294 ms | 0.0807 ms | 0.0792 ms |  1.00 |    0.00 |    4 |         - |         - |         - |   606.36 KB |
|       ServiceStack_Small_List |   4.858 ms | 0.1297 ms | 0.1274 ms |  1.13 |    0.03 |    5 |         - |         - |         - |   694.09 KB |
|                 Jil_Long_List |  73.653 ms | 1.3107 ms | 1.1619 ms | 17.16 |    0.48 |    6 | 2000.0000 | 1000.0000 |         - | 23938.82 KB |
|       NetJSONNative_Long_List |  90.130 ms | 1.1356 ms | 0.9483 ms | 20.98 |    0.52 |    7 | 4666.6667 | 1000.0000 |  333.3333 | 32737.75 KB |
|             NetJSON_Long_List | 101.670 ms | 1.9465 ms | 1.8207 ms | 23.70 |    0.76 |    8 | 5000.0000 | 1500.0000 |  500.0000 | 35490.75 KB |
|  ServiceStackNative_Long_List | 208.560 ms | 3.9748 ms | 5.0269 ms | 48.51 |    1.51 |    9 | 7000.0000 | 1000.0000 |         - | 34170.24 KB |
|        ServiceStack_Long_List | 234.847 ms | 5.2629 ms | 8.3475 ms | 54.82 |    2.14 |   10 | 7000.0000 | 1000.0000 |         - | 34172.01 KB |
|          Newtonsoft_Long_List | 262.506 ms | 5.1590 ms | 6.1414 ms | 61.36 |    1.32 |   11 | 5000.0000 | 3000.0000 | 1000.0000 | 31086.63 KB |
```

### Conclusions

- Serialized ouputs of each library are different! So if you need to migrate existing solution from Newtonsoft to NetJSON or Jil, you might loose some data (in case you have serialized strings persisted in any batabase) due to how these frameworks behave during serialization with date format, nullable types, etc
- Currently Jil converts an enum item to its string representation, DeliveryType.OneWeek becomes "OneWeek". In Newtonsoft DeliveryType.OneWeek becomes 0. Jil Options class does not offer an option to serialize enums output as integers just by using Serialize method. 
- An ugly workaround to make Jil serialzie enum as int value would be add it `[EnumMember(Value="0")] OneWeek = 0`, but that does not work and it generates a string as in "DeliveryType": "0" and not "DeliveryType": 0 as Newtonsoft. System.Runtime has no way of setting EnumMember as an int value (it seems).
- NetJSON currently is not converting nullable int (int? PreferredCurrencyId) to null. So in NetJSON, serialized string becomes "PreferredCurrencyId": 0 instead of "PreferredCurrencyId": null as in Jil and Newtonsoft.
- If you do not care so much of null you can stick with NetJSON
- If you do not care about enums, you can stick with Jil
- If you do not care of processing time, you can still use Newtonsoft. It is said that to improve its performance you must create custom mapping, which may represent too many extra lines of code in your solution
- Using NetJSON and ServiceStack with their native serialization settings seems faster than tweaking their configurations.
- NetJSON eats more RAM for long list (5000 elements), followed by ServiceStack and Newtonsoft. Jil uses less RAM!
- For small or large lists, Newtonsoft :snail: and ServiceStack :turtle: are slowest ones. Our question has been answered!

### How about others serializers?

- ZeroFormatter not included since we must add custom attributes to DTOs :-O
- Hyperion not included since issues are not being resolved or answered by contributors
- Microsoft Bond and Google Protocolbuf not included since you would need to add extra schema / model files to make data platform independent
