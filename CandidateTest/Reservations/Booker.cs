using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class Booker
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "postalCode")]
        public string PostalCode { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "countryCode")]
        public string CountryCode { get; set; }
    }
}