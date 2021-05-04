using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopPerformanceLib.Entities
{
    public class Foo : IEquatable<Foo>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool Equals(Foo other)
        {
            return this.Name == other.Name;
        }
    }
}
