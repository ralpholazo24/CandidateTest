using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class GuestsCount
    {
        [DataMember(Name = "adults")]
        public int? Adults { get; set; }

        [DataMember(Name = "children")]
        public int? Children { get; set; }
    }
}