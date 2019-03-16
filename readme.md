# SerializersBenchmark

### Ever wanted to know if Newtonsoft is slower than other packages such as Jil and NetJSON?

```
BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.379 (1809/October2018Update/Redstone5)
Intel Core i7-3632QM CPU 2.20GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview3-010431
  [Host]     : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT


|                      Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Rank | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------------------------- |----------:|----------:|----------:|------:|--------:|-----:|------------:|------------:|------------:|--------------------:|
|              Jil_Small_List |  1.129 ms | 0.0135 ms | 0.0112 ms |  0.28 |    0.00 |    1 |           - |           - |           - |           433.62 KB |
|          NetJSON_Small_List |  1.291 ms | 0.0257 ms | 0.0228 ms |  0.32 |    0.01 |    2 |    142.5781 |     46.8750 |     46.8750 |           572.04 KB |
|       Newtonsoft_Small_List |  4.060 ms | 0.0448 ms | 0.0419 ms |  1.00 |    0.00 |    3 |    140.6250 |     46.8750 |     46.8750 |           561.45 KB |
|               Jil_Long_List | 11.809 ms | 0.2331 ms | 0.2948 ms |  2.91 |    0.09 |    4 |           - |           - |           - |          4240.83 KB |
|           NetJSON_Long_List | 13.429 ms | 0.1137 ms | 0.1008 ms |  3.31 |    0.05 |    5 |   1218.7500 |    687.5000 |    281.2500 |          5757.24 KB |
|        Newtonsoft_Long_List | 38.671 ms | 0.7616 ms | 0.9631 ms |  9.53 |    0.24 |    6 |   1000.0000 |           - |           - |          5546.44 KB |
```

### How about others serializers?

- ZeroFormatter not included since we must add custom attributes to DTOs
- Hyperion not included since issues are not being resolved or answered by contributors
- Microsoft Bond and Google Protocolbuf not included since you will have annoying platform independent scripts
