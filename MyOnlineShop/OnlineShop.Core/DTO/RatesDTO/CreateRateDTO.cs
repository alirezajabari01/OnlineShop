using OnlineShop.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.RatesDTO
{
    public class CreateRateDTO
    {
        [MaxValue(5)]
        public int Rate { get; set; }
        [Required]
        public string ProductId { get; set; }
    }
}
