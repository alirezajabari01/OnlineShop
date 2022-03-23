using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.CategoriesDTO
{
    public class ShowCategiroesDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public List<ShowCategiroesDTO> SubCategiries { get; set; }
    }
}
