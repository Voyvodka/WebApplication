﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapplication.core.CrossCuttingConcerns.Logging
{

    public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
        public string Date = DateTime.Now.ToString("HH.mm.ss - dd/MM/yyyy");
    }
}
