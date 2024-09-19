using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseController
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Parameter(string name, object value)
        {
            Name = $"@{name.Replace("@", "")}";
            Value = value.ToString();
        }
    }
}
