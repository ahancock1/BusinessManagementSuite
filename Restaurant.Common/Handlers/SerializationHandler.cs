using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Restaurant.Common.Handlers
{

    /// <summary>
    /// TODO tidy this up and add the XmlHandler class
    /// </summary>
    public static class SerializationHandler
    {

        public static byte[] Serialize<T>(this T data) where T : class
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(T));
                var stream = new MemoryStream();

                using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream))
                {
                    serializer.WriteObject(writer, data);
                }

                return stream.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error serializing, {0}", e.Message);
            }

            return null;
        }

        public static T Deserialize<T>(byte[] data) where T : class
        {
            try
            {
                var serializer = new DataContractSerializer(typeof (T));
                using (var stream = new MemoryStream(data))
                {
                    using (var reader = XmlDictionaryReader.CreateBinaryReader(
                        stream, XmlDictionaryReaderQuotas.Max))
                    {
                        return (T) serializer.ReadObject(reader);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deserializing, {0}", e.Message);
            }

            return default(T);
        }

        public static T ReadFile<T>(string filePath)
        {
            return default(T);
        }

        public static bool WriteToFile<T>(this T data, string filePath)
        {
            
            if (!(Attribute.IsDefined(typeof(T), typeof(DataContractAttribute))
                || Attribute.IsDefined(typeof(T), typeof(SerializableAttribute))))
                return false;
            
            try
            {
                if (String.IsNullOrEmpty(Path.GetFileName(filePath)))
                {
                    return false;
                }
                if (String.IsNullOrEmpty(Path.GetExtension(filePath)))
                {
                    filePath += ".xml";
                }
                if (!Directory.Exists(filePath))
                {
                    try
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    }
                    catch (Exception e)
                    {
                        // Couldn't create directory
                        return false;
                    }
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs))
                    {
                        DataContractSerializer serializer =
                            new DataContractSerializer(typeof(T));
                        serializer.WriteObject(writer, data);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                // Something in the class is not serializable

            }

            return false;
        }
    }
}
