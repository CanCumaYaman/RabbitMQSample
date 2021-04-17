using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        [HttpPost("TakeEmployee")]
        public IActionResult TakeOrder(TakeeEmployeeRequest request)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    UserName = "cancuma",
                    Password = "cancuma."
                };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                channel.QueueDeclare(
                    queue: "TakeEmployeeQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );
                for(int i = 1; i <= 100; i++)
                {
                    request.EmployeeId = i;
                    var data = JsonConvert.SerializeObject(request);
                    var byteData = Encoding.UTF8.GetBytes(data);
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "TakeEmployeeQueue",
                        basicProperties: null,
                        body: byteData
                        );
                }
                return Ok("Success");
                }
                catch(Exception e)
            {
                return Ok(e.Message);
            
            }
        }
    }
}
