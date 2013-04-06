using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace C7Suggested1WpfApplication
{
    class ClassCustomConfig: ConfigurationSection
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("Value")]
        public double Value {
            get { return (double)this["Value"];}
            set { this["Value"] = value; }
        }

        [ConfigurationProperty("Age")]
        public int Age {
            get { return (int)this["Age"];}
            set { this["Age"] = value;}
        }    
        
    }
}
