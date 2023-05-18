using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnectInterfacing.ResponseEventHandlers
{
    internal class EventDataOnSimObject
    {
        internal static Dictionary<SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS, Type> SimVarHandlerRegistry { get; private set; } = null;

        internal EventDataOnSimObject()
        {
            if (SimVarHandlerRegistry == null)
            {
                //http://www.blackwasp.co.uk/FindAllImplementers.aspx

                SimVarHandlerRegistry = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                {
                    Type[] types = t.GetInterfaces();
                    return types.Contains(typeof(IEventSimVar));
                })?
                .ToDictionary(k => (SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS)k.GetField("DefineId")?.GetValue(null));
            }
        }

        internal static void Handle(SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS definitionId, object eventSender, object eventData)
        {
            Type svType = SimVarHandlerRegistry[definitionId];
            svType.GetMethod("Handle")?.Invoke(Activator.CreateInstance(svType), new object[] { eventSender, eventData });
        }


    }
}
