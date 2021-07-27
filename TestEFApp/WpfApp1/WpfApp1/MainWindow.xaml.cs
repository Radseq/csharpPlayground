using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        localhost.WebService1 webService = new localhost.WebService1();
        public MainWindow()
        {
            InitializeComponent();
            string webServiceContent = webService.TestDataTable();
            DataTable val = JsonConvert.DeserializeObject<DataTable>(webServiceContent);
            dt.ItemsSource = val.DefaultView;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddResult(int.Parse(tb1.Text), int.Parse(tb2.Text));
        }

        private async void AddResult(int val, int val2)
        {
            // First
            int res = await Task.Run(() =>
            {
                return webService.Add(val, val2);

            });

            tb4.Text = res.ToString();

            // Second
            /*await Task.Run(() =>
            {
                string res2 = webService.Add(val, val2).ToString();

                Dispatcher.Invoke(() =>
                {
                    tb4.Text = res2;
                });
            });*/
        }
    }
}
