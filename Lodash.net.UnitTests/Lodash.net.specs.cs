using Xunit;
using System;
using Lodash.Net;
using FluentAssertions;
using Newtonsoft.Json;

namespace Lodash.Net.UnitTests
{
    public class Lodash_IsEvenShould

    {
        // private readonly Lodash.Net._ _;
        public Lodash_IsEvenShould()
        {
            // _ = new Lodash.Net._();
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(2, true)]
        [InlineData(10, true)]
        [InlineData(1, false)]
        [InlineData(17, false)]
        public void IsEven_ReturnFalse(int number, bool expected)
        {
            bool result = _.IsEven(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("a", "aa")]
        [InlineData("b.c", "cc")]
        [InlineData("x.y.z", null)]
        [InlineData("x.y.z", "xyz", "xyz")]
        public void Get_ReturnProperty(string key, string expected, dynamic? defaultValue = null)
        {
            string json = @"{ a:""aa"", b: {c: ""cc""}}";
            var result = _.Get(json, key, defaultValue);

            Assert.Equal(expected, (string)result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "a", "d" } })]
        public void Pick_ReturnObjects(string[] keys)
        {
            string json = @"{ a:""aa"", b: {c: ""cc""}, d: ""dd""}";
            var result = _.Pick(json, keys);

            Assert.Equal(JsonConvert.SerializeObject(new { a = "aa", d = "dd" }), result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "d" } })]
        public void Omit_ReturnObjects(string[] keys)
        {
            string json = @"{ a:""aa"", b: {c: ""cc""}, d: ""dd""}";
            var result = _.Omit(json, keys);

            Console.WriteLine("Test: {0}\n", result);
            Assert.Equal(JsonConvert.SerializeObject(new { a = "aa", b = new { c = "cc" } }), result);
        }
    }
}