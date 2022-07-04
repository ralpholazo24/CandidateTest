using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class ListReservation
    {
        [DataMember(Name = "timestamp")]
        public DateTime TimeStamp { get; set; }

        [DataMember(Name = "reservations")]
        public List<Reservation> Reservations { get; set; }

        [DataMember(Name = "nextPage")]
        public int? NextPage { get; set; }
    }
}
