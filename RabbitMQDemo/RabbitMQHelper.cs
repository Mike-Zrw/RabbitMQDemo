using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDemo
{
    /// <summary>
    /// RabbitMQApi地址：http://localhost:15672/api
    /// </summary>
    public class RabbitMQHelper
    {
        private static string username = "guest";
        private static string password = "guest";
        string queuesUrl = "http://localhost:15672/api/queues";
        private static ConnectionFactory _ConFactory;
        public static ConnectionFactory ConFactory
        {
            get
            {
                if (_ConFactory == null)
                    _ConFactory = new ConnectionFactory() { HostName = "192.168.1.15", Port = 5672, UserName = username, Password = password };
                return _ConFactory;
            }
        }
        /// <summary>
        /// 查询所有队列
        /// </summary>
        /// <returns></returns>
        public string GetAllQuenes()
        {
            string jsonContent = GetApiResult(queuesUrl).Result;
            List<QueueModel> queues = JsonConvert.DeserializeObject<List<QueueModel>>(jsonContent);
            return JsonConvert.SerializeObject(queues);
        }

        private async Task<string> GetApiResult(string Url)
        {
            var client = new HttpClient();
            var passByte = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(passByte));
            using (HttpResponseMessage response = await client.GetAsync(Url).ConfigureAwait(false))
            {
                string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return result;
            }
        }

    }

    public class QueueModel
    {
        public int memory { get; set; }
        public int messages { get; set; }
        public int messages_ready { get; set; }
        public int messages_unacknowledged { get; set; }
        public string idle_since { get; set; }
        public string consumers { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public string vhost { get; set; }
        public bool durable { get; set; }
        public bool auto_delete { get; set; }
        public string node { get; set; }
    }
}
