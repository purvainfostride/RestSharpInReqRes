using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.IO;
using Newtonsoft.Json;

namespace RestSharpInReqRes
{
    public static class HandleContent
    {
        public static T GetContent<T>(IRestResponse response)
        {
            var gettingContent = response.Content;
            return JsonConvert.DeserializeObject<T>(gettingContent);
        }
        public static string Serialize(dynamic payload)
        {
            return JsonConvert.SerializeObject(payload, Formatting.Indented);

        }
        public static T ParseJson<T>(string file) //Taking string file and parse it to JSON - return object after deserialize
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}
