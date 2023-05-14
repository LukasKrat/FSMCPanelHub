using FSMicroControllerHub.SimConnect;
using FSMicroControllerHub.SimConnect.Control;

namespace FSMicroControllerHub
{
    public partial class FormMain : Form
    {
        private SimConnectInterface simConnectInterface;

        public FormMain()
        {
            InitializeComponent();

            this.simConnectInterface = new SimConnectInterface(base.Handle);
            new SCIControl().SetRadioFrequence();
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == Convert.ToUInt32(Program.Configuration["SimConnect:WmUserId"]))
            {
                if (SimConnectInterface.SimConnectInstance != null)
                {
                    SimConnectInterface.SimConnectInstance.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }
    }
}