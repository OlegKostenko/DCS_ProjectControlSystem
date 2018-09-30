using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.DAL.Entities
{
    public class ProjectLine
    {
        public Product Product { get; set; }
        public int Quntity { get; set; }
    }
}
