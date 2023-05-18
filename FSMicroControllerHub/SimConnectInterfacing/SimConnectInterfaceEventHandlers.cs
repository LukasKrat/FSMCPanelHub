using FSMicroControllerHub.SimConnectInterfacing.ResponseEventHandlers;
using FSMicroControllerHub.SimConnectInterfacing.SimEvents;
using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnectInterfacing
{
    internal class SimConnectInterfaceEventHandlers
    {
        internal static void SimConnectInterface_HandleOnRecvOpen(Microsoft.FlightSimulator.SimConnect.SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            SimConnectInterface.RegisterDataDefinitionsAndStructs();
            SimConnectInterface.MapClientEvents();
            SimConnectInterface.StartRequests();

            // TEST START
            /*
            for (int i = 0; i < 10; i++)
            {
                SimConnectInterface.SimConnectInstance.TransmitClientEvent(1, SimEventEnums.EVENT_ID.EVENT_COM_RADIO_FRACT_INC_CARRY, 0, null, SIMCONNECT_EVENT_FLAG.DEFAULT);

                Thread.Sleep(500);
            }
            */
            // TEST END

        }

        /// <summary>
        /// Handles all received SimobjectData-Events and routes them, based on their Request-Id, to the related handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        internal static void SimConnectInterface_HandleOnRecvSimobjectData(Microsoft.FlightSimulator.SimConnect.SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            try
            {
                switch (data.dwRequestID)
                {
                    case (byte)SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY:
                        new EventDataOnSimObject();
                        EventDataOnSimObject.Handle((SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS)data.dwDefineID, sender, data);
                        break;
                    case (byte)SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_COM_STANDBY_FREQUENCY_1:
                        new EventDataOnSimObject();
                        EventDataOnSimObject.Handle((SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS)data.dwDefineID, sender, data);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }
    }
}
