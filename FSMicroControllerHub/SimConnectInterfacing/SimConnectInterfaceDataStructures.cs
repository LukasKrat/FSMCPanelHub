using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnectInterfacing
{
    /// <summary>
    /// Contains all Event-Data-Structures to be registered with SimConnect.
    /// </summary>
    internal class SimConnectInterfaceDataStructures
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        internal struct CATEGORY
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String category;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct SO_COM_STANDBY_FREQUENCY_1
        {
            public float COM_STANDBY_FREQUENCY_1;
        };
    }
}
