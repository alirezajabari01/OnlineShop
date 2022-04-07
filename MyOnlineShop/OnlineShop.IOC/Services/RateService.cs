using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO.RatesDTO;
using OnlineShop.Domain.Entities.UserFeedBacks;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.Services
{
    public class RateService : IRateService
    {
        private readonly IRepository<ProductRate> repository;
        private readonly IMapper mapper;

        public RateService(IRepository<ProductRate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<string> CreateRateAsync(CreateRateDTO createRateDTO, string userId)
        {
            string outPut = "انجام نشد";

            var userRatesAny = await repository.GetAll()
                .Where(w => w.ProductId == createRateDTO.ProductId && w.UserId == userId)
                .SingleOrDefaultAsync();
            if (userRatesAny != null)
            {
                userRatesAny.Rate = createRateDTO.Rate;
                var updateResult = await repository.UpdateAsync(userRatesAny);
                if (updateResult > 0)
                {
                    outPut = "انجام شد";
                }
            }
            else
            {
                var mappedRate = mapper.Map<ProductRate>(createRateDTO);
                mappedRate.UserId = userId;
                var createResult = await repository.CreateAsync(mappedRate);
                if(createResult > 0)
                {
                    outPut = "انجام شد";
                }
            }

            return outPut;
        }

        public async Task<int> GetAllProductRatesAsync(string id)
        {
            int ratePercent = 0;
            int ratesCount = 0;
            int ratesValue = 0;

            var rates = await repository.GetAll().Where(w => w.ProductId == id).ToListAsync();
            if (rates.Any())
            {
                ratesCount = rates.Count();
                foreach (var rate in rates)
                {
                    ratesValue += rate.Rate;
                }
            }

            ratePercent = (ratesValue * 100) / (ratesCount * 5);

            return ratePercent;
        }
    }
}
