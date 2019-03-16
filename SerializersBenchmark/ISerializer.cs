namespace SerializersBenchmark
{
    using System.Collections.Generic;

    using Application.DTOs;

    interface ISerializer
    {
        IEnumerable<Merchant> Deserialize(string s);
        string Serialize(IEnumerable<Merchant> m);
    }
}
