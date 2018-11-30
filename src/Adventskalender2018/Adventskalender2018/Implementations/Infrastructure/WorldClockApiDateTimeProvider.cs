using System;
using System.Net;
using Adventskalender2018.Interfaces.Infrastructure;
using Newtonsoft.Json.Linq;

namespace Adventskalender2018.Implementations.Infrastructure
{
    public class WorldClockApiDateTimeProvider : IDateTimeProvider
    {
        public DateTime Today
        {
            get
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        string jsonData = webClient.DownloadString(address: "http://worldclockapi.com/api/json/cet/now");
                        JObject parsedJObject = JObject.Parse(json: jsonData);
                        return parsedJObject.Value<DateTime>(key: "currentDateTime");
                    }
                }
                catch (Exception)
                {
                    return DateTime.Today;
                }
            }
        }
    }
}