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

namespace WpfEventSetterBadSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var style = new Style(typeof(Button));
                style.Setters.Add(new EventSetter(UIElement.MouseDownEvent,
                    new RoutedEventHandler(Handler)));
                Button.Style = style;
            }
            catch (Exception ex)
            {
                this.Content = ex.ToString();
            }
        }

        private void Handler(object sender, EventArgs e)
        {
            MessageBox.Show(e.GetType().ToString());
        }

    }
}
