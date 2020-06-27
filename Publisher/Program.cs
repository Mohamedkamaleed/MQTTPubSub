using MQTTShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {

            //Intailize the Broker Settings
            BrokerModel _Broker = new BrokerModel();
            _Broker.Url = "tailor.cloudmqtt.com";
            _Broker.Username = "jxdgnsju";
            _Broker.Password = "by2uhfp1iSx8";
            _Broker.Port = 11300;
            _Broker.SSLPort = 21300;
            _Broker.WebSocketPort = 31300;

            //Connect to Server 
            MQTT mQTT = new MQTT();
            mQTT.Initailize(_Broker);
            mQTT.Connect();

            while (true)
            {
                if (mQTT.Connected)
                {
                    //publish string
                    mQTT.Publish("StringValue", "5");

                    //publish json Object
                    Sensor Sensor = new Sensor();
                    var result = Sensor.CreateSensor();
                    string Jsonresult = JsonConvert.SerializeObject(result);
                    mQTT.Publish("SensorObject", Jsonresult);

                    //publish json List of Objectss

                    var resultList = Sensor.CreateSensorList();
                    string JsonresultList = JsonConvert.SerializeObject(resultList);
                    mQTT.Publish("SensorList", JsonresultList);
                }


                Thread.Sleep(10000);
            }




        }
    }
}
