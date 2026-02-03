using Safonov_POSU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OPCClientApp
{
    internal interface IOPCClientControl
    {
        void Init(SimpleOPCClient client);
    }
}
