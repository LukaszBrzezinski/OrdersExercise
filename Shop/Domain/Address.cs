namespace Shop.Domain
{
    public class Address
    {
        public string Country { get; }
        public string City { get; }
        public string ZipCode { get; }
        public string Street { get; }
        public string House { get; }

        public Address(string country, string city, string zipCode, string street, string house)
        {
            Country = country;
            City = city;
            ZipCode = zipCode;
            Street = street;
            House = house;
        }
    }
}