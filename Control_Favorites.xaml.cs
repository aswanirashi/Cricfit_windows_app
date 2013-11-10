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
    public partial class Control_Favorites : UserControl
    {
        public event EventHandler goToVideoInfo;

        public Control_Favorites()
        {
            InitializeComponent();

            loadFavorites();
        }

        public void loadFavorites()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("channel9List"))
            {
                List<VideoObject> channel9List = IsolatedStorageSettings.ApplicationSettings["channel9List"] as List<VideoObject>;

                if (channel9List != null)
                {
                    var tempList =
                    from channel9 in channel9List
                    orderby channel9.PostedDate descending
                    where channel9.Favorite == true
                    select channel9;

                    List<VideoObject> list = tempList.ToList();
                    lboFavorites.ItemsSource = list;
                }
            }
        }

        private void lboFavorites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VideoObject video = lboFavorites.SelectedItem as VideoObject;
            if (video != null)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Video"))
                    IsolatedStorageSettings.ApplicationSettings["Video"] = video;
                else
                    IsolatedStorageSettings.ApplicationSettings.Add("Video", video);

                goToVideoInfo(video, new EventArgs());
                lboFavorites.SelectedIndex = -1;
            }
        }
    }
}
