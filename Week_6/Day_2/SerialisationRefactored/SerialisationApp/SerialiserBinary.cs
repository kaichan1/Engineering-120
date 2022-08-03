using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    internal class SerialiserBinary : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            //Stream or FileStream
            FileStream filestream = File.Create(filePath);
            //Create a BinaryFormatter object and use it to serialise the item to file
            BinaryFormatter writer = new BinaryFormatter();
            //Serialise
            writer.Serialize(filestream, item);
            filestream.Close();
        }

        public T DeserialiseFromFile<T>(string filePath)
        {
            //Create a stream object for reading
            Stream fileStream = File.OpenRead(filePath);
            BinaryFormatter reader = new BinaryFormatter();
            var deserialisedItem = (T)reader.Deserialize(fileStream);
            fileStream.Close();
            return deserialisedItem;
        }
    }
}
