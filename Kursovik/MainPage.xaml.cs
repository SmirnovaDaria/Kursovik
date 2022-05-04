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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            MainFrame.Content = new ExkousionWin();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Kursovik.ZooparkDataSet zooparkDataSet = ((Kursovik.ZooparkDataSet)(this.FindResource("zooparkDataSet")));
            // Загрузить данные в таблицу Exkursion. Можно изменить этот код как требуется.
            Kursovik.ZooparkDataSetTableAdapters.ExkursionTableAdapter zooparkDataSetExkursionTableAdapter = new Kursovik.ZooparkDataSetTableAdapters.ExkursionTableAdapter();
            zooparkDataSetExkursionTableAdapter.Fill(zooparkDataSet.Exkursion);
            System.Windows.Data.CollectionViewSource exkursionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exkursionViewSource")));
            exkursionViewSource.View.MoveCurrentToFirst();
        }

        private void NavHistory(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MyHistory();
        }

        private void NavMainPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ExkousionWin();
        }
    }
}
