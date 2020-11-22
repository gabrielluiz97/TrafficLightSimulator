using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightControllerSimulatorCOM
{
        public class ModBusConnection
    {
        static ModBusConnection HTTPRequesterIntance;
        private string IpAddress { get; set; }
        private int Port { get; set; }
        public ModbusClient Client { get; set; }
        public static ModBusConnection GetInstance
        {
            get { return HTTPRequesterIntance ?? (HTTPRequesterIntance = new ModBusConnection()); }
        }
        private ModBusConnection()
        {
            IpAddress = "127.0.0.1";
            Port = 502;

            Client = new ModbusClient(IpAddress, Port);
        }

        public  void Connect()
        {
            if(!Client.Connected) Client.Connect();
        }
        public void Disconnect()
        {
             Client.Disconnect();

        }
        public void WriteValues(bool on, int presetRedLightTimeLeft, int presetGreenLightTimeLeft, int presetYellowLightTimeLeft)
        {
            var client2 = new ModbusClient();
            client2.Connect();
            client2.WriteSingleCoil(4, on);
            client2.WriteSingleRegister(1, presetRedLightTimeLeft);
            client2.WriteSingleRegister(3, presetGreenLightTimeLeft);
            client2.WriteSingleRegister(5, presetYellowLightTimeLeft);
            client2.Disconnect();
        }
        public int[] ReadInputRegister()
        {
            if (Client.Connected)
            {
                var registers = Client.ReadInputRegisters(0, 20);

                return registers;
            }
            return null;
        }

        public bool[] ReadCoils()
        {
            if (Client.Connected)
            {
                var readCoils = Client.ReadCoils(0, 20);
                return readCoils;
            }
            return null;
        }

        public int[] ReadHoldingRegisters()
        {
            if (Client.Connected)
            {
                var readHoldingRegisters = Client.ReadHoldingRegisters(0, 20);
                return readHoldingRegisters;
            }

            return null;
        }


    }
    }
