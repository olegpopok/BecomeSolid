using System.Linq;
using  AutoMapper;
using ConsoleApplication.Infastructure.Models.WeatherModels;

namespace ConsoleApplication.Infastructure.Mappers
{
    public static class MapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<WeatherResponce, Weather>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.weather.First().Description))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.main.temp));
        }
    }
}
