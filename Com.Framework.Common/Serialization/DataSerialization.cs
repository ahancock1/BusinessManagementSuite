﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Com.Framework.Common.Logging;

namespace Com.Framework.Common.Serialization
{
    public class DataSerializationException : Exception
    {
        public DataSerializationException(string msg) : base(msg) { }
    }

    public static class DataSerialization
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
                Logger.Error(String.Format("Error Serializing, {0}", typeof(T).Name), e);
            }

            return null;
        }

        public static T Deserialize<T>(byte[] data) where T : class
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(T));
                using (var stream = new MemoryStream(data))
                {
                    using (var reader = XmlDictionaryReader.CreateBinaryReader(
                        stream, XmlDictionaryReaderQuotas.Max))
                    {
                        return (T)serializer.ReadObject(reader);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Error Deserializing, {0}", typeof(T).Name), e);
            }

            return null;
        }

        public static T ReadFile<T>(string filePath) where T : class
        {
            if (!Attribute.IsDefined(typeof(T), typeof(DataContractAttribute)))
                return default(T);

            try
            {
                if (String.IsNullOrEmpty(Path.GetFileName(filePath)))
                {
                    return null;
                }
                if (String.IsNullOrEmpty(Path.GetExtension(filePath)))
                {
                    filePath += ".xml";
                }
                if (!Directory.Exists(Path.GetDirectoryName(Path.GetFullPath(filePath))))
                {
                    Logger.Info(string.Format("File Doesn't Exist, {0}", typeof(T).Name));
                    return null;
                }

                var serializer = new DataContractSerializer(typeof(T));

                using (var reader = XmlReader.Create(new StreamReader(filePath)))
                {
                    return (T)serializer.ReadObject(reader);
                }
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Error Reading File: {0}, {1}", filePath, typeof(T).Name), e);
            }

            return null;
        }

        /// <summary>
        /// Writes a serializable class marked with the DataContract attribute to the
        /// specified file. If the directory doesn't exist it will be created. A default 
        /// .xml file extension will be added if the file path doesn't specify one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool WriteToFile<T>(this T data, string filePath)
        {
            if (!Attribute.IsDefined(typeof(T), typeof(DataContractAttribute)))
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
                if (!Directory.Exists(Path.GetDirectoryName(Path.GetFullPath(filePath))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(filePath)));
                }

                var serializer = new DataContractSerializer(typeof(T));

                var settings = new XmlWriterSettings { Indent = true };

                using (var writer = XmlWriter.Create(filePath, settings))
                {
                    serializer.WriteObject(writer, data);
                    return true;
                }
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Error Writing File: {0}, {1}", filePath, typeof(T).Name), e);
                return false;
            }
        }

    }
}
