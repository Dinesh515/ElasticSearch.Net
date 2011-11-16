using System;
using System.Text;
using Newtonsoft.Json;

namespace ElasticSearch.Client.QueryDSL
{
    public class ExistsFilterConvert:JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // {"exists" : { "field" : "user" }}
            ExistsFilter term = (ExistsFilter)value;
            if (term != null)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("{exists:{ \"field\" : \"");
                stringBuilder.Append(term.Filed);
                stringBuilder.Append("\"}}");

                //TODO 完成更多参数+ 参数判断

                writer.WriteRawValue(stringBuilder.ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ExistsFilter).IsAssignableFrom(objectType);
        }
    }
}