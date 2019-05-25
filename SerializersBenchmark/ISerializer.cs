namespace SerializersBenchmark
{
    using System.Collections.Generic;

    using Application.DTOs;

    interface ISerializer<T>
    {
        T Deserialize(string s);
        string Serialize(T m);
        string SerializeNative(T m);
    }
}
