using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class RoomStay
    {
        [DataMember(Name = "indexNumber")]
        public int IndexNumber { get; set; }

        [DataMember(Name = "roomType")]
        public RoomType RoomType { get; set; }

        [DataMember(Name = "ratePlan")]
        public RatePlan RatePlan { get; set; }

        [DataMember(Name = "checkIn")]
        public string CheckIn { get; set; }

        public DateTime CheckinDate
        {
            get
            {
                return DateTime.ParseExact(CheckIn, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
            }
        }

        [DataMember(Name = "checkOut")]
        public string CheckOut { get; set; }

        public DateTime CheckOutDate
        {
            get
            {
                return DateTime.ParseExact(CheckOut, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo); 
            }
        }

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
        public List<object> Comments { get; set; }

        [DataMember(Name = "rates")]
        public List<Rate> Rates { get; set; }

        public RoomStay()
        {
            Rates = new List<Rate>();
            RoomType = new RoomType();
        }

    }
}