using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nomenclative__list__of__furniture
{
    [Serializable]
    public class Furniture
    {
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        private string Size;

        public string size
        {
            get { return Size; }
            set { Size = value; }
        }

        private string Set;

        public string set
        {
            get { return Set; }
            set { Set = value; }
        }

        private string Colour;

        public string colour
        {
            get { return Colour; }
            set { Colour = value; }
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

        public string Info(Furniture obj)
        {
            return string.Format("Название: {0}; Размер: {1}; Набор: {2}; Цвет: {3}; Материал: {4};Цена: {5}", Name, Size, Set, Colour, Material, Price);
        }

        public Furniture(string Name, string Size, string Set, string Colour, string Material, string Price)
        {
            name = Name;
            size = Size;
            set = Set;
            colour = Colour;
            material = Material;
            price = Price;
        }
        public Furniture()
        {

        }
    }
}
