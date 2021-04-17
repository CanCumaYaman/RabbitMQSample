using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Common.Models;
using System;
using System.Text;

namespace RabbitMQ.Console.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName="localhost",
                UserName="cancuma",
                Password="cancuma."
            };
            var conneciton = factory.CreateConnection();
            var channel = conneciton.CreateModel();
            channel.QueueDeclare(
                queue:"TakeEmployeeQueue",
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null
                );
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, mq) =>
              {
                  var data = Encoding.UTF8.GetString(mq.Body.ToArray());
                  var consumeData = JsonConvert.DeserializeObject<TakeeEmployeeRequest>(data);
                  System.Console.WriteLine(String.Format("{0} ID user has added the employee named {1}", consumeData.EmployeeId, consumeData.EmployeeName));

              };
            channel.BasicConsume(
                queue:"TakeEmployeeQueue",
                autoAck:true,
                consumer:consumer
                );
            System.Console.ReadKey();
        }
    }
}
