using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Nomenclative__list__of__furniture
{
    /// <summary>
    /// Логика взаимодействия для Base.xaml
    /// </summary>
    public partial class Base : Window
    {
        Base wnd;
        public  ListFurn furn = new ListFurn();
        public ListAccess access = new ListAccess();
       // public List<Accessories> access = new List<Accessories>();
        
        public Base()
        {
            InitializeComponent();
            FurniturePage p = new FurniturePage(this);
            Main.NavigationService.Navigate(p);

        }

        public void FurnButton(object sender, RoutedEventArgs e)
        {
            FurniturePage p = new FurniturePage(this);
            Main.NavigationService.Navigate(p);
        }

        private void AcesButton(object sender, RoutedEventArgs e)
        {
            AccessorasiesPage a = new AccessorasiesPage(this);
            Main.NavigationService.Navigate(a);
           // Main.Content = new AccessorasiesPage();
        }

        /*public void Addfurn(string Name, string Size, string Set, string Colour)
        {
            furn.Add(new Furniture(Name, Size, Set, Colour)
            {
                _name = Name,
                _size = Size,
                _set = Set,
                _colour = Colour
            });
        */
        public void Savefurn(string fileName)
        {
           
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ListFurn));
                BinaryFormatter bf = new BinaryFormatter();
                try
                {

                    xs.Serialize(fs, furn);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    //MessageBox.Show("Не удалось сохранить файл", "Ошибка",
                    //     MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public ListFurn ReadFromFurnfile(string fileName)
        {
            ListFurn data = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                
                XmlSerializer xs = new XmlSerializer(typeof(ListFurn));
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    data = (ListFurn)xs.Deserialize(fs);
                }
                catch
                {
                    MessageBox.Show("Не удалось вывести файл", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return data;
        }

        public ListAccess ReadFromAccessfile(string fileName)
        {
            ListAccess data = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {

                XmlSerializer xs = new XmlSerializer(typeof(ListAccess));
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    data = (ListAccess)xs.Deserialize(fs);
                }
                catch
                {
                    MessageBox.Show("Не удалось вывести файл", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return data;
        }
        //public List<string> GetFurn(object sender, RoutedEventArgs e)
        //{
        //    List<string> list = new List<string>();
        //    foreach (Furniture obj in furn.LF)
        //    {
        //        list.Add(obj.Info(obj));
        //    }

        //    return list;
        //}

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Addpage page = new Addpage(this);
            Main.NavigationService.Navigate(page);
            
        }

        
        private void buttonsearch_Click(object sender, RoutedEventArgs e)
        {
            string mes=null;
            bool isFound = false;
            foreach (Furniture obj in furn.LF)
            {
                if (obj.name.Contains(textBoxSearch.Text) || obj.colour.Contains(textBoxSearch.Text) || obj.size.Contains(textBoxSearch.Text) || obj.set.Contains(textBoxSearch.Text))
                {
                    mes += (obj.Info(obj) + "\n");
                    
                    isFound = true;
                }
            }
            MessageBox.Show(mes);
            if (!isFound)
                MessageBox.Show("");

            foreach (Accessories obj in access.LA)
            {
                if (obj.name.Contains(textBoxSearch.Text) || obj.colour.Contains(textBoxSearch.Text) || obj.value.Contains(textBoxSearch.Text))
                {
                    mes += (obj.Info(obj) + "\n");

                    isFound = true;
                }
            }
            MessageBox.Show(mes);
            if (!isFound)
                MessageBox.Show("");
        }

        private void buttondelete_Click(object sender, RoutedEventArgs e)
        {
            FurniturePage p = new FurniturePage(this);
            wnd.furn = wnd.ReadFromFurnfile("../../furnlist.xml");
            string mes = null;
            bool isFound = false;
            foreach (Furniture obj in wnd.furn.LF)
            {
                if (obj.name.Contains(textBoxSearch.Text) || obj.colour.Contains(textBoxSearch.Text) || obj.size.Contains(textBoxSearch.Text) || obj.set.Contains(textBoxSearch.Text))
                {

                    wnd.furn.LF.Remove(obj);
                    p.listViewfurn.Items.Remove(obj);
                    wnd.Savefurn("../../furnlist.xml");
                    isFound = true;
                }
            }
            MessageBox.Show(mes);
            if (!isFound)
                MessageBox.Show("");
            
        }
    }
}
