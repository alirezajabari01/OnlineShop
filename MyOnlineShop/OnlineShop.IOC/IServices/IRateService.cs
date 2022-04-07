using OnlineShop.Core.DTO.RatesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface IRateService
    {
        Task<int> GetAllProductRatesAsync(string id);
        Task<string> CreateRateAsync(CreateRateDTO createRateDTO,string userId);
    }
}
