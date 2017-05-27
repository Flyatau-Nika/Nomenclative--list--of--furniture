using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomenclative__list__of__furniture
{[Serializable]
    public class ListFurn
    {
        public List<Furniture> LF { get; set; } = new List<Furniture>();
        public ListFurn(List<Furniture> lf)
        {
            LF = lf;
        }

        public ListFurn()
        {
        }
    }
}
