using System.Collections.Generic;

namespace CSQA
{
    public class Person
    {
        public string Name { get; internal set; }

        public List<string> Answers { get; set; } = new List<string>();
    }
}