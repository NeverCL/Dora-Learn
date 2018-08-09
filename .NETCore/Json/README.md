# 说明

dotnet add package Newtonsoft.Json

1. JObject 与 JArray 与 JToken

    1. JObject 与 JArray 用于 LinQ to JSON

        ```csharp
        JObject o = JObject.Parse(@"{
        'CPU': 'Intel',
        'Drives': [
            'DVD read/writer',
            '500 gigabyte hard drive'
        ]
        }");
        IList<string> allDrives = o["Drives"].Select(t => (string)t).ToList();
        ```

    1. JArray 由 JObject 组成，JObject 由 JProperty 组成，JObject 通过索引返回的对象为 JValue
    1. JToken 可以使用字符串路径,JObject 和 JArray 继承 JToken 通过 SelectToken 方法。
    1. 需要使用LinQ to JSON 则使用 JObject 与 JArray
    1. 需要使用字符串路径，则使用 JToken
