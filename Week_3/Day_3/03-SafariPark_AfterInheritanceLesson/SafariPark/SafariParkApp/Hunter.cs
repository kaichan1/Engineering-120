using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public /*sealed*/ class Hunter : Person
    {
        private string _camera;
        public Hunter(string fName, string lName, string camera = "") : base(fName, lName)
        {
            _camera = camera;        
        }

        public Hunter() { }

        public string Shoot()
        {
            var firstName = _firstName;
            return $"{FullName} has taken a photo with their {_camera}";
        }
        //sealed key word means that overriden inherited methods
        //cannot be overriden in derived classes
        public override /*sealed*/ string ToString()
        {
            return $"{base.ToString()} Camera: {_camera}";
        }
    }

    public class MonsterHunter : Hunter
    {
        private string? _weapon;

        public MonsterHunter(string fName, string lName, string camera, string weapon) : base(fName,lName, camera)
        {
            _weapon = weapon;
        }
        public override string ToString()
        {
            return $"{base.ToString()} Weapon: {_weapon}";
        }
    }
}
