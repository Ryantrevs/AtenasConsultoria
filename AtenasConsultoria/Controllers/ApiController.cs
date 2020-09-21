using AtenasConsultoria.API;
using AtenasConsultoria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public async Task<IActionResult> CriarLink(ApiViewModel model)
        {
            if (ModelState.IsValid)
            {
                items Item = new items()
                {
                    id = Guid.NewGuid().ToString(),
                    title = model.title,
                    unit_price = model.unit_price,
                    quantity = model.quantity,
                    tangible = model.tangible
                };
                LinkPagamento novo = new LinkPagamento()
                {
                    api_key = configuration.GetConnectionString("ApiKey"),
                    name = model.name,
                    amount = model.amount,
                    payment_Config = new payment_config()
                    {
                        boleto = new boleto()
                        {
                            enabled = model.enabledboleto,
                            expires_in = model.expires_in
                        },
                        credit_Card = new credit_card()
                        {
                            enabled = model.enabledCard,
                            free_installments = model.free_installments,
                            interest_rate = model.interest_rate,
                            max_installments = model.max_installments
                        }

                    }
                };
                novo.AddItem(Item);

                var resultado = await criarLink(novo);

                Console.WriteLine(resultado);

                return RedirectToAction("");
            }
            return View();
        }

        private async Task<string> criarLink(LinkPagamento model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetConnectionString("BaseAddress"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(model);

            var response = await client.PostAsync("https://api.pagar.me/1/payment_links",new StringContent(json,Encoding.UTF8,"application/json"));

            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
         
        }
    }
}
