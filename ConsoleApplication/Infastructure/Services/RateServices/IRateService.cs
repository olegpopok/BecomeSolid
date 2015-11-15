using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Infastructure.Models;

namespace ConsoleApplication.Infastructure.Services.RateServices
{
    public interface IRateService
    {
        List<Rate> GetRates(string from, params string[] to);
    }
}
