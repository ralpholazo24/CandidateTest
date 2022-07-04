using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class Domain
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}