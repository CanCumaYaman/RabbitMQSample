using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Common.Models
{
    public class TakeOrderRequest
    {
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
    }
}
