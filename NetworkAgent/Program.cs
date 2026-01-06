using System;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetworkAgent
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            string machineName = Environment.MachineName;
            string apiUrl = "https://localhost:44316/Network/PushStats";   // Update with your actual API endpoint

            Console.WriteLine("Starting Ethernet Monitor Agent for: " + machineName);

            var client = new HttpClient();

            // Capture baseline bytes
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            var statsStart = new long[nics.Length][];
            for (int i = 0; i < nics.Length; i++)
            {
                var stats = nics[i].GetIPv4Statistics();
                statsStart[i] = new long[] { stats.BytesReceived, stats.BytesSent };
            }

            while (true)
            {
                for (int i = 0; i < nics.Length; i++)
                {
                    var nic = nics[i];
                    if (nic.OperationalStatus != OperationalStatus.Up) continue;

                    var stats = nic.GetIPv4Statistics();
                    long received = stats.BytesReceived - statsStart[i][0];
                    long sent = stats.BytesSent - statsStart[i][1];

                    statsStart[i][0] = stats.BytesReceived;
                    statsStart[i][1] = stats.BytesSent;

                    var data = new
                    {
                        MachineName = machineName,
                        Interface = nic.Name,
                        InboundBytes = received,
                        OutboundBytes = sent,
                        RecordedAt = DateTime.Now
                    };


                    string json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        var response = await client.PostAsync(apiUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"[{DateTime.Now}] NIC={nic.Name}, In={received} B, Out={sent} B");
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                await Task.Delay(1000);
            }
        }
    }
}
