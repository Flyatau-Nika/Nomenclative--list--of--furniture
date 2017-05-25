using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomenclative__list__of__furniture
{[Serializable]
    class Auth
    {
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Auth(string password)
        {
            _password = password;
        }
    }
}
