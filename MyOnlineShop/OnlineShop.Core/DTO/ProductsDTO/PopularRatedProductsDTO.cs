using OnlineShop.Core.DTO.CommentsDTO;
using OnlineShop.Core.DTO.RatesDTO;
using OnlineShop.Core.DTO.VotesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.ProductsDTO
{
    public class PopularRatedProductsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public int Inventory { get; set; }
                
        public List<AllCommentsDTO> Comments { get; set; }
        public List<AllProductVotesDTO> ProductVotes { get; set; }
        public List<AllProductRateDTO> ProductRates { get; set; }
        public decimal Rate;
        public decimal RatePercent
        {
            get
            {
                int ratesValue = 0;
                int ratesCount = ProductRates.Count();
             
                foreach (var item in ProductRates)
                {
                    ratesValue += item.Rate;
                }
                Rate = (ratesValue * 100) / (ratesCount * 5);
                return Rate;
            }
            set
            {
                Rate = value;
            }
        }
    }
}
