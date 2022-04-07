using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.VotesDTO
{
    public class AllProductVotesDTO
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public bool Vote { get; set; }
    }
}
