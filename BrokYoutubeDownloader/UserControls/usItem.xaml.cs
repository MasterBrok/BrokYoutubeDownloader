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
    /// Interaction logic for usItem.xaml
    /// </summary>
    public partial class usItem : UserControl
    {
        public usItem()
        {
            InitializeComponent();
        }
        public usItem(object model)
        {
            InitializeComponent();
            this.DataContext = model;
        }

        public event EventHandler<EventArgs> Path_Click;


        public object MyTag
        {
            get { return (object)GetValue(MyTagProperty); }
            set { SetValue(MyTagProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyTag.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyTagProperty =
            DependencyProperty.Register("MyTag", typeof(object), typeof(usItem), new PropertyMetadata(default));


        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Path_Click != null)
            {
                Path_Click(sender, e);
            }
        }
    }
}
