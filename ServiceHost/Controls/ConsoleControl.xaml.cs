using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace ServiceHost.Controls
{
    /// <summary>
    /// Interaction logic for ConsoleControl.xaml
    /// </summary>
    public partial class ConsoleControl : UserControl
    {
        public ConsoleControl()
        {
            InitializeComponent();

            Console.SetOut(new ControlWriter(this));

        }
    }


    public class ControlWriter : TextWriter
    {
        private readonly ConsoleControl control;

        public ControlWriter(ConsoleControl control)
        {
            this.control = control;
        }

        public override void Write(char value)
        {
            Write(value.ToString());
        }

        public override void Write(string value)
        {
            //control.ConsoleBox.Text += value;
        }

        public override Encoding Encoding => Encoding.ASCII;
    }
}
