using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FSMCPanelHub.MicroController
{
    internal class SerialComInterface
    {
        /*
        static SerialPort _serialPort;
        public static void Main()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";//Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            while (true)
            {
                string a = _serialPort.ReadExisting();
                Console.WriteLine(a);
                Thread.Sleep(200);
            }
        }
        */

        /*
        using (var searcher = new ManagementObjectSearcher
                ("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
    var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
    var tList = (from n in portnames
                 join p in ports on n equals p["DeviceID"].ToString()
                 select n + " - " + p["Name"]).ToList();

    tList.ForEach(Console.WriteLine);
            }
        */
    }
}
