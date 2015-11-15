
namespace ConsoleApplication.Infastructure.Models.WeatherModels
{
    public class WeatherResponce
    {
        public Coord coord { get; set; }
        public WeatherDto[] weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
