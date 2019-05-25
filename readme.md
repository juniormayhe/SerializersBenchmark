# SerializersBenchmark

### Ever wanted to know if Newtonsoft is slower than other packages such as Jil and NetJSON?

```
BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.379 (1809/October2018Update/Redstone5)
Intel Core i7-3632QM CPU 2.20GHz(Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK = 3.0.100-preview3-010431

 [Host]     : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT[AttachedDebugger]
  DefaultJob : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT


|                      Method |      Mean | Rank | Allocated Memory/Op |
|---------------------------- |----------:|-----:|--------------------:|
|              Jil_Small_List |  1.129 ms |    1 |           433.62 KB |
|          NetJSON_Small_List |  1.291 ms |    2 |           572.04 KB |
|       Newtonsoft_Small_List |  4.060 ms |    3 |           561.45 KB |
|               Jil_Long_List | 11.809 ms |    4 |          4240.83 KB |
|           NetJSON_Long_List | 13.429 ms |    5 |          5757.24 KB |
|        Newtonsoft_Long_List | 38.671 ms |    6 |          5546.44 KB |
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
