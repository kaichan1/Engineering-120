﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    public class Address
    {
        public int HouseNo { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public Address(int houseNo, string street, string town)
        {
            HouseNo = houseNo;
            Street = street;
            Town = town;
        }
        public string GetAddress()
        {
            return $"{_address.HouseNo} {_address.Street}, {_address.Town}";
        }
    }
}
