using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public abstract class Weapon : IShootable
    {
        protected string _brand;
        public Weapon(string brand)
        {
            _brand = brand;
        }
        public override string ToString()
        {
            return $"{base.ToString()} - {_brand}";
        }
        public abstract string Shoot();
    }
}
