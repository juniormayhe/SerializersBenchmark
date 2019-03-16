using System;

namespace Application.DTOs
{
    using System.Collections;
    using System.Collections.Generic;

    public class Merchant
    {
        public Guid RequestId { get; set; }
        public int MerchantId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<ShippingOption> ShippingOptions { get; set; }

    }
}
