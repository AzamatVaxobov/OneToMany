using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany.Service.DTOs
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CarDto> Cars { get; set; } = new List<CarDto>();
    }
}
