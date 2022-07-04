using System.Runtime.Serialization;

namespace Hoteliga.Channel.HotelAvailabilities.Responses.Reservations
{
    [DataContract]
    public class Rate
    {
        [DataMember(Name = "effectiveDate")]
        public string EffectiveDate { get; set; }

        [DataMember(Name = "expireDate")]
        public string ExpireDate { get; set; }

        [DataMember(Name = "amountBeforeTax")]
        public decimal? AmountBeforeTax { get; set; }

        [DataMember(Name = "tax")]
        public decimal? Tax { get; set; }

        [DataMember(Name = "amountAfterTax")]
        public decimal? AmountAfterTax { get; set; }

        [DataMember(Name = "commission")]
        public decimal? Commission { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }
    }
}