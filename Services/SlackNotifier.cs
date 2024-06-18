using System.Text;
using Newtonsoft.Json;
using SlackAPI;

namespace Cupones.Services
{
    public class SlackNotifier
    {
        private readonly HttpClient _httpClient;
        private readonly string _webhookUrl;
        public SlackNotifier(HttpClient httpClient, string webhookUrl)
        {
            _webhookUrl = webhookUrl;
            _httpClient = httpClient;
        }
        public async Task NotifyAsync(string message)
        {
            // Configuración del mensaje hacia slack
            var payload = new { text = $"‼️Actualmente tenemos un bug en proceso.. \n\nEl cual tiene como error: {message} \n\n Fecha y hora: {DateTime.Now}" };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            //var client = new SlackTaskClient(_webhookUrl);

            try
            {
                var response = await _httpClient.PostAsync(_webhookUrl, httpContent);
                Console.WriteLine(httpContent.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error sending message to Slack: {ex.Message}");
            }
        }
    }
}