using AtenasConsultoria.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace AtenasConsultoria.Controllers
{
    public class ApiController:Controller
    {
        private readonly IConfiguration configuration;


        public ApiController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult CriarLink()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarLink(LinkPagamento model)
        {
            if (ModelState.IsValid)
            {
                LinkPagamento novo = new LinkPagamento()
                {
                    api_key = configuration.GetConnectionString("ApiKey"),
                    name = model.name,
                    amount = model.amount,
                    items = new items()
                    {
                        id = Guid.NewGuid().ToString(),
                        title = model.items.title,
                        unit_price = model.items.unit_price,
                        quantity = model.items.quantity,
                        tangible = model.items.tangible
                    },
                    payment_Config = new payment_config()
                    {
                        boleto = new boleto()
                        {
                            enabled = model.payment_Config.boleto.enabled,
                            expires_in = model.payment_Config.boleto.expires_in
                        },
                        credit_Card = new credit_card()
                        {
                            enabled = model.payment_Config.credit_Card.enabled,
                            free_installments = model.payment_Config.credit_Card.free_installments,
                            interest_rate = model.payment_Config.credit_Card.interest_rate,
                            max_installments = model.payment_Config.credit_Card.max_installments
                        }

                    }
                };

                _ = await criarLink(novo);

                return RedirectToAction("");
            }
            return View();
        }

        private async Task<HttpResponseMessage> criarLink(LinkPagamento model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetConnectionString("BaseAddress"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            
            var json = JsonConvert.SerializeObject(model);

            HttpResponseMessage response = await client.PostAsync("/payment_links", new StringContent(json,
                                                                                               Encoding.UTF8,
                                                                                               "application/json"));

            return response;
        }
    }
}
