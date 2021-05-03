using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class EmployeeV2 : PersonV2
    {
        void Process()
        {
            Name = "...";
            Birthday = DateTime.Now;
            SecondName = "..";
        }
    }
}
