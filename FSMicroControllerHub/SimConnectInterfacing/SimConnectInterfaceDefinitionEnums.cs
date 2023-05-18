using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnectInterfacing
{
    /// <summary>
    /// Contains all Data-Definitions in an enum and all Data-Requests in an enum.
    /// </summary>
    internal class SimConnectInterfaceDefinitionEnums
    {
        /// <summary>
        /// Contains all Data-Definitions.
        /// </summary>
        internal enum DATA_DEFINITIONS
        {
            SO_CATEGORY = 0,
            SO_COM_STANDBY_FREQUENCY_1 = 1
        }

        /// <summary>
        /// Contains all Data-Requests.
        /// </summary>
        internal enum DATA_REQUESTS : byte
        {
            SO_CATEGORY,
            SO_COM_STANDBY_FREQUENCY_1
        }
    }
}
