using Belly.Enums;
using Belly.Objects;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belly.Classes
{
    public class MediaDataJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(MediaData));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var typeData = (TypeData)Enum.Parse(typeof(TypeData), jo["typeData"].Value<string>());

            switch (typeData)
            {
                case TypeData.Track:
                    return jo.ToObject<Track>(serializer);
                case TypeData.Folder:
                    return jo.ToObject<Folder>(serializer);
                default:
                    throw new Exception("Неизвестный тип MediaData.");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
