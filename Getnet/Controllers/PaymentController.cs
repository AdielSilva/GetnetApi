﻿using Getnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Getnet.Controllers
{
    public class PaymentController : ControllerBase
    {
        IConfiguration _configuration;
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("[controller]/TokenCard")]

        //parameters: CardNumber and CustomerId
        public async Task<ActionResult> CardTokenization([FromBody] CardPaymentRequest request)
        {
            JsonResult data;
            try
            {
                // manually input, but you can take by your appsettings
                var service = new Services.GetNetService("https://api-sandbox.getnet.com.br");
                var credential = new Models.Credentials
                {
                    ClientId = "",
                    ClientSecret = ""
                };

                await service.Authentication(credential);

                var response = await service.CardTokenization(tokenCardRequest);

                data = new JsonResult(response);

                return data;
            }
            catch (Exception ex)
            {
                data = new JsonResult(ex);
                data.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return data;
            }


        }
    }
}
