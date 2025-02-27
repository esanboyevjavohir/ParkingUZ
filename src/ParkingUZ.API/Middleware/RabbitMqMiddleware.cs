using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Airways.API.Middleware
{
    public class RabbitMqMiddleware
    {
        private readonly RequestDelegate _next;

        public RabbitMqMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestData = new
            {
                Method = context.Request.Method,
                Host = context.Request.Host,
                Path = context.Request.Path,
                Body = context.Request.Body.ToString()
                //Body = await ReadRequestBodyAsync(context.Request)
            };
           
            var originalResponseBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var responseData = new
            {
                StatusCode = context.Response.StatusCode,
                Body = context.Response.Body.ToString(),
                Headers = context.Response.Headers
               // Body = responseBodyText
            };

            var AllApi = new
            {
                request = requestData,
                responce = responseData,
            };

            SendToRabbitMq("api.ticket", AllApi);

            await responseBody.CopyToAsync(originalResponseBodyStream);
        }

        private static async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
            request.Body.Seek(0, SeekOrigin.Begin);
            return Encoding.UTF8.GetString(buffer);
        }

        private static void SendToRabbitMq(string queueName, object data)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var message = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange:"",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
