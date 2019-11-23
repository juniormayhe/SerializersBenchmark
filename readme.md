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


BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.864 (1809/October2018Update/Redstone5)
Intel Core i7-3632QM CPU 2.20GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


|                        Method |       Mean |     Error |     StdDev | Ratio | RatioSD | Rank |     Gen 0 |     Gen 1 |     Gen 2 |   Allocated |
|------------------------------ |-----------:|----------:|-----------:|------:|--------:|-----:|----------:|----------:|----------:|------------:|
|           Utf8Json_Small_List |   1.227 ms | 0.0238 ms |  0.0341 ms |  0.29 |    0.01 |    1 |         - |         - |         - |   505.66 KB |
|                Jil_Small_List |   1.291 ms | 0.0234 ms |  0.0195 ms |  0.30 |    0.01 |    2 |         - |         - |         - |   476.81 KB |
|      NetJSONNative_Small_List |   1.370 ms | 0.0082 ms |  0.0068 ms |  0.32 |    0.01 |    3 |  181.6406 |   62.5000 |   31.2500 |   624.05 KB |
|            NetJSON_Small_List |   1.512 ms | 0.0354 ms |  0.0519 ms |  0.36 |    0.01 |    4 |         - |         - |         - |   684.64 KB |
|         Newtonsoft_Small_List |   4.270 ms | 0.0684 ms |  0.0640 ms |  1.00 |    0.00 |    5 |  171.8750 |   62.5000 |   31.2500 |   611.02 KB |
| ServiceStackNative_Small_List |   4.673 ms | 0.1659 ms |  0.4867 ms |  1.11 |    0.18 |    6 |  195.3125 |   50.7813 |   35.1563 |   669.51 KB |
|       ServiceStack_Small_List |   4.782 ms | 0.0955 ms |  0.1275 ms |  1.11 |    0.03 |    6 |         - |         - |         - |   698.56 KB |
|            Utf8Json_Long_List |  73.933 ms | 1.1771 ms |  1.1011 ms | 17.32 |    0.33 |    7 | 2000.0000 | 1000.0000 | 1000.0000 | 36053.55 KB |
|                 Jil_Long_List |  74.635 ms | 1.4341 ms |  1.8647 ms | 17.53 |    0.65 |    7 | 2000.0000 | 1000.0000 |         - | 24331.88 KB |
|       NetJSONNative_Long_List |  88.447 ms | 0.9068 ms |  0.8039 ms | 20.70 |    0.32 |    8 | 4833.3333 | 1000.0000 |  333.3333 | 32942.53 KB |
|             NetJSON_Long_List | 101.437 ms | 2.0043 ms |  2.3082 ms | 23.78 |    0.60 |    9 | 5000.0000 | 1166.6667 |  333.3333 | 35953.92 KB |
|        ServiceStack_Long_List | 232.742 ms | 3.9141 ms |  3.4698 ms | 54.47 |    1.23 |   10 | 7000.0000 | 1000.0000 |         - | 34392.33 KB |
|  ServiceStackNative_Long_List | 236.269 ms | 8.0832 ms | 23.3218 ms | 54.31 |    4.51 |   10 | 7000.0000 | 1000.0000 |         - | 34204.28 KB |
|          Newtonsoft_Long_List | 243.435 ms | 3.7751 ms |  3.3465 ms | 56.98 |    1.22 |   11 | 5000.0000 | 3000.0000 | 1000.0000 |  31493.3 KB |
```

### Serialized strings
Here the outputs produced by serializer methods of each framework. Some serializers might render different serialized strings.

| field name | datatype | value | newtonsoft | jil | netjson | service stack | utf8json |
|--|--|--|--|--|--|--|--|--|--|--|
|MerchantId| int | 145 | 145 | 145 | 145 | 145 | 145 |
|DeliveryType| enum | OneWeek = 0 | 0 | OneWeek| 0| 0 | OneWeek |
|RequestId| Guid | 98cced3c-5e67-48e3-875f-7ab4ad246655 | 98cced3c-5e67-48e3-875f-7ab4ad246655 | 98cced3c-5e67-48e3-875f-7ab4ad246655| 98cced3c-5e67-48e3-875f-7ab4ad246655| 98cced3c5e6748e3875f7ab4ad246655 | 98cced3c-5e67-48e3-875f-7ab4ad246655 |
|Created| DateTime | 2018-08-07T05:13:28.1340152 | /Date(1533615208134)/ | 2018-08-07T05:13:28.1340152| 2018-08-07T05:13:28.1340152| 2018-08-07T05:13:28.1340152 | 2018-08-07T05:13:28.1340152 |
|PreferredCurrencyId| int? | null | null | null | 0| null | null |
|HasOwnStock| bool? | null | null | null | false| null | null |

We can see that

- Currently Jil and UTF8Json convert an enum to its string representation, so DeliveryType.OneWeek becomes "OneWeek". The other serializers output 0. 
- As for this investigation, Jil cannot serialize the numeric representation as a string. To do so, you can add EnumMemberAttribute before the enum item declaration `[EnumMember(Value="0")] OneWeek = 0`, that will produce a serialized string as `"DeliveryType": "0"` and not `"DeliveryType": 0` as Newtonsoft.
- NetJSON cannot generate null for nullable int, nullable boolean (and perhaps other nullable types). So in NetJSON, nullable int is serialized as `"PreferredCurrencyId": 0`.

### Conclusions

- If you already have legacy databasese with serialized data and intend to migrate to a new serializer (i.e. from Newtonsoft to NetJSON or Jil), you might loose some data due to how these serializer frameworks behave during serialization with date format, nullable types, etc. Do some tests!
- If you do not care so much of null you can stick with NetJSON
- If you do not care about enums, you can stick with Jil
- If you do not care of processing time, you can stick to Newtonsoft. It is said that to improve its performance you must create custom mapping, which may represent too many extra lines of code in your solution
- Using NetJSON and ServiceStack with their native serialization settings seems faster than tweaking their configurations.
- NetJSON eats more RAM for long list (5000 elements), followed by ServiceStack and Newtonsoft. Jil uses less RAM!
- For small or large lists, Newtonsoft :snail: and ServiceStack :turtle: are slowest ones. Our question has been answered!

### How about others serializers?

- ZeroFormatter not included since we must add custom attributes to DTOs :-O
- Hyperion not included since issues are not being resolved or answered by contributors
- Microsoft Bond and Google Protocolbuf not included since you would need to add extra schema / model files to make data platform independent
