using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    class Factory
    {
        void Process()
        {
            var person = new Person();
            person.Name = "..";

            var personV2 = new PersonV2();
            personV2.SomeProperty = "...";
           
        }
    }
}
