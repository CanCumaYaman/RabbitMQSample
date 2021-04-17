using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Common.Models
{
    public class TakeeEmployeeRequest
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
