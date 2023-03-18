using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace weatherlogr.Repository.MySql.Internal
{
    internal sealed class ClassMetadata
    {
        public string ClassName{get;set;} = string.Empty;
        
        public ConstructorInfo? Constructor { get; set; }

        public PropertyInfo[] Properties { get; set; } = new PropertyInfo[] { };
    }
}