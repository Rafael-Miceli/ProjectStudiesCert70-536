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

        }

        public Airplane()
        {

        }

        public double? Impulse()
        {
            return Speed;
        }

        public double? Repulse()
        {
            return Speed;
        }

        public void Fly()
        {

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
