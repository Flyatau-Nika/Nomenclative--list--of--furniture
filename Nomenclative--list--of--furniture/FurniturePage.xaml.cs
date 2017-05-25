using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для FurniturePage.xaml
    /// </summary>
    public partial class FurniturePage : Page
    {
        Base bas;
        public FurniturePage(Base b)
        {
            InitializeComponent();
            bas = b;
            refresh();
        }
        public void refresh()
        {
            listViewfurn.Items.Clear();
            try
            {
                bas.furn = bas.ReadFromFurnfile("../../furnlist.xml");
                foreach (Furniture f in bas.furn.LF)
                {
                    listViewfurn.Items.Add(f);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
                
        }
    }
}
