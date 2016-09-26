using System;

namespace Freedom.Models
{
    public class FeedModel
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public Uri Link { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public string ImageUrl { get; set; }
        public string PublishedDateFormatted => PublishedDate.ToString("MMMM dd, yyyy    HH:mm").ToUpper();
        //public override bool Equals(object obj) =>
            //obj is ArticleViewModel ? (obj as ArticleViewModel).GetHashCode() == GetHashCode() : false;
        public override int GetHashCode() => Link.GetHashCode();
        private bool? _isStarred = false;
        public bool? IsStarred { get { return _isStarred; } set { SetProperty(ref _isStarred, value); } }

        private void SetProperty(ref bool? _isStarred, bool? value)
        {
            throw new NotImplementedException();
        }
    }
}
