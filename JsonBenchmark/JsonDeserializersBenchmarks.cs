using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using fastJSON;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using ZeroFormatter;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root NewtonsoftJson_Deserialize()
        {
            return JsonConvert.DeserializeObject<Root>(JsonSampleString);
        }

        [Benchmark]
        public Root JavaScriptSerializer_Deserialize()
        {
            return new JavaScriptSerializer().Deserialize<Root>(JsonSampleString);
        }

        [Benchmark]
        public Root ZeroFormatter_Deserialize()
        {
            return ZeroFormatterSerializer.Deserialize<Root>(System.Text.Encoding.UTF8.GetBytes(JsonSampleString));
        }

        [Benchmark]
        public Root FastJson_Deserialize()
        {
            return fastJSON.JSON.ToObject<Root>(JsonSampleString);
        }
    }
}
