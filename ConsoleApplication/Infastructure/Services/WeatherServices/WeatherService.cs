using ConsoleApplication.Infastructure.Models.WeatherModels;
using System.Net;
using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace ConsoleApplication.Infastructure.Services.WeatherServices
{
    public class WeatherService : IWeatherService
    {
        private const string BaseUrl = "http://api.openweathermap.org";
        private const string WeatherApiKey = "ab5eba46f2daa5872f8afdac8d8e50b8";

        public Weather GetWeatherForCity(string city)
        {
            city = WebUtility.UrlEncode(city);

            var client = new RestClient(BaseUrl);

            var request = new RestRequest("/data/2.5/weather", Method.GET);
            request.AddParameter("q", city);
            request.AddParameter("APPID", WeatherApiKey);
            request.AddParameter("units", "metric");

            var responce = client.Execute(request);
            var weatherResponce = JsonConvert.DeserializeObject<WeatherResponce>(responce.Content);

            return Mapper.Map<Weather>(weatherResponce);
        }
    }
}
