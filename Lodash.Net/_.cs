using System;

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;
namespace Lodash.Net
{
    public class _
    {
        /// <summary>
        /// Checks if number is even
        /// </summary>
        /// <param name="number"></param>
        /// <returns>bool</returns>
        /// <example>
        /// <code>
        /// int value = _.IsEven(4);
        /// // => true
        /// /// int value = _.IsEven(4);
        /// // => false
        /// </code>
        /// </example>
        static public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Gets the value at path of object. If the resolved value is null, the defaultValue is returned in its place.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="path"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns the resolved value.</returns>
        /// <example>
        /// <code>
        /// int value = _.Get(@"{ a:""aa"", b: {c: ""cc""}}", "b");
        /// // => {c: ""cc""}
        /// int value = _.Get(@"{ a:""aa"", b: {c: ""cc""}}", "b.c");
        /// // => "cc"
        /// int value = _.Get(@"{ a:""aa"", b: {c: ""cc""}}", "x.y.z", "DEFAULT_VALUE");
        /// // => "DEFAULT_VALUE"
        /// </code>
        /// </example>
        static public dynamic Get(dynamic json, string path, dynamic? defaultValue = null)
        {
            JObject result = JObject.Parse(json);
            var value = result.SelectToken($"$.{path}");
            if (value != null) { return value; }

            return defaultValue;
        }

        /// <summary>
        /// Creates an object composed of the picked object properties.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="paths"></param>
        /// <returns>Returns the new object.</returns>
        /// <example>
        /// <code>
        /// int value = _.Pick(@"{ a:""aa"", b: {c: ""cc""}}", "b");
        /// // => { b: {c: ""cc""}}
        /// </code>
        /// </example>
        static public dynamic Pick(dynamic json, string[] paths)
        {
            var result = new JObject();
            foreach (string path in paths)
            {
                result.Add(path, _.Get(json, path));
            }

            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// The opposite of _.Pick; this method creates an object composed of the paths that are not omitted.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="paths"></param>
        /// <returns>Returns the new object.</returns>
        /// <example>
        /// <code>
        /// int value = _.Omit(@"{ a:""aa"", b: {c: ""cc""}}", "b");
        /// // => { a: "aa"}
        /// </code>
        /// </example>
        static public dynamic Omit(dynamic json, string[] paths)
        {
            var result = new JObject();
            dynamic dynJson = JsonConvert.DeserializeObject(json);

            foreach (var item in dynJson)
            {
                var match = paths.FirstOrDefault(key => key.Equals(item.Name));
                if (match == null)
                {
                    result.Add(item.Name, item.Last);
                }
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}