using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnectInterfacing.ResponseEventHandlers
{
    internal interface IEventSimVar
    {
        public static string DatumName { get; }
        /// <summary>
        /// The byte-value of the referenced element in the DATA_DEFINITIONS-enum.
        /// </summary>
        public static byte DefineId { get; }
        public static string? UnitsName { get; }
        /// <summary>
        /// The integer-value of the referenced element in the SIMCONNECT_DATATYPE-enum.
        /// </summary>
        public static int? DatumType { get; }
        public static float? fEpsilon { get; }
        public static int? DatumId { get; }
        public void RegisterDataDefineStruct(ref SimConnect simConnectInstance);
        public void StartRequests(ref SimConnect simConnectInstance);
        public void Handle(object eventSender, object eventData);
    }
}
