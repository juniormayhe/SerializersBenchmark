namespace SerializersBenchmark
{
    using System.Collections.Generic;

    using Application.DTOs;

    using AutoFixture;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Order;

    /// <summary>
    /// ZeroFormatter not included since we must add custom attributes to DTOs
    /// Hyperion not included since issues are not being resolved or answered by contributors
    /// Microsoft Bond and Google Protocolbuf not included since you will have annoying platform independent scripts
    /// </summary>
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class Serializers
    {
        private static IEnumerable<Merchant> smallList;
        private static IEnumerable<Merchant> longList;

        [GlobalSetup]
        public void Setup()
        {
            smallList = MerchantBuilder.BuildMerchants(100);
            longList = MerchantBuilder.BuildMerchants(5000);
        }

        [Benchmark(Baseline = true)]
        public void Newtonsoft_Small_List()
        {
            ISerializer newtonsoftSerializer = new NewtonsoftSerializer();
            string json = newtonsoftSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = newtonsoftSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Newtonsoft_Long_List()
        {
            ISerializer newtonsoftSerializer = new NewtonsoftSerializer();
            string json = newtonsoftSerializer.Serialize(longList);
            IEnumerable<Merchant> list = newtonsoftSerializer.Deserialize(json);
        }

        [Benchmark]
        public void NetJSON_Small_List()
        {
            ISerializer netJsonSerializer = new NetJSONSerializer();
            string json = netJsonSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = netJsonSerializer.Deserialize(json);
        }

        [Benchmark]
        public void NetJSON_Long_List()
        {
            ISerializer netJsonSerializer = new NetJSONSerializer();
            string json = netJsonSerializer.Serialize(longList);
            IEnumerable<Merchant> list = netJsonSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Jil_Small_List()
        {
            ISerializer jilSerializer = new JilSerializer();
            string json = jilSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = jilSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Jil_Long_List()
        {
            ISerializer jilSerializer = new JilSerializer();
            string json = jilSerializer.Serialize(longList);
            IEnumerable<Merchant> list = jilSerializer.Deserialize(json);
        }
    }
}
