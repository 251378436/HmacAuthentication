using Server.Serialization;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Test.Serialization
{
    [TestClass]
    public class JsonCustomDateConverterTests
    {
        private readonly JsonCustomDateConverter _sut;
        private readonly JsonSerializerOptions _serializerOptions;

        public JsonCustomDateConverterTests()
        {
            _sut = new JsonCustomDateConverter();
            _serializerOptions = new JsonSerializerOptions();
        }

        [DataRow("\"2021-02-12\"")]
        [DataRow("\"2021-01-01\"")]
        [TestMethod]
        public void Success(string date)
        {
            var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(date), false, new JsonReaderState(new JsonReaderOptions()));
            utf8JsonReader.Read();
            var result = _sut.Read(ref utf8JsonReader, typeof(DateTime), _serializerOptions);
            Assert.AreEqual(date, $"\"{result.ToString("yyyy-MM-dd")}\"");
        }

        [DataRow("\"2021-02-12 10:02:23\"")]
        [DataRow("\"2021/02/12\"")]
        [DataRow("\"2021/02/12 10:02:23\"")]
        [DataRow("\"abcdefd\"")]
        [TestMethod]
        public void Failed_JsonException(string date)
        {
            var exception = Assert.ThrowsException<JsonException>(() =>
            {
                var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(date), false, new JsonReaderState(new JsonReaderOptions()));
                utf8JsonReader.Read();
                _sut.Read(ref utf8JsonReader, typeof(DateTime), _serializerOptions);
            });
            Assert.AreEqual("Please use date format yyyy-MM-dd.", exception.Message);
        }

        [DataRow("\"2021-14-12\"")]
        [DataRow("\"2021-11-31\"")]
        [DataRow("\"0000-11-31\"")]
        [TestMethod]
        public void Failed_FormatException(string date)
        {
            var exception = Assert.ThrowsException<FormatException>(() =>
            {
                var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(date), false, new JsonReaderState(new JsonReaderOptions()));
                utf8JsonReader.Read();
                _sut.Read(ref utf8JsonReader, typeof(DateTime), _serializerOptions);
            });
            Assert.AreEqual("The JSON value is not in a supported DateTime format.", exception.Message);
        }

        [DataRow(DateTimeKind.Unspecified)]
        [DataRow(DateTimeKind.Utc)]
        [DataRow(DateTimeKind.Local)]
        [TestMethod]
        public void WriteTest(DateTimeKind kind)
        {
            var dateTime = new DateTime(2020, 2, 2, 0, 0, 0, kind);
            var output = new ArrayBufferWriter<byte>();
            var writer = new Utf8JsonWriter(output);
            _sut.Write(writer, dateTime, _serializerOptions);

            string actualResult = Encoding.UTF8.GetString(output.GetSpan()).Split('"')[1];
            string format;
            if (kind == DateTimeKind.Unspecified || kind == DateTimeKind.Utc)
            {
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
                format = "yyyy-MM-ddTHH:mm:ssZ";
            }
            else
            {
                format = "yyyy-MM-ddTHH:mm:sszzz";
            }

            var expectedResult = dateTime.ToString(format);

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
