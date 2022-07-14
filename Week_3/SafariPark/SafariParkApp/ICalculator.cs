﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public interface ICalculator
    {
        public int Add(int a, int b);
        public int Subtract(int a, int b);
        public int Multiply(int a, int b);
        public int Divide(int a, int b);
    }
}
