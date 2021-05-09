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

namespace TplDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnGo_Click(object sender, RoutedEventArgs e)
        {
            txtPleaseWait.Visibility = Visibility.Visible;
            progressBar.IsIndeterminate = true;
            btnGo.IsEnabled = false;

            var task = Helper.GetAllPrimesAsync(160000);

            var res = await task;

            lstResults.ItemsSource = task.Result;

            btnGo.IsEnabled = true;
            progressBar.IsIndeterminate = false;
            txtPleaseWait.Visibility = Visibility.Collapsed;


            //task.ContinueWith(t =>
            //{
            //    lstResults.ItemsSource = task.Result;

            //    btnGo.IsEnabled = true;
            //    progressBar.IsIndeterminate = false;
            //    txtPleaseWait.Visibility = Visibility.Collapsed;

            //}, TaskScheduler.FromCurrentSynchronizationContext());

            //Console.WriteLine("Hello");


        }
    }
}
