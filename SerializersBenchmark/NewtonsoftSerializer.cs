namespace SerializersBenchmark
{
    using System.Collections.Generic;
    using System.IO;
    using Application.DTOs;

    using Newtonsoft.Json;

    public class NewtonsoftSerializer<T> : ISerializer<T>
    {
        public IEnumerable<Merchant> DeserializeWithStream(string s)
        {
            IEnumerable<Merchant> list = null;

            using (Stream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(s)))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();

                        // read the json from a stream
                        // json size doesn't matter because only a small piece is read at a time from the HTTP request
                        //Person p = serializer.Deserialize<Person>(reader);
                        list = serializer.Deserialize<IEnumerable<Merchant>>(reader);
                    }
                }
            }

            list = JsonConvert.DeserializeObject<IEnumerable<Merchant>>(s);
            return list;
        }

        public T Deserialize(string s)
        {
            T list = JsonConvert.DeserializeObject<T>(s);
            return list;
        }

        public string Serialize(T m)
        {
            string s = JsonConvert.SerializeObject(m);
            return s;
        }

        public string SerializeNative(T m)
        {
            throw new System.NotImplementedException();
        }
    }
}
