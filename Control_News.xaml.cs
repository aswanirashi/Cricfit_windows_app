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
using System.Xml.Linq;
using System.Threading;

namespace myChannel9
{
    public partial class Control_News : UserControl
    {
        public event EventHandler goToVideoInfo;
        
        public Control_News()
        {
            InitializeComponent();
        }

        public void loadNews()
        {
            lblLoading.Visibility = Visibility.Visible;
            lboNews.Visibility = Visibility.Collapsed;

            WebClient client = new WebClient();
            client.DownloadStringCompleted += ReadNews;
            string url = "http://channel9.msdn.com/Feeds/RSS/";
            client.DownloadStringAsync(new Uri((url)));
        }

        private void ReadNews(object Sender, DownloadStringCompletedEventArgs e)
        {
            List<VideoObject> videoList = new List<VideoObject>();

            try
            {
                List<VideoObject> channel9List = new List<VideoObject>();

                if (!e.Cancelled)
                {
                    XDocument xDoc = XDocument.Parse(e.Result);
                    XElement xml = XElement.Parse(e.Result);

                    List<VideoObject> lst = new List<VideoObject>();
                    var queue = from item in xDoc.Descendants("item")

                                select new VideoObject
                                {
                                    Heading = item.Element("title").Value,
                                    Url = item.Element("link").Value,
                                    Description = Helper.removeHtml(item.Element("description").Value),
                                    Posted = item.Element("pubDate").Value,
                                    videoList = (from img in item.Elements(item.GetNamespaceOfPrefix("media") + "group").Elements(item.GetNamespaceOfPrefix("media") + "content")
                                                 select img.Attribute("url").Value).ToList(),
                                    lenghtList = (from img in item.Elements(item.GetNamespaceOfPrefix("media") + "group").Elements(item.GetNamespaceOfPrefix("media") + "content")
                                                  select img.Attribute("duration").Value).ToList(),
                                    imageList = (from img in item.Elements(item.GetNamespaceOfPrefix("media") + "thumbnail")
                                                 select img.Attribute("url").Value).ToList(),
                                    Lenght = "",
                                    LenghtDetails = "",
                                    PostedDate = Helper.getPostedDate(item.Element("pubDate").Value),
                                    PostedDetails = Helper.getPostedDetails(item.Element("pubDate").Value),
                                    Tags = "",
                                    Type = "",
                                    Favorite = false
                                };

                    videoList = queue.ToList<VideoObject>();

                    if (IsolatedStorageSettings.ApplicationSettings.Contains("channel9List"))
                        channel9List = IsolatedStorageSettings.ApplicationSettings["channel9List"] as List<VideoObject>;
                    else
                        IsolatedStorageSettings.ApplicationSettings.Add("channel9List", channel9List);

                    foreach (VideoObject video in videoList)
                    {
                        if(Helper.isUnique(video.Url, channel9List))
                        {
                            channel9List.Add(video);
                        }
                    }

                    IsolatedStorageSettings.ApplicationSettings["channel9List"] = channel9List;
                }

                lboNews.ItemsSource = videoList;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

            lboNews.Visibility = Visibility.Visible;
            lblLoading.Visibility = Visibility.Collapsed;
        }

        private void lboNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VideoObject video = lboNews.SelectedItem as VideoObject;
            if (video != null)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Video"))
                    IsolatedStorageSettings.ApplicationSettings["Video"] = video;
                else
                    IsolatedStorageSettings.ApplicationSettings.Add("Video", video);

                goToVideoInfo(video, new EventArgs());
                lboNews.SelectedIndex = -1;
            }
        }
    }
}
