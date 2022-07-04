using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class ReservationsError
    {
        [DataMember]
        public string TimeStamp { get; set; }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public Errors Errors { get; set; }

        public DateTime TimeStampDate
        {
            get
            {
                return DateTime.Parse(TimeStamp, DateTimeFormatInfo.InvariantInfo);
            }
        }

        public ReservationsError()
        {
            Errors = new Errors();
        }
    }

    public class Errors
    {
        public List<string> GeneralErrors { get; set; }
    }
}