using FSMicroControllerHub.SimConnectInterfacing.SimEvents;
using Microsoft.FlightSimulator.SimConnect;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSMicroControllerHub.SimConnectInterfacing.Control
{
    internal class SCIControl
    {
        internal void DecreaseRadioFrequenceCOM1()
        {
            try
            {
                SimConnectInterface.SimConnectInstance.TransmitClientEvent(1, SimEventEnums.EVENT_ID.EVENT_COM_RADIO_FRACT_DEC_CARRY, 0, null, SIMCONNECT_EVENT_FLAG.DEFAULT);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        internal void IncreaseRadioFrequenceCOM1()
        {
            try
            {
                SimConnectInterface.SimConnectInstance.TransmitClientEvent(1, SimEventEnums.EVENT_ID.EVENT_COM_RADIO_FRACT_INC_CARRY, 0, null, SIMCONNECT_EVENT_FLAG.DEFAULT);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }
    }
}
