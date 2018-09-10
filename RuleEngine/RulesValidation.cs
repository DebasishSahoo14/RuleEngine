using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine
{
   public class RuleEngine
    {
       
        public IList<RuleItem> ValidateRule(RuleItem selectedSignal, IList<RuleItem> ruleItems, IList<RuleItem> jsonData,
            string rule)
        {
            switch (selectedSignal?.Value_Type)
            {
                case "String":
                    ruleItems = jsonData.Where(r => r.Value != rule && r.Value_Type == selectedSignal.Value_Type).ToList();
                    break;
                case "Integer":
                    var c = jsonData.Where(r => r.Value_Type == selectedSignal.Value_Type);
                    ruleItems = c.Where(m => double.Parse(m.Value) > int.Parse(rule)).ToList();
                    break;
                case "Datetime":
                    var j = jsonData.Where(r => r.Value_Type == selectedSignal.Value_Type);
                    ruleItems = j.Where(m => DateTime.Parse(m.Value) > DateTime.Parse(rule)).ToList();
                    break;
                default:
                    break;
            }

            return ruleItems;
        }
    }
}
