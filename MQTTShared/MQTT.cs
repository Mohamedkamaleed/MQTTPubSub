using System;
using System.Collections.Generic;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using static uPLibrary.Networking.M2Mqtt.MqttClient;

namespace MQTTShared
{
   public class MQTT
    {
        private BrokerModel _Broker = new BrokerModel();
        private MqttClient _client { get; set; }
       // public event MqttMsgPublishEventHandler MqttMsgPublishReceived;
        public bool Connected;
        public bool Initailized;
        public void Initailize(BrokerModel Broker)
        {
            
            if (Broker != null)
            {
                if (!string.IsNullOrEmpty( Broker.Url)
                    && !string.IsNullOrEmpty(Broker.Username)
                    && !string.IsNullOrEmpty(Broker.Password)
                    && Broker.Port > 0
                    && Broker.SSLPort > 0
                    && Broker.WebSocketPort > 0)
                {
                    _Broker = Broker;
                    Initailized = true;
                    Console.WriteLine("MQTT is succesfully intialized");

                }
                else
                {
                    Console.WriteLine("MQTT is badly intialized");
                }
              
            }
            else
            {
                Console.WriteLine("MQTT is badly intialized");

            }

        }

        public void Connect()
        {
            if (Initailized)
            {
                _client = new MqttClient(_Broker.Url, _Broker.Port, false, MqttSslProtocols.None, null, null); ;
                string clientId = Guid.NewGuid().ToString();
                Console.WriteLine("Client " + clientId + " started");
                try
                {
                    _client.Connect(clientId, _Broker.Username, _Broker.Password);
                    Connected = true;
                    Console.WriteLine("MQTT is succesfully Connected");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Client " + clientId + " cannot connect");
                    Console.WriteLine(e.Message);
                }

            }

          



        }

        public void Publish(string Topic, string Message)
        {
            if (Connected)
            {
                string strValue = Convert.ToString(Message);

                // publish a message on a topic with QoS 2
                _client.Publish(Topic, Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,false);
                Console.WriteLine("Publish = " + Message + " is Published on Topic " +Topic+ " at " + DateTime.Now);

            }
            else
            {
                Console.WriteLine("Client " + _client.ClientId + " is not connected");

            }

        }
        public void SubscribeEventHandler(MqttMsgPublishEventHandler MqttMsgPublishReceived)
        {
            _client.MqttMsgPublishReceived += MqttMsgPublishReceived;

        }
        public void Subscribe (string Topic)
        {
            if (Connected)
            {
                
                _client.Subscribe(new string[] { Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            }
            else
            {
                Console.WriteLine("Client " + _client.ClientId + " is not connected");
            }


        }
    }
}
