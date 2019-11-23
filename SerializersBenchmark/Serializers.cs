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
            ISerializer<IEnumerable<Merchant>> newtonsoftSerializer = new NewtonsoftSerializer<IEnumerable<Merchant>>();
            string json = newtonsoftSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = newtonsoftSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Newtonsoft_Long_List()
        {
            ISerializer<IEnumerable<Merchant>> newtonsoftSerializer = new NewtonsoftSerializer<IEnumerable<Merchant>>();
            string json = newtonsoftSerializer.Serialize(longList);
            IEnumerable<Merchant> list = newtonsoftSerializer.Deserialize(json);
        }

        [Benchmark]
        public void NetJSON_Small_List()
        {
            ISerializer<IEnumerable<Merchant>> netJsonSerializer = new NetJSONSerializer<IEnumerable<Merchant>>();
            string json = netJsonSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = netJsonSerializer.Deserialize(json);
        }

        [Benchmark]
        public void NetJSON_Long_List()
        {
            ISerializer<IEnumerable<Merchant>> netJsonSerializer = new NetJSONSerializer<IEnumerable<Merchant>>();
            string json = netJsonSerializer.Serialize(longList);
            IEnumerable<Merchant> list = netJsonSerializer.Deserialize(json);
        }

        [Benchmark]
        public void NetJSONNative_Small_List()
        {
            ISerializer<IEnumerable<Merchant>> netJsonSerializer = new NetJSONSerializer<IEnumerable<Merchant>>();
            string json = netJsonSerializer.SerializeNative(smallList);
            IEnumerable<Merchant> list = netJsonSerializer.Deserialize(json);
        }

        [Benchmark]
        public void NetJSONNative_Long_List()
        {
            ISerializer<IEnumerable<Merchant>> netJsonSerializer = new NetJSONSerializer<IEnumerable<Merchant>>();
            string json = netJsonSerializer.SerializeNative(longList);
            IEnumerable<Merchant> list = netJsonSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Jil_Small_List()
        {
            ISerializer<IEnumerable<Merchant>> jilSerializer = new JilSerializer<IEnumerable<Merchant>>();
            string json = jilSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = jilSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Jil_Long_List()
        {
            ISerializer<IEnumerable<Merchant>> jilSerializer = new JilSerializer<IEnumerable<Merchant>>();
            string json = jilSerializer.Serialize(longList);
            IEnumerable<Merchant> list = jilSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Utf8Json_Small_List()
        {
            ISerializer<IEnumerable<Merchant>> jilSerializer = new Utf8JsonSerializer<IEnumerable<Merchant>>();
            string json = jilSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = jilSerializer.Deserialize(json);
        }

        [Benchmark]
        public void Utf8Json_Long_List()
        {
            ISerializer<IEnumerable<Merchant>> jilSerializer = new Utf8JsonSerializer<IEnumerable<Merchant>>();
            string json = jilSerializer.Serialize(longList);
            IEnumerable<Merchant> list = jilSerializer.Deserialize(json);
        }

        [Benchmark]
        public void ServiceStack_Small_List()
        {
            ISerializer<IEnumerable<Merchant>> ssSerializer = new ServiceStackSerializer<IEnumerable<Merchant>>();
            string json = ssSerializer.Serialize(smallList);
            IEnumerable<Merchant> list = ssSerializer.Deserialize(json);
        }

        [Benchmark]
        public void ServiceStack_Long_List()
        {
            ISerializer<IEnumerable<Merchant>> ssSerializer = new ServiceStackSerializer<IEnumerable<Merchant>>();
            string json = ssSerializer.Serialize(longList);
            IEnumerable<Merchant> list = ssSerializer.Deserialize(json);
        }

        [Benchmark]
        public void ServiceStackNative_Small_List()
        {
            ISerializer<IEnumerable<Merchant>> ssSerializer = new ServiceStackSerializer<IEnumerable<Merchant>>();
            string json = ssSerializer.SerializeNative(smallList);
            IEnumerable<Merchant> list = ssSerializer.Deserialize(json);
        }

        [Benchmark]
        public void ServiceStackNative_Long_List()
        {
            ISerializer<IEnumerable<Merchant>> ssSerializer = new ServiceStackSerializer<IEnumerable<Merchant>>();
            string json = ssSerializer.SerializeNative(longList);
            IEnumerable<Merchant> list = ssSerializer.Deserialize(json);
        }
    }
}
