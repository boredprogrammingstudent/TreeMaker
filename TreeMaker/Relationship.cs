using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeMaker.Utils;
namespace TreeMaker
{
    internal class Relationship
    {
        public string Type;
        public Person Other;
        public Relationship(string type, Person other)
        {
            Type = type;
            Other = other;
        }
        public Relationship(Relationships type, Person other)
        {
            Type = Text.Relationship(type);
            Other = other;
        }
    }
    enum Relationships
    {
        Parents,
        Children,
        Friends,
        Spouse_or_Lover,
        Other
    };
}
