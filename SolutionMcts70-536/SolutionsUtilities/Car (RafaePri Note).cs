using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SolutionsUtilities
{
    [Serializable]
    public class Car:Vehicle, IDeserializationCallback
    {
        public string License;

        public Car()
        {

        }

        public Car(string _model, string _manufacturer, int _manufactureYear, string _color, string _license)
        {
            Model = _model;
            Manufacturer = _manufacturer;
            Color = _color;
            License = _license;
            ManufactureYear = _manufactureYear;
        }

        public double Accelerate(double speed)
        {
            return base.Speed += speed;
        }

        public double Break(double speed)
        {
            return Speed -= speed;
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            Speed = Accelerate(30);
            Speed = Break(10);
        }
    }
}
