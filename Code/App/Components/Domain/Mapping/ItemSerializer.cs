//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Runtime.Serialization;

//namespace Domain.Mapping
//{
//    internal static class ItemSerializer
//    {
//        public static string Serialize<T>(T obj)
//        {
//            using (MemoryStream memoryStream = new MemoryStream())
//            using (StreamReader reader = new StreamReader(memoryStream))
//            {
//                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
//                serializer.WriteObject(memoryStream, obj);
//                memoryStream.Position = 0;
//                return reader.ReadToEnd();
//            }
//        }

//        public static T Deserialize<T>(string xml)
//        {
//            using (Stream stream = new MemoryStream())
//            {
//                T obj = default(T);

//                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
//                stream.Write(data, 0, data.Length);
//                stream.Position = 0;
//                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
//                obj = (T)deserializer.ReadObject(stream);

//                return obj;
//            }
//        }
//    }
//}
