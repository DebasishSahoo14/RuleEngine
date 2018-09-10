using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Newtonsoft.Json;

namespace RuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
                IList<RuleItem> ruleItems = new List<RuleItem>();
                var jsonData = LoadJson();

                Console.Write("Please Enter Signal:");
                var inputSignal = Console.ReadLine();

                var selectedSignal = jsonData.FirstOrDefault(r => r.Signal == inputSignal);

                Console.Write("ValueType:" + selectedSignal?.Value_Type);
                Console.ReadLine();

                Console.WriteLine("Please Enter Rule:");
                var rule = Console.ReadLine();
                var rules = new RuleEngine();

                ruleItems = rules.ValidateRule(selectedSignal, ruleItems, jsonData, rule);


                foreach (var ruleItem in ruleItems)
                {
                    Console.WriteLine(ruleItem.Signal, ruleItem.Value);
                }
                Console.ReadLine();
        }

        public static IList<RuleItem> LoadJson()
        {
            using (var r = new StreamReader(@"C:\raw_data.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<RuleItem>>(json);
                return items;
            }
        }


    }
}
