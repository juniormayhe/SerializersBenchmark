namespace SerializersBenchmark
{
    using Application.DTOs;
    using BenchmarkDotNet.Running;
    using System;
    using System.Collections.Generic;
    using MerchantDTO = Application.DTOs.Merchant;

    class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
            DebugSerializers();
#else
            var summary = BenchmarkRunner.Run<Serializers>();
#endif

            Console.WriteLine("done!");
            Console.ReadLine();
        }

        private static void DebugSerializers()
        {
            IEnumerable<MerchantDTO> merchants = MerchantBuilder.BuildMerchants(2);

            // Mind that serialized strings will be different due to differences among frameworks
            ISerializer<IEnumerable<Merchant>> newtonsoft = new NewtonsoftSerializer<IEnumerable<Merchant>>();
            string jsonNewtonsoft = newtonsoft.Serialize(merchants);

            ISerializer<IEnumerable<Merchant>> ss = new ServiceStackSerializer<IEnumerable<Merchant>>();
            string jsonSS = ss.Serialize(merchants);

            ISerializer<IEnumerable<Merchant>> netjson = new NetJSONSerializer<IEnumerable<Merchant>>();
            string jsonNetjson = netjson.Serialize(merchants);

            ISerializer<IEnumerable<Merchant>> jil = new JilSerializer<IEnumerable<Merchant>>();
            string jsonJil = jil.Serialize(merchants);

            ISerializer<IEnumerable<Merchant>> utf8 = new Utf8JsonSerializer<IEnumerable<Merchant>>();
            string jsonUtf8 = utf8.Serialize(merchants);
        }
    }
}
