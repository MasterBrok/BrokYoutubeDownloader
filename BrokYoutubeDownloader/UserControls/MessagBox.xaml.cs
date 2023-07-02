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

namespace BrokYoutubeDownloader.UserControls
{
    /// <summary>
    /// Interaction logic for MessagBox.xaml
    /// </summary>
    public partial class MessagBox : UserControl
    {
        public MessagBox()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Close_UserControl;
        private void ccButton_Click(object sender, RoutedEventArgs e)
        {
            if (Close_UserControl != null)
                Close_UserControl(sender, e);
        }
    }
}
