using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FSMicroControllerHub.SimConnectInterfacing.ResponseEventHandlers;
using Microsoft.FlightSimulator.SimConnect;

namespace FSMicroControllerHub.SimConnectInterfacing
{
    internal class SimConnectInterface
    {
        /// <summary>
        /// The static SimConnectInstance that is used client-wide.
        /// </summary>
        internal static Microsoft.FlightSimulator.SimConnect.SimConnect SimConnectInstance = null;

        /// <summary>
        /// Create a new SimConnectInterface-instance.
        /// </summary>
        /// <param name="handle">The handle with which the SimConnectInstance is to be associated.</param>
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
                Debug.Print(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Register the Event-Handlers for the events sent by SimConnect to the Client.
        /// </summary>
        internal static void RegisterHandlers()
        {
            try
            {
                SimConnectInstance.OnRecvOpen += SimConnectInterfaceEventHandlers.SimConnectInterface_HandleOnRecvOpen;
                SimConnectInstance.OnRecvSimobjectData += SimConnectInterfaceEventHandlers.SimConnectInterface_HandleOnRecvSimobjectData;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Register the Data-Definitions and Data-Structs.
        /// </summary>
        internal static void RegisterDataDefinitionsAndStructs()
        {
            try
            {
                foreach (var element in EventDataOnSimObject.SimVarHandlerRegistry)
                {
                    var svName = element.Value.GetField("DatumName")?.GetValue(null)?.ToString();
                    SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS dataDefinition = (SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS)element.Value.GetField("DefineId")?.GetValue(null);
                    string? unitsName = element.Value.GetField("UnitsName")?.GetValue(null)?.ToString();
                    int datumType = Convert.ToInt32(element.Value.GetField("DatumType")?.GetValue(null));
                    float fEpsilon = (float)Convert.ToDouble(element.Value.GetField("fEpsilon")?.GetValue(null));
                    uint datumId = Convert.ToUInt32(element.Value.GetField("DatumId")?.GetValue(null));

                    SimConnectInstance.AddToDataDefinition(dataDefinition, svName, null, (SIMCONNECT_DATATYPE)datumType, fEpsilon, datumId);

                    element.Value.GetMethod("RegisterDataDefineStruct")?.Invoke(Activator.CreateInstance(element.Value), new object[] { SimConnectInstance });
                    
                    //SimConnectInstance.AddToDataDefinition(SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY, "CATEGORY", null, SIMCONNECT_DATATYPE.STRING256, 0, 1);
                    //SimConnectInstance.RegisterDataDefineStruct<SimConnectInterfaceDataStructures.CATEGORY>(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Start/Initiate the requests to the SimConnect-server.
        /// </summary>
        internal static void StartRequests()
        {
            try
            {
                foreach (var element in EventDataOnSimObject.SimVarHandlerRegistry)
                {
                    //SimConnectInstance.RequestDataOnSimObject(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY, SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY, 1, SIMCONNECT_PERIOD.ONCE, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);
                    element.Value.GetMethod("StartRequests")?.Invoke(Activator.CreateInstance(element.Value), new object[] { SimConnectInstance });
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Maps the Client-Events to Sim-Events.
        /// </summary>
        internal static void MapClientEvents()
        {
            try
            {
                SimConnectInstance.MapClientEventToSimEvent(SimEvents.SimEventEnums.EVENT_ID.EVENT_COM_RADIO_FRACT_DEC_CARRY, "COM_RADIO_FRACT_DEC_CARRY");
                SimConnectInstance.MapClientEventToSimEvent(SimEvents.SimEventEnums.EVENT_ID.EVENT_COM_RADIO_FRACT_INC_CARRY, "COM_RADIO_FRACT_INC_CARRY");
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }
    }
}
