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
using System.Windows.Threading;

namespace ServiceHost.Controls
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl
    {
        private DispatcherTimer timer { get; set; }

        public int Interval { get; set; }


        public Graph()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            // todo add some logic here

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Draw();
            timer.Interval = new TimeSpan(0, 0, 0, 0, Interval);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 10);
            timer.Tick += timer_Tick;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GraphCanvas.Width = e.NewSize.Width;
            GraphCanvas.Height = e.NewSize.Height;

            Draw();
        }
    }
}
