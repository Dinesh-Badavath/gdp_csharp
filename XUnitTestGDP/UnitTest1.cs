using System;
using Xunit;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using GDP_PROBLEM;
namespace XUnitTestGDP
{
    public class UnitTest1
    {
        string expectedPath = "../../../expected-output.json";
        string actualPath = "../../../actual-output.json";
        [Fact]
        public void Test1()
        {
            Program.gdp_pop();

            bool right = false;
            if (File.Exists(expectedPath))
            {
                JObject xpctJSON = JObject.Parse(expectedPath);
                JObject actJSON = JObject.Parse(actualPath);
                right = JToken.DeepEquals(xpctJSON, actJSON);
                Assert.True(right);
            }
        }
        [Fact]
        public void Test2()
        {
            if (!File.Exists("../../../../actual-output.json"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file actual-output.json"));
            }
            if (!File.Exists("../../../../expected-output.json"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file expected-output.json"));
            }
            if (!File.Exists("../../../../datafile.csv"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file datafile.csv"));
            }
        }
        [Fact]
        public void Test3()
        {
            bool flag = true;
            if(new FileInfo("../../../../actual-output.json").Length==0)
            {
                flag = false;
            }
            Assert.True(flag);
        }
    }
}
