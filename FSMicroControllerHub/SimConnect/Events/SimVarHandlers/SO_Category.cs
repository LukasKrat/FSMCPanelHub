using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnect.Events.SimVarHandlers
{
    internal class SO_Category : IEventSimVar
    {
        public static string Name = "CATEGORY";
        public static byte DefinitionId = (byte)SimConnectInterfaceDefinitionEnums.DATA_DEFINITIONS.SO_CATEGORY;

        public void Handle(object eventSender, object eventData)
        {
        
        }
    }
}
