using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany.Service.DTOs
{
    public class CarCreateDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public long PersonId { get; set; }
    }
}
