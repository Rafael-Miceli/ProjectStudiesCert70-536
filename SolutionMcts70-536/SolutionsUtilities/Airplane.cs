using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SolutionsUtilities
{
    [Serializable]
    public class Airplane:Vehicle, ISerializable
    {
        public string Route;

        public Airplane(string _model, string _manufacturer, int _manufactureYear, string _color, string _route)
        {
            Model = _model;
            Manufacturer = _manufacturer;
            Color = _color;
            Route = _route;
            ManufactureYear = _manufactureYear;
        }

        public Airplane(SerializationInfo info, StreamingContext context)
        {
            Model = info.GetString("Model");
            Manufacturer = info.GetString("Manufacturer");
            Color = info.GetString("Color");
            Route = info.GetString("Route");
            ManufactureYear = info.GetUInt16("Year");
        }

        public Airplane()
        {

        }

        [OnDeserializing]
        public void Impulse(StreamingContext sc)
        {
            Speed = 30;
        }

        public double Repulse()
        {
            return Speed;
        }

        [OnDeserialized]
        public void Fly(StreamingContext sc)
        {
            Console.WriteLine("I came first OnDeserialized");
            Console.WriteLine("i'm Flying, here's the context attributes: " + sc.Context + "   " + sc.State);
        }

        public void Land()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Model", Model);
            info.AddValue("Manufacturer", Manufacturer);
            info.AddValue("Year", ManufactureYear);
            info.AddValue("Color", Color);
            info.AddValue("Route", Route);
        }
    }
}
