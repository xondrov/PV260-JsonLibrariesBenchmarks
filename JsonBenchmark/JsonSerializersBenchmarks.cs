using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using ZeroFormatter;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonSerializersBenchmarks : JsonBenchmarkBase
    {
        protected Root RootSampleInstance;

        public JsonSerializersBenchmarks()
        {
            RootSampleInstance = new JsonDeserializersBenchmarks().NewtonsoftJson_Deserialize();
        }

        [Benchmark]
        public void NewtonsoftJson_Serialize()
        {
            JsonConvert.SerializeObject(RootSampleInstance);
        }

        [Benchmark]
        public void JavaScriptSerializer_Serialize()
        {
            new JavaScriptSerializer().Serialize(RootSampleInstance);
        }

        [Benchmark]
        public void ZeroFormatter_Serialize()
        {
            ZeroFormatterSerializer.Serialize(RootSampleInstance);
        }

        [Benchmark]
        public void FastJson_Serialize()
        {
            fastJSON.JSON.ToJSON(RootSampleInstance);
        }
    }
}
