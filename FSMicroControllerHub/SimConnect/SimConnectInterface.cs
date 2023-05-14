using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSMicroControllerHub.SimConnect.ResponseEventHandlers;
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
                    new EventDataOnSimObject();  //Create istance and register internal event-handlers;
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
                foreach (var element in EventDataOnSimObject.SimVarHandlerRegistry)
                {
                    var dataDefinition = (SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS)element.Value.GetField("DefinitionId")?.GetValue(null);
                    var svName = element.Value.GetField("Name")?.GetValue(null)?.ToString();
                    
                    SimConnectInstance.AddToDataDefinition(dataDefinition, svName, null, SIMCONNECT_DATATYPE.STRING256, 0, 1);

                    //SimConnectInstance.AddToDataDefinition(SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY, "CATEGORY", null, SIMCONNECT_DATATYPE.STRING256, 0, 1);
                    SimConnectInstance.RegisterDataDefineStruct<SimConnectInterfaceDataStructures.CATEGORY>(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY);
                }
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
                //SimConnectInstance.RequestDataOnSimObject(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY, SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY, 1, SIMCONNECT_PERIOD.ONCE, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        internal static void MapClientEvents()
        {
            try
            {
                SimConnectInstance.MapClientEventToSimEvent(SimEvents.SimEventEnums.EVENT_ID.EVENT_COM_RADIO_FRACT_DEC_CARRY, "COM_RADIO_FRACT_DEC_CARRY");
                SimConnectInstance.MapClientEventToSimEvent(SimEvents.SimEventEnums.EVENT_ID.EVENT_COM_RADIO_FRACT_INC_CARRY, "COM_RADIO_FRACT_INC_CARRY");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
