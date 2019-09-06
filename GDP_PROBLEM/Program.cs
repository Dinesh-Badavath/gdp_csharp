using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GDP_PROBLEM
{
    public class Program
    {
        private static string outputPath = "../../../../actual-output.json";
        public static Dictionary<string, string> Dict()
        {

            var dictJson = new Dictionary<string, string>();
            if (File.Exists("../../../../continents.json"))
            {
                using (StreamReader file = File.OpenText("../../../../continents.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JToken o2 = JToken.ReadFrom(reader);
                    foreach (var i in o2)
                    {
                        dictJson.Add((string)i["Country"], (string)i["Continent"]);
                    }
                }
            }
            return dictJson;
        }
        public static void gdp_pop()
        {
            var countries = new StreamReader("../../../../datafile.csv");
            List<string[]> CSVdata = new List<string[]>();

            while (!countries.EndOfStream)
            {
                var line = countries.ReadLine();
                var values = (line.Replace("\"", "")).Split(',');
                CSVdata.Add(values);
            }

            /*int row = CSVdata.Count;*/
            var Obj = Dict();
            var result = new Dictionary<string, Dictionary<string, decimal>>();
            foreach (var x in CSVdata)
            {
                if (Obj.ContainsKey(x[0]))
                {
                    string continent = Obj[x[0]];
                    if (result.ContainsKey(continent))
                    {
                        result[continent]["POPULATION_2012"] += Decimal.Parse(x[4]);
                        result[continent]["GDP_2012"] += Decimal.Parse(x[7]);
                    }
                    else
                    {
                        result[continent] = new Dictionary<string, decimal>();
                        result[continent].Add("GDP_2012", Decimal.Parse(x[7]));
                        result[continent].Add("POPULATION_2012", Decimal.Parse(x[4]));
                    }
                }
                else
                {

                }
            }
            /*    foreach(var items in result){
                     foreach(var item in items.Value)
                     {
                         Console.WriteLine($"{item.Value} {item.Key}");
                     }
                 }*/
            File.WriteAllText(outputPath, JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public static void Main(string[] args)
        {
          gdp_pop();
        }
    }
}

