using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace C1Suggested2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Names> names = new List<Names>();

            //Alwas create comparer in a separeted class
            Names name = new Names("Rosana", "Lemos");

            names.Add(new Names("Rafael", "Miceli"));
            names.Add(new Names("Priscilla", "Valim"));
            names.Add(new Names("Constantino", "Miceli"));
            names.Add(new Names("Fabio", "Valim"));
            names.Add(new Names("Lorena", "Miceli"));
            names.Add(name);

            names.Sort();

            foreach (var item in names)
            {
                Console.WriteLine(item.Name + " " + item.LastName);
            }

            Console.WriteLine(Convert.ToString(name));
            Console.WriteLine(name.ToString());

            Console.ReadKey();

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            
        }
    }

    public class NamesComparer: IComparer<Names>
    {

        int IComparer<Names>.Compare(Names x, Names y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }

    public class Names: IComparable<Names>, IConvertible
    {
        public string Name;
        public string LastName;

        public Names(string _Name, string _LastName)
        {
            Name = _Name;
            LastName = _LastName;
        }

        public override string ToString()
        {
            return Name + " " + LastName;
        }

        //int IComparable.CompareTo(string obj)
        //{
        //    string othername = (string)obj;
        //    return this.Namnames.Add(new Names("", ""));e.CompareTo(othername);
        //}

        int IComparable<Names>.CompareTo(Names other)
        {
            return this.Name.CompareTo(other.Name);
        }

        //int IComparer<Names>.Compare(Names x, Names y)
        //{
        //    return x.LastName.CompareTo(y.LastName);
        //}

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(Name);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(Name);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Name + " " + LastName;
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
