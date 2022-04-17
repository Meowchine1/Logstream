using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1VoroninaVar5
{
    internal class Street
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<House> Users { get; set; } = new List<House>();
    }
}
