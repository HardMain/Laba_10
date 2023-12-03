using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    internal class SortByAge : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            return a.Age.CompareTo(b.Age);
        }
    }
}   