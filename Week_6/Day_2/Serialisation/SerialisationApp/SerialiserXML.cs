using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationApp
{
    public class SerialiserXML : ISerialise
    {
        public T DeserialiseFromFile<T>(string filePath)
        {
            FileStream fileStream = File.OpenRead(filePath);
            //Create XML serialiser
            XmlSerializer writer = new XmlSerializer(typeof(T));
            var deserialiedItem = (T)writer.Deserialize(fileStream);
            fileStream.Close();
            return deserialiedItem;
        }

        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            //Create XML serialiser
            XmlSerializer writer = new XmlSerializer(typeof(T));
            writer.Serialize(fileStream, item);
            fileStream.Close();
        }
    }
}
