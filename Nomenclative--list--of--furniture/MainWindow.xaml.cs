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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nomenclative__list__of__furniture
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string password = "";
        public MainWindow()
        {
            InitializeComponent();
            using (FileStream fs = new FileStream("../../autorization.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    guests = (List<Auth>)bf.Deserialize(fs);
                }
                catch
                {
                    guests = new List<Auth>(); 
                    
                }
            }
        }

        private void savepassword_Click(object sender, RoutedEventArgs e)
        {
            password = passwordBox.Text;
            Auth pass = new Auth(password);
            foreach (Auth p in guests)
            {
                if(p.Password  ==password)
                {
                    MessageBox.Show("Такой пароль уже есть");
                    return;
                }
            }
            guests.Add(pass);

            
            using (FileStream fs = new FileStream("../../autorization.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    bf.Serialize(fs, guests);
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить пароль", "Ошибка",
                         MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
           
        }

        List<Auth> guests = new List<Auth>();

        private void enter_Click(object sender, RoutedEventArgs e)

        { 
            
            
            using (FileStream fs = new FileStream("../../autorization.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    guests = (List<Auth>)bf.Deserialize(fs);
                }
                catch
                {
                    guests = new List<Auth>();
                    MessageBox.Show("Не удалось вывести файл", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            List<Auth> l = new List<Auth>();
            foreach (var item in guests)
            {
                if (item.Password == passwordBox.Text)
                {

                    //using (FileStream fs = new FileStream("../../autorization.dat", FileMode.OpenOrCreate))
                    //{
                    //    BinaryFormatter bf = new BinaryFormatter();
                    //    try
                    //    {
                    //        bf.Serialize(fs, guests);
                    //    }
                    //    catch
                    //    {
                    //        MessageBox.Show("Не удалось сохранить пароль", "Ошибка",
                    //             MessageBoxButton.OK, MessageBoxImage.Error);
                    //    }
                    //}
                    l.Add(item);
                    Base wnd = new Base();
                    wnd.Show();
                    
                    
                }
               
                   
            }
            if (l.Count==0)
            {
                MessageBox.Show("Такого пароля нет");
            }
        }
    }
}
