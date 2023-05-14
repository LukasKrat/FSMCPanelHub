using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMicroControllerHub.SimConnect.Events
{
    internal interface IEventSimVar
    {
        public static string Name { get; }
        public static byte DefinitionId { get; }
        public void Handle(object eventSender, object eventData);
    }
}
