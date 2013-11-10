using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace myChannel9
{
    public partial class Control_About : UserControl
    {
        public Control_About()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<VideoObject> list = new List<VideoObject>();
            list.Add(new VideoObject { Heading = "name:" + Environment.NewLine + "myChannel9" });
            list.Add(new VideoObject { Heading = "version:" + Environment.NewLine + "2.7" });
            list.Add(new VideoObject { Heading = "support:" + Environment.NewLine + "sigurd.snorteland@gmail.com" });
            list.Add(new VideoObject { Heading = "web:" + Environment.NewLine + "sigurdsnorteland.wordpress.com" });
            lboAbout.ItemsSource = list;
        }
    }
}
