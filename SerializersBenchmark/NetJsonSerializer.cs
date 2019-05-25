namespace SerializersBenchmark
{
    using NetJSON;

    public class NetJSONSerializer<T> : ISerializer<T>
    {
        public T Deserialize(string s)
        {
            T merchant = NetJSON.Deserialize<T>(s);
            return merchant;
        }

        public string Serialize(T m)
        { 
            string s = NetJSON.Serialize(m, new NetJSONSettings { UseEnumString = false, SkipDefaultValue = false, DateFormat = NetJSONDateFormat.JsonNetISO });
            return s;
        }

        public string SerializeNative(T m)
        {
            string s = NetJSON.Serialize(m);
            return s;
        }
    }
}
