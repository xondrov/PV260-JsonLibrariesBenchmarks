using BenchmarkDotNet.Running;
using JsonBenchmark.TestDTOs;

namespace JsonBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<JsonDeserializersBenchmarks>();
            BenchmarkRunner.Run<JsonSerializersBenchmarks>();
            System.Console.ReadKey();
        }
    }
}
