﻿using BrokYoutubeDownloader.UserControls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
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

namespace BrokYoutubeDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Find Element MyTag
        public UserControls.usItem FindElementByTag(object tag)
        {
            foreach (var item in spItems.Children)
            {
                if (item is usItem us && us.MyTag == tag)
                {
                    return us;
                }
            }
            return null;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }
        public object privateTag { get; set; }
        private void usItem_Path_Click(object sender, EventArgs e)
        {
            var userControlToDelete = this.FindElementByTag(privateTag);
            if (userControlToDelete != null)
            {
                spItems.Children.Remove(userControlToDelete);
            }
        }

        private void ccButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validates.ValidateUrl.IsYouTubeLinkValid(txtUrl.Text.Trim()) is true)
            {
                if (spItems.Children.Count < 4)
                {
                 
                    var item = new UserControls.usItem(txtUrl.Text.Trim())
                    {
                        Name = spItems.Name + spItems.Children.Count,
                        MyTag = spItems.Children.Count,
                    };
                    item.Path_Click += usItem_Path_Click;
                    item.MouseEnter += Item_MouseEnter;
                    spItems.Children.Add(item);
                    txtUrl.Clear();
                }
                else
                {
                    var message = new Windows.wMeessageBox("You can only have 4 files downloading at the same time.");
                    message.ShowDialog();
                }
            }
            else
            {
                var message = new Windows.wMeessageBox("Url(Link) is Not Valid");
                message.ShowDialog();
            }

        }

        private void Item_MouseEnter(object sender, MouseEventArgs e)
        {
            privateTag = (sender as UserControls.usItem).MyTag;
        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Path_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (spItems.Children.Count > 0)
            {
                var message = new Windows.wMeessageBox("Are you sure Exit ? (OK == Exit)");
                message.ShowDialog();
                if (message.isClose == true)
                {
                    this.Close();
                }
            }
            else
                Application.Current.Shutdown();
        }
    }
}
