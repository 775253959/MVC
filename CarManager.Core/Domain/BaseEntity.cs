using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Domain
{
    public class BaseEntity<T>
    {
        public T Id { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDT { set; get; }
        public string UpdateBy { set; get; }
        public DateTime UpdateDT { set; get; }
    }
}
