using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnect
{
    internal class SimConnectInterfaceDefinitionEnums
    {
        internal enum DATA_DEFINITIONS
        {
            SO_CATEGORY = 0
        }

        internal enum DATA_REQUESTS : byte
        {
            SO_CATEGORY
        }
    }
}
