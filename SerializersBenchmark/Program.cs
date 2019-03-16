namespace SerializersBenchmark
{
    using System;
    using AutoFixture;
    using BenchmarkDotNet.Running;

    class Program
    {
        static void Main(string[] args)
        {
            var fixture = new Fixture();
            
            var summary = BenchmarkRunner.Run<Serializers>();

            Console.WriteLine("done!");
            Console.ReadLine();
        }
    }
}
