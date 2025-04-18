using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany.DataAccess.Entites
{
    public class Logs
    {
        public long Id { get; set; }
        public string RequestMethod { get; set; }
        public string RequestPath { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
