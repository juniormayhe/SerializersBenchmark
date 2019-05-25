namespace SerializersBenchmark
{
    using Jil;

    using System.IO;

    public class JilSerializer<T> : ISerializer<T>
    {
        public T Deserialize(string s)
        {
            T list;

            using (var input = new StringReader(s))
            {
                list = JSON.Deserialize<T>(input);
            }

            return list;
        }

        public string Serialize(T m)
        {
            string s = JSON.Serialize(m);
            return s;
        }

        public string SerializeNative(T m)
        {
            throw new System.NotImplementedException();
        }
    }
}
