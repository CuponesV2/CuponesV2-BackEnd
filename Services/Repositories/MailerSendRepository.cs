using System.Net.Http;
using System.Text;


namespace Cupones.Services
{
    public class MailerSendRepository : IMailerSendRepository
    {
        private readonly HttpClient _httpClient;
        public MailerSendRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SendMail(string to, string user)
        {
            try
            {
                var requestBody = new
                {
                    from = new
                    {
                        email = "MS_XPsRZo@trial-yzkq340ooe34d796.mlsender.net"
                    },
                    to = new[]
                    {
                        new {
                            email = to
                        }
                    },
                    subject = "Haz redimido un cupón!",
                    variables = new[]{
                        new {
                            email = to,
                            substitutions = new []{
                                new {
                                    var = "name",
                                    value =  user
                                }
                            }
                        }
                    },
                    template_id = "0r83ql3x1dzlzw1j"
                };

                var body = System.Text.Json.JsonSerializer.Serialize(requestBody);

                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mailersend.com/v1/email")
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                request.Headers.Add("Authorization", $"Bearer mlsn.8ec4fc329c5277da5ef3fa7b0f4a7fd574f3370ec1ab2f14d9c74fb5d4bdc437");
                HttpResponseMessage response = _httpClient.Send(request);
                Console.WriteLine(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}