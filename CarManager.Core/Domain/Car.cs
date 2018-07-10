using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Domain
{
    public class Car:BaseEntity<string>
    {
        public string Name { set; get; }
        public decimal Price { set; get; }

        public string Comment { set; get; }
    }
}
