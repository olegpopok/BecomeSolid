using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Infastructure.Models;
using ConsoleApplication.Infastructure.Models.RateModels;
using ConsoleApplication.Infastructure.Models.WeatherModels;
using Newtonsoft.Json;
using RestSharp;
using System.Xml.Serialization;
using RestSharp.Deserializers;

namespace ConsoleApplication.Infastructure.Services.RateServices
{
    public class RateService : IRateService
    {
        private const string BaseUrl="http://www.nbrb.by";
        private DailyExRates _rateContainer;

        public List<Rate> GetRates(string from, params string[] to)
        {

            LoadRates();

            return null;
        }

        private void LoadRates()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("Services/XmlExRates.aspx", Method.GET);
            var responce = client.Execute(request);
            var xmlDeserializer = new XmlSerializer(typeof(DailyExRates));

            using (TextReader reader = new StringReader(responce.Content))
            {
                var weatherResponce = xmlDeserializer.Deserialize(reader) as DailyExRates;
            }
        }

    }
}
