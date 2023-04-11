using System;

namespace BusinessPartner
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class DTOBusinessPartner
    {
        public string CardName { get; set; }
        public int Series { get; set; }
        public string FederalTaxID { get; set; }
        public ContactEmployees ContactEmployees { get; set; }
        public Addresses Addresses { get; set; }
        public int PayTermsGrpCode { get; set; }

    }

    public class ContactEmployees
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string E_Mail { get; set; }

    }

    public class Addresses
    {
        //public string AddressName { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        //public int AddressType { get; set; }

    }

    public class Response
    {
        public int code { get; set; }
        public string type { get; set; }
        public string message { get; set; }

    }
}
