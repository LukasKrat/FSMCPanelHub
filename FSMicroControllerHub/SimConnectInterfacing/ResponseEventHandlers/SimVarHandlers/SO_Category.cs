using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnectInterfacing.ResponseEventHandlers.SimVarHandlers
{
    internal class SO_Category : IEventSimVar
    {
        public readonly static string DatumName = "CATEGORY";
        public readonly static SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS DefineId = SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY;

        public readonly static string? UnitsName = null;

        public readonly static int? DatumType = (int)SIMCONNECT_DATATYPE.STRING256;

        public readonly static float? fEpsilon = 0;

        public readonly static int? DatumId = 0;

        public void RegisterDataDefineStruct(ref SimConnect simConnectInstance)
        {
            simConnectInstance.RegisterDataDefineStruct<SimConnectInterfaceDataStructures.CATEGORY>(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY);
        }

        public void StartRequests(ref SimConnect simConnectInstance)
        {
            try
            {
                simConnectInstance.RequestDataOnSimObject(SimConnectInterfaceDefinitionEnums.DATA_REQUESTS.SO_CATEGORY, SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY, 1, SIMCONNECT_PERIOD.ONCE, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        public void Handle(object eventSender, object eventData)
        {
        
        }
    }
}
