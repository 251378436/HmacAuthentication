using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Server.Serialization
{
    /// <summary>
    /// The custom date json converter, used in Json serialize and deserialize
    /// </summary>
    public class JsonCustomDateConverter : JsonConverter<DateTime>
    {
        // this link is about how system.text.json to support datetime format
        // https://docs.microsoft.com/en-us/dotnet/standard/datetime/system-text-json-support
        //
        // the source code about the default datetime converter can be found using ILSpy or github
        // https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/Value/DateTimeConverter.cs

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("Step 4 - 3: date json converter");
            Console.WriteLine("*****************");

            // use regular express to allow the client only submit date
            // if the client submit datetime "2022-06-26T21:00:00-11", default datetime parse will convert to local time, If the server is in AU or NZ, the date of local time is 2022-06-27

            var dateString = reader.GetString();
            if (string.IsNullOrEmpty(dateString) ||
                !Regex.IsMatch(dateString, "^[0-9]{4}-[0-9]{2}-[0-9]{2}$", RegexOptions.IgnoreCase))
            {
                throw new JsonException("Please use date format yyyy-MM-dd.");
            }

            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // set kind can make the serialized string to be an example like "2022-06-26T00:00:00Z"
            var valueWithKind = value;
            if (value.Kind == DateTimeKind.Unspecified)
                valueWithKind = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            writer.WriteStringValue(valueWithKind);
        }
    }
}