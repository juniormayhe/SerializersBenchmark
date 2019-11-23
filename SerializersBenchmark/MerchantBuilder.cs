namespace SerializersBenchmark
{
    using Application.DTOs;

    using AutoFixture;

    using System.Collections.Generic;
    using System.Linq;

    public static class MerchantBuilder
    {
        public static IEnumerable<Merchant> BuildMerchants(int total)
        {
            var fixture = new Fixture();
            var list = fixture.CreateMany<Merchant>(total);
            foreach (var item in list)
            {
                item.PreferredCurrencyId = null;
                item.HasOwnStock = null;
            }
            return list;
        }
    }
}
