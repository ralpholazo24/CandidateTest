using Hoteliga.Channel.HotelAvailabilities.Responses.Reservations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CandidateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // EXCERCISE #1
            // During deserialization there will be two exceptions
            // modify the Reservation class and all its associated classes accordingly 
            // so that the deserialization works without problems
            DeserializeReservation();

            // EXCERCISE #2
            // Implement ConvertBookerToCustomer as you feel fit to support the following cases
            // for name conversion. As you will see, in the Booker class, the name is one simple string
            // while in hoteliga there is a separation for first name and second name
            // the booker can be from one word to four words. Develop the logic as you see fit so that the method
            // ConvertBookerToCustomer is ready to handle from 1 to 4 words and throw exceptions for other cases
            var hoteligaCustomer1 = ConvertBookerToCustomer(new Booker { Name = "Dimitris van Leusden" });
            var hoteligaCustomer2 = ConvertBookerToCustomer(new Booker { Name = "Smith" });
            var hoteligaCustomer3 = ConvertBookerToCustomer(new Booker { Name = "John Smith" });
            var hoteligaCustomer4 = ConvertBookerToCustomer(new Booker { Name = "José Luis Rodríguez Zapatero" });

            // EXERCISE #3
            // currently the output of the method is 
            //  <Reservations xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            //  <ReservationsList>
            //    <Reservation>
            //      <ReservationId>123</ReservationId>
            //      <LastName>van Leusden</LastName>
            //    </Reservation>
            //    <Reservation>
            //      <ReservationId>567</ReservationId>
            //      <LastName>Smith</LastName>
            //    </Reservation>
            //  </ReservationsList>
            //  </Reservations>
            // Adjust the code accordingly so that the output is:
            //  <Reservations>
            //    <Reservation id="123">
            //      <LastName>van Leusden</LastName>
            //    </Reservation>
            //    <Reservation id="567">
            //      <LastName>Smith</LastName>
            //    </Reservation>
            //  </Reservations>
            SerializeReservationsListToXml();
        }

        private static void DeserializeReservation()
        {
            var reservationsJson = File.ReadAllText("SampleReservation.json");
            var reservationsObject = JsonConvert.DeserializeObject<Hoteliga.Channel.HotelAvailabilities.Responses.Reservations.Reservation>(reservationsJson);
            Console.WriteLine("Successful deserialization");
        }

        private static Customer ConvertBookerToCustomer(Booker booker)
        {
            // TODO: Add implementation here
            Customer customer = new Customer();
            if (booker != null)
            {
                var fullname = booker.Name.Split(" ");

                switch(fullname.Length)
                {
                    case 1:
                        customer.FirstName = booker.Name;
                        break;
                    case 2: 
                        customer.FirstName = fullname[0];
                        customer.LastName = fullname[1];
                        break;
                    case 3:
                        customer.FirstName = fullname[0];
                        customer.LastName = string.Format("{0} {1}", fullname[1], fullname[2]);
                        break;
                    case 4:
                        customer.FirstName = string.Format("{0} {1}", fullname[0], fullname[1]);
                        customer.LastName = string.Format("{0} {1}", fullname[2], fullname[3]);
                        break;
                    default:
                        break;
                }
            }                      
            return customer;
        }

        private static void SerializeReservationsListToXml()
        {
            var reservationsList = new Reservations
            {
                ReservationsList = new List<Reservation>()
                {
                    new Reservation { ReservationId = "123", LastName = "van Leusden"},
                    new Reservation { ReservationId = "567", LastName = "Smith"}
                }
            };
           
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");
            var serializer = new XmlSerializer(reservationsList.GetType());
            serializer.Serialize(Console.Out, reservationsList, xmlSerializerNamespaces);
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    [XmlRoot("Reservations")]
    public class Reservations
    {
        [XmlElement("Reservation")]
        public List<Reservation> ReservationsList { get; set; }

        public Reservations()
        {
            ReservationsList = new List<Reservation>();
        }
    }

    public class Reservation
    {
        [XmlAttributeAttribute("id")]
        public string ReservationId { get; set; }
        public string LastName { get; set; }
    }
}