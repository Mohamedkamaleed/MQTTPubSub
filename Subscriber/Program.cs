using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTShared;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Subscriber
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
            mQTT.SubscribeEventHandler(client_MqttMsgPublishReceived);
            mQTT.Subscribe( "StringValue");
            mQTT.Subscribe("SensorObject");
            mQTT.Subscribe("SensorList");

        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
         
                //Return string
                var RecievedMsg = Encoding.UTF8.GetString(e.Message);

            //Return json Object
           // var RecievedObj = JsonConvert.DeserializeObject<Sensor.Data>(RecievedMsg);

            //Return json List of Object
            //var RecievedObj = JsonConvert.DeserializeObject<List<Sensor.Data>>(RecievedMsg);


            Console.WriteLine("Received = " + RecievedMsg + " on topic: " + e.Topic + " at " + DateTime.Now);
          
        }

    }
}
