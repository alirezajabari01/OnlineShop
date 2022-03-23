using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.BaseEntities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            IsActive = true;
        }
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
