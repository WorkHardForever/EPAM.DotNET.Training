using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadingRCA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Thread(Work).Start();
        }

        void Work()
        {
            Thread.Sleep(5000); // Simulate time-consuming task
            UpdateMessage("The answer");
        }
        void UpdateMessage(string message)
        {
            Action action = () => txtMessage.Text = message;
            Dispatcher.BeginInvoke(action);
        }
    }
}
