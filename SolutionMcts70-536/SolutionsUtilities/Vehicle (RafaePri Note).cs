using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SolutionsUtilities
{
    [Serializable]
    [XmlRoot]
    public class Vehicle: IDeserializationCallback
    {
        public string Model;
        [XmlAttribute]
        public string Manufacturer;
        public int ManufactureYear;
        public string Color;
        [NonSerialized]
        public double Speed;


        public void OnDeserialization(object sender)
        {
            if(Model == "X5")
            { 
                //Car car = new Car();
                //Speed = car.Accelerate(20);
                //Speed = car.Accelerate(80);
            }
        }
    }
}
