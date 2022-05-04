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
using System.Windows.Shapes;

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для Bronir.xaml
    /// </summary>
    public partial class Bronir : Window
    {
        public Bronir(Exkursion ex)
        {
            InitializeComponent();
            BronirFrame.Content = new InfoExkurs(ex);
        }

    }
}
