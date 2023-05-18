using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnectInterfacing.ResponseEventHandlers.SimVarHandlers
{
    internal class SO_COM_Standby_Frequency_1 : IEventSimVar
    {
        public readonly static string DatumName = "COM STANDBY FREQUENCY:1";
        public readonly static SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS DefineId = SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_COM_STANDBY_FREQUENCY_1;

        public readonly static string? UnitsName = "MHz";

        public readonly static int? DatumType = (int)SIMCONNECT_DATATYPE.FLOAT32;

        public readonly static float? fEpsilon = 0;

        public readonly static int? DatumId = 0;

        public void RegisterDataDefineStruct(ref SimConnect simConnectInstance)
        {
            simConnectInstance.RegisterDataDefineStruct<SimConnectInterfaceDataStructures.SO_COM_STANDBY_FREQUENCY_1>(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_COM_STANDBY_FREQUENCY_1);
        }

        public void StartRequests(ref SimConnect simConnectInstance)
        {
            try
            {
                simConnectInstance.RequestDataOnSimObject(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_COM_STANDBY_FREQUENCY_1, SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_COM_STANDBY_FREQUENCY_1, 1, SIMCONNECT_PERIOD.SIM_FRAME, SIMCONNECT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        public void Handle(object eventSender, object eventData)
        {
            Debug.Print((((SimConnectInterfaceDataStructures.SO_COM_STANDBY_FREQUENCY_1)((SIMCONNECT_RECV_SIMOBJECT_DATA)eventData).dwData[0]).COM_STANDBY_FREQUENCY_1.ToString()));
        }
    }
}
