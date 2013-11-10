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
using System.IO.IsolatedStorage;

namespace myChannel9
{
    public partial class Control_Search : UserControl
    {
        public event EventHandler goToVideoInfo;

        public Control_Search()
        {
            InitializeComponent();

            gridSearchHelp.Visibility = Visibility.Visible;
        }

        private void btnSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            search();
        }

        private void search()
        {
            gridSearchHelp.Visibility = Visibility.Collapsed;

            lboSearch.ItemsSource = null;

                if (IsolatedStorageSettings.ApplicationSettings.Contains("channel9List"))
                {
                    List<VideoObject> channel9List = IsolatedStorageSettings.ApplicationSettings["channel9List"] as List<VideoObject>;

                    string searchText = txtSearch.Text.ToLower();

                    if (channel9List != null)
                    {
                        var tempList =
                        from channel9 in channel9List
                        orderby channel9.PostedDate descending
                        where channel9.Type.ToLower().Contains(searchText) ||
                              channel9.Heading.ToLower().Contains(searchText) ||
                              channel9.Tags.ToLower().Contains(searchText) ||
                              channel9.Description.ToLower().Contains(searchText)
                        select channel9;

                        List<VideoObject> list = tempList.ToList();
                        lboSearch.ItemsSource = list;
                    }
                }
        }

        private void lboSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VideoObject video = lboSearch.SelectedItem as VideoObject;
            if (video != null)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Video"))
                    IsolatedStorageSettings.ApplicationSettings["Video"] = video;
                else
                    IsolatedStorageSettings.ApplicationSettings.Add("Video", video);

                goToVideoInfo(video, new EventArgs());
                lboSearch.SelectedIndex = -1;
            }
        }
    }
}
