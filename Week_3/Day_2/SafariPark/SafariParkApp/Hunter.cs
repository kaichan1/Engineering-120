using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Hunter : Person
    {
        private string _camera;

        public Hunter(string fName, string lName, string camera = "") : base(fName, lName)
        {
            _camera = camera;
        }

        public Hunter() { }

        public string Shoot()
        {
            return $"{FullName} has taken a photo with their {_camera}";
        }
    }
}
