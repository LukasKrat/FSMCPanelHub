using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FlightSimulator.SimConnect;

namespace FSMicroControllerHub.SimConnect
{
    internal class SimConnectInterface
    {
        internal static Microsoft.FlightSimulator.SimConnect.SimConnect SimConnectInstance = null;

        internal SimConnectInterface(IntPtr handle)
        {
            try
            {
                if (SimConnectInstance == null)
                {
                    SimConnectInstance = new Microsoft.FlightSimulator.SimConnect.SimConnect(Program.Configuration["SimConnect:ClientName"], handle, Convert.ToUInt32(Program.Configuration["SimConnect:WmUserId"]), null, 0);
                    RegisterHandlers();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        internal static void RegisterHandlers()
        {
            try
            {
                SimConnectInstance.OnRecvOpen += SimConnectInterfaceEventHandlers.SimConnectInterface_HandleOnRecvOpen;
                SimConnectInstance.OnRecvSimobjectData += SimConnectInterfaceEventHandlers.SimConnectInterface_HandleOnRecvSimobjectData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        internal static void RegisterDataDefinitionsAndStructs()
        {
            try
            {
                // SimObject - CATEGORY
                SimConnectInstance.AddToDataDefinition(SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY, "CATEGORY", null, SIMCONNECT_DATATYPE.STRING256, 0, 1);
                SimConnectInstance.RegisterDataDefineStruct<SimConnectInterfaceDataStructures.CATEGORY>(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        internal static void StartRequests()
        {
            try
            {
                SimConnectInstance.RequestDataOnSimObject(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY, SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY, 1, SIMCONNECT_PERIOD.ONCE, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
