namespace SerializersBenchmark
{
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
            ISerializer newtonsoft = new NewtonsoftSerializer();
            string jsonNewtonsoft = newtonsoft.Serialize(merchants);

            ISerializer netjson = new NetJSONSerializer();
            string jsonNetjson = netjson.Serialize(merchants);

            ISerializer jil = new JilSerializer();
            string jsonJil = jil.Serialize(merchants);
        }
    }
}
