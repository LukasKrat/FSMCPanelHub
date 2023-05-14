using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnect
{
    internal class SimConnectInterfaceDataStructures
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct StructCategory
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String category;
        };
    }
}
