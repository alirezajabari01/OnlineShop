using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.VotesDTO
{
    public class CreateVoteDTO
    {
        [Required]
        public bool Vote { get; set; }
        [Required]
        public string ProductId { get; set; }
    }
}
