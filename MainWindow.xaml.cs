﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using HttpHelper;

namespace HttpHelperDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequestHelper<User>.Instance.OnStart().OnStart()
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            new Test().TestGet();
        }
    }
}
