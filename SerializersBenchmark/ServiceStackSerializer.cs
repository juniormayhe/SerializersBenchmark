namespace SerializersBenchmark
{
    using System.Collections.Generic;

    using Application.DTOs;

    using ServiceStack.Text;

    public class ServiceStackSerializer<T> : ISerializer<T>
    {
        static Config config = new Config
        {
            IncludeNullValues = true,
            IncludeDefaultEnums = true,
            IncludeTypeInfo = false,
            DateHandler = DateHandler.ISO8601,
            AlwaysUseUtc = true,
            ExcludeDefaultValues = false,
            ExcludeTypeInfo = true,
            TreatEnumAsInteger = true
        };

        public T Deserialize(string s)
        {
            T merchant = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(s);
            return merchant;
        }

        public string Serialize(T m)
        {    
            JsConfig.Init(config);
            string s = ServiceStack.Text.JsonSerializer.SerializeToString(m);
            return s;
        }

        public string SerializeNative(T m)
        {
            JsConfig.Reset();
            string s = ServiceStack.Text.JsonSerializer.SerializeToString(m);
            return s;
        }
    }
}
