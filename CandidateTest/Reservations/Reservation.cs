using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class Reservation
    {
        [DataMember(Name = "reservationId")]
        public string ReservationId { get; set; }

        [DataMember(Name = "reservationStatus")]
        public string ReservationStatus { get; set; }

        [DataMember(Name = "channel")]
        public string Channel { get; set; }

        [DataMember(Name = "domain")]
        public Domain Domain { get; set; }

        [DataMember(Name = "createdAt")]
        public string CreatedAt { get; set; }

        public DateTime CreateDate
        {
            get
            {
                // we need to drop the hours of the reservation creation date otherwise
                // the comparison when a change comes will be confused
                return DateTime.ParseExact(CreatedAt, "yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo).Date;
            }
        }

        [DataMember(Name = "lastModifiedAt")]
        public string LastModifiedAt { get; set; }

        [DataMember(Name = "amountBeforeTax")]
        public decimal? AmountBeforeTax { get; set; }

        [DataMember(Name = "amountAfterTax")]
        public decimal? AmountAfterTax { get; set; }

        [DataMember(Name = "tax")]
        public decimal? Tax { get; set; }

        [DataMember(Name = "commission")]
        public decimal? Commission { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "comments")]
        public string Comments { get; set; }

        [DataMember(Name = "guestsCount")]
        public GuestsCount GuestsCount { get; set; }

        [DataMember(Name = "booker")]
        public Booker Booker { get; set; }

        [DataMember(Name = "guests")]
        public List<Guest> Guests { get; set; }

        [DataMember(Name = "roomStays")]
        public List<RoomStay> RoomStays { get; set; }

        public Reservation()
        {
            Booker = new Booker();
        }
    }
}