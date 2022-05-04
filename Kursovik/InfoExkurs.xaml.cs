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

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для InfoExkurs.xaml
    /// </summary>
    public partial class InfoExkurs : Page
    {
        public Exkursion thisEx;
        public InfoExkurs(Exkursion ex)
        {
            InitializeComponent();
            thisEx = ex;
            nameTextBlock.Text = ex.Name;
            priceTextBlock.Text = ex.Price.ToString();
            maxManTextBlock.Text = ex.MaxMan.ToString();
            timeTextBlock.Text = ex.Time.ToString();
            skidkaTextBlock.Text = ex.skidka.ToString();
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

        private void Bronir(object sender, RoutedEventArgs e)
        {
            Bronir Br = (Bronir)Window.GetWindow(this);
            Br.BronirFrame.Content = new WriteDataExkurs(thisEx);
        }
    }
}
