using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ExploringTpl
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await CalculateStockUsingAllOfThem();
            MessageBox.Show("Finished");
        }

        public async Task Go()
        {
            Debug.WriteLine("1");
            var t = Task.Delay(2000);
            Debug.WriteLine("2");

            var theAnswer = GetTheAnswerOfLifeTheUniverseAndEverything();

            await t;
            Debug.WriteLine("3");

        }

        public Task SomethingThatEndsWhenTheUserClicksAnotherButton()
        {
            stopButton.Visibility = Visibility.Visible;
            var tcs = new TaskCompletionSource<int>();


            stopButton.Click += (s, e) =>
            {
                tcs.TrySetResult(50);
            };

            return tcs.Task;
        }

        public Task SomethingThatTakesAWhile()
        {
            return Task.Delay(4000);
        }

        public void OldGo()
        {
            Debug.WriteLine("1");
            var t = Task.Delay(2000);
            Debug.WriteLine("2");
            var c = t.ContinueWith(_ =>
            {
                Debug.WriteLine("3");
                return true;
            });
        }

        public Task<int> GetTheAnswerOfLifeTheUniverseAndEverything()
        {
            return Task.FromResult(42);
        }

        public Task<int> SomethingWentWrongAsync()
        {
            return Task.FromException<int>(new NullReferenceException());
        }

        public async Task<int> CalcualteStockIDontCareHow()
        {
            var someTasks = new List<Task<int>>
            {
                CalculateStockUsingGoogle(),   // 4 sec
                CalculateStockUsingYahoo(),    // 2 sec
                CalculateStockUsingAltaVista(),// 3 sec
            };

            var tRace = Task.WhenAny(someTasks);

            var tWinner = await tRace;

            var losers = someTasks.Except(new[] { tWinner });

            return await tWinner;
        }

        public async Task<int> CalculateStockUsingAllOfThem()
        {
            var someTasks = new List<Task<int>>
            {
                CalculateStockUsingGoogle(),   // 4 sec
                CalculateStockUsingYahoo(),    // 2 sec
                CalculateStockUsingAltaVista(),// 3 sec
            };

            var all = await Task.WhenAll(someTasks);

            return all.Sum();
        }

        public async Task<int> CalculateStockUsingGoogle()
        {
            var rnd = new Random();
            var delay = rnd.Next(1000, 3000);

            await Task.Delay(delay);
            return 42;
        }

        public async Task<int> CalculateStockUsingYahoo()
        {
            var rnd = new Random();
            var delay = rnd.Next(1000, 3000);

            await Task.Delay(delay);
            return 42;
        }

        public async Task<int> CalculateStockUsingAltaVista()
        {
            var rnd = new Random();
            var delay = rnd.Next(1000, 3000);

            await Task.Delay(delay);
            return 42;
        }


    }
}
