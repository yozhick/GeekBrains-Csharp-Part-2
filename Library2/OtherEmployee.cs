﻿using Library1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2
{
    public class OtherEmployee : PersonV2
    {
        void Process()
        {
            Name = "...";
            Birthday = DateTime.Now;
            //SecondName = "...";
        }
    }
}
