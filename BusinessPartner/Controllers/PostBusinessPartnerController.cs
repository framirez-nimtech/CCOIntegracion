using BusinessPartner.SAPDIConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessPartner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostBusinessPartnerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PostBusinessPartnerController> _logger;

        public PostBusinessPartnerController(ILogger<PostBusinessPartnerController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpPost(Name = "PostBusinessPartner")]
        public Response Post(DTOBusinessPartner businessPartner)
        {
            Response response = new Response();
            Company? oCompany = null;
            try
            {

                oCompany = SapConnection.connection();

                if (oCompany != null)
                {
                    BusinessPartners businessPartners = oCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);
                    businessPartners.CardName = businessPartner.CardName;
                    businessPartners.Series = businessPartner.Series; //74;
                    businessPartners.CardType = BoCardTypes.cCustomer;
                    businessPartners.FederalTaxID = businessPartner.FederalTaxID; //"123456789012";

                    businessPartners.ContactEmployees.Name = businessPartner.ContactEmployees.Name;
                    businessPartners.ContactEmployees.FirstName = businessPartner.ContactEmployees.FirstName;
                    businessPartners.ContactEmployees.LastName = businessPartner.ContactEmployees.LastName;
                    businessPartners.ContactEmployees.Position = businessPartner.ContactEmployees.Position;
                    businessPartners.ContactEmployees.E_Mail = businessPartner.ContactEmployees.E_Mail;
                    businessPartners.ContactEmployees.Add();

                    businessPartners.Addresses.AddressName = "Entregas";
                    businessPartners.Addresses.State = businessPartner.Addresses.State;
                    businessPartners.Addresses.Country = businessPartner.Addresses.Country;
                    businessPartners.Addresses.Street = businessPartner.Addresses.Street;
                    businessPartners.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_ShipTo;
                    businessPartners.Addresses.Add();

                    businessPartners.Addresses.AddressName = "Facturacción";
                    businessPartners.Addresses.State = businessPartner.Addresses.State;
                    businessPartners.Addresses.Country = businessPartner.Addresses.Country;
                    businessPartners.Addresses.Street = businessPartner.Addresses.Street;
                    businessPartners.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo;
                    businessPartners.Addresses.Add();

                    businessPartners.PayTermsGrpCode = businessPartner.PayTermsGrpCode; //11;



                    if (businessPartners.Add() == 0)
                    {
                        response.code = 0;
                        response.type = "Success";
                        response.message = "Business partner created in SAP: CardCode " + oCompany.GetNewObjectKey();
                    }
                    else
                    {
                        response.code = oCompany.GetLastErrorCode();
                        response.type = "Error";
                        response.message = "Error creating business partner to SAP: " + oCompany.GetLastErrorDescription();
                    }

                }
                else
                {
                    response.type = "Error";
                    response.message = "Connection to SAP not established";
                }
            }
            catch (Exception ex)
            {
                response.type = "Error";
                response.message = ex.Message;
            }

            return response;
        }
    }
}
