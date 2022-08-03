using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    public class SerialiserFactory
    {
        public static ISerialise? MakeSerialiser(string serialiserType)
        {
            switch (serialiserType.ToLower())
            {
                case "binary":
                    return new SerialiserBinary();
                case "xml":
                    return new SerialiserXML();
                case "json":
                    return new SerialiserJson();
                default:
                    return null;
            }
        }
    }
}
