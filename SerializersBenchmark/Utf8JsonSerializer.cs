namespace SerializersBenchmark
{
    using Utf8Json;

    public class Utf8JsonSerializer<T> : ISerializer<T>
    {
        public T Deserialize(string s)
        {
            T @object = JsonSerializer.Deserialize<T>(s);
            return @object;
        }

        public string Serialize(T m)
        {
            string s = JsonSerializer.ToJsonString(m);
            return s;
        }

        public string SerializeNative(T m)
        {
            throw new System.NotImplementedException();
        }
    }
}
