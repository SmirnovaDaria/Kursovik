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
    /// Логика взаимодействия для WriteDataExkurs.xaml
    /// </summary>
    public partial class WriteDataExkurs : Page
    {
        private Exkursion thisEx;
        private double itog = 0;
        public WriteDataExkurs(Exkursion ex)
        {
            InitializeComponent();
            thisEx = ex;
            DateTime date = new DateTime();
            date = DateTime.Now;
            dateDatePicker.DisplayDateStart = date;
            int maxMan = (from E in App.Context.Exkursion.ToList()
                         where E.IdExkursion == ex.IdExkursion
                         select E.MaxMan).Max(x=>x.Value);
            for (int i = 1; i < maxMan+1; i++)
            {
                valueManTextBox.Items.Add(i);
            }
            for (int i = 9; i < 20 + 1; i++)
            {
                HourComboBox.Items.Add(i);
            }
            for (int i = 0; i < 50 + 1; i+=10)
            {
                MinutComboBox.Items.Add(i);
            }
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
            Operation operation = new Operation();
            SostavOperation sostavOperation = new SostavOperation();
            operation.IdUser = 1;
            operation.IdExkursion = thisEx.IdExkursion;
            App.Context.Operation.Add(operation);
            App.Context.SaveChanges();
            operation = (from O in App.Context.Operation.ToList()
                        select O).Last();
            sostavOperation.IdOperation = operation.IdOperation;
            sostavOperation.Date = dateDatePicker.SelectedDate;
            int man = valueManTextBox.SelectedIndex;
            sostavOperation.ValueMan = (int)valueManTextBox.Items[man];
            sostavOperation.ItogPrice = itog;
            App.Context.SostavOperation.Add(sostavOperation);
            App.Context.SaveChanges();

        }

        private void valueManTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double price = (from E in App.Context.Exkursion.ToList()
                            where E.IdExkursion == thisEx.IdExkursion
                            select E.Price).Max(x=>x.Value);
            double sale = (from E in App.Context.Exkursion.ToList()
                           where E.IdExkursion == thisEx.IdExkursion
                           select E.skidka).Max(x => x.Value);
            sale /= 100;
            itog = price * int.Parse(valueManTextBox.SelectedValue.ToString());
            itog = itog - itog * sale;
            itogPriceTextBox.Text = (itog).ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void HourComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
