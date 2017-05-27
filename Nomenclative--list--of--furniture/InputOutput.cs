using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nomenclative__list__of__furniture
{
    class InputOutput
    {
        ListFurn lf = new ListFurn();
        
        List<Furniture> furn = new List<Furniture>();

        public void ClearList()
        {
            furn.Clear();
        }

        public void Addfurn(string Name, string Size, string Set, string Colour, string Material, string Price)
        {
            furn.Add(new Furniture(Name, Size, Set, Colour, Material, Price)
            {
                name = Name,
                size = Size,
                set = Set,
                colour = Colour,
                material = Material,
                price = Price
        });
        }
        public void Savefurn(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    bf.Serialize(fs, furn);
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", "Ошибка",
                         MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        
        public List<string> GetFurn()
        {
            List<string> list = new List<string>();
            foreach (Furniture obj in furn)
            {
                list.Add(obj.Info(obj));
            }

            return list;
        }
    }
}
