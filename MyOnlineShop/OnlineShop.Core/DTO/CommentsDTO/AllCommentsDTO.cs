using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.CommentsDTO
{
    public class AllCommentsDTO
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string ParentId { get; set; }
        public string CreateDate { get; set; }
        public string IsActive { get; set; }
        public List<AllCommentsDTO> Replies { get; set; }
    }
}
