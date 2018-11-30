using System;
using System.Net;
using Adventskalender2018.Interfaces.Infrastructure;
using Newtonsoft.Json.Linq;

namespace Adventskalender2018.Implementations.Infrastructure
{
    public class WorldClockApiDateTimeProvider : IDateTimeProvider
    {
        private readonly WebClient _webClient;

        public WorldClockApiDateTimeProvider()
        {
            _webClient = new WebClient();
        }

        public DateTime Today
        {
            get
            {
                try
                {
                    string jsonData = _webClient.DownloadString(address: "http://worldclockapi.com/api/json/cet/now");
                    var x = JObject.Parse(json: jsonData);
                    var y = x.Value<DateTime>(key: "currentDateTime");
                    return y;
                }
                catch (Exception)
                {
                    return DateTime.Today;
                }
            }
        }
    }
}