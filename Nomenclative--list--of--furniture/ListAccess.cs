using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomenclative__list__of__furniture
{
    [Serializable]
    public class ListAccess
    {
        public List<Accessories> LA { get; set; }
        public ListAccess(List<Accessories> la)
        {
            LA = la;
        }

        public ListAccess()
        {

        }
    }
}
