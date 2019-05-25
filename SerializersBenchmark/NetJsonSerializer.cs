namespace SerializersBenchmark
{
    using System.Collections.Generic;

    using Application.DTOs;

    using NetJSON;

    public class NetJSONSerializer : ISerializer
    {
        public IEnumerable<Merchant> Deserialize(string s)
        {
            IEnumerable<Merchant> merchant = NetJSON.Deserialize<IEnumerable<Merchant>>(s);
            return merchant;
        }

        public string Serialize(IEnumerable<Merchant> m)
        { 
            string s = NetJSON.Serialize(m, new NetJSONSettings { UseEnumString = false, SkipDefaultValue = false, DateFormat = NetJSONDateFormat.JsonNetISO });
            return s;
        }
    }
}
