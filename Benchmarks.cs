namespace StructsJsonBenchmark;

using System.Text.Json;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Benchmarks
{
    private static readonly string _jsonString = @"{""number"": 4}";

    [Benchmark]
    public int DeserializeToStruct()
    {
        var jsonStruct = JsonSerializer.Deserialize<JsonStruct>(_jsonString);
        return jsonStruct.Number;
    }

    [Benchmark]
    public int DeserializeToClass()
    {
        var jsonClass = JsonSerializer.Deserialize<JsonClass>(_jsonString);
        return jsonClass!.Number;
    }

    [Benchmark]
    public string SerializeFromStruct()
    {
        JsonStruct jsonStruct = new()
        {
            Number = 4
        };
        var jsonStr = JsonSerializer.Serialize(jsonStruct);
        return jsonStr;
    }

    [Benchmark]
    public string SerializeFromClass()
    {
        JsonClass jsonClass = new()
        {
            Number = 4
        };
        var jsonStr = JsonSerializer.Serialize(jsonClass);
        return jsonStr;
    }
}