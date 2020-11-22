using System;
using System.Collections.Generic;
using System.Text;
using EasyModbus;
namespace HTTPService
{
    //public class ModBusConnection
    //{
    //    static ModBusConnection HTTPRequesterIntance;
    //    private string IpAddress { get; set; }
    //    private int Port { get; set; }
    //    public ModbusClient Client { get; set; }
    //    public static ModBusConnection GetInstance
    //    {
    //        get { return HTTPRequesterIntance ?? (HTTPRequesterIntance = new ModBusConnection()); }
    //    }
    //    private ModBusConnection()
    //    {
    //        IpAddress = "127.0.0.1";
    //        Port = 502;

    //        Client = new ModbusClient(IpAddress, Port);
    //    }

    //    private void Connect()
    //    {
    //        Client.Connect();
    //    }
    //    private void Disconnect()
    //    {
    //        Client.Disconnect();
    //    }
    //    public int[] ReadInputRegister()
    //    {
    //        this.Connect();
    //        var registers =  Client.ReadInputRegisters(0, 8);

    //        this.Disconnect();

    //        return registers;


    //    } 


    //}
}
