using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomenclative__list__of__furniture
{[Serializable]
    public class Accessories
    {
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        

        private string Colour;

        public string colour
        {
            get { return Colour; }
            set { Colour = value; }
        }

        private string Value;

        public string value
        {
            get { return Value; }
            set { Value = value; }
        }

        private string Material;

        public string material
        {
            get { return Material; }
            set { Material = value; }
        }
        private string Price;

        public string price
        {
            get { return Price; }
            set { Price = value; }
        }

        public string Info(Accessories obj)
        {
            return string.Format("Название: {0}; Цвет: {1}; Назначение: {2}; Материал: {3}; Цена: {4}", Name, Colour, Value, Material, Price);
        }

        public Accessories(string Name, string Colour, string Value, string Material, string Price)
        {
            name = Name;
            colour = Colour;
            value = Value;
            material = Material;
            price = Price;
        }
        public Accessories()
        {

        }
    }
}
