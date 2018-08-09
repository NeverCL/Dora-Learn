using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User { Id = 1, Name = "name" };
            var json = JsonConvert.SerializeObject(new[] { user });
            var array = JArray.Parse(json);
            var obj = JObject.Parse(JsonConvert.SerializeObject(array[0]));
            var token = JToken.Parse(json);
            System.Console.WriteLine(obj["Id"] + "-" + array[0].SelectToken("Id") + "-" + token.SelectToken("[0].Id"));

            Console.WriteLine("Hello World!");
        }
    }

    class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}