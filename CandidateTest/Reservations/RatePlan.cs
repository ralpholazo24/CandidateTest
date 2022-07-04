using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class RatePlan
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}