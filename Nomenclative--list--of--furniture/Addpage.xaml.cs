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
    /// Логика взаимодействия для Addpage.xaml
    /// </summary>
    public partial class Addpage : Page
    {
        
        bool isfurn = true;
        Base wnd;
       // string[] sets = [] 

        public Addpage(Base w)
        {
            InitializeComponent();
            wnd = w;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            comboBoxValue.IsEnabled = false;
            Room.IsEnabled = false;
            Name.IsEnabled = true;
            Colour.IsEnabled = true;
            Size.IsEnabled = true;
            TBName.IsEnabled = true;
            TBColour.IsEnabled = true;
            TBSize.IsEnabled = true;
            comboBoxSet.IsEnabled = true;
            Set.IsEnabled = true;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            comboBoxValue.IsEnabled = true;
            Room.IsEnabled = true;
            Name.IsEnabled = true;
            Colour.IsEnabled = true;
            Size.IsEnabled = false;
            TBName.IsEnabled = true;
            TBColour.IsEnabled = true;
            TBSize.IsEnabled = false;
            comboBoxSet.IsEnabled = false;
            Set.IsEnabled = false;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isfurn)
            {
                wnd.furn = wnd.ReadFromFurnfile("../../furnlist.xml");
                Furniture f = new Furniture( TBName.Text, TBSize.Text, comboBoxSet.Text, TBColour.Text);
                wnd.furn.LF.Add(f);

                wnd.Savefurn("../../furnlist.xml");
                wnd.FurnButton(sender, e);
            }
            else
            {
                wnd.access = wnd.ReadFromAccessfile("../../accessories.xml");
                Accessories a = new Accessories(TBName.Text, TBColour.Text, comboBoxValue.Text);
                wnd.access.LA.Add(a);

                wnd.Savefurn("../../acessories.xml");
                wnd.FurnButton(sender, e);

            }

        }

        
    }
}
