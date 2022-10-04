using Microsoft.AspNetCore.Mvc;
using Confluent.Kafka; 
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Kafka;

namespace ApacheKafkaProducerDemo.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly string
        bootstrapServers = "localhost:9092";
        //private readonly string topic = "sms";

       // private readonly ILogger<ProducerController> _logger;
       // private IProducer<Null, string> producer;


        //public ProducerController(ILogger<ProducerController> logger)
        //{ 
        //   _logger = logger;
        //    ProducerConfig config = new ProducerConfig
        //    {
        //        BootstrapServers = bootstrapServers,
        //        ClientId = Dns.GetHostName()
        //    };
        //     producer = new ProducerBuilder<Null, string>(config).Build();
        //}
      




    //    /// <summary>
    //    /// ////////////////thats True.
    //    /// </summary>
    //    /// <param name="orderRequest"></param>
    //    /// <returns></returns>
    //[HttpPost]
    //    public async Task<IActionResult>
    //    Post([FromBody] OrderRequest orderRequest)
    //    {
    //        string message = JsonSerializer.Serialize(orderRequest);
    //        return Ok(await SendOrderRequest("1", message));
    //    }
    //    private async Task<bool> SendOrderRequest
    //    (string topic, string message)
    //    {
    //        ProducerConfig config = new ProducerConfig
    //        {
    //            BootstrapServers = bootstrapServers,
    //            ClientId = Dns.GetHostName()
    //        };

    //        try
    //        {
    //            using (var producer = new ProducerBuilder
    //            <Null, string>(config).Build())
    //            {
    //                var result = await producer.ProduceAsync
    //                (topic, new Message<Null, string>
    //                {
    //                    Value = message
    //                });
    //                Debug.WriteLine($"Delivery Timestamp:{  result.Timestamp.UtcDateTime}");
    //                return await Task.FromResult(true);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error occured: {ex.Message}");
    //        }

    //        return await Task.FromResult(false);
    //    }
        ////////////////////////////////////////////////////////////////////////

         
        [HttpPost]
        public async Task<IActionResult>
            Post([FromBody] OrderRequestFull orderRequest)
        {
            string message = JsonSerializer.Serialize(orderRequest);
            return Ok(await SendOrderRequest(orderRequest.topic, message));
        }
        private async Task<bool> SendOrderRequest
        (string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder
                <Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topic, new Message<Null, string>
                    {
                        Value = message
                    });
                    Debug.WriteLine($"Delivery Timestamp:{  result.Timestamp.UtcDateTime}");
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return await Task.FromResult(false);
        }






        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] OrderRequest orderRequest)
        //{
        //    string message = JsonSerializer.Serialize(orderRequest);
        //    var res=await SendOrderRequest(orderRequest.topic, message);
        //    return Ok(res);
        //    //return Ok(await SendOrderRequest(topic, message));
        //}

        //private async Task<OrderProcessingRequest> SendOrderRequest(string topic, string message)
        //{


        //    try
        //    {
        //        using (producer)
        //        {
        //            var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });

        //            Debug.WriteLine($"Delivery Timestamp:{  result.Timestamp.UtcDateTime}");

        //            return await Task.FromResult(new OrderProcessingRequest { datesend=DateTime.Now.ToString(),statuse="ارسال شد"});
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error occured: {ex.Message}");
        //    }

        //    return await Task.FromResult(new OrderProcessingRequest { cost = 0, deliverd = 0, statuse = "ارسال نشد" });
        //}

    }
}

