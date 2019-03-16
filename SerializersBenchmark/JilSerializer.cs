namespace SerializersBenchmark
{
    using System.Collections.Generic;
    using System.IO;

    using Application.DTOs;

    using Jil;

    public class JilSerializer : ISerializer
    {
        public IEnumerable<Merchant> Deserialize(string s)
        {
            IEnumerable<Merchant> list;

            using (var input = new StringReader(s))
            {
                list = JSON.Deserialize<IEnumerable<Merchant>>(input);
            }

            return list;
        }

        public string Serialize(IEnumerable<Merchant> m)
        {
            string s = JSON.Serialize(m);
            return s;
        }
    }
}
