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
### How about others serializers?

- ZeroFormatter not included since we must add custom attributes to DTOs
- Hyperion not included since issues are not being resolved or answered by contributors
- Microsoft Bond and Google Protocolbuf not included since you will have annoying platform independent scripts
