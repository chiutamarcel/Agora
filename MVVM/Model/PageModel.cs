using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    public class PageModel
    {
        public int CustomerCount { get; set; }
        public string PrdocuctStatus { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TrasactionValue { get; set; }
        public TimeOnly ShippmentDelivery { get; set; }
        public bool LocationStatus { get; set; }
        
    }
}
