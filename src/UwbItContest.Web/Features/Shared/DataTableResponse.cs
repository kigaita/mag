using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UwbItContest.Web.Features.Shared
{
    public class DataTableResponse<T> where T : class
    {
        private DataTableResponse(object data)
        {
            Data = data;
        }

        public object Data { get; set; }

        public static DataTableResponse<T> Create(IReadOnlyList<T> data)
        {
            var arrays = new object[data.Count];

            for (int i = 0; i < data.Count; i++)
            {
                var i1 = i;
                arrays[i] =
                    data[i].GetType().GetProperties().Select(p => p.GetValue(data[i1])).Select(v => v.ToString());
            }

            return new DataTableResponse<T>(arrays);
        }

        public static DataTableResponse<T> Create(IEnumerable<T> data)
        {
            return Create(data.ToList());
        }
    }

    public class DataTableReponseJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jObject = new JObject();
            JArray dataArray = new JArray();

            var data = (IEnumerable) value;

            foreach (var obj in data)
            {
                var jArray = new JArray();
                foreach (var propertyInfo in obj.GetType().GetProperties())
                {
                    jArray.Add(propertyInfo.GetValue(obj));
                }
                dataArray.Add(jArray);
            }

            jObject.Add("data", dataArray);
            jObject.WriteTo(writer);
        }

        public override bool CanConvert(Type objectType) => objectType.IsClass;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}