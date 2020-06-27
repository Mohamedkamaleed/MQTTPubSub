using System;
using System.Collections.Generic;
using System.Text;

namespace MQTTShared
{
    public interface ISensor
    {
        Sensor.Data CreateSensor();
        List<Sensor.Data> CreateSensorList();
    }

    public class Sensor : ISensor
    {
        public class Data
        {
            public DateTime TimeStamp { get; set; }
            public int Value { get; set; }
            public int SensorId { get; set; }
            public string Unit { get; set; }
        }


        public Data CreateSensor()
        {
            return new Data
            {
                SensorId = new Random().Next(1000, 9999),
                TimeStamp = DateTime.Now,
                Value = new Random().Next(-100, 100),
                Unit = "Celsius"

            };
        }
        public List<Data> CreateSensorList()
        {
            List<Data> data = new List<Data>();
            data.Add(CreateSensor());
            data.Add(CreateSensor());
            data.Add(CreateSensor());
            data.Add(CreateSensor());
            data.Add(CreateSensor());
            return data;
        }
    }
}
