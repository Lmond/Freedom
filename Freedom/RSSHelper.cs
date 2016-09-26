using Freedom.Models;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Syndication;

namespace Freedom
{
    public class RSShelperClass
    {
        private async void load(ItemsControl list, Uri uri)
        {
            var feed = await new SyndicationClient().RetrieveFeedAsync(uri);

            //FeedModel.Name = String.IsNullOrEmpty(FeedModel.Name) ? feed.Title.Text : FeedModel.Name;
            //FeedModel.Description = feed.Subtitle?.Text ?? String.Empty;
            feed.Items.Select(item => new FeedModel
            {
                Title = item.Title.Text,
                Summary = item.Summary.Text,
                Author = item.Authors.Select(a => a.NodeValue).FirstOrDefault(),
                Link = item.ItemUri ?? item.Links.Select(l => l.Uri).FirstOrDefault(),
                PublishedDate = item.PublishedDate,
                ImageUrl = item.Links.Select(l => l.Uri).Last().AbsoluteUri

            })
            .ToList().ForEach(article =>
            {
                //var favorites = AppShell.Current.ViewModel.FavoritesFeed;
                //var existingCopy = favorites.Articles.FirstOrDefault(a => a.Equals(article));
                //article = existingCopy ?? article;
                list.Items.Add(article);
            });
            /*SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(uri);
            if (feed != null)
            {
                foreach (SyndicationItem item in feed.Items)
                {
                    list.Items.Add(item);
                }
            }*/
        }

        public void Go(ref ItemsControl list, string value)
        {
            try
            {
                load(list, new Uri(value));
            }
            catch
            {

            }
            list.Focus(FocusState.Keyboard);

        }
    }
    /*feed.Items.Select(item => new ArticleViewModel
                    {
                        Title = item.Title.Text,
                        Summary = item.Summary == null ? string.Empty :
                            item.Summary.Text.RegexRemove("\\&.{0,4}\\;").RegexRemove("<.*?>"),
                        Author = item.Authors.Select(a => a.NodeValue).FirstOrDefault(),
                        Link = item.ItemUri ?? item.Links.Select(l => l.Uri).FirstOrDefault(),
                        PublishedDate = item.PublishedDate,
                        ImageUrl = item.Links.Select(l => l.Uri).Last().AbsoluteUri

})
                    .ToList().ForEach(article =>
                    {
    var favorites = AppShell.Current.ViewModel.FavoritesFeed;
    var existingCopy = favorites.Articles.FirstOrDefault(a => a.Equals(article));
    article = existingCopy ?? article;
    if (!feedViewModel.Articles.Contains(article)) feedViewModel.Articles.Add(article);
});*/
}