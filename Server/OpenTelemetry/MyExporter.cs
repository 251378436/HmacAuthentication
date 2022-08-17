using OpenTelemetry;
using System.Diagnostics;
using System.Text.Json;

namespace Server.OpenTelemetry
{
    public class MyExporter : BaseExporter<Activity>
    {
        public override ExportResult Export(in Batch<Activity> batch)
        {
            using var scope = SuppressInstrumentationScope.Begin();

            foreach (var activity in batch)
            {
                var json1 = JsonSerializer.Serialize(activity, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                });
                var attributes = this.ParentProvider.GetResource().Attributes;
                var json2 = JsonSerializer.Serialize(attributes, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                });
                Console.WriteLine(json1);
                Console.WriteLine(json2);
                Console.WriteLine($"Export: {activity.DisplayName}");
            }

            return ExportResult.Success;
        }
    }
}