using FSMicroControllerHub.SimConnect.Events;
using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnect
{
    internal class SimConnectInterfaceEventHandlers
    {
        internal static void SimConnectInterface_HandleOnRecvOpen(Microsoft.FlightSimulator.SimConnect.SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            SimConnectInterface.RegisterDataDefinitionsAndStructs();
            SimConnectInterface.StartRequests();
        }

        internal static void SimConnectInterface_HandleOnRecvSimobjectData(Microsoft.FlightSimulator.SimConnect.SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            try
            {
                switch (data.dwRequestID)
                {
                    case (byte)SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY:
                        new EventDataOnSimObject();
                        EventDataOnSimObject.Handle((byte)data.dwDefineID, sender, data);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
