using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для ExkousionWin.xaml
    /// </summary>
    public partial class ExkousionWin : Page
    {
        public ExkousionWin()
        {
            InitializeComponent();
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

        private void exkursionDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var ex =  as Exkursion;
            //Exkursion exkurs = ex;
            //ex = sender as Exkursion;
            var id = (exkursionDataGrid.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
            var exkurs = from ex in App.Context.Exkursion.ToList()
                         where ex.IdExkursion == int.Parse(id)
                         select ex;
            Exkursion selectExkursion = new Exkursion();
            foreach (var item in exkurs)
            {
                selectExkursion = item;
            }
            Bronir BR = new Bronir(selectExkursion);
            BR.Show();
        }

        private void exkursionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
