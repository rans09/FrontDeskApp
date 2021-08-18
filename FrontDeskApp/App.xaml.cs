using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FrontDeskApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            View.MainWindow window = new View.MainWindow();
            ViewModel.CustomerViewModel customerViewModel = new ViewModel.CustomerViewModel();
            window.DataContext = customerViewModel;
            window.Show();
        }
    }
}
