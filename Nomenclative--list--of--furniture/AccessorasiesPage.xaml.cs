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
    /// Логика взаимодействия для AccessorasiesPage.xaml
    /// </summary>
    public partial class AccessorasiesPage : Page
    {
        Base bas;
        public AccessorasiesPage(Base b)
        {
            InitializeComponent();
            bas = b;
            refresh();
        }
        public void refresh()
        {
            listViewaccess.Items.Clear();
            try
            {
                bas.access = bas.ReadFromAccessfile("../../accessories.xml");
                foreach (Accessories a in bas.access.LA)
                {
                    listViewaccess.Items.Add(a);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
    }
}
