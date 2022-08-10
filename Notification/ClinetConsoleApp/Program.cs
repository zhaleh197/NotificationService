using Grpc.Core;
using Grpc.Net.Client;
using ServerGRPCNotification;


Console.WriteLine("salam");
// var channel = GrpcChannel.ForAddress("https://localhost:7269");
var channel = GrpcChannel.ForAddress("https://localhost:7218");
var client = new Greeter.GreeterClient(channel);



//static GrpcChannel CreateAuthenticatedChannel(string address)
//{
//    var credentials = CallCredentials.FromInterceptor((context, metadata) =>
//    {
//        if (!string.IsNullOrEmpty(_token))
//        {
//            metadata.Add("Authorization", $"Bearer {token}");
//        }
//        return Task.CompletedTask;
//    });

//    var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
//    {
//        Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
//    });
//    return channel;
//}


string DoAuthenticatedCall(Greeter.GreeterClient client1, string token)
{
    var headers = new Metadata();
    headers.Add("Authorization", $"Bearer {token}");

    var request = new HelloRequest { Name = " test auth 14010309" };
    var response =  client1.SayHello(request, headers);

    return response.Message;
}

//try
//{






    var reply = client.SayHello(new HelloRequest { Name="sdfsdf" });
    Console.WriteLine(" Greet GRPCV server  Greeter" + reply.Message.ToString());

//Console.ReadLine();
//var client2 = new SMSGrpcs.SMSGrpcsClient(channel);
//var reply2 = client2.SendSMSGrpc(new SMSRequest { To = "09187875761", Txt = "hiii shshla- this is test for GRPC" });
//Console.WriteLine(" SMSGrpcs GRPCV server" + reply2.Res.ToString());

Console.ReadLine();





var client3 = new SMSGrpcs.SMSGrpcsClient(channel);
var reply3 = client3.GetUserSMS(new Empty { });
Console.WriteLine(" GetQeueUserSMS GRPCV server. resiver 1 is:" + reply3.Items[0].Resiver);
Console.ReadLine();
//var client3 = new EmailGrpc.EmailGrpcClient(channel);
//var reply3 = client3.SendEmailGrpc(new EmailRequest { To = "09187875761", Txt = "hiii shshla- this is test for GRPC" });
//Console.WriteLine(" Email GRPCV server" + reply3.Res.ToString());



// var channel = GrpcChannel.ForAddress("https://localhost:7269");
//var client = new SMS.SMSClient(channel);
//var getusers = client.GetUserSMS(new Empty());


//foreach (var item in getusers.Items)
//{
//    Console.WriteLine(item.Id);

//    ////Console.WriteLine($ "{item.Id} { item.ProductId} { item.IdUser} { item.Resiver} { item.Body} { item.DateSend} { item.DateDelivere}{ item.Status}");
//}
//}

//catch (RpcException ex)
//{
//    //ex.Me?ssage;
//    // Write logic to inspect the error and retry
//    // if the error is from a transient fault.
//}

//static void GetAll(SMS.SMSClient client)
//{
//    var RE = client.GetUserSMSAsync(new Empty());

//    foreach (var item in RE)
//    {
//        Console.WriteLine($ "{item.ProductRowId} { item.ProductId} { item.ProductName} { item.CategoryName} { item.Manufacturer} { item.Price} ");
//    }
//}




