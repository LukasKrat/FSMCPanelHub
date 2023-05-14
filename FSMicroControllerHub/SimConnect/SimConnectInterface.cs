using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FlightSimulator.SimConnect;

namespace FSMicroControllerHub.SimConnect
{
    internal class SimConnectInterface
    {
        internal static Microsoft.FlightSimulator.SimConnect.SimConnect SimConnectInstance = null;

        internal SimConnectInterface()
        {
            if (SimConnectInstance == null)
            {
                SimConnectInstance = new Microsoft.FlightSimulator.SimConnect.SimConnect();
            }
        }
    }
}
